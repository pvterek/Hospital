using Hospital.Utilities;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.LoginWindow
{
    internal class LoginCommand : CompositeCommand
    {
        public static bool IsLoggedIn;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMenuHandler _menuHandler;
        private readonly IInputHandler _inputHandler;

        public LoginCommand(
            IAuthenticationService authenticationService,
            IMenuHandler menuHandler,
            IInputHandler inputHandler) 
            : base(UiMessages.LoginCommandMessages.Introduce) 
        {
            _authenticationService = authenticationService;
            _menuHandler = menuHandler;
            _inputHandler = inputHandler;
        }

        public override void Execute()
        {
            var login = _inputHandler.GetInput(UiMessages.FactoryMessages.ProvideLoginPrompt);
            if(_authenticationService.GetUserByLogin(login) is null)
            {
                _menuHandler.ShowMessage(UiMessages.LoginCommandMessages.CantFindLoginPrompt);
                return;
            }

            var password = _inputHandler.GetInput(UiMessages.FactoryMessages.ProvidePasswordPrompt);
            if (!_authenticationService.Authenticate(login, password))
            {
                _menuHandler.ShowMessage(UiMessages.LoginCommandMessages.WrongPasswordPrompt);
                return;
            }

            IsLoggedIn = true;
        }
    }
}