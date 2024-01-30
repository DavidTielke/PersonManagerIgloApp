using CrossCutting.DomainModel;

namespace Data.Contract.DataAccess;

public interface IPersonDataValidator
{
    bool IsValidForInsert(Person person);
}