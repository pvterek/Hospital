using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Hospital.Objects.DoctorObject;
using Hospital.Objects.PersonObject;
using Hospital.Objects.WardObject;
using Hospital.Utilities;

namespace Hospital.Objects.PatientObject
{
    /// <summary>
    /// Represents a patient in the hospital, inheriting the properties of a person from the <see cref="Person"/> class.
    /// </summary>
    internal class Patient : Person
    {
        //private readonly Guid _id = Guid.NewGuid();
        //public Guid Id => _id;

        private string _pesel;

        /// <summary>
        /// Gets the Patient's PESEL. 
        /// Sets the PESEL number ensuring it adheres to its defined format.
        /// </summary>
        public string Pesel
        {
            get => _pesel;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length == 11 && value.All(char.IsDigit))
                {
                    _pesel = value;
                }
                else
                {
                    throw new ArgumentException(UIMessages.FactoryMessages.InvalidPeselPrompt);
                }
            }
        }

        private Health? _healthStatus = null;

        /// <summary>
        /// Gets or sets the health status of the patient, ensuring it's a valid value.
        /// </summary>
        public Health? HealthStatus
        {
            get => _healthStatus;
            set
            {
                if (value == null || !Enum.IsDefined(typeof(Health), value))
                {
                    throw new ArgumentException(UIMessages.FactoryMessages.InvalidHealthPrompt);
                }
                else
                {
                    _healthStatus = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the ward assigned to the patient.
        /// </summary>
        public Ward AssignedWard { get; set; }

        /// <summary>
        /// Gets or sets the doctor assigned to the patient.
        /// </summary>
        public Doctor AssignedDoctor { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Patient"/> class with provided properties.
        /// </summary>
        /// <param name="name">The first name of the patient.</param>
        /// <param name="surname">The surname of the patient.</param>
        /// <param name="gender">The gender of the patient.</param>
        /// <param name="birthday">The birthday of the patient.</param>
        /// <param name="pesel">The PESEL of the patient.</param>
        /// <param name="assignedWard">The ward assigned to the patient.</param>
        public Patient(string name, string surname, Gender gender, DateTime birthday, string pesel, Ward assignedWard) : base(name, surname, gender, birthday)
        {
            Pesel = pesel;
            Birthday = birthday;
            AssignedWard = assignedWard;
            IntroduceString = string.Format(UIMessages.PatientObjectMessages.Introduce, name, surname, pesel, AssignedWard.Name);
        }
    }
}
