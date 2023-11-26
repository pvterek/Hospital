using Hospital.Entities.Interfaces;

namespace Hospital.Commands
{
    internal abstract class CompositeCommand : IHasIntroduceString
    {
        public string IntroduceString { get; }

        protected CompositeCommand(string introduceString)
        {
            IntroduceString = introduceString;
        }

        public abstract void Execute();
    }
}