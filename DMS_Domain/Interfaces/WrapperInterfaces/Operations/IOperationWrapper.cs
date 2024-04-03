using DMS_Domain.Interfaces.ServiceInterfaces;

namespace DMS_Domain.Interfaces.WrapperInterfaces.Operations
{
    public interface IOperationWrapper
    {
        void Subscribe(IOperationsEventsAdapter eventHandler);
        void Unsubscribe(IOperationsEventsAdapter eventHandler);
    }
}