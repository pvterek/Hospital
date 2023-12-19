//using Hospital.Utilities;

//namespace Hospital.Test.UtilitiesTests
//{
//    public class FileServiceTest
//    {
//        private readonly FileService _fileService;
//
//        public FileServiceTest()
//        {
//            _fileService = new FileService();
//        }
//
//        [Fact]
//        public void CreateDirectory_DirectoryDoesNotExist_CreatesDirectory()
//        {
//            string directoryPath = FileService.DirectoryPath;
//            if (Directory.Exists(directoryPath))
//            {
//                Directory.Delete(directoryPath, true);
//            }
//
//            _fileService.CreateDirectory();
//
//            Assert.True(Directory.Exists(directoryPath));
//
//            Directory.Delete(directoryPath);
//        }
//
//        [Fact]
//        public void CreateLogFile_FileDoesNotExist_CreatesFile()
//        {
//            string logFilePath = FileService.LogFilePath;
//            if (File.Exists(logFilePath))
//            {
//                File.Delete(logFilePath);
//            }
//
//            _fileService.CreateLogFile();
//
//            Assert.True(File.Exists(logFilePath));
//
//            File.Delete(logFilePath);
//        }
//
//        [Fact]
//        public void CreateLogFile_FileExists_DoesNotThrowException()
//        {
//            string logFilePath = FileService.LogFilePath;
//            if (!File.Exists(logFilePath))
//            {
//                File.Create(logFilePath).Close();
//            }
//
//            var exception = Record.Exception(() => _fileService.CreateLogFile());
//            Assert.Null(exception);
//
//            File.Delete(logFilePath);
//        }
//
//        [Fact]
//        public void CreateDirectory_DirectoryExists_DoesNotThrowException()
//        {
//            string directoryPath = FileService.DirectoryPath;
//            if (Directory.Exists(directoryPath))
//            {
//                Directory.Delete(directoryPath, true);
//            }
//        
//            var exception = Record.Exception(() => _fileService.CreateDirectory());
//            Assert.Null(exception);
//        
//            File.Delete(directoryPath);
//        }
//    }
//}