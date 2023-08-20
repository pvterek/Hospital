using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.PersonObject;
using Hospital.Objects.WardObject;
using Hospital.Utilities;

namespace Hospital.Objects.NurseObject
{
    /// <summary>
    /// Represents a nurse working in the hospital. Inherits from the <see cref="Person"/> class and implements the <see cref="IEmployee"/> interface.
    /// </summary>
    internal class Nurse : Person, IEmployee
    {
        /// <summary>
        /// Gets the ward assigned to the nurse.
        /// </summary>
        internal Ward AssignedWard { get; private set; }

        /// <summary>
        /// Gets the position of the nurse.
        /// </summary>
        public string Position => "Nurse";

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
            IntroduceString = $"{Name} {Surname} - {Position} at {AssignedWard.Name} Ward";
        }

        /// <summary>
        /// Assigns the nurse to a new ward.
        /// </summary>
        /// <param name="newWard">The ward to which the nurse is to be assigned.</param>
        /// <exception cref="ArgumentException">Thrown when the provided ward is null.</exception>
        public void AssignToWard(Ward newWard)
        {
            if (newWard != null)
            {
                AssignedWard = newWard;
            }
            else
            {
                throw new ArgumentException(UIMessages.WardObjectMessages.NullPrompt);
            }
        }
    }
}
