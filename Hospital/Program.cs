using Hospital.Commands;
using Hospital.Commands.LoginWindow;
using Hospital.Commands.Navigation;
using Hospital.Utilities.ErrorLogger;
using Hospital.Utilities.UserInterface;

namespace Hospital
{
    /// <summary>
    /// Represents the main entry point of the Hospital application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the Hospital application. Executes the main command manager and handles any exceptions that might occur.
        /// </summary>
        private static void Main()
        {
            Logger.CheckIfExist();

            try
            {
                var commandManager = MainWindowCommand.Instance;
                
                while (true)
                {
                    if (!LoginCommand.IsLoggedIn)
                    {
                        LoginWindowCommand.Instance.Execute();
                    }
                    else
                    {
                        NavigationCommand.Queue(commandManager);
                        commandManager.Execute();
                    }
                }
            }
            catch (Exception ex)
            {
                UiHelper.HandleError(ex.Message, ex);
            }
        }
    }
}