using DMS_Domain.Interfaces.HelperInterfaces;
using DMS_Domain.Interfaces.ProviderInterfaces;
using DMS_Domain.Interfaces.ServiceInterfaces;
using System.Text;

namespace DMS_BLL.Services.DrivePanelServices
{
    public class DriveInfoService : IDriveInfoService
    {
        private readonly IFormatter _formatter;
        private readonly IFileSystemWrapperProvider _fileSystemFactory;

        public DriveInfoService(IFormatter formatter, IFileSystemWrapperProvider fileSystemFactory)
        {
            _formatter = formatter;
            _fileSystemFactory = fileSystemFactory;
        }

        public string GetDriveDetails(string driveName)
        {
            var driveInfo = _fileSystemFactory.CreateDriveInfo(driveName);
            var sb = new StringBuilder();

            if (driveInfo.IsReady)
            {
                sb.AppendLine($"{_formatter.FormatBytes(driveInfo.TotalFreeSpace)} free of {_formatter.FormatBytes(driveInfo.TotalSize)}");
            }
            else
            {
                sb.AppendLine("Drive not ready.");
            }

            return sb.ToString();
        }

        public IEnumerable<DriveInfo> QueryReadyDrives()
        {
            return DriveInfo.GetDrives().Where(drive => drive.IsReady);
        }

        public DriveInfo GetDriveByPath(string path)
        {
            return DriveInfo.GetDrives().FirstOrDefault(d => d.Name == path);
        }
    }
}