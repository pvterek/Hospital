using Hospital.Commands;
using Hospital.Utilities;
using System;

namespace Hospital
{
    /// <summary>
    /// Represents the main entry point of the Hospital application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Maintains a history of executed commands in the application, allowing for potential undo navigation.
        /// </summary>
        public static Stack<CompositeCommand> commandHistory = new();

        /// <summary>
        /// The main entry point for the Hospital application. Executes the main command manager and handles any exceptions that might occur.
        /// </summary>
        static void Main()
        {
            MainWindowCommand commandManager = MainWindowCommand.Instance;

            while (true)
            {
                try
                {
                    commandHistory.Push(commandManager);
                    commandManager.Execute();
                }
                catch (Exception ex)
                {
                    UserInterface.ShowMessage(ex.ToString());
                }
            }
        }
    }
}
