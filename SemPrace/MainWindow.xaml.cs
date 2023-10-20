using SemPrace.Classes;
using SemPrace.Dialog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace SemPrace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Knihovna> knihovnyObs = new ObservableCollection<Knihovna>();

        public MainWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            MouseLeftButtonDown += Window_MouseLeftButtonDown;
            
            buttonOdebratKnihovna.IsEnabled = false;
            buttonUpravitKnihovna.IsEnabled = false;
            buttonPridatKniha.IsEnabled = false;
            buttonPridatOsoba.IsEnabled = false;
            buttonUpravitKniha.IsEnabled = false;
            buttonOdebratKniha.IsEnabled = false;
            buttonPridatVyp.IsEnabled = false;
            buttonUpravVyp.IsEnabled = false;
            buttonOdeberVyp.IsEnabled = false;
            buttonUpravitOsoba.IsEnabled = false;
            buttonOdebratOsoba.IsEnabled = false;
            buttonZobrazVypKnihyOsoba.IsEnabled = false;
           comboBoxKniha.SelectedIndex = 0;

            Knihovna knihovna = new Knihovna("Univerzitni", "Pardubice");
            Kniha kniha = new Kniha("Robot", "Karel Čapek", 1998);
            Osoba osoba = new Osoba("Václav", "Pavlíček");
            knihovna.PridatKniha(kniha);
            knihovna.PridatOsobu(osoba);

            knihovnyObs.Add(knihovna);
            listViewKnihovna.ItemsSource = knihovnyObs;
            listViewKniha.ItemsSource = knihovna.Knihy;
            listViewOsoba.ItemsSource = knihovna.RegistrovaneOsoby;

        }
        private void listViewKnihovna_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            bool isAnyKnihaSelected = listViewKnihovna.SelectedItems.Count > 0;

            buttonOdebratKnihovna.IsEnabled = isAnyKnihaSelected;
            buttonUpravitKnihovna.IsEnabled = isAnyKnihaSelected;
            buttonPridatKniha.IsEnabled = isAnyKnihaSelected;
            buttonPridatOsoba.IsEnabled = isAnyKnihaSelected;
        }
        private void listViewKnihovna_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isAnyKnihaSelected = listViewKnihovna.SelectedItems.Count > 0;

            buttonOdebratKnihovna.IsEnabled = isAnyKnihaSelected;
            buttonUpravitKnihovna.IsEnabled = isAnyKnihaSelected;
            buttonPridatKniha.IsEnabled = isAnyKnihaSelected;
            buttonPridatOsoba.IsEnabled = isAnyKnihaSelected;
            int selectedIndex = listViewKnihovna.SelectedIndex;
            listViewKniha.ItemsSource = knihovnyObs[selectedIndex].Knihy;
            listViewOsoba.ItemsSource = knihovnyObs[selectedIndex].RegistrovaneOsoby;
        }
        private void listViewKniha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isAnyKnihaSelected = listViewKniha.SelectedItems.Count > 0;
            bool isAnyVypSelected = isAnyKnihaSelected && ((Kniha)listViewKniha.SelectedItem).Vypujceni;

            buttonUpravitKniha.IsEnabled = isAnyKnihaSelected;
            buttonOdebratKniha.IsEnabled = isAnyKnihaSelected;
            buttonPridatVyp.IsEnabled = isAnyKnihaSelected;
            buttonUpravVyp.IsEnabled = isAnyVypSelected;
            buttonOdeberVyp.IsEnabled = isAnyVypSelected;
        }

        private void listViewOsoba_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isAnyOsobaSelected = listViewOsoba.SelectedItems.Count > 0;
            bool isAnyKnihovnaSelected = listViewKnihovna.SelectedItems.Count > 0;

            buttonPridatOsoba.IsEnabled = isAnyOsobaSelected;
            buttonUpravitOsoba.IsEnabled = isAnyOsobaSelected;
            buttonOdebratOsoba.IsEnabled = isAnyOsobaSelected;
            buttonZobrazVypKnihyOsoba.IsEnabled = isAnyOsobaSelected && isAnyKnihovnaSelected;
        }
        private void buttonPridatKnihovna_Click(object sender, RoutedEventArgs e)
        {
            DialogKnihovna dialog = new DialogKnihovna();
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                knihovnyObs.Add(new Knihovna(dialog.Nazev, dialog.Lokalita));
            }
        }

        private void buttonUpravitKnihovna_Click(object sender, RoutedEventArgs e)
        {
            Knihovna temp = listViewKnihovna.SelectedItem as Knihovna;
            if (temp != null)
            {
                DialogKnihovnaEdit dialog = new DialogKnihovnaEdit(temp);
                bool? result = dialog.ShowDialog();

                if (result == true)
                {
                    temp.Nazev = dialog.Nazev;
                    temp.Lokalita = dialog.Lokalita;
                }
            }
        }

        private void buttonOdebratKnihovna_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listViewKnihovna.SelectedIndex;
            knihovnyObs.RemoveAt(selectedIndex);
        }

        private void buttonPridatKniha_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listViewKnihovna.SelectedIndex;

            if (selectedIndex >= 0)
            {
                DialogKnihaPridat dialog = new DialogKnihaPridat();
                bool? result = dialog.ShowDialog();

                if (result == true)
                {
                    Kniha kniha = new Kniha(dialog.Nazev, dialog.Autor, dialog.RokVydani);
                    knihovnyObs[selectedIndex].PridatKniha(kniha);
                }
            }
        }

        private void buttonUpravitKniha_Click(object sender, RoutedEventArgs e)
        {
            Kniha kniha = listViewKniha.SelectedItem as Kniha;
            if (kniha != null)
            {
                DialogKnihaEdit dialog = new DialogKnihaEdit(kniha);
                bool? result = dialog.ShowDialog();

                if (result == true)
                {
                    kniha.Nazev = dialog.Nazev;
                    kniha.Autor = dialog.Autor;
                    kniha.RokVydani = dialog.RokVydani;
                }
            }


        }

        private void buttonOdebratKniha_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndexKnihovna = listViewKnihovna.SelectedIndex;
            int selectedIndexKniha = listViewKniha.SelectedIndex;
            knihovnyObs[selectedIndexKnihovna].Knihy.RemoveAt(selectedIndexKniha);
        }

        private void buttonPridatVyp_Click(object sender, RoutedEventArgs e)
        {
            DialogVypujckaPridat dialog = new DialogVypujckaPridat(knihovnyObs[listViewKnihovna.SelectedIndex]);
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                Kniha vybranaKniha = listViewKniha.SelectedItem as Kniha;
                vybranaKniha.zadejVypujcku(dialog.Osoba, dialog.DateZacatek, dialog.DateKonec);
                buttonUpravVyp.IsEnabled = true;
                buttonOdeberVyp.IsEnabled = true;
            }

        }

        private void buttonUpravVyp_Click(object sender, RoutedEventArgs e)
        {
            Kniha vybranaKniha = listViewKniha.SelectedItem as Kniha;
            if (vybranaKniha != null)
            {
                vybranaKniha.prodluzVypujcku();
            }
        }

        private void buttonOdeberVyp_Click(object sender, RoutedEventArgs e)
        {
            Kniha vybranaKniha = listViewKniha.SelectedItem as Kniha;
            if (vybranaKniha != null)
            {
                vybranaKniha.odeberVypujcku();
                buttonUpravVyp.IsEnabled = false;
                buttonOdeberVyp.IsEnabled = false;
            }
        }

        private void buttonPridatOsoba_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listViewKnihovna.SelectedIndex;

            if (selectedIndex >= 0)
            {
                DialogOsobaPridat dialog = new DialogOsobaPridat();
                bool? result = dialog.ShowDialog();

                if (result == true)
                {
                    Osoba osoba = new Osoba(dialog.Jmeno,dialog.Prijmeni);
                    knihovnyObs[selectedIndex].PridatOsobu(osoba);
                }
            }
        }

        private void buttonUpravitOsoba_Click(object sender, RoutedEventArgs e)
        {
            Osoba osoba = listViewOsoba.SelectedItem as Osoba;
            if (osoba != null)
            {
                DialogOsobaEdit dialog = new DialogOsobaEdit(osoba);
                bool? result = dialog.ShowDialog();

                if (result == true)
                {
                    osoba.Jmeno = dialog.Jmeno;
                    osoba.Prijmeni = dialog.Prijmeni;
                }
            }
        }

        private void buttonOdebratOsoba_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndexKnihovna = listViewKnihovna.SelectedIndex;
            int selectedIndexOsoba = listViewOsoba.SelectedIndex;
            knihovnyObs[selectedIndexKnihovna].RegistrovaneOsoby.RemoveAt(selectedIndexOsoba);
        }

        private void buttonZobrazVypKnihyOsoba_Click(object sender, RoutedEventArgs e)
        {
            Osoba osoba = listViewOsoba.SelectedItem as Osoba;
            if (osoba != null)
            {
                DialogOsobaListKnihy dialog = new DialogOsobaListKnihy(osoba);
                bool? result = dialog.ShowDialog();

                
            }
        }

        private void HledatListViewKniha_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (listViewKnihovna.SelectedIndex >= 0)
            {
                string searchText = HledatListViewKniha.Text.ToLower();
                List<Kniha> filteredItems = new List<Kniha>();
                if (string.IsNullOrEmpty(searchText) || HledatListViewKniha.Text == "Hledat...")
                {

                    listViewKniha.ItemsSource = knihovnyObs[listViewKnihovna.SelectedIndex].Knihy;
                }

                foreach (Kniha item in knihovnyObs[listViewKnihovna.SelectedIndex].Knihy)
                {

                    if (item.Nazev.ToLower().Contains(searchText) || item.Autor.ToLower().Contains(searchText) || item.RokVydani.ToString().Contains(searchText) ||
                        item.DatumVypujceni.ToString().Contains(searchText) || item.DatumNavraceni.ToString().Contains(searchText))
                        
                    {
                        filteredItems.Add(item);
                    }
                }
                listViewKniha.ItemsSource = filteredItems;
            }
        }









        private void HledatListViewOsoba_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (listViewKnihovna.SelectedIndex >= 0)
            {
                string searchText = HledatListViewOsoba.Text.ToLower();
                List<Osoba> filteredItems = new List<Osoba>();
                if (string.IsNullOrEmpty(searchText) || HledatListViewOsoba.Text == "Hledat...")
                {

                    listViewOsoba.ItemsSource = knihovnyObs[listViewKnihovna.SelectedIndex].RegistrovaneOsoby;
                }

                foreach (Osoba item in knihovnyObs[listViewKnihovna.SelectedIndex].RegistrovaneOsoby)
                {

                    if (item.Jmeno.ToLower().Contains(searchText) || item.Prijmeni.ToLower().Contains(searchText) || item.Id.ToLower().Contains(searchText))

                    {
                        filteredItems.Add(item);
                    }
                }
                listViewOsoba.ItemsSource = filteredItems;
            }

        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (HledatListViewKniha.Text == "Hledat...")
            {
                HledatListViewKniha.Text = "";
                HledatListViewKniha.Foreground = Brushes.Black; 
            }
            
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(HledatListViewKniha.Text))
            {
                HledatListViewKniha.Text = "Hledat...";
                HledatListViewKniha.Foreground = Brushes.Gray; 
            }
            string searchText = HledatListViewKniha.Text.ToLower();
            List<Kniha> filteredItems = new List<Kniha>();
            if (string.IsNullOrEmpty(searchText) || HledatListViewKniha.Text == "Hledat...")
            {

                listViewKniha.ItemsSource = knihovnyObs[listViewKnihovna.SelectedIndex].Knihy;
            }

        }
        private void SearchTextBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (HledatListViewOsoba.Text == "Hledat...")
            {
                HledatListViewOsoba.Text = "";
                HledatListViewOsoba.Foreground = Brushes.Black;
            }
            
        }
        private void SearchTextBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(HledatListViewOsoba.Text))
            {
                HledatListViewOsoba.Text = "Hledat...";
                HledatListViewOsoba.Foreground = Brushes.Gray;
            }
            string searchText = HledatListViewOsoba.Text.ToLower();
            List<Osoba> filteredItems = new List<Osoba>();
            if (string.IsNullOrEmpty(searchText) || HledatListViewOsoba.Text == "Hledat...")
            {

                listViewOsoba.ItemsSource = knihovnyObs[listViewKnihovna.SelectedIndex].RegistrovaneOsoby;
            }
        }

        private void comboBoxKniha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewKnihovna.SelectedIndex >= 0)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)comboBoxKniha.SelectedItem;
                string selectedOption = selectedItem.Content.ToString();

                if (selectedOption == "Všechny knihy")
                {
                    listViewKniha.ItemsSource = knihovnyObs[listViewKnihovna.SelectedIndex].Knihy;
                }
                else if (selectedOption == "Vypůjčené knihy")
                {
                    List<Kniha> vypujceneKnihy = knihovnyObs[listViewKnihovna.SelectedIndex].Knihy.Where(k => k.Vypujceni).ToList();
                    listViewKniha.ItemsSource = vypujceneKnihy;
                }
                else if (selectedOption == "Nevypůjčené knihy")
                {
                    List<Kniha> vypujceneKnihy = knihovnyObs[listViewKnihovna.SelectedIndex].Knihy.Where(k => !k.Vypujceni).ToList();
                    listViewKniha.ItemsSource = vypujceneKnihy;
                }
                else if (selectedOption == "Název")
                {
                    List<Kniha> sortedList = knihovnyObs[listViewKnihovna.SelectedIndex].Knihy.OrderBy(k => k.Nazev).ToList();
                    listViewKniha.ItemsSource = sortedList;
                }
                else if (selectedOption == "Autor")
                {
                    List<Kniha> sortedList = knihovnyObs[listViewKnihovna.SelectedIndex].Knihy.OrderBy(k => k.Autor).ToList();
                    listViewKniha.ItemsSource = sortedList;
                }
                else if (selectedOption == "Rok Vydání")
                {
                    List<Kniha> sortedList = knihovnyObs[listViewKnihovna.SelectedIndex].Knihy.OrderBy(k => k.RokVydani).ToList();
                    listViewKniha.ItemsSource = sortedList;
                }
            }
        }

        private void comboBoxOsoba_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewKnihovna.SelectedIndex >= 0)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)comboBoxOsoba.SelectedItem;
                string selectedOption = selectedItem.Content.ToString();

                if (selectedOption == "Jméno")
                {
                    List<Osoba> osoby = knihovnyObs[listViewKnihovna.SelectedIndex].RegistrovaneOsoby.OrderBy(k => k.Jmeno).ToList();
                    listViewOsoba.ItemsSource = osoby;
                }
                else if (selectedOption == "Příjmení")
                {
                    List<Osoba> osoby = knihovnyObs[listViewKnihovna.SelectedIndex].RegistrovaneOsoby.OrderBy(k => k.Prijmeni).ToList();
                    listViewOsoba.ItemsSource = osoby;
                }

            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        // Doplnky
        
    }
}
