using ConsoleClient.CrossCutting;
using ConsoleClient.Data;
using ConsoleClient.UI;

namespace ConsoleClient.Logic
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository _repository;
        private readonly IPersonLogicValidator _validator;
        private readonly int AGE_TRESHOLD;

        public PersonManager(IPersonRepository repository, 
            IConfigurator config,
            IPersonLogicValidator validator)
        {
            _repository = repository;
            _validator = validator;
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
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            var isValidForAdd = _validator.IsValidForAdd(person);
            if (!isValidForAdd)
            {
                throw new ArgumentException(nameof(person));
            }
            
            // ...

            _repository.Insert(person);
        }
    }
}
