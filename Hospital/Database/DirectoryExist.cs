using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Database
{
    /// <summary>
    /// Utility class for managing the existence of a directory.
    /// </summary>
    internal class DirectoryExist
    {
        /// <summary>
        /// The path of the directory to be managed.
        /// </summary>
        public static string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Hospital management program");

        /// <summary>
        /// Creates the directory if it does not exist.
        /// </summary>
        public static void Create()
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}