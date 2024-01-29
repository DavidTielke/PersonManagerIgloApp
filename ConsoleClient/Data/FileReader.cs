using ConsoleClient.CrossCutting;

namespace ConsoleClient.Data
{
    public class FileReader : IFileReader
    {
        private readonly ILogger _logger;
        private readonly string _PATH;

        public FileReader(ILogger logger)
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
    }
}
