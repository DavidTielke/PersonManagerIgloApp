using DavidTielke.PMA.CrossCutting.Contract.DomainModel;

namespace DavidTielke.PMA.Data.Contract.DataAccess;

public interface IPersonParser
{
    IEnumerable<Person> ParseFromCsv(string[] lines);
    string ParseToCsv(Person person);
}