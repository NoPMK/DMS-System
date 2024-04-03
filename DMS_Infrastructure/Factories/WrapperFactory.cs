using DMS_Domain.Interfaces.FactoryInterfaces;
using DMS_Domain.Interfaces.WrapperInterfaces.FileSystem;
using DMS_Infrastructure.Wrappers.FileSystem;

namespace DMS_Infrastructure.Factories
{
    internal class WrapperFactory : IWrapperFactory
    {
        public IDriveInfoWrapper CreateDriveInfoWrapper(string driveName)
        {
            return new DriveInfoWrapper(driveName);
        }

        public IDirectoryInfoWrapper CreateDirectoryInfoWrapper(string directoryName)
        {
            return new DirectoryInfoWrapper(directoryName);
        }

        public IFileInfoWrapper CreateFileInfoWrapper(string fileName)
        {
            return new FileInfoWrapper(fileName);
        }
    }
}