using System.Collections;
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
        var persons = Control<Person>.GeneratePersons(0, null);

        // Assert
        var personsCount = ((IEnumerable<Person>)persons).Count();
        Assert.AreEqual(expected: 0, actual: personsCount);
    }

    [TestMethod]
    public void GeneratePersonsShouldGenerateExpectedAmountOfPersonsIfDelegateIsNull()
    {
        // Arrange

        // Act
        var persons = Control<Person>.GeneratePersons(10, null);

        // Assert
        var personsCount = ((IEnumerable<Person>)persons)?.Count();
        Assert.AreEqual(expected: 10, actual: personsCount);
    }

    [TestMethod]
    public void GeneratePersonsShouldWorkIfDelegateContainsEverything()
    {
        // Arrange
        Control<Person>.BuildInstructions buildInstructions;

        buildInstructions = t => t.BuildFirstName();
        buildInstructions += t => t.BuildLastName();
        buildInstructions += t => t.BuildAddress();
        buildInstructions += t => t.BuildPhoneNumber();
        buildInstructions += t => t.BuildDateOfBirth();
        buildInstructions += t => t.BuildGender();
        buildInstructions += t => t.BuildEmail();

        // Act

        var persons = Control<Person>.GeneratePersons(10, buildInstructions);

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