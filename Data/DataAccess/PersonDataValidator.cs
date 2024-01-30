using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CrossCutting.DomainModel;
using Data.Contract.DataAccess;

namespace Data.DataAccess
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
