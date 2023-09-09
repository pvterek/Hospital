using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.PersonObject;
using Hospital.Objects.WardObject;
using Hospital.Objects.PatientObject;
using NHibernate;
using Hospital.Objects.Employee;
using Hospital.Utilities.UI.UserInterface;

namespace Hospital.Objects.DoctorObject
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
        public IEmployee? CreateEmployee()
        {
            using var session = Program.sessionFactory.OpenSession();

            string name = AskForValue(UIMessages.FactoryMessages.ProvideNamePrompt, UIMessages.FactoryMessages.EmptyFieldPrompt);
            string surname = AskForValue(UIMessages.FactoryMessages.ProvideSurnamePrompt, UIMessages.FactoryMessages.EmptyFieldPrompt);
            Gender gender = AskForGender();
            DateTime birthday = AskForBirthday();
            Ward? assignedWard = AskForAssignedWard(session);

            if (assignedWard == null)
            {
                return null;
            }

            return new Doctor(name, surname, gender, birthday, assignedWard);
        }
    }
}