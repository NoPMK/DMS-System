using DMS_Domain.Interfaces.FactoryInterfaces;
using DMS_Domain.Interfaces.ProviderInterfaces;
using DMS_Domain.Interfaces.WrapperInterfaces.FileSystem;

namespace DMS_BLL.Providers
{
    public class FileSystemWrapperProvider : IFileSystemWrapperProvider
    {

        private readonly IWrapperFactory _wrapperFactory;

        public FileSystemWrapperProvider(IWrapperFactory wrapperFactory)
        {
            _wrapperFactory = wrapperFactory;
        }

        public IDriveInfoWrapper CreateDriveInfo(string driveName)
        {
            var driveInfo = _wrapperFactory.CreateDriveInfoWrapper(driveName);
            return driveInfo;
        }

        public IDirectoryInfoWrapper CreateDirectoryInfo(string path)
        {
            var dirInfo = _wrapperFactory.CreateDirectoryInfoWrapper(path);
            return dirInfo;
        }

        public IFileInfoWrapper CreateFileInfo(string path)
        {
            var fileInfo = _wrapperFactory.CreateFileInfoWrapper(path);
            return fileInfo;
        }
    }
}