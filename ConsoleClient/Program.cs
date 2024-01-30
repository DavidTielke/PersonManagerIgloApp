using System.ComponentModel.DataAnnotations;
using ConsoleClient.Logic;
using CrossCutting.Configuration;
using CrossCutting.Contract.Configuration;
using CrossCutting.Contract.Logging;
using CrossCutting.Logging;
using Data.Contract.DataAccess;
using Data.Contract.FileSystem;
using Data.DataAccess;
using Data.FileSystem;
using Logic.Contract.PersonManagement;
using Ninject;

namespace ConsoleClient
{
    internal interface IFoo
    {
        void Muh();
    }

    class Foo : IFoo
    {
        public int _counter = 0;

        public void Muh()
        {

        }
    }

    static class StringUtils
    {
        public static string ToUpper(string source) => source.ToUpper();
    }

    static class PersonConfigKeys
    {
        public static readonly string AgeTreshold = "AgeTreshold";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();

            kernel.Bind<IFileStore>().To<FileStore>().InTransientScope();
            kernel.Bind<IPersonParser>().To<PersonParser>();
            kernel.Bind<IPersonRepository>().To<PersonRepository>();
            kernel.Bind<IPersonManager>().To<PersonManager>();
            kernel.Bind<ILogger>().To<Logger>();
            kernel.Bind<IPersonLogicValidator>().To<PersonLogicValidator>();
            kernel.Bind<IPersonDataValidator>().To<PersonDataValidator>();
            kernel.Bind<IConfigurator>().To<Configurator>().InSingletonScope();
            kernel.Bind<IFoo>().To<Foo>().InSingletonScope();

            var config = kernel.Get<IConfigurator>();
            config.Set(PersonConfigKeys.AgeTreshold, 10);
            config.Set("CsvPath", "data.csv");

            var app = kernel.Get<App>();
            app.Run();
        }
    }
}
