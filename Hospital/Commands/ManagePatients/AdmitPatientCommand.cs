using Hospital.Commands.Navigation;
using Hospital.Database;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.UserInterface;
using NHibernate;

namespace Hospital.Commands.ManagePatients
{
    /// <summary>
    /// Represents a command to admit a patient to the hospital.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class AdmitPatientCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="AdmitPatientCommand"/> class.
        /// </summary>
        private static AdmitPatientCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="AdmitPatientCommand"/> class.
        /// </summary>
        internal static AdmitPatientCommand Instance => _instance ??= new AdmitPatientCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="AdmitPatientCommand"/> class with the specified introduction message.
        /// </summary>
        public AdmitPatientCommand() : base(UiMessages.AdmitPatientMessages.Introduce) { }

        /// <summary>
        /// Executes the admit patient command. If there are no wards available, a message is displayed. 
        /// Otherwise, a patient is created and added to the list of patients.
        /// </summary>
        public override void Execute()
        {
            using var session = CreateSession.SessionFactory.OpenSession();

            var wards = (List<Ward>)DatabaseOperations<Ward>.GetAll(session);   
            if (!wards.Any())
            {
                Ui.ShowMessage(UiMessages.AdmitPatientMessages.NoWardErrorPrompt);
            }
            else
            {
                var patient = AdmitPatient(session, wards);

                Ui.ShowMessage(string.Format(UiMessages.AdmitPatientMessages.PatientCreatedPrompt, patient.Name, patient.Surname));
            }

            NavigationCommand.Instance.Execute();
        }

        /// <summary>
        /// Admits a new patient, creates their record in the database, and updates the capacity of the assigned ward.
        /// </summary>
        /// <param name="session">The database session to use for the operation.</param>
        /// <param name="wards">The list of available wards for the patient assignment.</param>
        /// <returns>Returns the newly admitted patient.</returns>
        /// <remarks>
        /// The method uses the PatientFactory to create a new patient based on the available wards and the session provided.
        /// After creating the patient, their record is added to the database.
        /// The capacity of the ward assigned to the new patient is then updated accordingly.
        /// </remarks>
        private Patient AdmitPatient(ISession session, List<Ward> wards)
        {
            var patient = PatientFactory.CreatePatient(wards, session);
            DatabaseOperations<Patient>.Add(patient, session);

            ManageCapacity.UpdateWardCapacity(patient.AssignedWard, patient, OperationType.Operation.AddPatient, session);

            return patient;
        }
    }
}