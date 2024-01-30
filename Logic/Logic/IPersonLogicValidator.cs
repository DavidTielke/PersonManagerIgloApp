using ConsoleClient.CrossCutting;

namespace ConsoleClient.Logic;

public interface IPersonLogicValidator
{
    bool IsValidForAdd(Person person);
}