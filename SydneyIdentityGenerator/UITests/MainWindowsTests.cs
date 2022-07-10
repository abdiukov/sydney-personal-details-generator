namespace UITests;
class MainWindowsTests
{
    // Tests to add:
    // 1. GenerateCsvFileName => should generate a name successfully
    // 2. NumberValidationTextBox => if input is not a number; should fail
    // 3. NumberValidationTextBox => if input is a number; should pass
    // 4. Btn_GenerateCSV_ClickAsync => if TextBoxOutputFileName?.Text is null, should call generateCsvFileName()
    // 5. Btn_GenerateCSV_ClickAsync => if TextBoxNumberOfRecords.Text is not a number; should throw
    // 6. Btn_GenerateCSV_ClickAsync => fileName should always have `.csv` at the end
    // 7. Btn_GenerateCSV_ClickAsync => if no checkboxes are clicked, should return nothing and delegate should be null
    // 8. Btn_GenerateCSV_ClickAsync => should call GeneratePersonsAndWriteToCsv and pass all the parameters
    // 9. Btn_GenerateCSV_ClickAsync => if everything was completed successfully, and messagebox is Yes, should call processor and open file
    // 10. Btn_GenerateCSV_ClickAsync => if everything was completed successfully, and messagebox is No, should do nothing.
}