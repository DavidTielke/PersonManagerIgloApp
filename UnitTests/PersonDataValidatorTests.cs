using ConsoleClient.CrossCutting;
using ConsoleClient.Data;
using FluentAssertions;

namespace UnitTests;

[TestClass]
public class PersonDataValidatorTests
{
    [TestMethod]
    public void IsValidForInsert_ValidPerson_ReturnsTrue()
    {
        var validator = new PersonDataValidator();
        var person = new Person(0, "Test", 0);

        var actual = validator.IsValidForInsert(person);

        actual.Should().BeTrue();
    }

    [TestMethod]
    public void IsValidForInsert_PersonWithId1_ReturnsFalse()
    {
        var validator = new PersonDataValidator();
        var person = new Person(1, "Test", 0);

        var actual = validator.IsValidForInsert(person);

        actual.Should().BeFalse();
    }
    
    [TestMethod]
    public void IsValidForInsert_PersonWithNameNull_ReturnsFalse()
    {
        var validator = new PersonDataValidator();
        var person = new Person(1, null, 0);

        var actual = validator.IsValidForInsert(person);

        actual.Should().BeFalse();
    }
}