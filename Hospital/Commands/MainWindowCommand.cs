using Hospital.Commands.LoginWindow;
using Hospital.Commands.ManageEmployees;
using Hospital.Commands.ManagePatients;
using Hospital.Commands.ManageWards;
using Hospital.Commands.Navigation;
using Hospital.Utilities.UserInterface;

namespace Hospital.Commands
{
    /// <summary>
    /// Represents the main window command in the application.
    /// It aggregates a collection of key commands related to managing patients, staff, and wards.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class MainWindowCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="MainWindowCommand"/> class.
        /// </summary>
        private static MainWindowCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="MainWindowCommand"/> class.
        /// </summary>
        internal static MainWindowCommand Instance => _instance ??= new MainWindowCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowCommand"/> class.
        /// </summary>
        private MainWindowCommand() : base(UiMessages.MainWindowMessages.Introduce, new List<CompositeCommand>())
        {
            Commands.Add(ManagePatientsCommand.Instance);
            Commands.Add(ManageEmployeesCommand.Instance);
            Commands.Add(ManageWardsCommand.Instance);
            Commands.Add(LogoutCommand.Instance);
        }

        /// <summary>
        /// Executes the logic to display the main window menu.
        /// </summary>
        public override void Execute()
        {
            var command = Ui.ShowInteractiveMenu(Commands);
            NavigationCommand.Queue(command);
        }
    }
}