using Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllerTests;

[TestClass]
class HelperTests
{
    [TestMethod]
    public void RandomShouldNotBeNull()
    {
        // Arrange

        // Act

        // Assert
        Assert.IsNotNull(Helper.Random);
    }

    [TestMethod]
    public void NameGeneratorShouldNotBeNull()
    {
        // Arrange

        // Act

        // Assert
        Assert.IsNotNull(Helper.NameGenerator);
    }

    [TestMethod]
    public void AddressGeneratorShouldNotBeNull()
    {
        // Arrange

        // Act

        // Assert
        Assert.IsNotNull(Helper.AddressGenerator);
    }
}