using Hospital.PeopleCategories.PersonClass;

namespace Hospital.PeopleCategories.Factory.Interfaces
{
    internal interface IEmployeeFactory
    {
        Person CreateEmployee(string employeeType, PersonDTO dto);
        public IEnumerable<string> GetEmployeeTypes();
    }
}