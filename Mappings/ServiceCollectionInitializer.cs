using DavidTielke.PMA.CrossCutting.Configuration;
using DavidTielke.PMA.CrossCutting.Contract.Configuration;
using DavidTielke.PMA.Data.Contract.DataAccess;
using DavidTielke.PMA.Data.Contract.FileSystem;
using DavidTielke.PMA.Data.DataAccess;
using DavidTielke.PMA.Data.FileSystem;
using DavidTielke.PMA.Logic.Contract.PersonManagement;
using DavidTielke.PMA.Logic.PersonManagement;
using Microsoft.Extensions.DependencyInjection;

namespace DavidTielke.PMA.Mappings
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection source)
        {
            new ServiceCollectionInitializer().Initialize(source);
        }
    }

    public class ServiceCollectionInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddTransient<IFileStore, FileStore>();
            services.AddTransient<IPersonParser, PersonParser>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPersonManager, PersonManager>();
            services.AddTransient<IPersonLogicValidator, PersonLogicValidator>();
            services.AddTransient<IPersonDataValidator, PersonDataValidator>();
            services.AddSingleton<IConfigurator, Configurator>();
        }
    }
}
