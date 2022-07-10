using Controller;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Controller.Models;

namespace UI;

public partial class MainWindow
{
    // TODO: numberRegex should force a number to be more than 0
    private readonly Regex _numberRegex = new("[^0-9]+");
    private readonly Control<Person> _controller = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Btn_GenerateCSV_ClickAsync(object sender, RoutedEventArgs e)
    {
        //defining
        var fileName = TextBoxOutputFileName?.Text;
        var amountOfRecordsToGenerate = int.Parse(TextBoxNumberOfRecords.Text);
        Control<Person>.BuildInstructions builder = null;

        //validating user input
        if (string.IsNullOrEmpty(fileName))
            fileName = GenerateCsvFileName();

        fileName += ".csv";

        if (File.Exists(fileName))
            fileName = GenerateCsvFileName();

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
        var result = _controller.GeneratePersonsAndWriteToCsv(amountOfRecordsToGenerate, builder, fileName);

        if (result.IsCompletedSuccessfully)
        {
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
    }

    string GenerateCsvFileName() => $"{DateTime.Now.Ticks}";
    void NumberValidationTextBox(object sender, TextCompositionEventArgs e) => e.Handled = _numberRegex.IsMatch(e.Text);
}