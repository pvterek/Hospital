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
    /// Represents the main command for displaying the login window options, such as logging in and creating a new account.
    /// Inherits from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class LoginWindowCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="LoginWindowCommand"/> class.
        /// </summary>
        private static LoginWindowCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="LoginWindowCommand"/> class.
        /// </summary>
        internal static LoginWindowCommand Instance => _instance ??= new LoginWindowCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginWindowCommand"/> class.
        /// </summary>
        public LoginWindowCommand() : base(UIMessages.LoginWindowCommandMessages.Introduce, new List<CompositeCommand>())
        {
            Commands.Add(LoginCommand.Instance);
            Commands.Add(CreateAccountCommand.Instance);
            Commands.Add(ExitCommand.Instance);
        }

        /// <summary>
        /// Executes the login window process, displaying the interactive menu with options for the user to select.
        /// </summary>
        public override void Execute()
        {
            UserInterface.ShowInteractiveMenu(Commands).Execute();
        }
    }
}