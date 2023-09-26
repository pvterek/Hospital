using Hospital.Database;
using Hospital.PeopleCategories.UserClass;
using Hospital.Utilities.UserInterface;
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
        internal static CreateAccountCommand Instance => _instance ??= new CreateAccountCommand(UiMessages.CreateAccountCommandMessages.Introduce);

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAccountCommand"/> class, with a specified introduction message.
        /// </summary>
        /// <param name="introduceString">The introduction message for the account creation process.</param>
        private CreateAccountCommand(string introduceString) : base(introduceString) { }

        /// <summary>
        /// Executes the account creation process, prompting the user for details and adding the newly created user to database.
        /// </summary>
        public override void Execute()
        {
            using var session = CreateSession.SessionFactory.OpenSession();

            try
            {
                var user = CreateAccount(session);
            
                Ui.ShowMessage(string.Format(UiMessages.CreateAccountCommandMessages.CreatedAccountPrompt, user.Login));
            }
            catch (Exception ex)
            {
                UiHelper.HandleError(UiMessages.CreateAccountCommandMessages.ErrorCreateAccountPrompt, ex);
            }
        }

        /// <summary>
        /// Creates a new user account, adds it to the database, and returns the created user.
        /// </summary>
        /// <param name="session">The database session to use for the operation.</param>
        /// <returns>The newly created user account.</returns>
        private User CreateAccount(ISession session)
        {
            var user = UserFactory.CreateUser();
            DatabaseOperations<User>.Add(user, session);

            return user;
        }
    }
}