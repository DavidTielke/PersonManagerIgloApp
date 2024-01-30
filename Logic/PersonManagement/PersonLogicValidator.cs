using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCutting.DomainModel;
using Logic.Contract.PersonManagement;

namespace ConsoleClient.Logic
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
