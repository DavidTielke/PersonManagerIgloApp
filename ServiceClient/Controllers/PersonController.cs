using ConsoleClient.Logic;
using CrossCutting.DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace ServiceClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonManager _manager;

        public PersonController(IPersonManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("/person")]
        public IEnumerable<Person> GetAll()
        {
            return _manager.GetAll();
        }

        [HttpGet]
        [Route("/person/adults")]
        public IEnumerable<Person> GetAllAdults()
        {
            return _manager.GetAllAdults();
        }

        [HttpGet]
        [Route("/person/children")]
        public IEnumerable<Person> Get()
        {
            return _manager.GetAllChildren();
        }
    }
}
