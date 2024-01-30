using DavidTielke.PMA.CrossCutting.Contract.DomainModel;

namespace DavidTielke.PMA.Data.Contract.DataAccess;

public interface IPersonRepository
{
    void Insert(Person personToAdd);
    IEnumerable<Person> Query();
}