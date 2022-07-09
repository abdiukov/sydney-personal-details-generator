using Controller;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Controller.Models;

namespace UI;

public partial class MainWindow : Window
{
    private readonly Regex _numberRegex = new("[^0-9]+");
    private readonly Control _controller = new();

    public MainWindow()
    {
        InitializeComponent();
    } 

    private void Btn_GenerateCSV_ClickAsync(object sender, RoutedEventArgs e)
    {
        //defining
        var fileName = Textbox_OutputFileName?.Text;
        var amountOfRecordsToGenerate = int.Parse(Textbox_NumberOfRecords.Text);
        Builder<Person> builder = new();

        //validating user input
        if (string.IsNullOrEmpty(fileName))
            fileName = GenerateCsvFileName();

        fileName += ".csv";

        if (File.Exists(fileName))
            fileName = GenerateCsvFileName();

        if (amountOfRecordsToGenerate is < 1)
            throw new InvalidOperationException("The number in \"Number of records to generate\" field has to be at least 1");

        if (CheckBox_FirstName.IsChecked == true)
            builder.BuildFirstName();

        if (CheckBox_LastName.IsChecked == true)
            builder.BuildLastName();

        if (CheckBox_Address.IsChecked == true)
            builder.BuildAddress();

        if (CheckBox_PhoneNumber.IsChecked == true)
            builder.BuildPhoneNumber();

        if (CheckBox_DateOfBirth.IsChecked == true)
            builder.BuildDateOfBirth();

        if (CheckBox_Gender.IsChecked == true)
            builder.BuildGender();

        if (CheckBox_Email.IsChecked == true)
            builder.BuildEmail();

        //calling the method to generate and write onto csv file
        var result = _controller.GeneratePersonsAndWriteToCsv(amountOfRecordsToGenerate, builder.buildInstructions, fileName);

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