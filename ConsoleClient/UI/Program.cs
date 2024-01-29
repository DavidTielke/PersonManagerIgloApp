using System.ComponentModel.DataAnnotations;
using ConsoleClient.CrossCutting;
using ConsoleClient.Data;
using ConsoleClient.Logic;
using Ninject;

namespace ConsoleClient.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();

            kernel.Bind<IFileReader>().To<FileReader>().InTransientScope();
            kernel.Bind<IPersonParser>().To<PersonParser>();
            kernel.Bind<IPersonRepository>().To<PersonRepository>();
            kernel.Bind<IPersonManager>().To<PersonManager>();
            kernel.Bind<ILogger>().To<Logger>();
            kernel.Bind<IConfigurator>().To<Configurator>().InSingletonScope();

            var config = kernel.Get<IConfigurator>();
            config.Set("AgeTreshold", 10);

            var app = kernel.Get<App>();
            app.Run();
        }
    }
}
