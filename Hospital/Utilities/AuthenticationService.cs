using Hospital.Database;
using Hospital.PeopleCategories.UserClass;
using Hospital.Utilities.UserInterface;

namespace Hospital.Utilities
{
    /// <summary>
    /// Provides an methods for authentication-related operations in the Hospital application.
    /// </summary>
    internal static class AuthenticationService
    {
        /// <summary>
        /// Authenticates a user based on the provided login and password.
        /// </summary>
        /// <param name="login">The user's login.</param>
        /// <param name="password">The user's password.</param>
        /// <returns><c>true</c> if the authentication is successful; otherwise, <c>false</c>.</returns>
        public static bool Authenticate(string login, string password)
        {
            var user = GetUserByLogin(login);
            return user != null && user.Password == password;
        }

        /// <summary>
        /// Retrieves a <see cref="User"/> based on the provided login.
        /// </summary>
        /// <param name="login">The user's login.</param>
        /// <returns>An object of <see cref="User"/> if found.</returns>
        public static User? GetUserByLogin(string login)
        {
            using var session = CreateSession.SessionFactory.OpenSession();

            try
            {
                var users = DatabaseOperations<User>.GetAll(session);

                return users?.FirstOrDefault(u => u.Login == login);
            }
            catch
            {
                Ui.ShowMessage(UiMessages.AuthenticationServiceMessages.ErrorGetUserByLoginPrompt);

                return null;
            }
        }
    }
}
