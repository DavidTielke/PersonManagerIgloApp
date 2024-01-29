using ConsoleClient.CrossCutting;

namespace ConsoleClient.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IFileStore _store;
        private readonly IPersonParser _parser;
        private readonly IPersonDataValidator _validator;

        public PersonRepository(IFileStore store, 
            IPersonParser parser,
            IPersonDataValidator validator)
        {
            _store = store;
            _parser = parser;
            _validator = validator;
        }

        public void Insert(Person person)
        {
            var isValidForInsert = _validator.IsValidForInsert(person);
            if (!isValidForInsert)
            {
                throw new ArgumentException("Person is not valid", nameof(person));
            }

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
