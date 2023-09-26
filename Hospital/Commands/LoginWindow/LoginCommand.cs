using Hospital.PeopleCategories;
using Hospital.PeopleCategories.UserClass;
using Hospital.Utilities;
using Hospital.Utilities.UserInterface;

namespace Hospital.Commands.LoginWindow
{
    /// <summary>
    /// Represents the main command for the login process, handling user input for login credentials and authenticating the user.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class LoginCommand : CompositeCommand
    {
        /// <summary>
        /// Value indicating whether the user is currently logged in.
        /// </summary>
        public static bool IsLoggedIn;
        
        /// <summary>
        /// Holds a singleton instance of the <see cref="LoginCommand"/> class.
        /// </summary>
        private static LoginCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="LoginCommand"/> class.
        /// </summary>
        internal static LoginCommand Instance => _instance ??= new LoginCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginCommand"/> class with the specified introduction message.
        /// </summary>
        private LoginCommand() : base(UiMessages.LoginCommandMessages.Introduce) { }

        /// <summary>
        /// Executes the login process, prompting the user for login credentials and authenticating against the available users.
        /// </summary>
        public override void Execute()
        {
            string login;
            
            do
            {
                login = FactoryMethods.AskForValue(UiMessages.FactoryMessages.EnterLoginPrompt, UiMessages.FactoryMessages.EmptyFieldPrompt);
            }
            while (!CheckIfUserExist(AuthenticationService.GetUserByLogin(login)));

            var password = FactoryMethods.AskForPassword();

            AuthenticateUser(login, password);
        }

        /// <summary>
        /// Checks if the user exists based on the provided user object.
        /// </summary>
        /// <param name="user">The user object to check.</param>
        private bool CheckIfUserExist(User? user)
        {
            if (user != null) return true;
            
            Ui.ShowMessage(UiMessages.LoginCommandMessages.CantFindLoginPrompt);
            return false;
        }

        /// <summary>
        /// Authenticates the user using the given login and password.
        /// </summary>
        /// <param name="login">The user's login for authentication.</param>
        /// <param name="password">The user's password for authentication.</param>
        private void AuthenticateUser(string login, string password)
        {
            if (AuthenticationService.Authenticate(login, password))
            {
                IsLoggedIn = true;
            }
            else
            {
                Ui.ShowMessage(UiMessages.LoginCommandMessages.WrongPasswordPrompt);
            }
        }
    }
}