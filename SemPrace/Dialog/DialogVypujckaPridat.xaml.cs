using SemPrace.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interakční logika pro DialogVypujckaPridat.xaml
    /// </summary>
    public partial class DialogVypujckaPridat : Window 
    {
        public Osoba Osoba { get; set; }
        public DateOnly DateZacatek { get; set; }
        public DateOnly DateKonec { get; set; }
        public DialogVypujckaPridat(Knihovna knihovna)
        {
            InitializeComponent();
            confirmButton.IsEnabled = false;
            listViewOsoba.ItemsSource = knihovna.RegistrovaneOsoby;
        }

        private void listViewOsoba_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Osoba = listViewOsoba.SelectedItem as Osoba;
            OnPropertyChange();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            Osoba = listViewOsoba.SelectedItem as Osoba;
            DateTime dateIn = calendarIn.SelectedDate.Value;
            DateZacatek = new DateOnly(dateIn.Year, dateIn.Month, dateIn.Day);
            DateTime dateOut = calendarOut.SelectedDate.Value;
            DateKonec = new DateOnly(dateOut.Year, dateOut.Month, dateOut.Day);
            DialogResult = true;
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void calendarIn_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            OnPropertyChange();
        }

        private void calendarOut_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            OnPropertyChange(); 
        }

        private void calendarIn_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dateIn = calendarIn.SelectedDate.Value;
            DateZacatek = new DateOnly(dateIn.Year, dateIn.Month, dateIn.Day);

            textBlockIn.Text = calendarIn.SelectedDate?.ToShortDateString();
            DateTime selectedDate = calendarIn.SelectedDate ?? DateTime.Now;
            if (selectedDate < DateTime.Today)
            {
                calendarIn.SelectedDate = DateTime.Today;
            }
            OnPropertyChange();
        }

        private void calendarOut_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dateOut = calendarOut.SelectedDate.Value;
            DateKonec = new DateOnly(dateOut.Year, dateOut.Month, dateOut.Day);

            textBlockOut.Text = calendarOut.SelectedDate?.ToShortDateString();
            DateTime selectedDate = calendarOut.SelectedDate ?? DateTime.Now;
            if (selectedDate < DateTime.Today)
            {
                calendarOut.SelectedDate = DateTime.Today;
            }
            OnPropertyChange();
        }
        private void OnPropertyChange()
        {
            Console.WriteLine("zmena");
            if (calendarIn.SelectedDate == null || calendarOut.SelectedDate ==null || listViewOsoba.SelectedItem == null || calendarIn.SelectedDate > calendarOut.SelectedDate) {
            confirmButton.IsEnabled = false;    
            }
            else { confirmButton.IsEnabled = true; }
        }
        
    }
}
