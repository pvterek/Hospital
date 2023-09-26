using Hospital.Commands.Navigation;
using Hospital.Database;
using Hospital.PeopleCategories.PatientClass;
using Hospital.Utilities.UserInterface;

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
        private DisplayPatientsCommand() : base(UiMessages.DisplayPatientsMessages.Introduce) { }

        /// <summary>
        /// Executes the display patients command.
        /// If there are no patients, displays a no patients prompt.
        /// Otherwise, it will display the list of patients.
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
                ListMaker.DisplayList(patients);
            }

            NavigationCommand.Instance.Execute();
        }
    }
}