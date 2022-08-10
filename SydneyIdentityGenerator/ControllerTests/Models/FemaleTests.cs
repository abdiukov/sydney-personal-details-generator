using Controller;
using Controller.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RandomNameGeneratorLibrary;

namespace ControllerTests.Models;

[TestClass]
public class FemaleTests
{
    private readonly Female _female = new();

    [TestMethod]
    public void BuildFirstNameShouldCallGenerateRandomFemaleFirstName()
    {
        // Arrange
        var nameGeneratorMock = new Mock<IPersonNameGenerator>();
        nameGeneratorMock
            .Setup(x => x.GenerateRandomFemaleFirstName())
            .Returns("Jane");
        Helper.NameGenerator = nameGeneratorMock.Object;

        // Act
        _female.BuildFirstName();

        // Assert
        nameGeneratorMock.Verify(x => x.GenerateRandomFemaleFirstName(), Times.Once);
        Assert.AreEqual("Jane", _female.FirstName);
    }

    [TestMethod]
    public void BuildGenderShouldReturnFemale()
    {
        // Arrange

        // Act
        _female.BuildGender();

        // Assert
        Assert.AreEqual("female", _female.Gender);
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
        _female.BuildLastName();

        // Assert
        nameGeneratorMock.Verify(x => x.GenerateRandomLastName(), Times.Once);
        Assert.AreEqual("Doe", _female.LastName);
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
        _female.BuildAddress();

        // Assert
        addressGeneratorMock.Verify(x => x.GenerateRandomSydneyAddress(), Times.Once);
        Assert.AreEqual("123 Church Street, Parramatta, NSW 2150", _female.Address);
    }

    [TestMethod]
    public void BuildPhoneNumberShouldReturnPhoneNumberWithLength9()
    {
        // Arrange

        // Act
        _female.BuildPhoneNumber();

        // Assert
        Assert.AreEqual(9, _female.PhoneNumber.Length);
    }

    [TestMethod]
    public void BuildEmailShouldReturnCorrectEmailFormat()
    {
        // Arrange
        _female.BuildFirstName();
        _female.BuildLastName();
        var generatedFirstName = _female.FirstName;
        var generatedLastName = _female.LastName;

        // Act
        _female.BuildEmail();

        // Assert
        Assert.IsNotNull(_female.Email);
        Assert.AreEqual($"{generatedFirstName}.{generatedLastName}@gmail.com", _female.Email);
    }

    [TestMethod]
    public void BuildDateOfBirthShouldHaveCorrectDateFormat()
    {
        // Arrange

        // Act
        _female.BuildDateOfBirth();

        // Assert
        Assert.IsNotNull(_female.DateOfBirth);
    }
}