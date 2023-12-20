
using SemPrace.Model;
using SemPrace.Utility;
using SemPrace.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SemPrace.View
{
    /// <summary>
    /// Interakční logika pro Main.xaml
    /// </summary>
    public partial class Main : Window
    {

        public event EventHandler<string> TextChangedEvent;
        public Main()
        {
            MainViewModel mainViewModel = new MainViewModel();
            InitializeComponent();
            DataContext = mainViewModel;
            mainViewModel.RequestClose += (s, e) => this.Close();
            mainViewModel.RequestMinimize += (s, e) => this.WindowState = WindowState.Minimized; 
        }
        private void HledatListViewKniha_GotFocus(object sender, RoutedEventArgs e)
        {
            if (HledatListViewKniha.Text == "Hledat...")
            {
                HledatListViewKniha.Text = "";
                HledatListViewKniha.Foreground = Brushes.Black;
            }
        }

        private void HledatListViewKniha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(HledatListViewKniha.Text))
            {
                HledatListViewKniha.Text = "Hledat...";
                HledatListViewKniha.Foreground = Brushes.Gray;
            }
        }

        private void HledatListViewOsoba_GotFocus(object sender, RoutedEventArgs e)
        {
            if (HledatListViewOsoba.Text == "Hledat...")
            {
                HledatListViewOsoba.Text = "";
                HledatListViewOsoba.Foreground = Brushes.Black;
            }
        }

        private void HledatListViewOsoba_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(HledatListViewOsoba.Text))
            {
                HledatListViewOsoba.Text = "Hledat...";
                HledatListViewOsoba.Foreground = Brushes.Gray;
            }
        }
        private void comboBoxKniha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedItem = ((ComboBoxItem)comboBox.SelectedItem).Content.ToString();

            (DataContext as MainViewModel)?.UpdateSortingKniha(selectedItem);
        }

        private void comboBoxOsoba_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedItem = ((ComboBoxItem)comboBox.SelectedItem).Content.ToString();

            (DataContext as MainViewModel)?.UpdateSortingOsoba(selectedItem);
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
        
}

