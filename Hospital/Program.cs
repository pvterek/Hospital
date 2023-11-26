using Autofac;
using Hospital.Commands;
using Hospital.Commands.LoginWindow;
using Hospital.Commands.Navigation;
using Hospital.Utilities.ErrorLogger;

namespace Hospital
{
    internal static class Program
    {
        private static IContainer Container;

        private static void Main()
        {
            InitializeApplication();
            ExecuteApplication();
        }

        private static void InitializeApplication()
        {
            AutofacConfig config = new();
            Container = config.ConfigureContainer();
        }

        private static void ExecuteApplication()
        {
            var logger = Container.Resolve<ILogger>();
            var mainWindow = Container.Resolve<MainWindowCommand>();
            var loginWindow = Container.Resolve<LoginWindowCommand>();
            var mainQueue = Container.Resolve<INavigationService>();
            mainQueue.Queue(loginWindow);
            mainQueue.Queue(mainWindow);

            while (true)
            {
                try
                {
                    if (!LoginCommand.IsLoggedIn)
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
                    logger.HandleError(ex.Message, ex);
                }
            }
        }
    }
}