using Hospital.Commands.Navigation;
using Hospital.Utilities.UserInterface;

namespace Hospital.Commands.ManagePatients
{
    /// <summary>
    /// Represents the main command to manage multiple patients, providing options like admitting a patient, displaying all patients, managing individual patients, and going back.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class ManagePatientsCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="ManagePatientsCommand"/> class.
        /// </summary>
        private static ManagePatientsCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="ManagePatientsCommand"/> class.
        /// </summary>
        internal static ManagePatientsCommand Instance => _instance ??= new ManagePatientsCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagePatientsCommand"/> class, providing a list of patient management options.
        /// </summary>
        private ManagePatientsCommand() : base(UiMessages.ManagePatientsMessages.Introduce, new List<CompositeCommand>())
        {
            Commands.Add(AdmitPatientCommand.Instance);
            Commands.Add(DisplayPatientsCommand.Instance);
            Commands.Add(ManagePatientCommand.Instance);
            Commands.Add(NavigationCommand.Instance);
        }

        /// <summary>
        /// Executes the patient management menu, allowing the user to select from various options.
        /// </summary>
        public override void Execute()
        {
            var command = Ui.ShowInteractiveMenu(Commands);
            NavigationCommand.Queue(command);
        }
    }
}
