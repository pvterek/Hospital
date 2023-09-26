using Hospital.PeopleCategories.Employee;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.PersonClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.UserInterface;

namespace Hospital.PeopleCategories.DoctorClass
{
    /// <summary>
    /// Represents a doctor working in the hospital. Inherits from the <see cref="Person"/> class and implements the <see cref="IEmployee"/> interface.
    /// </summary>
    public class Doctor : Person, IEmployee
    {
        /// <summary>
        /// Gets the ward assigned to the doctor.
        /// </summary>
        public virtual Ward AssignedWard { get; }

        /// <summary>
        /// Gets the position of the doctor.
        /// </summary>
        public static string Position => UiMessages.DoctorObjectMessages.Position;

        //public virtual IList<Ward> AssignedWards { get; set; } = new List<Ward>();

        /// <summary>
        /// List of patients assigned to the doctor.
        /// </summary>
        public virtual IList<Patient> Patients { get; } = new List<Patient>();

        /// <summary>
        /// Constructor needed for NHibernate.
        /// </summary>
        protected Doctor() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Doctor"/> class with the provided parameters.
        /// </summary>
        /// <param name="name">The first name of the doctor.</param>
        /// <param name="surname">The last name of the doctor.</param>
        /// <param name="gender">The gender of the doctor.</param>
        /// <param name="birthday">The birthdate of the doctor.</param>
        /// <param name="ward">The ward to which the doctor is initially assigned.</param>
        public Doctor(string name, string surname, Gender gender, DateTime birthday, Ward ward)
            : base(name, surname, gender, birthday)
        {
            AssignedWard = ward;
            IntroduceString = string.Format(UiMessages.DoctorObjectMessages.Introduce, name, surname, Position, AssignedWard.Name);
        }
    }
}