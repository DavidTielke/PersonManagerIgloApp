using ConsoleClient.CrossCutting;

namespace ConsoleClient.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IFileReader _reader;
        private readonly IPersonParser _parser;

        public PersonRepository(IFileReader reader, 
            IPersonParser parser)
        {
            _reader = reader;
            _parser = parser;
        }

        public void Insert(Person person)
        {
            
        }

        public IEnumerable<Person> Query()
        {
            var lines = _reader.ReadAllLines();
            var persons = _parser.ParseFromCsv(lines);
            return persons;
        }
    }
}
