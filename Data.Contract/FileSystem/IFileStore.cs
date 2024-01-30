namespace Data.Contract.FileSystem;

public interface IFileStore
{
    string[] ReadAllLines(string path);
    void WriteAllLines(string path, IEnumerable<string> lines);
}