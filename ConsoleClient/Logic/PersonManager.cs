using ConsoleClient.CrossCutting;
using ConsoleClient.Data;
using ConsoleClient.UI;

namespace ConsoleClient.Logic
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository _repository;
        private readonly int AGE_TRESHOLD;

        public PersonManager(IPersonRepository repository, IConfigurator config)
        {
            _repository = repository;
            AGE_TRESHOLD = config.Get<int>(PersonConfigKeys.AgeTreshold);
        }

        public IEnumerable<Person> GetAllAdults()
        {
            return _repository.Query().Where(p => p.Age >= AGE_TRESHOLD);
        }
        public IEnumerable<Person> GetAllChildren()
        {
            return _repository.Query().Where(p => p.Age < AGE_TRESHOLD);
        }

        public IEnumerable<Person> GetAll()
        {
            return _repository.Query();
        }

        public void Add(Person person)
        {
            // ...
            _repository.Insert(person);
        }
    }
}
