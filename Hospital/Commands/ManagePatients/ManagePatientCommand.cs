using Hospital.Commands.Navigation;
using Hospital.Utilities.UserInterface;

namespace Hospital.Commands.ManagePatients
{
    /// <summary>
    /// Represents the main command to manage patients, providing options like assigning to a doctor, changing health status, signing out a patient, and going back.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class ManagePatientCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="ManagePatientCommand"/> class.
        /// </summary>
        private static ManagePatientCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="ManagePatientCommand"/> class.
        /// </summary>
        internal static ManagePatientCommand Instance => _instance ??= new ManagePatientCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagePatientCommand"/> class, providing options to manage patients.
        /// </summary>
        private ManagePatientCommand() : base(UiMessages.ManagePatientMessages.Introduce, new List<CompositeCommand>())
        {
            Commands.Add(AssignToDoctorCommand.Instance);
            Commands.Add(ChangeHealthStatusCommand.Instance);
            Commands.Add(SignOutPatientCommand.Instance);
            Commands.Add(NavigationCommand.Instance);
        }

        /// <summary>
        /// Executes the main patient management menu, allowing the user to select from various management options.
        /// </summary>
        public override void Execute()
        {
            var command = Ui.ShowInteractiveMenu(Commands);
            NavigationCommand.Queue(command);
        }
    }
}
