using DavidTielke.PMA.CrossCutting.Contract.DomainModel;
using DavidTielke.PMA.Logic.Contract.PersonManagement;

namespace DavidTielke.PMA.Logic.PersonManagement
{
    public class PersonLogicValidator : IPersonLogicValidator
    {
        public bool IsValidForAdd(Person person)
        {
            if (person.Age < 0 || person.Age > 99) return false;
            if (person.Name == "Max") return false;
            return true;
        }
    }
}
