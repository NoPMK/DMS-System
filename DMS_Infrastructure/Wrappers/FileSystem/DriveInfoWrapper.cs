using DMS_Domain.Interfaces.WrapperInterfaces.FileSystem;

namespace DMS_Infrastructure.Wrappers.FileSystem
{
    public class DriveInfoWrapper : IDriveInfoWrapper
    {
        private readonly DriveInfo _driveInfo;

        public DriveInfoWrapper(string driveName)
        {
            _driveInfo = new DriveInfo(driveName);
        }

        public bool IsReady => _driveInfo.IsReady;
        public long TotalFreeSpace => _driveInfo.TotalFreeSpace;
        public long TotalSize => _driveInfo.TotalSize;
    }
}