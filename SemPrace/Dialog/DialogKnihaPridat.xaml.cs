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
    /// <summary>
    /// Interakční logika pro DialogKnihaPridat.xaml
    /// </summary>
    public partial class DialogKnihaPridat : Window
    {
        public String Nazev { get; set; }
        public String Autor { get; set; }
        public int RokVydani { get; set; }
        public DialogKnihaPridat()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            Nazev = String.Empty;
            Autor = String.Empty;
            RokVydani = int.MinValue;
            ConfirmButton.IsEnabled = false;
            
        }

        private void NazevTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsTextFilled())
            {
                ConfirmButton.IsEnabled = true;
            }
            else { ConfirmButton.IsEnabled = false; }
        }

        private void RokVydaniTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsTextFilled() )
            {
                ConfirmButton.IsEnabled = true;
            }
            else { ConfirmButton.IsEnabled = false; }

        }

        private void AutorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsTextFilled())
            {
                ConfirmButton.IsEnabled = true;
            }
            else { ConfirmButton.IsEnabled = false; }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Nazev = NazevTextBox.Text;
            Autor = AutorTextBox.Text;
            int.TryParse(RokVydaniTextBox.Text, out int rok);
            RokVydani = rok;
            DialogResult = true;
            Close();
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
            if (!IsNumeric(RokVydaniTextBox.Text)) {
            return false;
            }
            return true;
        }

        private void RokVydaniTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string newText = ((TextBox)sender).Text + e.Text;

            if (!IsNumeric(newText))
            {
                e.Handled = true; 
            }
          
        }
        private bool IsNumeric(string text)
        {
            return int.TryParse(text, out _);
        }

        private void RokVydaniTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                e.Handled = true;
            }
        }

        private void RokVydaniTextBox_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsTextFilled())
            {
                ConfirmButton.IsEnabled = true;
            }
            else { ConfirmButton.IsEnabled = false; }
        }
    }
}
