using Hospital.PeopleCategories.DoctorClass;
using Hospital.PeopleCategories.NurseClass;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.UserClass;
using Hospital.PeopleCategories.WardClass;

namespace Hospital.PeopleCategories.Factory.Interfaces
{
    public interface IObjectsFactory
    {
        Doctor CreateDoctor(DoctorDTO dto);
        Patient CreatePatient(PatientDTO dto);
        Nurse CreateNurse(NurseDTO dto);
        User CreateUser(UserDTO dto);
        Ward CreateWard(WardDTO dto);
    }
}