using Hospital.Commands.Navigation;
using Hospital.Utilities.UserInterface;

namespace Hospital.Commands.ManageEmployees
{
    /// <summary>
    /// Represents a command to manage various operations related to staff members.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class ManageEmployeesCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="ManageEmployeesCommand"/> class.
        /// </summary>
        private static ManageEmployeesCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="ManageEmployeesCommand"/> class.
        /// </summary>
        internal static ManageEmployeesCommand Instance => _instance ??= new ManageEmployeesCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageEmployeesCommand"/> class, providing options to manage staff.
        /// </summary>
        private ManageEmployeesCommand() : base(UiMessages.ManageEmployeesMessages.Introduce, new List<CompositeCommand>())
        {
            Commands.Add(HireEmployeeCommand.Instance);
            Commands.Add(FireEmployeeCommand.Instance);
            Commands.Add(DisplayEmployeesCommand.Instance);
            Commands.Add(NavigationCommand.Instance);
        }

        /// <summary>
        /// Executes the main staff management menu, allowing the user to select from various management options.
        /// </summary>
        public override void Execute()
        {
            var command = Ui.ShowInteractiveMenu(Commands);
            NavigationCommand.Queue(command);
        }
    }
}
