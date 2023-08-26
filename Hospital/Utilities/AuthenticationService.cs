using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.UserObject;

namespace Hospital.Utilities
{
    /// <summary>
    /// Provides an methods for authentication-related operations in the Hospital application.
    /// </summary>
    internal class AuthenticationService
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
            return Storage.users.FirstOrDefault(u => u.Login == login);
        }
    }
}
