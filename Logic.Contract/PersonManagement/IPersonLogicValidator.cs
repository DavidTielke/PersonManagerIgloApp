using DavidTielke.PMA.CrossCutting.Contract.DomainModel;

namespace DavidTielke.PMA.Logic.Contract.PersonManagement;

public interface IPersonLogicValidator
{
    bool IsValidForAdd(Person person);
}