using Controller;
using Controller.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllerTests;

[TestClass]
public class ControlTests
{
    [TestMethod]
    public async Task GeneratePersonsAndWriteToCsvShouldCallAllMethodsAsync()
    {
        // Arrange
        Control<Person>.BuildInstructions instructions = null;
        var amountToGenerate = 10;
        var fileName = "myFile.csv";

        // Act
        await Control<Person>.GeneratePersonsAndWriteToCsv(amountToGenerate, null, fileName);

        // Assert
        
        // GeneratePersons method is called
        // CsvFileWriter.Write method is called


    }

    [TestMethod]
    public void GeneratePersonsAndWriteToCsvIfErrorOccurredShouldReturnTaskFailure()
    {
        // Arrange

        // Act

        // Assert
    }

    [TestMethod]
    public void GeneratePersonsShouldGenerateExpectedAmountOfPersons()
    {
        // Arrange

        // Act

        // Assert
    }

    [TestMethod]
    public void GeneratePersonsShouldWorkIfDelegateIsNull()
    {
        // Arrange

        // Act

        // Assert
    }

    [TestMethod]
    public void GeneratePersonsShouldWorkIfDelegateContainsEverything()
    {
        // Arrange

        // Act

        // Assert
    }

    [TestMethod]
    public void GeneratePersonsShouldContainRoughlyTheSameAmountOfMalesAndFemales()
    {
        // Arrange

        // Act

        // Assert
    }
}