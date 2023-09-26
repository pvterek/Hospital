using Hospital.PeopleCategories.PersonClass;
using Hospital.Utilities.UserInterface;

namespace Hospital.PeopleCategories.UserClass
{
    /// <summary>
    /// Represents a factory for creating <see cref="User"/> objects. 
    /// It extends the base <see cref="FactoryMethods"/> to include methods specific to the creation of users.
    /// </summary>
    internal class UserFactory : FactoryMethods
    {
        /// <summary>
        /// Creates a new instance of the <see cref="User"/> class by gathering all required details.
        /// </summary>
        /// <returns>A new <see cref="User"/> object populated with the provided details.</returns>
        public static User CreateUser()
        {
            var name = AskForValue(UiMessages.FactoryMessages.ProvideNamePrompt, UiMessages.FactoryMessages.EmptyFieldPrompt);
            var surname = AskForValue(UiMessages.FactoryMessages.ProvideSurnamePrompt, UiMessages.FactoryMessages.EmptyFieldPrompt);
            var gender = AskForGender();
            var birthday = AskForBirthday();
            var login = AskForLogin();
            var password = AskForPassword();

            return new User(name, surname, gender, birthday, login, password);
        }
    }
}
