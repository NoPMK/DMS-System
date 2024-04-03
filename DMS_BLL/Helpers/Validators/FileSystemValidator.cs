using DMS_Domain.Interfaces.HelperInterfaces;

namespace DMS_BLL.Helpers.Validators
{
    public class FileSystemValidator : IFileSystemValidator
    {
        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public bool CanAccessDirectory(string path)
        {
            try
            {
                var accessTest = Directory.GetDirectories(path);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }
    }
}