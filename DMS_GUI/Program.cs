using DMS_Application.Registrations;
using DMS_Domain.Interfaces.FactoryInterfaces;
using DMS_Domain.Interfaces.HelperInterfaces;
using DMS_GUI.Helpers.Calculators;
using DMS_GUI.Helpers.Calculators.Interfaces;
using DMS_GUI.Helpers.Mappers;
using DMS_GUI.Helpers.Mappers.Interfaces;
using DMS_GUI.Services.UserNotificationServices;
using DMS_Infrastructure.Factories;
using Microsoft.Extensions.DependencyInjection;


namespace DMS_GUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();


            // After configuring services, build the ServiceProvider and run the application

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var bootstrapperFactory = new BootstrapperFactory();
            var dependencyRegistrations = new DependencyRegistrations(bootstrapperFactory);
            dependencyRegistrations.RegisterServices(services);
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            var form1 = serviceProvider.GetRequiredService<BusDMS>();
            Application.Run(form1);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<BusDMS>();
            services.AddSingleton<IBootStrapperFactory, BootstrapperFactory>();
            services.AddSingleton<IUserNotifier, UserNotifier>();
            services.AddTransient<ICalculator, Calculator>();
            services.AddTransient<IControlItemConverter, ControlItemConverter>();
        }
    }
}