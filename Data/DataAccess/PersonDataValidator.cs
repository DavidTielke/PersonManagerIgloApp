using DavidTielke.PMA.CrossCutting.Contract.DomainModel;
using DavidTielke.PMA.Data.Contract.DataAccess;

namespace DavidTielke.PMA.Data.DataAccess
{
    public class PersonDataValidator : IPersonDataValidator
    {
        public bool IsValidForInsert(Person person)
        {
            if (person.Id != 0) return false;
            if (person.Name == null) return false;
            return true;
        }
    }
}
