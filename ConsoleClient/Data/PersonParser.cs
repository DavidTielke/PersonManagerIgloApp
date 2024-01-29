using ConsoleClient.CrossCutting;

namespace ConsoleClient.Data
{
    public class PersonParser : IPersonParser
    {
        private readonly ILogger _logger;

        public PersonParser(ILogger logger)
        {
            _logger = logger;
        }

        public IEnumerable<Person> ParseFromCsv(string[] lines)
        {
            _logger.Log($"Parse {lines.Length} zeilen");
            return lines.Select(l => l.Split(","))
                .Select(p => new Person
                {
                    Id = int.Parse(p[0]),
                    Name = p[1],
                    Age = int.Parse(p[2]),
                });
        }
    }
}
