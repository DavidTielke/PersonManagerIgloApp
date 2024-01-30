using DavidTielke.PMA.CrossCutting.Contract.DomainModel;

namespace DavidTielke.PMA.Logic.Contract.PersonManagement;

public interface IPersonManager
{
    IEnumerable<Person> GetAllAdults();
    IEnumerable<Person> GetAllChildren();
    IEnumerable<Person> GetAll();
    void Add(Person person);
}