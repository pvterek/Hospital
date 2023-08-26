using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Commands.ManagePatients;
using Hospital.Objects.PatientObject;
using Hospital.Utilities;

namespace Hospital.Objects.WardObject
{
    /// <summary>
    /// Represents a hospital ward with a specified capacity, a list of patients, and a unique name.
    /// </summary>
    internal class Ward : IHasIntroduceString
    {
        /// <summary>
        /// Gets or sets the list of patients in the ward.
        /// </summary>
        internal List<Patient> Patients { get; set; }

        /// <summary>
        /// Represents the number of patients currently in the ward.
        /// </summary>
        internal int PatientsNumber = 0;

        /// <summary>
        /// Gets or sets the string that introduces the ward.
        /// </summary>
        public string IntroduceString { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of patients the ward can hold.
        /// </summary>
        internal int Capacity { get; set; }

        /// <summary>
        /// Gets or sets the name of the ward.
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ward"/> class with a specified name and capacity.
        /// </summary>
        /// <param name="name">The name of the ward.</param>
        /// <param name="capacity">The maximum number of patients the ward can hold.</param>
        public Ward(string name, int capacity) 
        { 
            Name = name;
            Capacity = capacity;
            IntroduceString = string.Format(UIMessages.WardObjectMessages.Introduce, name, PatientsNumber, Capacity);
        }
    }
}