using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsoleClient.Logic;
using CrossCutting.Configuration;
using CrossCutting.DomainModel;
using CrossCutting.Logging;
using Data.DataAccess;
using Data.FileSystem;
using Ninject;

namespace DesktopClient
{
    static class PersonConfigKeys
    {
        public static readonly string AgeTreshold = "AgeTreshold";
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> Adults { get; set; }
        public ObservableCollection<Person> Children { get; set; }


        public MainWindow()
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

            var config = kernel.Get<IConfigurator>();
            config.Set(PersonConfigKeys.AgeTreshold, 10);
            config.Set("CsvPath", "data.csv");

            var manager = kernel.Get<IPersonManager>();

            Adults = new ObservableCollection<Person>(manager.GetAllAdults());
            Children = new ObservableCollection<Person>(manager.GetAllChildren());

            DataContext = this;

            InitializeComponent();


        }
    }
}