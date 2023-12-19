using Hospital.PeopleCategories.DoctorClass;
using Hospital.PeopleCategories.NurseClass;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.UserClass;
using Hospital.PeopleCategories.WardClass;

namespace Hospital.PeopleCategories.Factory.Interfaces
{
    public interface IValidateObjects
    {
        bool ValidateDoctorObject(DoctorDTO dto);
        bool ValidatePatientObject(PatientDTO dto);
        bool ValidateNurseObject(NurseDTO dto);
        bool ValidateUserObject(UserDTO dto);
        bool ValidateWardObject(WardDTO dto);

    }
}
