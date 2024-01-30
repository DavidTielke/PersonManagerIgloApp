namespace Data.FileSystem
{
    public class FileStore : IFileStore
    {
        public string[] ReadAllLines(string path)
        {
            try
            {
                return File.ReadAllLines(path);
            }
            catch (FileNotFoundException exc)
            {
                throw new InvalidOperationException("data to read cant be found", exc);
            }
        }

        public void WriteAllLines(string path, IEnumerable<string> lines)
        {
            File.Delete(path);
            File.WriteAllLines(path, lines);
        }
    }
}
