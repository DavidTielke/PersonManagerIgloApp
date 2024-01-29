using ConsoleClient.CrossCutting;
using ConsoleClient.UI;

namespace ConsoleClient.Data
{
    public class FileStore : IFileStore
    {
        private readonly ILogger _logger;
        private readonly string _PATH;

        public FileStore(ILogger logger)
        {
            _logger = logger;
            _PATH = "data.csv";
        }

        public string[] ReadAllLines()
        {
            try
            {
                return File.ReadAllLines(_PATH);
            }
            catch (FileNotFoundException exc)
            {
                _logger.Log(exc.ToString());
                throw new InvalidOperationException("data to read cant be found", exc);
            }
        }

        public void WriteAllLines(IEnumerable<string> lines)
        {
            File.Delete(_PATH);
            File.WriteAllLines(_PATH, lines);
        }
    }
}
