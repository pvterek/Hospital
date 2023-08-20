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
        /// Provides access to the main command manager used for application navigation and command execution.
        /// </summary>
        internal static MainWindowCommand commandManager = MainWindowCommand.Instance;

        /// <summary>
        /// The main entry point for the Hospital application.
        /// </summary>
        /// <param name="args">The command-line arguments passed to the application.</param>
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
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
