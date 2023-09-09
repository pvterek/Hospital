using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.PatientObject;
using Hospital.Objects.WardObject;
using NHibernate;
using Hospital.Utilities.UI;
using Hospital.Utilities.UI.UserInterface;
using Hospital.Commands.Navigation;

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
        private SignOutPatientCommand() : base(UIMessages.SignOutPatientMessages.Introduce) { }

        /// <summary>
        /// Executes the sign-out procedure for a patient. The patient will be removed from both the database and their assigned ward.
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
                    Patient patient = SignOutPatient(patients, session);

                    UI.ShowMessage(string.Format(UIMessages.SignOutPatientMessages.SuccessSignOutPrompt, patient.Name, patient.Surname));
                }
            }
            catch (Exception ex)
            {
                UIHelper.HandleError(UIMessages.SignOutPatientMessages.ErrorSignOutPrompt, ex);
            }

            NavigationCommand.Instance.Execute();
        }

        /// <summary>
        /// Signs out a patient from the system, removing them from the list of patients, database, and assigned ward.
        /// </summary>
        /// <param name="patients">The list of patients to choose from.</param>
        /// <param name="session">The database session to use for the operation.</param>
        /// <returns>The patient who has been signed out.</returns>
        private Patient SignOutPatient(List<Patient> patients, ISession session)
        {
            Patient patient = UI.ShowInteractiveMenu(patients);

            PatientDatabaseOperations.DeletePatient(patient, session);
            ManageCapacity.UpdateWardCapacity(patient.AssignedWard, session);

            return patient;
        }
    }
}