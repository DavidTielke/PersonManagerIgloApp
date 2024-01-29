using ConsoleClient.CrossCutting;
using ConsoleClient.Data;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class PersonRepositoryTests
    {
        private PersonRepository _sut;
        private Mock<IFileStore> _storeMock;

        [TestInitialize]
        public void Init()
        {
            var validator = new PersonDataValidator();
            var parser = new PersonParser();
            _storeMock = new Mock<IFileStore>();
            _sut = new PersonRepository(_storeMock.Object, parser, validator);
        }

        [TestMethod]
        public void Insert_NewPerson_PersonAddedToEndOfFile()
        {
            IEnumerable<string> lines = null;
            var person = new Person(0, "Test", 23);
            _storeMock.Setup(m => m.ReadAllLines()).Returns(new[] { "1,Test2,17" });
            _storeMock
                .Setup(m => m.WriteAllLines(It.IsAny<IEnumerable<string>>()))
                .Callback((Action<IEnumerable<string>>)(l => lines = l));

            _sut.Insert(person);

            Assert.AreEqual(2, lines.Count());
            Assert.AreEqual("0,Test,23", lines.Last());
        }
    }
}