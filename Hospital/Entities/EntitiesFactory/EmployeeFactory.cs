using Hospital.PeopleCategories.DoctorClass;
using Hospital.PeopleCategories.Factory.Interfaces;
using Hospital.PeopleCategories.NurseClass;
using Hospital.PeopleCategories.PersonClass;
using Hospital.Utilities.UserInterface;

namespace Hospital.PeopleCategories.Factory
{
    internal class EmployeeFactory : IEmployeeFactory
    {
        private readonly IValidateObjects _validateObjects;
        private readonly IObjectsFactory _objectsFactory;

        public EmployeeFactory(IValidateObjects validateObjects, IObjectsFactory objectsFactory)
        {
            _validateObjects = validateObjects;
            _objectsFactory = objectsFactory;
        }

        public Person CreateEmployee(string employeeType, PersonDTO dto)
        {
            bool isValid = employeeType switch
            {
                UiMessages.DoctorObjectMessages.Position => _validateObjects.ValidateDoctorObject(dto as DoctorDTO),
                UiMessages.NurseObjectMessages.Position => _validateObjects.ValidateNurseObject(dto as NurseDTO),
                _ => throw new ArgumentException(string.Format(UiMessages.ExceptionMessages.EntityType, employeeType)),
            };

            if (!isValid)
            {
                throw new InvalidOperationException(UiMessages.ExceptionMessages.DTOValidation);
            }

            return employeeType switch
            {
                UiMessages.DoctorObjectMessages.Position => _objectsFactory.CreateDoctor(dto as DoctorDTO),
                UiMessages.NurseObjectMessages.Position => _objectsFactory.CreateNurse(dto as NurseDTO),
                _ => throw new ArgumentException(string.Format(UiMessages.ExceptionMessages.EntityType, employeeType)),
            };
        }

        public IEnumerable<string> GetEmployeeTypes()
        {
            return new List<string>
            {
                UiMessages.DoctorObjectMessages.Position,
                UiMessages.NurseObjectMessages.Position,
            };
        }
    }
}