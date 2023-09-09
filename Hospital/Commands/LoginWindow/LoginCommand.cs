using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects;
using Hospital.Objects.UserObject;
using Hospital.Utilities;
using Hospital.Utilities.UI;
using Hospital.Utilities.UI.UserInterface;
using NHibernate.Mapping;

namespace Hospital.Commands.LoginWindow
{
    /// <summary>
    /// Represents the main command for the login process, handling user input for login credentials and authenticating the user.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class LoginCommand : CompositeCommand
    {
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
        public LoginCommand() : base(UIMessages.LoginCommandMessages.Introduce) { }

        /// <summary>
        /// Executes the login process, prompting the user for login credentials and authenticating against the available users.
        /// </summary>
        public override void Execute()
        {
            string login = FactoryMethods.AskForValue(UIMessages.FactoryMessages.EnterLoginPrompt, UIMessages.FactoryMessages.EmptyFieldPrompt);
            CheckIfUserExist(AuthenticationService.GetUserByLogin(login));

            string password = FactoryMethods.AskForPassword();

            AuthenticateUser(login, password);
        }

        /// <summary>
        /// Checks if the user exists based on the provided user object.
        /// </summary>
        /// <param name="user">The user object to check.</param>
        private void CheckIfUserExist(User? user)
        {
            if (user == null)
            {
                UI.ShowMessage(UIMessages.LoginCommandMessages.CantFindLoginPrompt);
                return;
            }
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
                Program.IsLoggedIn = true;
            }
            else
            {
                UI.ShowMessage(UIMessages.LoginCommandMessages.WrongPasswordPrompt);
            }
        }
    }
}