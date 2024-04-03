namespace DMS_Domain.Interfaces.ServiceInterfaces
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}