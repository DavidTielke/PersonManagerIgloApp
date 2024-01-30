using DavidTielke.PMA.CrossCutting.Contract.DomainModel;

namespace DavidTielke.PMA.Data.Contract.DataAccess;

public interface IPersonDataValidator
{
    bool IsValidForInsert(Person person);
}