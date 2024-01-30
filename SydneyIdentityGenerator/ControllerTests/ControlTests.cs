using Controller;
using Controller.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllerTests;

[TestClass]
public class ControlTests
{
    [TestMethod]
    public void WhenGeneratePersonsAmountIs0ShouldReturnNull()
    {
        // Arrange

        // Act
        var persons = Control.GeneratePersons(0, null);

        // Assert
        var personsCount = ((IEnumerable<Person>)persons).Count();
        Assert.AreEqual(expected: 0, actual: personsCount);
    }

    [TestMethod]
    public void GeneratePersonsShouldGenerateExpectedAmountOfPersonsIfDelegateIsNull()
    {
        // Arrange

        // Act
        var persons = Control.GeneratePersons(10, null);

        // Assert
        var personsCount = ((IEnumerable<Person>)persons).Count();
        Assert.AreEqual(expected: 10, actual: personsCount);
    }

    [TestMethod]
    public void GeneratePersonsShouldWorkIfDelegateContainsEverything()
    {
        // Arrange
        Control.Builder? builder = null;

        builder += t => t.BuildFirstName();
        builder += t => t.BuildLastName();
        builder += t => t.BuildAddress();
        builder += t => t.BuildPhoneNumber();
        builder += t => t.BuildDateOfBirth();
        builder += t => t.BuildGender();
        builder += t => t.BuildEmail();

        // Act
        var persons = Control.GeneratePersons(10, builder);

        // Assert
        foreach (Person person in persons)
        {
            Assert.IsNotNull(person.Address);
            Assert.IsNotNull(person.DateOfBirth);
            Assert.IsNotNull(person.Email);
            Assert.IsNotNull(person.FirstName);
            Assert.IsNotNull(person.LastName);
            Assert.IsNotNull(person.PhoneNumber);
        }

    }
}