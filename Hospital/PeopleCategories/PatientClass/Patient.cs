using Hospital.PeopleCategories.DoctorClass;
using Hospital.PeopleCategories.PersonClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.UserInterface;

namespace Hospital.PeopleCategories.PatientClass
{
    /// <summary>
    /// Represents a patient in the hospital, inheriting the properties of a person from the <see cref="Person"/> class.
    /// </summary>
    public class Patient : Person
    {
        /// <summary>
        /// Gets the Patient's PESEL. 
        /// Sets the PESEL number ensuring it adheres to its defined format.
        /// </summary>
        public virtual string Pesel { get; }

        /// <summary>
        /// Gets or sets the health status of the patient.
        /// </summary>
        public virtual Health? HealthStatus { get; set; }

        /// <summary>
        /// Gets or sets the ward assigned to the patient.
        /// </summary>
        public virtual Ward AssignedWard { get; }

        /// <summary>
        /// Gets or sets the doctor assigned to the patient.
        /// </summary>
        public virtual Doctor? AssignedDoctor { get; set; }

        /// <summary>
        /// Constructor needed for NHibernate.
        /// </summary>
        public Patient() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Patient"/> class with provided properties.
        /// </summary>
        /// <param name="name">The first name of the patient.</param>
        /// <param name="surname">The surname of the patient.</param>
        /// <param name="gender">The gender of the patient.</param>
        /// <param name="birthday">The birthday of the patient.</param>
        /// <param name="pesel">The PESEL of the patient.</param>
        /// <param name="assignedWard">The ward assigned to the patient.</param>
        public Patient(string name, string surname, Gender gender, DateTime birthday, string pesel, Ward assignedWard)
            : base(name, surname, gender, birthday)
        {
            Pesel = pesel;
            Birthday = birthday;
            AssignedWard = assignedWard;
            IntroduceString = string.Format(UiMessages.PatientObjectMessages.Introduce, name, surname, pesel, AssignedWard.Name);
        }
    }
}