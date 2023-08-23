using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Utilities;

namespace Hospital.Commands
{
    /// <summary>
    /// Represents the command used to navigate back to the previous command in the application.
    /// </summary>
    internal class BackCommand : CompositeCommand
    {
        private static BackCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="BackCommand"/> class.
        /// </summary>
        internal static BackCommand Instance => _instance ??= new BackCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="BackCommand"/> class with the specified introduction message.
        /// </summary>
        private BackCommand() : base(UIMessages.BackCommandMessages.Introduce) { }

        /// <summary>
        /// Executes the "Back" command, which navigates back to the previous command in the application's command history.
        /// </summary>
        public override void Execute()
        {
            Program.commandHistory.Pop();
            Program.commandHistory.Peek().Execute();
        }

        /// <summary>
        /// Adds a command to the command history and executes it, ensuring that the "Back" command itself is not added to the history.
        /// </summary>
        /// <param name="command">The command to be queued and executed.</param>
        public static void Queue(CompositeCommand command)
        {
            if (command != Instance)
            {
                Program.commandHistory.Push(command);
            }

            command.Execute();
        }
    }
}
