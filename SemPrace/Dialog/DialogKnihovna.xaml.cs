using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SemPrace.Dialog
{

    public partial class DialogKnihovna : Window
    {
        public String Nazev { get; set; }
        public String Lokalita { get; set; }
        public DialogKnihovna()
        {

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            Nazev = null;
            Lokalita = null;
            ConfirmButton.IsEnabled = false;


        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {

            Nazev = NameTextBox.Text;
            Lokalita = LokalitaTextBox.Text;
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();

        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsTextFilled())
            {
                ConfirmButton.IsEnabled = true;
            }
            else { ConfirmButton.IsEnabled = false; }
        }


        private void LokalitaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsTextFilled())
            {
                ConfirmButton.IsEnabled = true;
            }
            else { ConfirmButton.IsEnabled = false; }
        }
        private bool IsTextFilled()
        {
            foreach (var control in grid.Children)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
