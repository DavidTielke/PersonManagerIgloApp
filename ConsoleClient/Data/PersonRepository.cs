using ConsoleClient.CrossCutting;

namespace ConsoleClient.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IFileStore _store;
        private readonly IPersonParser _parser;

        public PersonRepository(IFileStore store, 
            IPersonParser parser)
        {
            _store = store;
            _parser = parser;
        }

        public void Insert(Person person)
        {
            var lines = _store.ReadAllLines().ToList();
            var dataLine = _parser.ParseToCsv(person);
            lines.Add(dataLine);
            _store.WriteAllLines(lines);
        }

        public IEnumerable<Person> Query()
        {
            var lines = _store.ReadAllLines();
            var persons = _parser.ParseFromCsv(lines);
            return persons;
        }
    }
}
