using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.PersonObject;
using Hospital.Utilities;

namespace Hospital.Objects.UserObject
{
    /// <summary>
    /// Represents a user in the hospital system. Inherits from the <see cref="Person"/> class.
    /// </summary>
    internal class User : Person
    {
        private string _login;

        /// <summary>
        /// Gets the login of the user.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the provided login is null or whitespace.</exception>
        public string Login
        {
            get => _login;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _login = value;
                }
                else
                {
                    throw new ArgumentException(UIMessages.FactoryMessages.EmptyLoginPrompt);
                }
            }
        }

        private string _password;

        /// <summary>
        /// Gets the password of the user.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the provided password is null or whitespace.</exception>
        public string Password
        {
            get => _password;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _password = value;
                }
                else
                {
                    throw new ArgumentException(UIMessages.FactoryMessages.EmptyPasswordPrompt);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class with the provided parameters.
        /// </summary>
        /// <param name="name">The first name of the user.</param>
        /// <param name="surname">The last name of the user.</param>
        /// <param name="gender">The gender of the user.</param>
        /// <param name="birthday">The birthdate of the user.</param>
        /// <param name="login">The login credential of the user.</param>
        /// <param name="password">The password credential of the user.</param>
        public User(string name, string surname, Gender gender, DateTime birthday, string login, string password)
            : base(name, surname, gender, birthday)
        {
            Login = login;
            Password = password;
            IntroduceString = string.Format(UIMessages.UserObjectMessages.Introduce, name, surname);
        }
    }
}