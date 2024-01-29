using ConsoleClient.Data;
using ConsoleClient.Models;

namespace ConsoleClient.Logic
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository _repository;

        public PersonManager(IPersonRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Person> GetAllAdults()
        {
            return _repository.Query().Where(p => p.Age >= 18);
        }
        public IEnumerable<Person> GetAllChildren()
        {
            return _repository.Query().Where(p => p.Age < 18);
        }

        public IEnumerable<Person> GetAll()
        {
            return _repository.Query();
        }

        public void Add(Person person)
        {
            _repository.Insert(person);
        }
    }
}
