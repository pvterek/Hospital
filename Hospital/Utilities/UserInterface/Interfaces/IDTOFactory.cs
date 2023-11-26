using Hospital.PeopleCategories.DoctorClass;
using Hospital.PeopleCategories.NurseClass;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.PersonClass;
using Hospital.PeopleCategories.UserClass;
using Hospital.PeopleCategories.WardClass;

namespace Hospital.Utilities.UserInterface.Interfaces
{
    public interface IDTOFactory
    {
        public PersonDTO GatherPersonData();
        public DoctorDTO GatherDoctorData(List<Ward> wards);
        public PatientDTO GatherPatientData(List<Ward> wards);
        public NurseDTO GatherNurseData(List<Ward> wards);
        public UserDTO GatherUserData();
        public WardDTO GatherWardData();
    }
}
