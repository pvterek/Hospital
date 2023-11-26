using Hospital.Utilities.UserInterface;

namespace Hospital.Commands.LoginWindow
{
    internal class LogoutCommand : CompositeCommand
    {
        public LogoutCommand()
            : base(UiMessages.LogoutCommandMessages.Introduce) { }

        public override void Execute()
        {
            LoginCommand.IsLoggedIn = false;
            return;
        }
    }
}