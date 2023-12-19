using Autofac;
using Hospital.Commands;
using Hospital.Commands.LoginWindow;
using Hospital.Commands.Navigation;
using Hospital.Utilities;
using Hospital.Utilities.ErrorLogger;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital
{
    internal static class Program
    {
        public static IContainer Container;

        private static void Main()
        {
            InitializeApplication();
            ExecuteApplication();
        }

        private static void InitializeApplication()
        {
            FileService fileService = new();
            fileService.CreateDirectory();
            fileService.CreateLogFile();

            AutofacConfig config = new();
            Container = config.ConfigureContainer();
        }

        private static void ExecuteApplication()
        {
            var logger = Container.Resolve<ILogger>();
            var mainWindow = Container.Resolve<MainWindowCommand>();
            var loginWindow = Container.Resolve<LoginWindowCommand>();
            var loginCommand = Container.Resolve<LoginCommand>();
            var mainQueue = Container.Resolve<INavigationService>();
            var menuHandler = Container.Resolve<IMenuHandler>();
            mainQueue.Queue(loginWindow);
            mainQueue.Queue(mainWindow);

            while (true)
            {
                try
                {
                    if (!loginCommand.IsLoggedIn)
                    {
                        loginWindow.Execute();
                    }
                    else
                    {
                        mainQueue.GetCurrentCommand().Execute();
                    }
                }
                catch (Exception ex)
                {
                    menuHandler.ShowMessage(ex.Message);
                    logger.WriteLog(ex);
                }
            }
        }
    }
}