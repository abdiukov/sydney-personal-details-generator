using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using Control = Controller.Control;

namespace UI;

public partial class MainWindow
{
    readonly Control _control;
    public MainWindow()
    {
        InitializeComponent();
        _control = new Control();
    }

    private async Task ProcessUserInput()
    {
        //defining
        var fileName = GenerateCsvFileName();
        var amountOfRecordsToGenerate = int.Parse(TextBoxNumberOfRecords.Text);
        Control.BuildInstructions builder = null;

        //validating user input
        if (amountOfRecordsToGenerate < 1)
            throw new InvalidOperationException("The number in \"Number of records to generate\" field has to be at least 1");

        if (CheckBoxFirstName.IsChecked == true)
            builder += t => t.BuildFirstName();

        if (CheckBoxLastName.IsChecked == true)
            builder += t => t.BuildLastName();

        if (CheckBoxAddress.IsChecked == true)
            builder += t => t.BuildAddress();

        if (CheckBoxPhoneNumber.IsChecked == true)
            builder += t => t.BuildPhoneNumber();

        if (CheckBoxDateOfBirth.IsChecked == true)
            builder += t => t.BuildDateOfBirth();

        if (CheckBoxGender.IsChecked == true)
            builder += t => t.BuildGender();

        if (CheckBoxEmail.IsChecked == true)
            builder += t => t.BuildEmail();

        //calling the method to generate and write onto csv file
        await _control.GeneratePersonsAndWriteToCsv(amountOfRecordsToGenerate, builder, fileName);

        //showing confirmation message to user
        var confirmOpenFileMessageBox = MessageBox.Show("Would you like to open your csv file?",
            "The file has been successfully created.", MessageBoxButton.YesNo, MessageBoxImage.Information);
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

    string GenerateCsvFileName() => $"{DateTime.Now.Ticks}.csv";
}