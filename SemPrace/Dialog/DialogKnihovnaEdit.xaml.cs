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
    /// Interakční logika pro DialogKnihovnaEdit.xaml
    /// </summary>
    public partial class DialogKnihovnaEdit : Window
    {
        public String Nazev { get; set; }
        public String Lokalita { get; set; }

        public DialogKnihovnaEdit(Knihovna knihovna)
        {
            Nazev = null;
            Lokalita = null;
            InitializeComponent();
            NameTextBox.Text = knihovna.Nazev;
            LokalitaTextBox.Text = knihovna.Lokalita;
            ConfirmButton.IsEnabled = false;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Nazev = NameTextBox.Text;
            Lokalita = LokalitaTextBox.Text;
            DialogResult = true;
            Close();
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (JeTextVyplnen())
            {
                ConfirmButton.IsEnabled = true;
            }
            else { ConfirmButton.IsEnabled = false; }
        }

        private void LokalitaTextBox_TextChanged(object sender, TextChangedEventArgs e)
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
