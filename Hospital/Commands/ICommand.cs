namespace Hospital.Commands
{
    /// <summary>
    /// Defines a contract for command objects that can be executed.
    /// </summary>
    internal interface ICommand
    {
        /// <summary>
        /// Executes the command logic. Derived classes must implement this method to provide actual command execution logic.
        /// </summary>
        void Execute();
    }
}