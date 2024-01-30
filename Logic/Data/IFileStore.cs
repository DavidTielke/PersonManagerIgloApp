namespace ConsoleClient.Data;

public interface IFileStore
{
    string[] ReadAllLines(string path);
    void WriteAllLines(string path, IEnumerable<string> lines);
}