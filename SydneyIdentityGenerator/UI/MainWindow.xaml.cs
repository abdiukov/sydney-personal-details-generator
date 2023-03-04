using Controller.Services;
using Controller.Services.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace UI;

public partial class MainWindow
{
    IFileWriterService _fileWriterService;
    IPersonCreator _personCreator;

    public MainWindow(IFileWriterService fileWriterService, IPersonCreator personCreator)
    {
        _fileWriterService = fileWriterService;
        _personCreator = personCreator;

        InitializeComponent();
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

    private async Task ProcessUserInput()
    {
        var fileName = GenerateCsvFileName();
        var amountOfRecordsToGenerate = int.Parse(TextBoxNumberOfRecords.Text);
        var builder = ValidateUserInput();

        if (amountOfRecordsToGenerate < 1)
            throw new InvalidOperationException("The number in \"Number of records to generate\" field has to be at least 1");

        if (builder is null)
            throw new ArgumentNullException("Please select at least one checkbox");

        var records = _personCreator.Create(amountOfRecordsToGenerate, builder);
        await _fileWriterService.Write(fileName, records).ConfigureAwait(false);

        ShowOpenFileConfirmationMessage(fileName);
    }

    private IPersonCreator.Builder ValidateUserInput()
    {
        IPersonCreator.Builder builder = null;

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

        return builder;
    }

    private void ShowOpenFileConfirmationMessage(string fileName)
    {
        var confirmOpenFileMessageBox = 
            MessageBox.Show("Would you like to open it now?",
            $"File {fileName} has been successfully created.", MessageBoxButton.YesNo, MessageBoxImage.Information);

        if (confirmOpenFileMessageBox is MessageBoxResult.Yes)
            new Process { StartInfo = { FileName = "explorer", Arguments = $"\"{fileName}\"" } }.Start();
    }

    private static string GenerateCsvFileName() => $"{DateTime.Now.Ticks}.csv";
}