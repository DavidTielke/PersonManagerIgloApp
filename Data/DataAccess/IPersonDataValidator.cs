using CrossCutting.DomainModel;

namespace Data.DataAccess;

public interface IPersonDataValidator
{
    bool IsValidForInsert(Person person);
}