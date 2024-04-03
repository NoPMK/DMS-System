namespace DMS_Domain.Interfaces.WrapperInterfaces.FileSystem
{
    public interface IDriveInfoWrapper
    {
        bool IsReady { get; }
        long TotalFreeSpace { get; }
        long TotalSize { get; }
    }
}