using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.PersonClass;
using Hospital.PeopleCategories.WardClass;

namespace Hospital.PeopleCategories.DoctorClass
{
    public class DoctorDTO : PersonDTO
    {
        public DoctorDTO(PersonDTO person)
        {
            Name = person.Name;
            Surname = person.Surname;
            Gender = person.Gender;
            Birthday = person.Birthday;
        }

        public Ward AssignedWard { get; set; }

        public IList<Patient> AssignedPatients { get; set; }
    }
}
