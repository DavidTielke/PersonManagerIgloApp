using System.Net.Http.Json;
using DavidTielke.PMA.CrossCutting.Contract.DomainModel;
using DavidTielke.PMA.UI.ServiceClient;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ServiceTests
{
    [TestClass]
    public class PersonApiTests
    {
        private WebApplicationFactory<Program> _server;
        private HttpClient _client;

        [TestInitialize]
        public void Init()
        {
            _server = new WebApplicationFactory<Program>();
            _client = _server.CreateClient();
        }

        [TestMethod]
        public async Task GetAllPersons_5PersonInFile_5PersonsReturned()
        {
            var persons = await _client
                .GetFromJsonAsync<IEnumerable<Person>>("person");

            persons.Should().HaveCount(5);
        }
    }
}