using CrossCutting.DomainModel;

namespace Data.Contract.DataAccess;

public interface IPersonRepository
{
    void Insert(Person personToAdd);
    IEnumerable<Person> Query();
}