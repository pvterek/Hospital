using Hospital.PeopleCategories.DoctorClass;
using Hospital.PeopleCategories.PersonClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.UserInterface;

namespace Hospital.PeopleCategories.PatientClass
{
    public class Patient : Person
    {
        public virtual int Id { get; set; }

        public virtual string Pesel { get; set; }

        public virtual Health? HealthStatus { get; set; }

        public virtual Ward AssignedWard { get; set; }

        public virtual Doctor? AssignedDoctor { get; set; }

        protected Patient() { }

        public Patient(string name, string surname, Gender gender, DateTime birthday, string pesel, Ward assignedWard)
            : base(name, surname, gender, birthday)
        {
            Pesel = pesel;
            AssignedWard = assignedWard;
            IntroduceString = string.Format(UiMessages.PatientObjectMessages.Introduce, name, surname, pesel, AssignedWard.Name);
        }
    }
}