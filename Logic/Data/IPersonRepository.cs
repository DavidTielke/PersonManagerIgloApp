using ConsoleClient.CrossCutting;

namespace ConsoleClient.Data;

public interface IPersonRepository
{
    void Insert(Person personToAdd);
    IEnumerable<Person> Query();
}