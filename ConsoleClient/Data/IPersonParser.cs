using ConsoleClient.Models;

namespace ConsoleClient.Data;

public interface IPersonParser
{
    IEnumerable<Person> ParseFromCsv(string[] lines);
}