using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Hospital.Utilities;
using Hospital.Objects.PersonObject;

namespace Hospital.Objects.UserObject
{
    /// <summary>
    /// Represents a factory for creating <see cref="User"/> objects. 
    /// It extends the base <see cref="PersonFactory"/> to include methods specific to the creation of users.
    /// </summary>
    internal class UserFactory : PersonFactory
    {
        /// <summary>
        /// Creates a new instance of the <see cref="User"/> class by gathering all required details.
        /// </summary>
        /// <returns>A new <see cref="User"/> object populated with the provided details.</returns>
        public static User CreateUser()
        {
            string name = AskForValue(UIMessages.FactoryMessages.ProvideNamePrompt, UIMessages.FactoryMessages.EmptyFieldPrompt);
            string surname = AskForValue(UIMessages.FactoryMessages.ProvideSurnamePrompt, UIMessages.FactoryMessages.EmptyFieldPrompt);
            Gender gender = AskForGender();
            DateTime birthday = AskForBirthday();
            string login = AskForLogin();
            string password = AskForPassword();

            return new User(name, surname, gender, birthday, login, password);
        }
    }
}
