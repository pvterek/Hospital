using Hospital.Commands.Navigation;
using Hospital.Entities.Interfaces;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.LoginWindow
{
    public class LoginWindowCommand : Command
    {
        private readonly Lazy<LoginCommand> _loginCommand;
        private readonly Lazy<ExitCommand> _exitCommand;
        private readonly IMenuHandler _menuHandler;

        public LoginWindowCommand(
            Lazy<LoginCommand> loginCommand,
            Lazy<ExitCommand> exitCommand,
            IMenuHandler menuHandler)
            : base(UiMessages.LoginWindowCommandMessages.Introduce)
        {
            _loginCommand = loginCommand;
            _exitCommand = exitCommand;
            _menuHandler = menuHandler;
        }

        public override void Execute()
        {
            var commands = new List<IHasIntroduceString>
            {
                _loginCommand.Value,
                _exitCommand.Value
            };

            var selectedCommand = _menuHandler.ShowInteractiveMenu(commands);

            switch (selectedCommand.IntroduceString)
            {
                case UiMessages.LoginCommandMessages.Introduce:
                    _loginCommand.Value.Execute();
                    break;
                case UiMessages.ExitCommandMessages.Introduce:
                    _exitCommand.Value.Execute();
                    break;
                default:
                    _menuHandler.ShowMessage(UiMessages.ExceptionMessages.Command);
                    break;
            }
        }
    }
}