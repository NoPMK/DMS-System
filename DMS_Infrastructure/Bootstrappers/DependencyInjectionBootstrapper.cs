using DMS_BLL.Helpers.Formatters;
using DMS_BLL.Helpers.Validators;
using DMS_BLL.Providers;
using DMS_BLL.Services.DrivePanelServices;
using DMS_BLL.Services.ErrorHandlerServices;
using DMS_BLL.Services.FileSystemServices;
using DMS_BLL.Services.ListViewServices;
using DMS_BLL.Services.LoggerServices;
using DMS_BLL.Services.SetupServices;
using DMS_BLL.Services.TextServices;
using DMS_BLL.Services.TreeNodeServices;
using DMS_BLL.Strategies.PopulationStrategies;
using DMS_Domain.Interfaces.BootstrapperInterfaces;
using DMS_Domain.Interfaces.FactoryInterfaces;
using DMS_Domain.Interfaces.HelperInterfaces;
using DMS_Domain.Interfaces.ProviderInterfaces;
using DMS_Domain.Interfaces.ServiceInterfaces;
using DMS_Domain.Interfaces.WrapperInterfaces.FileSystem;
using DMS_Domain.Interfaces.WrapperInterfaces.Operations;
using DMS_Infrastructure.Factories;
using DMS_Infrastructure.Wrappers.Operations;
using Interop.DMS_Server;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Abstractions;

namespace DMS_Infrastructure.Bootstrappers
{
    public class DependencyInjectionBootstrapper : IDependencyInjectionBootstrapper
    {
        public void RegisterServices(IServiceCollection services)
        {
            //Services
            services.AddTransient<ISetupService, SetupService>();
            services.AddTransient<ITreeNodeService, TreeNodeService>();
            services.AddTransient<IErrorHandler, ErrorHandler>();
            services.AddTransient<ITextHandler, TextHandler>();
            services.AddTransient<IFileSystemService, FileSystemService>();
            services.AddTransient<IListViewItemCreationService, ListViewItemCreationService>();
            services.AddTransient<IDriveInfoService, DriveInfoService>();
            services.AddSingleton<IAppLogger, AppLogger>();

            //Helpers
            services.AddTransient<IFormatter, Formatter>();
            services.AddTransient<IFileSystemValidator, FileSystemValidator>();

            //Strategies
            services.AddTransient<ITreeNodePopulationStrategy, TreeNodePopulationStrategy>();

            //Factories
            services.AddSingleton<IWrapperFactory, WrapperFactory>();
            services.AddSingleton<IBootStrapperFactory, BootstrapperFactory>();

            //Wrappers
            services.AddTransient<IFileOperationsWrapper, FileOperationsWrapper>();
            services.AddTransient<IFolderOperationsWrapper, FolderOperationsWrapper>();
            services.AddTransient<IDriveInfoWrapper, Wrappers.FileSystem.DriveInfoWrapper>();
            services.AddTransient<IFileInfoWrapper, Wrappers.FileSystem.FileInfoWrapper>();
            services.AddTransient<IDirectoryInfoWrapper, Wrappers.FileSystem.DirectoryInfoWrapper>();

            //IO
            services.AddSingleton<IFileSystem, FileSystem>();

            //Providers
            services.AddTransient<IFileSystemWrapperProvider, FileSystemWrapperProvider>();

            //DLL Interop
            services.AddTransient<IFileOperations>(provider =>
            {
                return new FileOperations();
            });

            services.AddTransient<IFolderOperations>(provider =>
            {
                return new FolderOperations();
            });
        }
    }
}