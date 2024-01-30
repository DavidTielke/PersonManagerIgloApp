using CrossCutting.DomainModel;

namespace Logic.Contract.PersonManagement;

public interface IPersonLogicValidator
{
    bool IsValidForAdd(Person person);
}