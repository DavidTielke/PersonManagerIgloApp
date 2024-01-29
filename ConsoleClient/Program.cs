using System.ComponentModel.DataAnnotations;
using ConsoleClient.Data;
using ConsoleClient.Logic;
using Ninject;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();

            kernel.Bind<IFileReader>().To<FileReader>();
            kernel.Bind<IPersonParser>().To<PersonParser>();
            kernel.Bind<IPersonRepository>().To<PersonRepository>();
            kernel.Bind<IPersonManager>().To<PersonManager>();

            var manager = kernel.Get<IPersonManager>();

            var adults = manager.GetAllAdults().ToList();
            Console.WriteLine($"### ERWACHSENE ({adults.Count}) ###");
            adults.ForEach(a => Console.WriteLine(a.Name));
            
            var children = manager.GetAllChildren().ToList();
            Console.WriteLine($"### KINDER ({children.Count}) ###");
            children.ForEach(c => Console.WriteLine(c.Name));
        }
    }
}
