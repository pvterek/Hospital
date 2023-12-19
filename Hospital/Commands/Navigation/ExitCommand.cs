using Hospital.Utilities.UserInterface;

namespace Hospital.Commands.Navigation
{
    public class ExitCommand : CompositeCommand
    {
        public ExitCommand() : base(UiMessages.ExitCommandMessages.Introduce) { }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
