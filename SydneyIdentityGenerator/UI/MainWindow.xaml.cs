using Controller;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Regex regex = new("[^0-9]+");
        private readonly Control controller = new();

        public MainWindow()
        {
            InitializeComponent();
            ComboBox_AvailableRegions.ItemsSource = new List<string> { "Sydney, NSW" };
            ComboBox_AvailableRegions.SelectedIndex = 0;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Btn_GenerateCSV_Click(object sender, RoutedEventArgs e)
        {
            //defining
            string parameters = "";

            //validating user input
            if (!int.TryParse(Textbox_NumberOfRecords.Text, out int amountToGenerate))
            {
                MessageBox.Show("Please enter a whole number into \"Number of records to generate\" field");
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
                parameters += "address";
            }
            if (CheckBox_PhoneNumber.IsChecked == true)
            {
                parameters += "phone_number";
            }
            if (CheckBox_DateOfBirth.IsChecked == true)
            {
                parameters += "dob";
            }
            if (CheckBox_Gender.IsChecked == true)
            {
                parameters += "gender";
            }
            if (CheckBox_Email.IsChecked == true)
            {
                parameters += "email";
            }

            if (parameters == "")
            {
                MessageBox.Show("Please select at least one field to be put into csv file");
                return;
            }

            //some method to call controller to start writing 
            controller.GeneratePersonsAndWriteToCsv(amountToGenerate, parameters);

        }
    }
}
