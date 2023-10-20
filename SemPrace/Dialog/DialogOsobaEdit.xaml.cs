using SemPrace.Classes;
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
    /// Interakční logika pro DialogOsobaEdit.xaml
    /// </summary>
    public partial class DialogOsobaEdit : Window
    {
        public String Jmeno { get; set; }
        public String Prijmeni { get; set; }
        public DialogOsobaEdit(Osoba osoba)
        {
            InitializeComponent();
            Jmeno = osoba.Jmeno;
            Prijmeni = osoba.Prijmeni;
            JmenoTextBox.Text = osoba.Jmeno;
            PrijmeniTextBox.Text = osoba.Prijmeni;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Jmeno = JmenoTextBox.Text;
            Prijmeni = PrijmeniTextBox.Text;
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void PrijmeniTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (JeTextVyplnen())
            {
                ConfirmButton.IsEnabled = true;
            }
            else { ConfirmButton.IsEnabled = false; }
        }

        private void JmenoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (JeTextVyplnen())
            {
                ConfirmButton.IsEnabled = true;
            }
            else { ConfirmButton.IsEnabled = false; }
        }
        private bool JeTextVyplnen()
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
