using Hospital.PeopleCategories.UserClass;
using Hospital.Utilities;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.LoginWindow
{
    public class LoginCommand : CompositeCommand
    {
        public bool IsLoggedIn;

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
            User? user = _authenticationService.GetUserByLogin(login);
            if (user is null)
            {
                _menuHandler.ShowMessage(UiMessages.LoginCommandMessages.CantFindLoginPrompt);
                return;
            }

            var inputPassword = _inputHandler.GetInput(UiMessages.FactoryMessages.ProvidePasswordPrompt);
            if (!_authenticationService.Authenticate(user.Password, inputPassword))
            {
                _menuHandler.ShowMessage(UiMessages.LoginCommandMessages.WrongPasswordPrompt);
                return;
            }

            IsLoggedIn = true;
        }
    }
}