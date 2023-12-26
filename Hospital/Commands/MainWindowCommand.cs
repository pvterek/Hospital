using Hospital.Commands.LoginWindow;
using Hospital.Commands.ManageEmployees;
using Hospital.Commands.ManagePatients;
using Hospital.Commands.ManageUsers;
using Hospital.Commands.ManageWards;
using Hospital.Commands.Navigation;
using Hospital.Entities.Interfaces;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands
{
    internal class MainWindowCommand : Command
    {
        private readonly Lazy<ManagePatientsCommand> _managePatientsCommand;
        private readonly Lazy<ManageEmployeesCommand> _manageEmployeesCommand;
        private readonly Lazy<ManageWardsCommand> _manageWardsCommand;
        private readonly Lazy<DeleteUserCommand> _deleteUserCommand;
        private readonly Lazy<LogoutCommand> _logoutCommand;
        private readonly INavigationService _navigationService;
        private readonly IMenuHandler _menuHandler;

        public MainWindowCommand(
            Lazy<ManagePatientsCommand> managePatientsCommand,
            Lazy<ManageEmployeesCommand> manageEmployeesCommand,
            Lazy<ManageWardsCommand> manageWardsCommand,
            Lazy<DeleteUserCommand> deleteUserCommand,
            Lazy<LogoutCommand> logoutCommand,
            INavigationService navigationService,
            IMenuHandler menuHandler)
            : base(UiMessages.MainWindowMessages.Introduce)
        {
            _managePatientsCommand = managePatientsCommand;
            _manageEmployeesCommand = manageEmployeesCommand;
            _manageWardsCommand = manageWardsCommand;
            _deleteUserCommand = deleteUserCommand;
            _logoutCommand = logoutCommand;
            _navigationService = navigationService;
            _menuHandler = menuHandler;
        }

        public override void Execute()
        {
            var commands = new List<IHasIntroduceString>
            {
                _managePatientsCommand.Value,
                _manageEmployeesCommand.Value,
                _manageWardsCommand.Value,
                _deleteUserCommand.Value,
                _logoutCommand.Value
            };
            var selectedCommand = _menuHandler.ShowInteractiveMenu(commands);

            _navigationService.Queue((Command)selectedCommand);

            switch (selectedCommand.IntroduceString)
            {
                case UiMessages.ManagePatientsMessages.Introduce:
                    _managePatientsCommand.Value.Execute();
                    break;
                case UiMessages.ManageEmployeesMessages.Introduce:
                    _manageEmployeesCommand.Value.Execute();
                    break;
                case UiMessages.ManageWardsMessages.Introduce:
                    _manageWardsCommand.Value.Execute();
                    break;
                case UiMessages.DeleteUserMessages.Introduce:
                    _deleteUserCommand.Value.Execute();
                    break;
                case UiMessages.LogoutCommandMessages.Introduce:
                    _logoutCommand.Value.Execute();
                    break;
                default:
                    Console.WriteLine(UiMessages.ExceptionMessages.Command);
                    break;
            }
        }
    }
}