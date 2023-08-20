using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.PersonObject;
using Hospital.Objects.WardObject;
using Hospital.Utilities;

namespace Hospital.Objects.PatientObject
{
    /// <summary>
    /// Represents a factory for creating <see cref="Patient"/> instances. 
    /// It extends the base <see cref="PersonFactory"/> to include methods specific to the creation of patients.
    /// </summary>
    internal class PatientFactory : PersonFactory
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Patient"/> class by gathering all required details.
        /// </summary>
        /// <returns>A new <see cref="Patient"/> instance populated with the provided details.</returns>
        public static Patient CreatePatient()
        {
            Console.Clear();

            string name = AskForValue(UIMessages.FactoryMessages.ProvideNamePrompt, UIMessages.FactoryMessages.EmptyFieldPrompt);
            string surname = AskForValue(UIMessages.FactoryMessages.ProvideSurnamePrompt, UIMessages.FactoryMessages.EmptyFieldPrompt);
            Gender gender = AskForGender();
            string pesel = AskForPesel();
            DateTime birthday = AskForBirthday();
            Ward assignedWard = AskForAssignedWard();

            return new Patient(name, surname, gender, birthday, pesel, assignedWard);
        }
    }
}
