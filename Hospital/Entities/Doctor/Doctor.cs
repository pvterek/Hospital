using Hospital.Entities.Interfaces;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.PersonClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.UserInterface;

namespace Hospital.PeopleCategories.DoctorClass
{
    public class Doctor : Person, IEmployee
    {
        public virtual int Id { get; set; }

        public virtual Ward AssignedWard { get; set; }

        public virtual string Position { get; }

        public virtual IList<Patient> AssignedPatients { get; set; }

        protected Doctor() { }

        public Doctor(string name, string surname, Gender gender, DateTime birthday, Ward ward, IList<Patient> assignedPatients)
            : base(name, surname, gender, birthday)
        {
            AssignedWard = ward;
            Position = UiMessages.DoctorObjectMessages.Position;
            AssignedPatients = assignedPatients;
            IntroduceString = string.Format(UiMessages.DoctorObjectMessages.Introduce, name, surname, Position, AssignedWard.Name);
        }
    }
}