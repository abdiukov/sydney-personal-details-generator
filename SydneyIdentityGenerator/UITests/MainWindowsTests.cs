using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UITests;

[TestClass]
class MainWindowsTests
{
    [TestMethod]
    public void GenerateCsvFileNameShouldGenerateNameSuccessfully()
    {
        //var window = new MainWindow();
        // GenerateCsvFileName();
    }

    [TestMethod]
    public void NumberValidationTextBoxIfInputIsNotNumberShouldFail()
    {

    }

    [TestMethod]
    public void NumberValidationTextBoxIfInputIsNumberShouldPass()
    {

    }

    [TestMethod]
    public void Btn_GenerateCSV_IfTextBoxOutputFileNameIsNullShouldCallGenerateCsvFileName()
    {

    }

    [TestMethod]
    public void Btn_GenerateCSV_IfTextBoxNumberOfRecordsIsNotANumberShouldThrow()
    {

    }

    [TestMethod]
    public void Btn_GenerateCSV_FileNameShouldAlwaysHaveCsvAtTheEnd()
    {

    }

    [TestMethod]
    public void Btn_GenerateCSV_IfNoCheckboxesAreClickedShouldReturnNothingAndDelegateShouldBeNull()
    {

    }

    [TestMethod]
    public void Btn_GenerateCSV_ShouldCallGeneratePersonsAndWriteToCsvWithParameters()
    {

    }

    [TestMethod]
    public void Btn_GenerateCSV_AfterSuccessAndMessageboxIsYesShouldCallProcessorAndOpenFile()
    {

    }

    [TestMethod]
    public void Btn_GenerateCSV_AfterSuccessAndMessageboxIsNoShouldDoNothing()
    {

    }
}