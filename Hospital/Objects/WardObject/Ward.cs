using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Commands.ManagePatients;
using Hospital.Objects.DoctorObject;
using Hospital.Objects.Employee;
using Hospital.Objects.PatientObject;
using Hospital.Objects.PersonObject;
using Hospital.Objects.UserObject;
using Hospital.Utilities.UI.UserInterface;

namespace Hospital.Objects.WardObject
{
    /// <summary>
    /// Represents a hospital ward with a specified capacity, a list of patients, and a unique name.
    /// </summary>
    public class Ward : IHasIntroduceString
    {
        /// <summary>
        /// Gets or sets the unique identifier for the ward.
        /// </summary>
        public virtual int Id { get; protected set; }

        /// <summary>
        /// Gets or sets the name of the ward.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the capacity of the ward.
        /// </summary>
        public virtual int Capacity { get; set; }

        /// <summary>
        /// Gets or sets the list of patients assigned to the ward.
        /// </summary>
        public virtual IList<Patient> AssignedPatients { get; set; }

        /// <summary>
        /// Gets the number of assigned patients in the ward.
        /// </summary>
        public virtual int PatientsNumber => AssignedPatients?.Count ?? 0;

        /// <summary>
        /// Gets or sets the list of employees assigned to the ward.
        /// </summary>
        public virtual IList<Person> AssignedEmployees { get; set; }

        //public virtual IList<User> AssignedUsers { get; set; }

        /// <summary>
        /// Gets or sets the introduce string for the ward.
        /// </summary>
        public virtual string IntroduceString { get; set; }

        /// <summary>
        /// Constructor needed for NHibernate.
        /// </summary>
        protected Ward() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ward"/> class with provided properties.
        /// </summary>
        /// <param name="name">The name of the ward.</param>
        /// <param name="capacity">The capacity of the ward.</param>
        public Ward(string name, int capacity)
        {
            AssignedPatients = new List<Patient>();
            AssignedEmployees = new List<Person>();
            //AssignedUsers = new List<User>();

            Name = name;
            Capacity = capacity;
            IntroduceString = string.Format(UIMessages.WardObjectMessages.Introduce, name, PatientsNumber, Capacity);
        }
    }
}