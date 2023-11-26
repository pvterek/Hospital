using Hospital.PeopleCategories.DoctorClass;
using Hospital.PeopleCategories.Factory.Interfaces;
using Hospital.PeopleCategories.NurseClass;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.UserClass;
using Hospital.PeopleCategories.WardClass;

namespace Hospital.PeopleCategories.Factory
{
    public class ObjectsFactory : IObjectsFactory
    {
        public Doctor CreateDoctor(DoctorDTO dto)
        {
            return new Doctor(
                dto.Name,
                dto.Surname,
                dto.Gender,
                dto.Birthday,
                dto.AssignedWard,
                dto.AssignedPatients
                );
        }

        public Patient CreatePatient(PatientDTO dto) 
        {
            return new Patient(
                dto.Name,
                dto.Surname,
                dto.Gender,
                dto.Birthday,
                dto.Pesel,
                dto.AssignedWard
                );
        }

        public Nurse CreateNurse(NurseDTO dto) 
        {
            return new Nurse(
                dto.Name,
                dto.Surname,
                dto.Gender,
                dto.Birthday,
                dto.AssignedWard
                );
        }

        public User CreateUser(UserDTO dto) 
        {
            return new User(
                dto.Name,
                dto.Surname,
                dto.Gender,
                dto.Birthday,
                dto.Login,
                dto.Password
                );
        }

        public Ward CreateWard(WardDTO dto) 
        {
            return new Ward(
                dto.Name,
                dto.Capacity,
                dto.AssignedPatients,
                dto.AssignedEmployees
                );
        }
    }
}