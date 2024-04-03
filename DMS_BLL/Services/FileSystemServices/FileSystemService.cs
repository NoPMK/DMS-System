using DMS_Domain.Interfaces.HelperInterfaces;
using DMS_Domain.Interfaces.ProviderInterfaces;
using DMS_Domain.Interfaces.ServiceInterfaces;
using DMS_Domain.Interfaces.WrapperInterfaces.FileSystem;

namespace DMS_BLL.Services.FileSystemServices
{
    public class FileSystemService : IFileSystemService
    {
        private readonly IFileSystemValidator _fileSystemValidator;
        private readonly IFileSystemWrapperProvider _fileSystemWrapperProvider;

        public FileSystemService(IFileSystemValidator fileSystemValidator, IFileSystemWrapperProvider fileSystemWrapperProvider)
        {
            _fileSystemValidator = fileSystemValidator;
            _fileSystemWrapperProvider = fileSystemWrapperProvider;
        }

        public IEnumerable<IFileInfoWrapper> GetFiles(string folderPath, bool includeHidden)
        {
            var dirInfo = _fileSystemWrapperProvider.CreateDirectoryInfo(folderPath);
            return dirInfo.GetFiles()
                .Where(f => includeHidden || (f.Attributes & FileAttributes.Hidden) == 0);
        }

        public IEnumerable<IDirectoryInfoWrapper> GetDirectories(string folderPath, bool includeHidden)
        {
            var dirInfo = _fileSystemWrapperProvider.CreateDirectoryInfo(folderPath);
            return dirInfo.GetDirectories()
                .Where(di => includeHidden || (di.Attributes & FileAttributes.Hidden) == 0);
        }

        public (IEnumerable<IDirectoryInfoWrapper> subDirectories, IEnumerable<string> restrictedDirectories) GetSubDirectories(string path, bool showHiddenItems)
        {
            var dirInfo = _fileSystemWrapperProvider.CreateDirectoryInfo(path);
            var subDirs = new List<IDirectoryInfoWrapper>();
            var restrictedItems = new List<string>();

            foreach (var dir in dirInfo.GetDirectories())
            {
                var isHidden = (dir.Attributes & FileAttributes.Hidden) != 0;

                if (isHidden && !showHiddenItems)
                {
                    continue;
                }
                if (_fileSystemValidator.CanAccessDirectory(dir.FullName))
                {
                    subDirs.Add(dir);
                }
                else
                {
                    restrictedItems.Add(dir.Name);
                }
            }

            return (subDirs, restrictedItems);
        }
    }
}