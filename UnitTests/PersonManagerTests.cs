using DavidTielke.PMA.CrossCutting.Contract.Configuration;
using DavidTielke.PMA.CrossCutting.Contract.DomainModel;
using DavidTielke.PMA.Data.Contract.DataAccess;
using DavidTielke.PMA.Logic.Contract.PersonManagement;
using DavidTielke.PMA.Logic.PersonManagement;
using FluentAssertions;
using Moq;

namespace DavidTielke.PMA.UI.UnitTests;

[TestClass]
public class PersonManagerTests
{
    private Mock<IPersonRepository> _repoMock;
    private Mock<IConfigurator> _configMock;
    private Mock<IPersonLogicValidator> _validatorMock;
    private PersonManager _sut;

    [TestInitialize]
    public void TestInitialize()
    {
        _repoMock = new Mock<IPersonRepository>();
        _configMock = new Mock<IConfigurator>();
        _validatorMock = new Mock<IPersonLogicValidator>();
        _sut = new PersonManager(_repoMock.Object, _configMock.Object, _validatorMock.Object);
    }

    [TestMethod]
    public void GetAllAdults_2AdultsInRepo_2AdultsReturned()
    {
        _repoMock.Setup(m => m.Query()).Returns(new List<Person>
        {
            new Person(1,"Test1",16),
            new Person(2,"Test2",17),
            new Person(3,"Test3",18),
            new Person(4,"Test4",19),
        });
        _configMock.Setup(m => m.Get<int>(It.IsAny<string>())).Returns(18);
        var expected = 2;

        var actual = _sut.GetAllAdults().Count();

        actual.Should().Be(expected, "two adults are returned by the repository");
    }

    [TestMethod]
    public void Add_PersonIsNull_ArgumentNullException()
    {
        _sut.Invoking(sut => sut.Add(null))
            .Should()
            .Throw<ArgumentNullException>();
    }
}