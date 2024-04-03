namespace DMS_Domain.Interfaces.ServiceInterfaces
{
    public interface IDriveInfoService
    {
        DriveInfo GetDriveByPath(string path);
        string GetDriveDetails(string driveName);
        IEnumerable<DriveInfo> QueryReadyDrives();
    }
}