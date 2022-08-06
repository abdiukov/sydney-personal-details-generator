using Controller;
using Controller.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RandomNameGeneratorLibrary;

namespace ControllerTests.Models;

[TestClass]
public class MaleTests
{
    private readonly Male _male = new();

    [TestMethod]
    public void BuildFirstNameShouldCallGenerateRandomMaleFirstName()
    {
        // Arrange
        var nameGeneratorMock = new Mock<IPersonNameGenerator>();
        nameGeneratorMock
            .Setup(x => x.GenerateRandomMaleFirstName())
            .Returns("John");

        Helper.NameGenerator = nameGeneratorMock.Object;

        // Act
        _male.BuildFirstName();

        // Assert
        nameGeneratorMock.Verify(x => x.GenerateRandomMaleFirstName(), Times.Once);
        Assert.AreEqual("John", _male.FirstName);
    }

    [TestMethod]
    public void BuildGenderShouldReturnMale()
    {
        // Arrange

        // Act
        _male.BuildGender();

        // Assert
        Assert.AreEqual("male", _male.Gender);
    }

    [TestMethod]
    public void BuildLastNameShouldCallGenerateRandomLastName()
    {
        // Arrange
        var nameGeneratorMock = new Mock<IPersonNameGenerator>();
        nameGeneratorMock
            .Setup(x => x.GenerateRandomLastName())
            .Returns("Doe");
        Helper.NameGenerator = nameGeneratorMock.Object;

        // Act
        _male.BuildLastName();

        // Assert
        nameGeneratorMock.Verify(x => x.GenerateRandomLastName(), Times.Once);
        Assert.AreEqual("Doe", _male.LastName);
    }

    [TestMethod]
    public void BuildAddressShouldCallGenerateRandomSydneyAddress()
    {
        // Arrange
        var addressGeneratorMock = new Mock<IAddressGenerator>();
        addressGeneratorMock
            .Setup(x => x.GenerateRandomSydneyAddress())
            .Returns("123 Church Street, Parramatta, NSW 2150");

        Helper.AddressGenerator = addressGeneratorMock.Object;

        // Act
        _male.BuildAddress();

        // Assert
        addressGeneratorMock.Verify(x => x.GenerateRandomSydneyAddress(), Times.Once);
        Assert.AreEqual("123 Church Street, Parramatta, NSW 2150", _male.Address);
    }

    [TestMethod]
    public void BuildPhoneNumberShouldReturnPhoneNumberWithLength9()
    {
        // Arrange

        // Act
        _male.BuildPhoneNumber();

        // Assert
        Assert.AreEqual(9, _male.PhoneNumber.Length);
    }

    [TestMethod]
    public void BuildEmailShouldReturnCorrectEmailFormat()
    {
        // Arrange
        _male.BuildFirstName();
        _male.BuildLastName();
        var generatedFirstName = _male.FirstName;
        var generatedLastName = _male.LastName;

        // Act
        _male.BuildEmail();

        // Assert
        Assert.IsNotNull(_male.Email);
        Assert.AreEqual($"{generatedFirstName}.{generatedLastName}@gmail.com", _male.Email);

    }

    [TestMethod]
    public void BuildDateOfBirthShouldHaveCorrectDateFormat()
    {
        // Arrange

        // Act
        _male.BuildDateOfBirth();

        // Assert
        Assert.IsNotNull(_male.DateOfBirth);
    }
}    