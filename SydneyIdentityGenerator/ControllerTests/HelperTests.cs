using Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllerTests;

[TestClass]
public class HelperTests
{
    [TestMethod]
    public void NameGeneratorShouldNotBeNull()
    {
        Assert.IsNotNull(Helper.NameGenerator);
    }

    [TestMethod]
    public void AddressGeneratorShouldNotBeNull()
    {
        Assert.IsNotNull(Helper.AddressGenerator);
    }
}
