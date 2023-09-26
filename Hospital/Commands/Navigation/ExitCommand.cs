using Hospital.Utilities.UserInterface;

namespace Hospital.Commands.Navigation
{
    /// <summary>
    /// Represents the command to exit the application.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class ExitCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="ExitCommand"/> class.
        /// </summary>
        private static ExitCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="ExitCommand"/> class.
        /// </summary>
        internal static ExitCommand Instance => _instance ??= new ExitCommand(UiMessages.ExitCommandMessages.Introduce);

        /// <summary>
        /// Initializes a new instance of the <see cref="ExitCommand"/> class with a specified introduce string.
        /// </summary>
        /// <param name="introduceString">The message or string that introduces this command to the user.</param>
        private ExitCommand(string introduceString) : base(introduceString) { }

        /// <summary>
        /// Executes the logic to exit the application.
        /// </summary>
        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
