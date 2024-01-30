using CrossCutting.DomainModel;

namespace Data.Contract.DataAccess;

public interface IPersonParser
{
    IEnumerable<Person> ParseFromCsv(string[] lines);
    string ParseToCsv(Person person);
}