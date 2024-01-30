using CrossCutting.DomainModel;

namespace ConsoleClient.Logic;

public interface IPersonLogicValidator
{
    bool IsValidForAdd(Person person);
}