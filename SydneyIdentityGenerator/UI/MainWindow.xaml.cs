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

        public MainWindow()
        {
            InitializeComponent();
            Cb_AvailableRegions.ItemsSource = new List<string> { "Sydney, NSW" };
            Cb_AvailableRegions.SelectedIndex = 0;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Btn_GenerateCSV_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
