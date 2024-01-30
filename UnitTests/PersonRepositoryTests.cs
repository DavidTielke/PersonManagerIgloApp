using ConsoleClient.CrossCutting;
using ConsoleClient.Data;
using FluentAssertions;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class PersonRepositoryTests
    {
        private PersonRepository _sut;
        private Mock<IFileStore> _storeMock;
        private Mock<IConfigurator> _configMock;

        [TestInitialize]
        public void Init()
        {
            var validator = new PersonDataValidator();
            var parser = new PersonParser();
            _storeMock = new Mock<IFileStore>();
            _configMock = new Mock<IConfigurator>();
            _sut = new PersonRepository(_storeMock.Object, parser, validator, _configMock.Object);
        }

        [TestMethod]
        public void Insert_NewPerson_PersonAddedToEndOfFile()
        {
            IEnumerable<string> lines = null;
            var person = new Person(0, "Test", 23);
            _storeMock.Setup(m => m.ReadAllLines(It.IsAny<string>())).Returns(new[] { "1,Test2,17" });
            _storeMock
                .Setup(m => m.WriteAllLines(It.IsAny<string>(), It.IsAny<IEnumerable<string>>()))
                .Callback((Action<string, IEnumerable<string>>)((_,l) => lines = l));

            _sut.Insert(person);

            lines.Count().Should().Be(2);
            lines.Last().Should().Be("2,Test,23");
        }

        [TestMethod]
        public void Insert_NewPerson_AddedPersonGetNextId()
        {
            IEnumerable<string> lines = null;
            var person = new Person(0, "Test", 23);
            _storeMock.Setup(m => m.ReadAllLines(It.IsAny<string>())).Returns(new[] { "1,Test2,17" });
            _storeMock
                .Setup(m => m.WriteAllLines(It.IsAny<string>(), It.IsAny<IEnumerable<string>>()))
                .Callback((Action<string, IEnumerable<string>>)((_,l) => lines = l));

            _sut.Insert(person);

            lines.Last().Should().Be("2,Test,23");
        }

        [TestMethod]
        public void Insert_PersonIsNull_ArgumentNullException()
        {
            _sut.Invoking(sut => sut.Insert(null))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void Insert_PersonWithId1_ArgumentException()
        {
            var person = new Person(1, "Test", 23);

            _sut.Invoking(sut => sut.Insert(person))
                .Should()
                .Throw<ArgumentException>();
        }
    }
}