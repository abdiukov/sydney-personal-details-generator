using Controller;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using Control = Controller.Control;

namespace UI;

public partial class MainWindow
{
    private readonly Control _control;
    public MainWindow()
    {
        InitializeComponent();
        _control = new Control();
    }

    private async Task ProcessUserInput()
    {
        // Defining
        var fileName = GenerateCsvFileName();
        var amountOfRecordsToGenerate = int.Parse(TextBoxNumberOfRecords.Text);
        Control.Builder builder = null;

        // Validating user input
        if (amountOfRecordsToGenerate < 1)
            throw new InvalidOperationException("The number in \"Number of records to generate\" field has to be at least 1");

        if (CheckBoxFirstName.IsChecked == true)
            builder += x => x.BuildFirstName();

        if (CheckBoxLastName.IsChecked == true)
            builder += x => x.BuildLastName();

        if (CheckBoxAddress.IsChecked == true)
            builder += x => x.BuildAddress();

        if (CheckBoxPhoneNumber.IsChecked == true)
            builder += x => x.BuildPhoneNumber();

        if (CheckBoxDateOfBirth.IsChecked == true)
            builder += x => x.BuildDateOfBirth();

        if (CheckBoxGender.IsChecked == true)
            builder += x => x.BuildGender();

        if (CheckBoxEmail.IsChecked == true)
            builder += x => x.BuildEmail();

        // Calling method to generate and write onto csv file
        var records = GeneratePersons(amountToGenerate, builder);
        await CsvFileWriter.WriteToFile(fileName, records).ConfigureAwait(false);

        // Showing confirmation message to user
        var confirmOpenFileMessageBox = MessageBox.Show("Would you like to open it now?",
            $"File {fileName} has been successfully created.", MessageBoxButton.YesNo, MessageBoxImage.Information);

        if (confirmOpenFileMessageBox is MessageBoxResult.Yes)
        {
            var fileOpener = new Process
            {
                StartInfo = { FileName = "explorer", Arguments = $"\"{fileName}\"" }
            };
            fileOpener.Start();
        }

    }

    private async void Btn_GenerateCSV_ClickAsync(object sender, RoutedEventArgs e)
    {
        try
        {
            await ProcessUserInput();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private static string GenerateCsvFileName() => $"{DateTime.Now.Ticks}.csv";
}