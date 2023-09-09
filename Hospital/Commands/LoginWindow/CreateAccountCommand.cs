using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Database;
using Hospital.Objects.UserObject;
using Hospital.Utilities.UI;
using Hospital.Utilities.UI.UserInterface;
using NHibernate;

namespace Hospital.Commands.LoginWindow
{
    /// <summary>
    /// Represents the main command to create a user account. 
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class CreateAccountCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="CreateAccountCommand"/> class.
        /// </summary>
        private static CreateAccountCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="CreateAccountCommand"/> class.
        /// </summary>
        internal static CreateAccountCommand Instance => _instance ??= new CreateAccountCommand(UIMessages.CreateAccountCommandMessages.Introduce);

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAccountCommand"/> class, with a specified introduction message.
        /// </summary>
        /// <param name="introduceString">The introduction message for the account creation process.</param>
        public CreateAccountCommand(string introduceString) : base(introduceString) { }

        /// <summary>
        /// Executes the account creation process, prompting the user for details and adding the newly created user to database.
        /// </summary>
        public override void Execute()
        {
            using var session = Program.sessionFactory.OpenSession();

            try
            {
                User user = CreateAccount(session);
            
                UI.ShowMessage(string.Format(UIMessages.CreateAccountCommandMessages.CreatedAccountPrompt, user.Login));
            }
            catch (Exception ex)
            {
                UIHelper.HandleError(UIMessages.CreateAccountCommandMessages.ErrorCreateAccountPrompt, ex);
            }
        }

        /// <summary>
        /// Creates a new user account, adds it to the database, and returns the created user.
        /// </summary>
        /// <param name="session">The database session to use for the operation.</param>
        /// <returns>The newly created user account.</returns>
        private User CreateAccount(ISession session)
        {
            User user = UserFactory.CreateUser();
            DatabaseOperations<User>.Add(user, session);

            return user;
        }
    }
}