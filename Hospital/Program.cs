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
            AutofacConfig config = new();

            fileService.CreateDirectory();
            fileService.CreateLogFile();

            Container = config.ConfigureContainer();
        }

        private static void ExecuteApplication()
        {
            var loginCommand = Container.Resolve<LoginCommand>();
            var loginWindow = Container.Resolve<LoginWindowCommand>();
            var mainWindow = Container.Resolve<MainWindowCommand>();
            var logger = Container.Resolve<ILogger>();
            var menuHandler = Container.Resolve<IMenuHandler>();
            var mainQueue = Container.Resolve<INavigationService>();

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