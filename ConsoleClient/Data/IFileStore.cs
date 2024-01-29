namespace ConsoleClient.Data;

public interface IFileStore
{
    string[] ReadAllLines();
    void WriteAllLines(IEnumerable<string> lines);
}