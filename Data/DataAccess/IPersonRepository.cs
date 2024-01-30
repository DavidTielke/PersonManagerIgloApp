using CrossCutting.DomainModel;

namespace Data.DataAccess;

public interface IPersonRepository
{
    void Insert(Person personToAdd);
    IEnumerable<Person> Query();
}