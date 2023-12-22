using Hospital.Entities.Employee;
using Hospital.PeopleCategories.Factory.Interfaces;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.UserClass;
using Hospital.PeopleCategories.WardClass;

namespace Hospital.PeopleCategories.Factory
{
    public class ObjectsFactory : IObjectsFactory
    {
        public Patient CreatePatient(PatientDTO dto)
        {
            return new Patient(
                dto.Name,
                dto.Surname,
                dto.Gender,
                dto.Birthday,
                dto.Pesel,
                dto.AssignedWard);
        }

        public Employee CreateEmployee(EmployeeDTO dto)
        {
            return new Employee(
                dto.Name,
                dto.Surname,
                dto.Gender,
                dto.Birthday,
                dto.AssignedWard,
                dto.Position,
                dto.AssignedPatients);
        }

        public User CreateUser(UserDTO dto)
        {
            return new User(
                dto.Name,
                dto.Surname,
                dto.Gender,
                dto.Birthday,
                dto.Login,
                dto.Password);
        }

        public Ward CreateWard(WardDTO dto)
        {
            return new Ward(
                dto.Name,
                dto.Capacity,
                dto.AssignedPatients,
                dto.AssignedEmployees);
        }
    }
}