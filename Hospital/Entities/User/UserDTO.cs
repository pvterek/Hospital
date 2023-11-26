using Hospital.PeopleCategories.PersonClass;

namespace Hospital.PeopleCategories.UserClass
{
    public class UserDTO : PersonDTO
    {
        public UserDTO(PersonDTO person)
        {
            Name = person.Name;
            Surname = person.Surname;
            Gender = person.Gender;
            Birthday = person.Birthday;
        }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}