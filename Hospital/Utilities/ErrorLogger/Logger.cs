using Hospital.Database;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Utilities.ErrorLogger
{
    internal class Logger : ILogger
    {
        public const string fileName = "log.txt";
        public static readonly string filePath = DirectoryExist.DirectoryPath + $"\\{fileName}";
        private readonly IMenuHandler _menuHandler;
        private readonly StreamWriter _streamWriter;

        public Logger(
            IMenuHandler menuHandler,
            StreamWriter streamWriter) 
        {
            _menuHandler = menuHandler;
            _streamWriter = streamWriter;

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        public void WriteLog(string ex)
        {
            _streamWriter.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + " | " + ex);
            _streamWriter.Flush();
        }

        public void HandleError(string message, Exception ex)
        {
            _menuHandler.ShowMessage(message);
            WriteLog(ex.ToString());
        }

        public void HandleError(Exception ex)
        {
            WriteLog(ex.ToString());
        }
    }
}