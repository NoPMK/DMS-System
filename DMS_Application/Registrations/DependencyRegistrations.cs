using DMS_Domain.Interfaces.FactoryInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DMS_Application.Registrations
{
    public class DependencyRegistrations
    {
        private readonly IBootStrapperFactory _bootStrapperFactory;

        public DependencyRegistrations(IBootStrapperFactory bootStrapperFactory)
        {
            _bootStrapperFactory = bootStrapperFactory;
        }

        public void RegisterServices(IServiceCollection services)
        {
            var bootstrapper = _bootStrapperFactory.CreateBootstrapper();
            bootstrapper.RegisterServices(services);
        }
    }
}