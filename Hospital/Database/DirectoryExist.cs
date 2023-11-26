namespace Hospital.Database
{
    internal static class DirectoryExist
    {
        private const string FolderName = "Hospital management program";
        
        public static readonly string DirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            , FolderName);

        public static void Create()
        {
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
        }
    }
}