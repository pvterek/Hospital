using Hospital.PeopleCategories.PersonClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.UserInterface;

namespace Hospital.PeopleCategories.UserClass
{
    public class User : Person
    {
        public virtual int Id { get; set; }

        public virtual string Login { get; }

        public virtual string Password { get; set; }

        public virtual Ward AssignedWard { get; set; }

        protected User() { }

        public User(string name, string surname, Gender gender, DateTime birthday, string login, string password)
            : base(name, surname, gender, birthday)
        {
            Login = login;
            Password = password;
            IntroduceString = string.Format(UiMessages.UserObjectMessages.Introduce, name, surname);
        }
    }
}