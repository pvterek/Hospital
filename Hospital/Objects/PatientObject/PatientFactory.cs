using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.PersonObject;
using Hospital.Objects.WardObject;
using Hospital.Utilities.UI.UserInterface;
using NHibernate;

namespace Hospital.Objects.PatientObject
{
    /// <summary>
    /// Represents a factory for creating <see cref="Patient"/> objects. 
    /// It extends the base <see cref="FactoryMethods"/> to include methods specific to the creation of patients.
    /// </summary>
    internal class PatientFactory : FactoryMethods
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Patient"/> class by gathering all required details.
        /// </summary>
        /// <returns>A new <see cref="Patient"/> object populated with the provided details.</returns>
        public static Patient? CreatePatient(ISession session)
        {
            string name = AskForValue(UIMessages.FactoryMessages.ProvideNamePrompt, UIMessages.FactoryMessages.EmptyFieldPrompt);
            string surname = AskForValue(UIMessages.FactoryMessages.ProvideSurnamePrompt, UIMessages.FactoryMessages.EmptyFieldPrompt);
            Gender gender = AskForGender();
            DateTime birthday = AskForBirthday();
            string pesel = AskForPesel();
            Ward assignedWard = AssignToWard(session);

            if(assignedWard == null) 
            {
                return null;
            }

            return new Patient(name, surname, gender, birthday, pesel, assignedWard);
        }
    }
}