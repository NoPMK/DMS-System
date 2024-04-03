using DMS_Domain.Interfaces.BootstrapperInterfaces;

namespace DMS_Domain.Interfaces.FactoryInterfaces
{
    public interface IBootStrapperFactory
    {
        IDependencyInjectionBootstrapper CreateBootstrapper();
    }
}