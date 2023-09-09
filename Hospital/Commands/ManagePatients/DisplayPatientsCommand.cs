using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Commands.Navigation;
using Hospital.Objects.PatientObject;
using Hospital.Utilities.UI;
using Hospital.Utilities.UI.UserInterface;

namespace Hospital.Commands.ManagePatients
{
    /// <summary>
    /// Represents a command to display patients.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class DisplayPatientsCommand : CompositeCommand
    {
        private static DisplayPatientsCommand? _instance;

        /// <summary>
        /// Singleton instance of the <see cref="DisplayPatientsCommand"/> class.
        /// </summary>
        internal static DisplayPatientsCommand Instance => _instance ??= new DisplayPatientsCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayPatientsCommand"/> class.
        /// </summary>
        private DisplayPatientsCommand() : base(UIMessages.DisplayPatientsMessages.Introduce) { }

        /// <summary>
        /// Executes the display patients command.
        /// If there are no patients, displays a no patients prompt.
        /// Otherwise, it will display the list of patients.
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
                    ListMaker.DisplayList(patients);
                }
            }
            catch (Exception ex)
            {
                UIHelper.HandleError(UIMessages.SignOutPatientMessages.ErrorSignOutPrompt, ex);
            }

            NavigationCommand.Instance.Execute();
        }
    }
}
