using Hospital.PeopleCategories.Employee;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.UserInterface;

namespace Hospital.PeopleCategories.DoctorClass
{
    /// <summary>
    /// Represents a factory responsible for creating instances of the <see cref="Doctor"/> class.
    /// This factory inherits from the <see cref="FactoryMethods"/> class and implements the <see cref="IEmployeeFactory"/> interface.
    /// </summary>
    internal class DoctorFactory : FactoryMethods, IEmployeeFactory
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Doctor"/> class with properties derived from user input.
        /// </summary>
        /// <returns>A new <see cref="Doctor"/> object with properties filled out based on user input.</returns>
        public IEmployee CreateEmployee(List<Ward> wards)
        {
            var name = AskForValue(UiMessages.FactoryMessages.ProvideNamePrompt, UiMessages.FactoryMessages.EmptyFieldPrompt);
            var surname = AskForValue(UiMessages.FactoryMessages.ProvideSurnamePrompt, UiMessages.FactoryMessages.EmptyFieldPrompt);
            var gender = AskForGender();
            var birthday = AskForBirthday();
            var assignedWard = AskForAssignedWard(wards);

            return new Doctor(name, surname, gender, birthday, assignedWard);
        }
    }
}