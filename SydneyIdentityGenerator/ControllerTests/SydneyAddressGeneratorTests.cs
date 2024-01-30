using Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllerTests;

[TestClass]
public class SydneyAddressGeneratorTests
{
    private readonly IAddressGenerator _addressGenerator = new SydneyAddressGenerator();

    [TestMethod]
    public void GetRandomAddressShouldReturnNonNullValue()
    {
        string address = _addressGenerator.GetRandomAddress();
        Assert.IsNotNull(address);
    }
}