using Model;
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
        private protected Regex regex = new("[^0-9]+");
        private protected Controller.Controller controller = new();

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
            if (!int.TryParse(Textbox_NumberOfRecords.Text, out int amountToGenerate))
            {
                MessageBox.Show("Please enter a whole number into \"Number of records to generate\" field");
                return;
            }

            if (CheckBox_FirstName.IsChecked == true)
            {
                UserChoice.ChosenParameters.Add("first_name");
            }
            if (CheckBox_LastName.IsChecked == true)
            {
                UserChoice.ChosenParameters.Add("last_name");
            }
            if (CheckBox_Gender.IsChecked == true)
            {
                UserChoice.ChosenParameters.Add("gender");
            }
            if (CheckBox_DateOfBirth.IsChecked == true)
            {
                UserChoice.ChosenParameters.Add("dob");
            }
            if (CheckBox_Email.IsChecked == true)
            {
                UserChoice.ChosenParameters.Add("email");
            }
            if (CheckBox_PhoneNumber.IsChecked == true)
            {
                UserChoice.ChosenParameters.Add("phone_number");
            }

            //some method to call controller to start writing 


            //some method to clear the list

        }
    }
}
