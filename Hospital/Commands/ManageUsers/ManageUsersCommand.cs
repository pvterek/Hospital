using Hospital.Commands.Navigation;
using Hospital.Entities.Interfaces;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.ManageUsers
{
    internal class ManageUsersCommand : Command
    {
        private readonly Lazy<CreateUserCommand> _createUserCommand;
        private readonly Lazy<DisplayUsersCommand> _displayUsersCommand;
        private readonly Lazy<DeleteUserCommand> _deleteUserCommand;
        private readonly Lazy<BackCommand> _backCommand;
        private readonly INavigationService _navigationService;
        private readonly IMenuHandler _menuHandler;

        public ManageUsersCommand(
            Lazy<CreateUserCommand> createUserCommand,
            Lazy<DisplayUsersCommand> displayUsersCommand,
            Lazy<DeleteUserCommand> deleteUserCommand,
            Lazy<BackCommand> backCommand,
            INavigationService navigationService,
            IMenuHandler menuHandler)
            : base(UiMessages.ManageUsersMessages.Introduce)
        {
            _createUserCommand = createUserCommand;
            _displayUsersCommand = displayUsersCommand;
            _deleteUserCommand = deleteUserCommand;
            _backCommand = backCommand;
            _navigationService = navigationService;
            _menuHandler = menuHandler;
        }

        public override void Execute()
        {
            var commands = new List<IHasIntroduceString>
            {
                _createUserCommand.Value,
                _displayUsersCommand.Value,
                _deleteUserCommand.Value,
                _backCommand.Value

            };
            var selectedCommand = _menuHandler.ShowInteractiveMenu(commands);

            _navigationService.Queue((Command)selectedCommand);

            switch (selectedCommand.IntroduceString)
            {
                case UiMessages.CreateUserCommandMessages.Introduce:
                    _createUserCommand.Value.Execute();
                    break;
                case UiMessages.DisplayUsersCommandMessages.Introduce:
                    _displayUsersCommand.Value.Execute();
                    break;
                case UiMessages.DeleteUserMessages.Introduce:
                    _deleteUserCommand.Value.Execute();
                    break;
                case UiMessages.BackCommandMessages.Introduce:
                    _backCommand.Value.Execute();
                    break;
                default:
                    _menuHandler.ShowMessage(UiMessages.ExceptionMessages.Command);
                    break;
            }
        }
    }
}
