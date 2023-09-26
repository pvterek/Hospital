namespace Hospital.Commands.Navigation
{
    /// <summary>
    /// Represents a storage mechanism for maintaining a history of executed commands within the application.
    /// </summary>
    public class CommandStack
    {
        /// <summary>
        /// A static stack that keeps track of the history of executed composite commands.
        /// </summary>
        /// <remarks>
        /// The most recently executed command is always on the top of the stack. 
        /// This design facilitates operations like undo or back-navigation by popping commands off the stack.
        /// </remarks>
        internal static Stack<CompositeCommand> CommandHistory = new();
    }    
}