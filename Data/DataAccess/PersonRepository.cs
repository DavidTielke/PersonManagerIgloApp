using CrossCutting.Configuration;
using CrossCutting.DomainModel;
using Data.FileSystem;

namespace Data.DataAccess
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IFileStore _store;
        private readonly IPersonParser _parser;
        private readonly IPersonDataValidator _validator;
        private readonly IConfigurator _config;

        public PersonRepository(IFileStore store,
            IPersonParser parser,
            IPersonDataValidator validator,
            IConfigurator config)
        {
            _store = store;
            _parser = parser;
            _validator = validator;
            _config = config;
        }

        private string CsvPath => _config.Get<string>("CsvPath");

        public void Insert(Person personToAdd)
        {
            ArgumentNullException.ThrowIfNull(personToAdd);

            var isNotValidForInsert = !_validator.IsValidForInsert(personToAdd);
            if (isNotValidForInsert)
            {
                throw new ArgumentException("Person is not valid", nameof(personToAdd));
            }

            var nextFreeId = Query().Max(p => p.Id) + 1;
            personToAdd.Id = nextFreeId;

            var linesOfCsvFile = _store.ReadAllLines(CsvPath).ToList();
            var personAsCsv = _parser.ParseToCsv(personToAdd);
            linesOfCsvFile.Add(personAsCsv);
            _store.WriteAllLines(CsvPath, linesOfCsvFile);
        }

        public IEnumerable<Person> Query()
        {
            var lines = _store.ReadAllLines(CsvPath);
            var persons = _parser.ParseFromCsv(lines);
            return persons;
        }
    }
}
