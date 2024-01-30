using ConsoleClient.CrossCutting;

namespace ConsoleClient.Data;

public interface IPersonDataValidator
{
    bool IsValidForInsert(Person person);
}