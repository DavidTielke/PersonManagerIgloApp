using ConsoleClient.CrossCutting;

namespace ConsoleClient.Data;

public interface IPersonRepository
{
    void Insert(Person person);
    IEnumerable<Person> Query();
}