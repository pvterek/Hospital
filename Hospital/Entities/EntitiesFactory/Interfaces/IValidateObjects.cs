using Hospital.PeopleCategories.DoctorClass;
using Hospital.PeopleCategories.NurseClass;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.UserClass;
using Hospital.PeopleCategories.WardClass;

namespace Hospital.PeopleCategories.Factory.Interfaces
{
    internal interface IValidateObjects
    {
        public bool ValidateDoctorObject(DoctorDTO dto);
        public bool ValidatePatientObject(PatientDTO dto);
        public bool ValidateNurseObject(NurseDTO dto);
        public bool ValidateUserObject(UserDTO dto);
        public bool ValidateWardObject(WardDTO dto);

    }
}
