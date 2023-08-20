using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.PersonObject;
using Hospital.Objects.WardObject;
using Hospital.Objects.PatientObject;
using Hospital.Utilities;

namespace Hospital.Objects.DoctorObject
{
    /// <summary>
    /// Represents a factory responsible for creating instances of the <see cref="Doctor"/> class.
    /// This factory inherits from the <see cref="PersonFactory"/> class and implements the <see cref="IEmployeeFactory"/> interface.
    /// </summary>
    internal class DoctorFactory : PersonFactory, IEmployeeFactory
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Doctor"/> class with properties derived from user input.
        /// </summary>
        /// <returns>A new <see cref="Doctor"/> object with properties filled out based on user input.</returns>
        public IEmployee CreateEmployee()
        {
            string name = AskForValue(UIMessages.FactoryMessages.ProvideNamePrompt, UIMessages.FactoryMessages.EmptyFieldPrompt);
            string surname = AskForValue(UIMessages.FactoryMessages.ProvideSurnamePrompt, UIMessages.FactoryMessages.EmptyFieldPrompt);
            Gender gender = AskForGender();
            DateTime birthday = AskForBirthday();
            Ward ward = AskForAssignedWard();

            return new Doctor(name, surname, gender, birthday, ward);
        }
    }
}
