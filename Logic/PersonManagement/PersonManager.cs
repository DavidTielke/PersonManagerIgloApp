﻿using DavidTielke.PMA.CrossCutting.Contract.Configuration;
using DavidTielke.PMA.CrossCutting.Contract.DomainModel;
using DavidTielke.PMA.Data.Contract.DataAccess;
using DavidTielke.PMA.Logic.Contract.PersonManagement;

namespace DavidTielke.PMA.Logic.PersonManagement
{
    public class PersonManager : IPersonManager
    {
        private const string Agetreshold = "AgeTreshold";
        private readonly IPersonRepository _repository;
        private readonly IConfigurator _config;
        private readonly IPersonLogicValidator _validator;

        public PersonManager(IPersonRepository repository,
            IConfigurator config,
            IPersonLogicValidator validator)
        {
            _repository = repository;
            _config = config;
            _validator = validator;
        }

        public IEnumerable<Person> GetAllAdults()
        {
            return _repository.Query().Where(p => p.Age >= _config.Get<int>(Agetreshold));
        }
        public IEnumerable<Person> GetAllChildren()
        {
            return _repository.Query().Where(p => p.Age < _config.Get<int>(Agetreshold));
        }

        public IEnumerable<Person> GetAll()
        {
            return _repository.Query();
        }

        public void Add(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            var isValidForAdd = _validator.IsValidForAdd(person);
            if (!isValidForAdd)
            {
                throw new ArgumentException(nameof(person));
            }

            // ...

            _repository.Insert(person);
        }
    }
}
