using NHibernate;
using Hospital.Commands.Navigation;
using Hospital.Database;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.UserInterface;

namespace Hospital.Commands.ManagePatients
{
    /// <summary>
    /// Represents a command to sign out a patient from the hospital.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class SignOutPatientCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="SignOutPatientCommand"/> class.
        /// </summary>
        private static SignOutPatientCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="SignOutPatientCommand"/> class.
        /// </summary>
        internal static SignOutPatientCommand Instance => _instance ??= new SignOutPatientCommand();


        /// <summary>
        /// Initializes a new instance of the <see cref="SignOutPatientCommand"/> class with a specific introduction message.
        /// </summary>
        private SignOutPatientCommand() : base(UiMessages.SignOutPatientMessages.Introduce) { }

        /// <summary>
        /// Executes the sign-out procedure for a patient. The patient will be removed from both the database and their assigned ward.
        /// </summary>
        public override void Execute()
        {
            using var session = CreateSession.SessionFactory.OpenSession();

            var patients = (List<Patient>)DatabaseOperations<Patient>.GetAll(session);
            if (!patients.Any())
            {
                Ui.ShowMessage(UiMessages.DisplayPatientsMessages.NoPatientsPrompt);
            }
            else
            { 
                var patient = UiHelper.SelectObject(patients, UiMessages.SignOutPatientMessages.SignOutPrompt);
                SignOutPatient(patient, session);

                Ui.ShowMessage(string.Format(UiMessages.SignOutPatientMessages.SuccessSignOutPrompt, patient.Name, patient.Surname));
            }

            NavigationCommand.Instance.Execute();
        }

        /// <summary>
        /// Signs out a patient from the system, removing their record from the database and updating the capacity of the assigned ward.
        /// </summary>
        /// <param name="patient">The patient to be signed out.</param>
        /// <param name="session">The database session to use for the operation.</param>
        /// <remarks>
        /// The method removes the patient record from the database and then updates the capacity of the ward the patient was assigned to.
        /// </remarks>
        private void SignOutPatient(Patient patient, ISession session)
        {
            DatabaseOperations<Patient>.Delete(patient, session);
            ManageCapacity.UpdateWardCapacity(patient.AssignedWard, patient, OperationType.Operation.RemovePatient, session);
        }
    }
}