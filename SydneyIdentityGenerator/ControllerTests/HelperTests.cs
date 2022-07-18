using Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllerTests;
class HelperTests
{
    // AddressGenerator:
    [TestMethod]
    public void GenerateRandomSydneyAddressShouldCallHelperRandomNext()
    {
        AddressGenerator generator = new();

    }

    [TestMethod]
    public void GenerateRandomSydneyAddressShouldCallReadFileSkipFirst()
    {
        // 1.5. GenerateRandomSydneyAddress => Should call ReadFile.skip(generatedLine).First()
        AddressGenerator generator = new();


    }

    // Helper:
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

    // CsvFileWriter
    [TestMethod]
    public void WriteShouldCallCsvWriterWriteRecordsAsync()
    {
        CsvFileWriter writer = new();

    }
}
