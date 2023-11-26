using Hospital.Entities.Interfaces;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.PersonClass;
using Hospital.Utilities.UserInterface;

namespace Hospital.PeopleCategories.WardClass
{
    public class Ward : IHasIntroduceString, IIdentifier
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual int Capacity { get; set; }

        public virtual IList<Patient> AssignedPatients { get; set; }

        public virtual int PatientsNumber => AssignedPatients?.Count ?? 0;

        public virtual IList<Person> AssignedEmployees { get; set; }

        public virtual string IntroduceString { get; set; }

        protected Ward() { }

        public Ward(string name, int capacity, IList<Patient> assignedPatients, IList<Person> assignedEmployees)
        {
            Name = name;
            Capacity = capacity;
            AssignedPatients = assignedPatients;
            AssignedEmployees = assignedEmployees;
            IntroduceString = string.Format(UiMessages.WardObjectMessages.Introduce, name, PatientsNumber, Capacity);
        }
    }
}