namespace ServiceClient.Data
{
    public class FileReader : IFileReader
    {
        private readonly string _PATH;

        public FileReader()
        {
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
                throw new InvalidOperationException("data to read cant be found", exc);
            }
        }
    }
}
