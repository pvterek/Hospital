using Hospital.PeopleCategories.PersonClass;
using Hospital.PeopleCategories.WardClass;

namespace Hospital.PeopleCategories.NurseClass
{
    public class NurseDTO : PersonDTO
    {
        public NurseDTO(PersonDTO person)
        {
            Name = person.Name;
            Surname = person.Surname;
            Gender = person.Gender;
            Birthday = person.Birthday;
        }

        public Ward AssignedWard { get; set; }
    }
}