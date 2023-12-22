using Hospital.Entities.Interfaces;

namespace Hospital.Commands
{
    public abstract class Command : IHasIntroduceString
    {
        public string IntroduceString { get; }

        protected Command(string introduceString)
        {
            IntroduceString = introduceString;
        }

        public abstract void Execute();
    }
}