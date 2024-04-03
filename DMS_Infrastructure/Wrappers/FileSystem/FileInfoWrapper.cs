using DMS_Domain.Interfaces.WrapperInterfaces.FileSystem;

namespace DMS_Infrastructure.Wrappers.FileSystem
{
    public class FileInfoWrapper : IFileInfoWrapper
    {
        private readonly FileInfo _fileInfo;

        public FileInfoWrapper(string fileName)
        {
            _fileInfo = new FileInfo(fileName);
        }

        public FileAttributes Attributes => _fileInfo.Attributes;
        public string Name => _fileInfo.Name;
        public string FullName => _fileInfo.FullName;
        public long Length => _fileInfo.Length;
        public string Extension => _fileInfo.Extension;
        public DateTime LastWriteTime => _fileInfo.LastWriteTime;
    }
}