using ServiceClient.Models;

namespace ServiceClient.Data;

public interface IPersonParser
{
    IEnumerable<Person> ParseFromCsv(string[] lines);
}