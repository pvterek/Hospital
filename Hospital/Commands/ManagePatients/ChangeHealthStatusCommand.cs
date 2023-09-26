using Hospital.Commands.Navigation;
using Hospital.Database;
using Hospital.PeopleCategories.PatientClass;
using Hospital.Utilities.UserInterface;
using NHibernate;

namespace Hospital.Commands.ManagePatients
{
    /// <summary>
    /// Represents a command to change the health status of a patient.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class ChangeHealthStatusCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="ChangeHealthStatusCommand"/> class.
        /// </summary>
        private static ChangeHealthStatusCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="ChangeHealthStatusCommand"/> class.
        /// </summary>
        internal static ChangeHealthStatusCommand Instance => _instance ??= new ChangeHealthStatusCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeHealthStatusCommand"/> class with the specified introduction message.
        /// </summary>
        private ChangeHealthStatusCommand() : base(UiMessages.ChangeHealthStatusMessages.Introduce) { }

        /// <summary>
        /// Executes the command to change the health status of a selected patient. 
        /// If there are no patients, displays a no patients prompt.
        /// Otherwise, it prompts the user to select a patient and then choose the health status from the provided options.
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
                var patient = UiHelper.SelectObject(patients, UiMessages.ChangeHealthStatusMessages.SelectPatientPrompt);
                ChangeHealthStatus(patient, session);

                Ui.ShowMessage(string.Format(UiMessages.ChangeHealthStatusMessages.OperationSuccessPrompt,
                    patient.Name, patient.Surname));
            }

            NavigationCommand.Instance.Execute();
        }

        /// <summary>
        /// Changes the health status of the provided patient and updates it in the database.
        /// </summary>
        /// <param name="patient">The patient whose health status needs to be changed.</param>
        /// <param name="session">The database session to use for updating the patient's health status.</param>
        private void ChangeHealthStatus(Patient patient, ISession session)
        {
            patient.HealthStatus = Ui.ShowInteractiveMenu();
            DatabaseOperations<Patient>.Update(patient, session);
        }
    }
}