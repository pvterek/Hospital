namespace Hospital.Database
{
    /// <summary>
    /// Utility class for managing the existence of a directory.
    /// </summary>
    internal static class DirectoryExist
    {
        /// <summary>
        /// The path of the directory to be managed.
        /// </summary>
        public static readonly string DirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            , "Hospital management program");

        /// <summary>
        /// Creates the directory if it does not exist.
        /// </summary>
        public static void Create()
        {
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
        }
    }
}