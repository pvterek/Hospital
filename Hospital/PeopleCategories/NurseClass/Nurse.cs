using Hospital.PeopleCategories.Employee;
using Hospital.PeopleCategories.PersonClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.UserInterface;

namespace Hospital.PeopleCategories.NurseClass
{
    /// <summary>
    /// Represents a nurse working in the hospital. Inherits from the <see cref="Person"/> class and implements the <see cref="IEmployee"/> interface.
    /// </summary>
    public class Nurse : Person, IEmployee
    {
        /// <summary>
        /// Gets the ward assigned to the nurse.
        /// </summary>
        public virtual Ward AssignedWard { get; }

        /// <summary>
        /// Gets the position of the nurse.
        /// </summary>
        public static string Position => UiMessages.NurseObjectMessages.Position;

        /// <summary>
        /// Constructor needed for NHibernate.
        /// </summary>
        protected Nurse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Nurse"/> class with the specified details.
        /// </summary>
        /// <param name="name">The name of the nurse.</param>
        /// <param name="surname">The surname of the nurse.</param>
        /// <param name="gender">The gender of the nurse.</param>
        /// <param name="birthday">The birth date of the nurse.</param>
        /// <param name="ward">The ward assigned to the nurse.</param>
        public Nurse(string name, string surname, Gender gender, DateTime birthday, Ward ward) : base(name, surname, gender, birthday)
        {
            AssignedWard = ward;
            IntroduceString = string.Format(UiMessages.NurseObjectMessages.Introduce, name, surname, Position, AssignedWard.Name);
        }
    }
}