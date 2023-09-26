using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.UserInterface;
using NHibernate;

namespace Hospital.PeopleCategories.PatientClass
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
        public static Patient CreatePatient(List<Ward> wards, ISession session)
        {
            var name = AskForValue(UiMessages.FactoryMessages.ProvideNamePrompt, UiMessages.FactoryMessages.EmptyFieldPrompt);
            var surname = AskForValue(UiMessages.FactoryMessages.ProvideSurnamePrompt, UiMessages.FactoryMessages.EmptyFieldPrompt);
            var gender = AskForGender();
            var birthday = AskForBirthday();
            var pesel = AskForPesel(session);
            var assignedWard = AssignToWard(wards);

            return new Patient(name, surname, gender, birthday, pesel, assignedWard);
        }
    }
}