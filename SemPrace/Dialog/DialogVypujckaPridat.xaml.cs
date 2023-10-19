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
    /// Interakční logika pro DialogVypujckaPridat.xaml
    /// </summary>
    public partial class DialogVypujckaPridat : Window
    {
        public DialogVypujckaPridat(Knihovna knihovna)
        {
            InitializeComponent();
            listViewOsoba.ItemsSource = knihovna.RegistrovaneOsoby;
        }

        private void listViewOsoba_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void calendarIn_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            
        }

        private void calendarOut_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            
        }

        private void calendarIn_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            textBlockIn.Text = calendarIn.SelectedDate?.ToShortDateString();
            DateTime selectedDate = calendarIn.SelectedDate ?? DateTime.Now;
            if (selectedDate < DateTime.Today)
            {
                calendarIn.SelectedDate = DateTime.Today;
            }
        }

        private void calendarOut_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            textBlockOut.Text = calendarOut.SelectedDate?.ToShortDateString();
            DateTime selectedDate = calendarOut.SelectedDate ?? DateTime.Now;
            if (selectedDate < DateTime.Today)
            {
                calendarOut.SelectedDate = DateTime.Today;
            }
        }
    }
}
