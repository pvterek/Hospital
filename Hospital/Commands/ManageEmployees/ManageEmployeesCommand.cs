using Hospital.Commands.Navigation;
using Hospital.Entities.Interfaces;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.ManageEmployees
{
    internal class ManageEmployeesCommand : Command
    {
        private readonly Lazy<CreateEmployeeCommand> _createEmployeeCommand;
        private readonly Lazy<DisplayEmployeesCommand> _displayEmployeesCommand;
        private readonly Lazy<DeleteEmployeeCommand> _deleteEmployeeCommand;
        private readonly Lazy<BackCommand> _backCommand;
        private readonly INavigationService _navigationService;
        private readonly IMenuHandler _menuHandler;

        public ManageEmployeesCommand(
            Lazy<CreateEmployeeCommand> createEmployeeCommand,
            Lazy<DisplayEmployeesCommand> displayEmployeesCommand,
            Lazy<DeleteEmployeeCommand> deleteEmployeeCommand,
            Lazy<BackCommand> backCommand,
            INavigationService navigationService,
            IMenuHandler menuHandler)
            : base(UiMessages.ManageEmployeesMessages.Introduce)
        {
            _createEmployeeCommand = createEmployeeCommand;
            _displayEmployeesCommand = displayEmployeesCommand;
            _deleteEmployeeCommand = deleteEmployeeCommand;
            _backCommand = backCommand;
            _navigationService = navigationService;
            _menuHandler = menuHandler;
        }

        public override void Execute()
        {
            var commands = new List<IHasIntroduceString>
            {
                _createEmployeeCommand.Value,
                _displayEmployeesCommand.Value,
                _deleteEmployeeCommand.Value,
                _backCommand.Value
            };

            var selectedCommand = _menuHandler.ShowInteractiveMenu(commands);
            _navigationService.Queue((Command)selectedCommand);

            switch (selectedCommand.IntroduceString)
            {
                case UiMessages.CreateEmployeeMessages.Introduce:
                    _createEmployeeCommand.Value.Execute();
                    break;
                case UiMessages.DisplayEmployeesMessages.Introduce:
                    _displayEmployeesCommand.Value.Execute();
                    break;
                case UiMessages.DeleteEmployeeMessages.Introduce:
                    _deleteEmployeeCommand.Value.Execute();
                    break;
                case UiMessages.BackCommandMessages.Introduce:
                    _backCommand.Value.Execute();
                    break;
                default:
                    Console.WriteLine(UiMessages.ExceptionMessages.Command);
                    break;
            }
        }
    }
}