using DMS_Domain.Interfaces.ServiceInterfaces;
using DMS_Domain.Interfaces.WrapperInterfaces.Operations;

namespace DMS_Infrastructure.Wrappers.Operations
{
    public abstract class OperationWrapperBase : IOperationWrapper
    {
        public abstract void Subscribe(IOperationsEventsAdapter eventHandler);
        public abstract void Unsubscribe(IOperationsEventsAdapter eventHandler);
    }
}