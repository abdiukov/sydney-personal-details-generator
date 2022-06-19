using Controller;
using Controller.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace UI;

public partial class MainWindow : Window
{
    private readonly Regex numberRegex = new("[^0-9]+");
    private readonly Control controller = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    void Btn_GenerateCSV_Click(object sender, RoutedEventArgs e)
    {
        //defining
        var parameters = string.Empty;
        var fileName = Textbox_OutputFileName?.Text;
        var amountOfRecordsToGenerate = int.Parse(Textbox_NumberOfRecords.Text);
        MultiDelegate multiDelegate = null;
        var listFunctions = new List<Func<IPerson>>();
        IPerson person = new Male();

        //validating user input
        if (string.IsNullOrEmpty(fileName))
            fileName = GenerateCsvFileName();


        if (amountOfRecordsToGenerate is < 1)
            throw new InvalidOperationException("The number in \"Number of records to generate\" field has to be at least 1");

        if (CheckBox_FirstName.IsChecked == true)
        {
            parameters += "first_name,";
            listFunctions += Visitor.GetFirstName;
        }

        if (CheckBox_LastName.IsChecked == true)
        {
            parameters += "last_name,";
            multiDelegate += Visitor.GetLastName;
        }

        if (CheckBox_Address.IsChecked == true)
        {
            parameters += "address,";
            multiDelegate += Visitor.GetAddress;
        }

        if (CheckBox_PhoneNumber.IsChecked == true)
        {
            parameters += "phone_number,";
            multiDelegate += Visitor.GetPhoneNumber;
        }

        if (CheckBox_DateOfBirth.IsChecked == true)
        {
            parameters += "date_of_birth,";
            multiDelegate += Visitor.GetDateOfBirth;
        }

        if (CheckBox_Gender.IsChecked == true)
        {
            parameters += "gender,";
            multiDelegate += Visitor.GetGender;
        }

        if (CheckBox_Email.IsChecked == true)
        {
            parameters += "email,";
            multiDelegate += Visitor.GetEmail;
        }

        fileName += ".csv";

        if (string.IsNullOrEmpty(parameters))
            throw new InvalidOperationException("Please select at least one field to be put into csv file");

        if (File.Exists(fileName))
            throw new InvalidOperationException("Please choose another file name. This file already exists.");

        //calling the method to generate and write onto csv file
        string result = controller.GeneratePersonsAndWriteToCsv(amountOfRecordsToGenerate, multiDelegate, fileName);


        MessageBox.Show(result);
        if (result == "success")
        {
            if (MessageBox.Show("Would you like to open your csv file?", "The file has been successfully created.", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                var fileOpener = new Process()
                {
                    StartInfo = { FileName = "explorer", Arguments = $"\"{fileName}\"" }
                };
                fileOpener.Start();
            }
        }
    }
    string GenerateCsvFileName() => $"{DateTime.Now.Ticks}";
    void NumberValidationTextBox(object sender, TextCompositionEventArgs e) => e.Handled = numberRegex.IsMatch(e.Text);
}