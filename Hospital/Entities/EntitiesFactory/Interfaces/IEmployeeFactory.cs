using Hospital.PeopleCategories.PersonClass;

namespace Hospital.PeopleCategories.Factory.Interfaces
{
    public interface IEmployeeFactory
    {
        Person CreateEmployee(string employeeType, PersonDTO dto);
        IEnumerable<string> GetEmployeeTypes();
    }
}