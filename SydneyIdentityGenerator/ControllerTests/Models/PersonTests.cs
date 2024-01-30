using Controller;
using Controller.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RandomNameGeneratorLibrary;

namespace ControllerTests.Models;

[TestClass]
public class PersonTests
{
    private readonly PersonToTest _person = new();

    [TestMethod]
    public void BuildFirstNameShouldCallGenerateRandomFirstName()
    {
        // Arrange
        var nameGeneratorMock = new Mock<IPersonNameGenerator>();
        nameGeneratorMock
            .Setup(x => x.GenerateRandomFirstName())
            .Returns("Alex");

        Helper.NameGenerator = nameGeneratorMock.Object;

        // Act
        _person.BuildFirstName();

        // Assert
        nameGeneratorMock.Verify(x => x.GenerateRandomFirstName(), Times.Once);
        Assert.AreEqual("Alex", _person.FirstName);
    }

    [TestMethod]
    public void BuildLastNameShouldCallGenerateRandomLastName()
    {
        // Arrange
        var nameGeneratorMock = new Mock<IPersonNameGenerator>();
        nameGeneratorMock
            .Setup(x => x.GenerateRandomLastName())
            .Returns("Smith");

        Helper.NameGenerator = nameGeneratorMock.Object;

        // Act
        _person.BuildLastName();

        // Assert
        nameGeneratorMock.Verify(x => x.GenerateRandomLastName(), Times.Once);
        Assert.AreEqual("Smith", _person.LastName);
    }

    [TestMethod]
    public void BuildAddressShouldCallGetRandomAddress()
    {
        // Arrange
        var addressGeneratorMock = new Mock<IAddressGenerator>();
        addressGeneratorMock
            .Setup(x => x.GetRandomAddress())
            .Returns("123 Any Street, Any City, Any State, Any Country");

        Helper.AddressGenerator = addressGeneratorMock.Object;

        // Act
        _person.BuildAddress();

        // Assert
        addressGeneratorMock.Verify(x => x.GetRandomAddress(), Times.Once);
        Assert.AreEqual("123 Any Street, Any City, Any State, Any Country", _person.Address);
    }

    [TestMethod]
    public void BuildPhoneNumberShouldReturnPhoneNumberWithLength13()
    {
        // Arrange

        // Act
        _person.BuildPhoneNumber();

        // Assert
        Assert.AreEqual(13, _person.PhoneNumber.Length);
    }

    [TestMethod]
    public void BuildEmailShouldReturnCorrectEmailFormat()
    {
        // Arrange
        _person.BuildFirstName();
        _person.BuildLastName();
        var generatedFirstName = _person.FirstName;
        var generatedLastName = _person.LastName;

        // Act
        _person.BuildEmail();

        // Assert
        Assert.IsNotNull(_person.Email);
        Assert.AreEqual($"{generatedFirstName}.{generatedLastName}@gmail.com", _person.Email);
    }

    [TestMethod]
    public void BuildDateOfBirthShouldHaveCorrectDateFormat()
    {
        // Arrange

        // Act
        _person.BuildDateOfBirth();

        // Assert
        Assert.IsNotNull(_person.DateOfBirth);
    }

    [TestMethod]
    public void BuildGenderShouldReturnNonBinary()
    {
        // Arrange

        // Act
        _person.BuildGender();

        // Assert
        Assert.AreEqual("Non-binary", _person.Gender);
    }

}

public class PersonToTest : Person
{
    
}