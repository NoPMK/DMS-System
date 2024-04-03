using DMS_Domain.Interfaces.WrapperInterfaces.FileSystem;

namespace DMS_Infrastructure.Wrappers.FileSystem
{
    public class DirectoryInfoWrapper : IDirectoryInfoWrapper
    {
        private readonly DirectoryInfo _directoryInfo;

        public DirectoryInfoWrapper(string directoryName)
        {
            _directoryInfo = new DirectoryInfo(directoryName);
        }

        public FileAttributes Attributes => _directoryInfo.Attributes;
        public string FullName => _directoryInfo.FullName;
        public string Name => _directoryInfo.Name;
        public DateTime LastWriteTime => _directoryInfo.LastWriteTime;

        public IEnumerable<IFileInfoWrapper> GetFiles()
        {
            return _directoryInfo.GetFiles().Select(file => new FileInfoWrapper(file.FullName));
        }

        public IEnumerable<IDirectoryInfoWrapper> GetDirectories()
        {
            return _directoryInfo.GetDirectories().Select(dir => new DirectoryInfoWrapper(dir.FullName));
        }
    }
}