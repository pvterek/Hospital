using Hospital.Utilities;

namespace Hospital.Commands.LoginWindow
{
    /// <summary>
    /// Represents the command that handles the logout action in the login window.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class LogoutCommand : CompositeCommand
    {
        /// <summary>
        /// Holds the single instance of the <see cref="LogoutCommand"/> class.
        /// </summary>
        private static LogoutCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="LogoutCommand"/> class.
        /// </summary>
        internal static LogoutCommand Instance => _instance ??= new LogoutCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="LogoutCommand"/> class with the specified introduction message.
        /// </summary>
        public LogoutCommand() : base(UIMessages.LogoutCommandMessages.Introdcue) { }

        /// <summary>
        /// Executes the logout command. Sets the user status to logged out and triggers the back command.
        /// </summary>
        public override void Execute()
        {
            Program.IsLoggedIn = false;
            BackCommand.Instance.Execute();
        }
    }
}