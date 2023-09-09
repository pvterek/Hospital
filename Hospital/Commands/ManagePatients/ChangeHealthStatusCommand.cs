using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Commands.Navigation;
using Hospital.Database;
using Hospital.Objects.PatientObject;
using Hospital.Objects.WardObject;
using Hospital.Utilities.UI;
using Hospital.Utilities.UI.UserInterface;
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
        private ChangeHealthStatusCommand() : base(UIMessages.ChangeHealthStatusMessages.Introduce) { }

        /// <summary>
        /// Executes the command to change the health status of a selected patient. 
        /// If there are no patients, displays a no patients prompt.
        /// Otherwise, it prompts the user to select a patient and then choose the health status from the provided options.
        /// </summary>
        public override void Execute()
        {
            using var session = Program.sessionFactory.OpenSession();

            try
            {
                List<Patient> patients = PatientDatabaseOperations.GetAllPatients(session);

                if (!patients.Any()) 
                {
                    UI.ShowMessage(UIMessages.DisplayPatientsMessages.NoPatientsPrompt);
                }
                else
                {
                    UI.ShowMessage(UIMessages.ChangeHealthStatusMessages.SelectPatientPrompt);

                    ChangeHealthStatus(patients, session);
                }
            }
            catch (Exception ex)
            {
                UIHelper.HandleError(UIMessages.ChangeHealthStatusMessages.ErrorChangeHealthStatusPrompt, ex);
            }

            NavigationCommand.Instance.Execute();
        }

        /// <summary>
        /// Changes the health status of a patient selected from a list and updates it in the database.
        /// </summary>
        /// <param name="patients">The list of patients to choose from.</param>
        /// <param name="session">The database session to use for the operation.</param>
        private void ChangeHealthStatus(List<Patient> patients, ISession session)
        {
            Patient patient = UI.ShowInteractiveMenu(patients);
            patient.HealthStatus = UI.ShowInteractiveMenu();

            DatabaseOperations<Patient>.Update(patient, session);
        }
    }
}
