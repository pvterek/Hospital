using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.PatientObject;
using Hospital.Objects.PersonObject;
using Hospital.Objects.WardObject;
using Hospital.Utilities.UI.UserInterface;

namespace Hospital.Objects.UserObject
{
    /// <summary>
    /// Represents a user in the hospital system. Inherits from the <see cref="Person"/> class.
    /// </summary>
    public class User : Person
    {
        private string _login;

        /// <summary>
        /// Gets or sets the login name of the user.
        /// </summary>
        public virtual string Login
        {
            get => _login;
            set
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
        /// Gets or sets the password of the user.
        /// </summary>
        public virtual string Password
        {
            get => _password;
            set
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
        /// Constructor needed for NHibernate.
        /// </summary>
        protected User() { }

        /// <summary>
        /// Gets or sets the ward assigned to the user.
        /// </summary>
        public virtual Ward AssignedWard { get; set; }

        //public virtual IList<Ward> AssignedWards { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class with provided properties.
        /// </summary>
        /// <param name="name">The first name of the user.</param>
        /// <param name="surname">The surname of the user.</param>
        /// <param name="gender">The gender of the user.</param>
        /// <param name="birthday">The birthday of the user.</param>
        /// <param name="login">The login name of the user.</param>
        /// <param name="password">The password of the user.</param>
        public User(string name, string surname, Gender gender, DateTime birthday, string login, string password)
            : base(name, surname, gender, birthday)
        {
            //AssignedWards = new List<Ward>();
            Login = login;
            Password = password;
            IntroduceString = string.Format(UIMessages.UserObjectMessages.Introduce, name, surname);
        }
    }
}