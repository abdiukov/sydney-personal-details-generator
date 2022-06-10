using Controller;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace UI
{
    public partial class MainWindow : Window
    {
        private readonly Regex regex = new("[^0-9]+");
        private readonly Control controller = new();

        public MainWindow()
        {
            InitializeComponent();
            Textbox_OutputFileName.Text = GenerateCsvFileName();
        }

        private void Btn_GenerateCSV_Click(object sender, RoutedEventArgs e)
        {
            //defining
            string parameters = "";
            string fileName = Textbox_OutputFileName.Text;

            //validating user input
            if (String.IsNullOrEmpty(fileName))
            {
                fileName = GenerateCsvFileName();
            }
            if (!int.TryParse(Textbox_NumberOfRecords.Text, out int amountToGenerate))
            {
                MessageBox.Show("Please enter a whole number into \"Number of records to generate\" field");
                return;
            }
            if (amountToGenerate < 1)
            {
                MessageBox.Show("The number in \"Number of records to generate\" field has to be at least 1");
                return;
            }
            if (CheckBox_FirstName.IsChecked == true)
            {
                parameters += "first_name,";
            }
            if (CheckBox_LastName.IsChecked == true)
            {
                parameters += "last_name,";
            }
            if (CheckBox_Address.IsChecked == true)
            {
                parameters += "address,";
            }
            if (CheckBox_PhoneNumber.IsChecked == true)
            {
                parameters += "phone_number,";
            }
            if (CheckBox_DateOfBirth.IsChecked == true)
            {
                parameters += "dob,";
            }
            if (CheckBox_Gender.IsChecked == true)
            {
                parameters += "gender,";
            }
            if (CheckBox_Email.IsChecked == true)
            {
                parameters += "email";
            }
            if (fileName.Length < 5 || fileName.Substring(fileName.Length - 4) != ".csv")
            {
                fileName += ".csv"; //if the last 4 letters are not csv add ".csv"

            }
            if (parameters == "")
            {
                MessageBox.Show("Please select at least one field to be put into csv file");
                return;
            }
            if (File.Exists(fileName))
            {
                MessageBox.Show("Please choose another file name. This file already exists.");
                return;
            }

            //calling the method to generate and write onto csv file
            string result = controller.GeneratePersonsAndWriteToCsv(amountToGenerate, parameters, fileName);

            //reading whether the csv file was successfully written
            if (result == "success")
            {
                if (MessageBox.Show("Would you like to open your csv file?", "The file has been successfully created.", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    Process fileopener = new();
                    fileopener.StartInfo.FileName = "explorer";
                    fileopener.StartInfo.Arguments = "\"" + fileName + "\"";
                    fileopener.Start();
                }
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private string GenerateCsvFileName()
        {
            return DateTime.Now.Ticks + ".csv";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
