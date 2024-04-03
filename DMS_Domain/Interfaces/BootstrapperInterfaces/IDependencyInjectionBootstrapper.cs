using Microsoft.Extensions.DependencyInjection;

namespace DMS_Domain.Interfaces.BootstrapperInterfaces
{
    public interface IDependencyInjectionBootstrapper
    {
        void RegisterServices(IServiceCollection services);
    }
}