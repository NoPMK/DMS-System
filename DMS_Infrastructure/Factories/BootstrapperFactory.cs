using DMS_Domain.Interfaces.BootstrapperInterfaces;
using DMS_Domain.Interfaces.FactoryInterfaces;
using DMS_Infrastructure.Bootstrappers;

namespace DMS_Infrastructure.Factories
{
    public class BootstrapperFactory : IBootStrapperFactory
    {
        public IDependencyInjectionBootstrapper CreateBootstrapper()
        {
            return new DependencyInjectionBootstrapper();
        }
    }
}