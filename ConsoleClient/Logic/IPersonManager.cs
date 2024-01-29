using ConsoleClient.Models;

namespace ConsoleClient.Logic;

public interface IPersonManager
{
    IEnumerable<Person> GetAllAdults();
    IEnumerable<Person> GetAllChildren();
    IEnumerable<Person> GetAll();
    void Add(Person person);
}