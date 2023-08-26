using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.UserObject;
using Hospital.Utilities;

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
            Console.Clear();

            Console.Write(UIMessages.FactoryMessages.EnterLoginPrompt);
            string login = Console.ReadLine();

            User? user = AuthenticationService.GetUserByLogin(login);

            if (user == null)
            {
                UserInterface.ShowMessage(UIMessages.LoginCommandMessages.CantFindLoginPrompt);
                return;
            }

            Console.Write(UIMessages.FactoryMessages.EnterPasswordPrompt);
            string password = Console.ReadLine();

            if (AuthenticationService.Authenticate(login, password))
            {
                Program.IsLoggedIn = true;
            }
            else
            {
                UserInterface.ShowMessage(UIMessages.LoginCommandMessages.WrongPasswordPrompt);
            }
        }
    }
}