using Hospital.Entities.Interfaces;
using Hospital.PeopleCategories.PersonClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.UserInterface;

namespace Hospital.PeopleCategories.NurseClass
{
    public class Nurse : Person, IEmployee
    {
        public virtual int Id { get; set; }

        public virtual Ward AssignedWard { get; set; }

        public virtual string Position { get; }

        protected Nurse() { }

        public Nurse(string name, string surname, Gender gender, DateTime birthday, Ward ward)
            : base(name, surname, gender, birthday)
        {
            AssignedWard = ward;
            Position = UiMessages.NurseObjectMessages.Position;
            IntroduceString = string.Format(UiMessages.NurseObjectMessages.Introduce, name, surname, Position, AssignedWard.Name);
        }
    }
}