using Hospital.Commands;
using Hospital.Commands.LoginWindow;
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
        /// Value indicating whether the user is currently logged in.
        /// </summary>
        public static bool IsLoggedIn = false;


        /// <summary>
        /// The main entry point for the Hospital application. Executes the main command manager and handles any exceptions that might occur.
        /// </summary>
        static void Main()
        {
            MainWindowCommand commandManager = MainWindowCommand.Instance;
            LoginWindowCommand loginWindowCommand = LoginWindowCommand.Instance;

            BackCommand.Queue(loginWindowCommand);

            while (true)
            {
                try
                {
                    if (!IsLoggedIn)
                    {
                        LoginWindowCommand.Instance.Execute();
                    }
                    else
                    {
                        BackCommand.Queue(commandManager);
                        commandManager.Execute();
                    }
                }
                catch (Exception ex)
                {
                    UserInterface.ShowMessage(ex.ToString());
                }
            }
        }
    }
}