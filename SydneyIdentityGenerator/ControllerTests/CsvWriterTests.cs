using Controller;
using Controller.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllerTests;

[TestClass]
public class CsvWriterTests
{
    [TestMethod]
    public async Task WriteToFileShouldNotThrowException()
    {
        string fileName = Path.GetTempFileName();
        try
        {
            IEnumerable<Person> recordsToWrite = new List<Person> { new Female() { FirstName = "Joan" } };
            await CsvFileWriter.WriteToFile(fileName, recordsToWrite);
        }
        finally
        {
            File.Delete(fileName);
        }
    }

    [TestMethod]
    public async Task WriteToFileShouldWriteCorrectContent()
    {
        string fileName = Path.GetTempFileName();
        var expectedContent = new List<Person> { new Male { FirstName = "John" } };

        try
        {
            await CsvFileWriter.WriteToFile(fileName, expectedContent);

            // Read from the file
            string[] lines = File.ReadAllLines(fileName);

            StringAssert.Contains(lines[0], "FirstName");
            StringAssert.Contains(lines[1], "John");
        }
        finally
        {
            File.Delete(fileName);
        }
    }
    
}