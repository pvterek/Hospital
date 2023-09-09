using Hospital.Commands;
using Hospital.Commands.LoginWindow;
using Hospital.Commands.Navigation;
using Hospital.Database;
using Hospital.Utilities.UI;
using NHibernate;
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
        /// The NHibernate session factory used for database operations.
        /// </summary>
        public static readonly ISessionFactory sessionFactory = CreateSession.CreateSessionFactory();
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

            NavigationCommand.Queue(loginWindowCommand);

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
                        NavigationCommand.Queue(commandManager);
                        commandManager.Execute();
                    }
                }
                catch (Exception ex)
                {
                    UI.ShowMessage(ex.ToString());
                }
            }
        }
    }
}