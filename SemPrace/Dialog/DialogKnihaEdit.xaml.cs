using SemPrace.Classes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SemPrace.Dialog
{

    public partial class DialogKnihaEdit : Window
    {
        public String Nazev { get; set; }
        public String Autor { get; set; }
        public int RokVydani { get; set; }

        public DialogKnihaEdit(Kniha kniha)

        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            Nazev = kniha.Nazev;
            Autor = kniha.Autor;
            RokVydani = kniha.RokVydani;
            ConfirmButton.IsEnabled = false;
            NazevTextBox.Text = Nazev;
            RokVydaniTextBox.Text = RokVydani.ToString();
            AutorTextBox.Text = Autor;


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
            if (IsTextFilled())
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
        
        private bool IsNumeric(string text)
        {
            return int.TryParse(text, out _);
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
            if (!IsNumeric(RokVydaniTextBox.Text))
            {
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
    }
}
