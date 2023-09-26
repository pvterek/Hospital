using Hospital.Database;

namespace Hospital.Utilities.ErrorLogger
{
    /// <summary>
    /// Provides functionality to log error messages to a designated file.
    /// </summary>
    /// <remarks>
    /// This logger writes logs to a file named 'log.txt' within a specified directory.
    /// It ensures that the file exists before writing and uses a StreamWriter to append messages to the file.
    /// </remarks>
    internal class Logger
    {
        /// <summary>
        /// The complete path to the log file.
        /// </summary>
        private static readonly string FilePath = DirectoryExist.DirectoryPath + "\\log.txt";

        /// <summary>
        /// StreamWriter instance to facilitate writing to the log file.
        /// </summary>
        private static readonly StreamWriter _sw = new(FilePath, true);

        /// <summary>
        /// Checks if the log file exists. If it doesn't, the method creates one.
        /// </summary>
        public static void CheckIfExist()
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();
            }
        }

        /// <summary>
        /// Writes a provided error message to the log file with a timestamp.
        /// </summary>
        /// <param name="ex">The error message to be logged.</param>
        public static void WriteLog(string ex)
        {
            _sw.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + " | " + ex);
            _sw.Flush();
        }
    }
}