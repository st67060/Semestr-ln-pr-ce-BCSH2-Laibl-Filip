using SemPrace.Classes;
using SemPrace.Dialog;
using SemPrace.Utility;
using SemPrace.ViewModel;
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

    public partial class MainWindow : Window
    {
        ObservableCollection<Knihovna> knihovnyObs; //Hlavní kolekce knihoven
        DBConnect db = new DBConnect(); //Databáze
        GeneratorDat gt = new GeneratorDat(); //generátor Dat

        public MainWindow()
        {
            //knihovnyObs = db.LoadDataFromDatabase(); //Načte data z Databáze
            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Nastaví okno doprostřed obrazovky
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            MouseLeftButtonDown += Window_MouseLeftButtonDown; //Listener pro pohyb s oknem
            //Nastavení komponentů na výchozí hodnotu
            SetButtonsTo(false);
            comboBoxOsoba.SelectedIndex = 0;
            comboBoxKniha.SelectedIndex = 0;
            listViewKnihovna.ItemsSource = knihovnyObs;

        }
        
        private void listViewKnihovna_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            bool isAnyKnihaSelected = listViewKnihovna.SelectedItems.Count > 0;

            buttonOdebratKnihovna.IsEnabled = isAnyKnihaSelected;
            buttonUpravitKnihovna.IsEnabled = isAnyKnihaSelected;
            buttonPridatKniha.IsEnabled = isAnyKnihaSelected;
            buttonPridatKniha.IsEnabled = isAnyKnihaSelected;
            buttonPridatOsoba.IsEnabled = isAnyKnihaSelected;
            buttonGeneKniha.IsEnabled = isAnyKnihaSelected;
            buttonGeneOsoba.IsEnabled = isAnyKnihaSelected;
        }
        private void listViewKnihovna_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isAnyKnihaSelected = listViewKnihovna.SelectedItems.Count > 0;
            comboBoxKniha.SelectedIndex = 0;
            comboBoxOsoba.SelectedIndex = 0;
            SetSearchBarToDefault(HledatListViewKniha);
            SetSearchBarToDefault(HledatListViewOsoba);
            buttonOdebratKnihovna.IsEnabled = isAnyKnihaSelected;
            buttonUpravitKnihovna.IsEnabled = isAnyKnihaSelected;
            buttonPridatKniha.IsEnabled = isAnyKnihaSelected;
            buttonPridatOsoba.IsEnabled = isAnyKnihaSelected;
            buttonGeneKniha.IsEnabled = isAnyKnihaSelected;
            buttonGeneOsoba.IsEnabled = isAnyKnihaSelected;
            int selectedIndex = listViewKnihovna.SelectedIndex;
            if (selectedIndex >= 0)
            {
                listViewKniha.ItemsSource = knihovnyObs[selectedIndex].Knihy;
                listViewOsoba.ItemsSource = knihovnyObs[selectedIndex].RegistrovaneOsoby;
            }


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
                Knihovna temp = new Knihovna(dialog.Nazev, dialog.Lokalita);
                temp.Id = gt.GenerateUniqueId();
                knihovnyObs.Add(temp);
                db.SaveKnihovnaToDatabase(temp);

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
                    db.SaveKnihovnaToDatabase(temp);
                }
            }
        }

        private void buttonOdebratKnihovna_Click(object sender, RoutedEventArgs e)
        {
            DialogConfirm dialog = new DialogConfirm();
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                int selectedIndex = listViewKnihovna.SelectedIndex;
                db.RemoveKnihovnaById(knihovnyObs[selectedIndex].Id);
                knihovnyObs.RemoveAt(selectedIndex);
                listViewKniha.ItemsSource = null;
                listViewOsoba.ItemsSource = null;
            }

        }

        private void buttonPridatKniha_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listViewKnihovna.SelectedIndex;

            if (selectedIndex >= 0)
            {  DialogKnihaAddViewModel viewModel = new DialogKnihaAddViewModel();
                View.DialogKnihaAdd dialog = new View.DialogKnihaAdd(viewModel);
                bool? result = dialog.ShowDialog();

                if (result == true)
                {
                    Kniha temp = new Kniha(viewModel.Nazev, viewModel.Autor, viewModel.RokVydani);
                    temp.Id = gt.GenerateUniqueId();
                    temp.IdKnihovna = knihovnyObs[selectedIndex].Id;
                    knihovnyObs[selectedIndex].AddKniha(temp);
                    db.SaveKnihaToDatabase(temp);
                }
            }
        }

        private void buttonUpravitKniha_Click(object sender, RoutedEventArgs e)
        {
            Kniha temp = listViewKniha.SelectedItem as Kniha;
            if (temp != null)
            {
                DialogKnihaEditViewModel viewModel = new DialogKnihaEditViewModel(temp);
                View.DialogKnihaEdit dialog = new  View.DialogKnihaEdit(viewModel);
                bool? result = dialog.ShowDialog();

                if (result == true)
                {
                    temp.Nazev = viewModel.Nazev;
                    temp.Autor = viewModel.Autor;
                    temp.RokVydani = viewModel.RokVydani;
                    db.SaveKnihaToDatabase(temp);
                }
            }


        }

        private void buttonOdebratKniha_Click(object sender, RoutedEventArgs e)
        {
            DialogConfirm dialog = new DialogConfirm();
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                int selectedIndexKnihovna = listViewKnihovna.SelectedIndex;
                int selectedIndexKniha = listViewKniha.SelectedIndex;
                db.RemoveKnihaById(knihovnyObs[selectedIndexKnihovna].Knihy[selectedIndexKniha].Id);
                knihovnyObs[selectedIndexKnihovna].Knihy.RemoveAt(selectedIndexKniha);
            }
        }

        private void buttonPridatVyp_Click(object sender, RoutedEventArgs e)
        {
            DialogVypujckaPridat dialog = new DialogVypujckaPridat(knihovnyObs[listViewKnihovna.SelectedIndex]);
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                Kniha vybranaKniha = listViewKniha.SelectedItem as Kniha;
                vybranaKniha.SetVypujcka(dialog.Osoba, dialog.DateZacatek, dialog.DateKonec);
                buttonUpravVyp.IsEnabled = true;
                buttonOdeberVyp.IsEnabled = true;
                db.SaveDataToDatabase(knihovnyObs);
            }

        }

        private void buttonUpravVyp_Click(object sender, RoutedEventArgs e)
        {
            Kniha vybranaKniha = listViewKniha.SelectedItem as Kniha;
            if (vybranaKniha != null)
            {
                vybranaKniha.ExtendVypujcka();
                db.SaveDataToDatabase(knihovnyObs);
            }
        }

        private void buttonOdeberVyp_Click(object sender, RoutedEventArgs e)
        {
            Kniha vybranaKniha = listViewKniha.SelectedItem as Kniha;
            if (vybranaKniha != null)
            {
                vybranaKniha.RemoveVypujcka();
                buttonUpravVyp.IsEnabled = false;
                buttonOdeberVyp.IsEnabled = false;
                db.SaveDataToDatabase(knihovnyObs);
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
                    Osoba temp = new Osoba(dialog.Jmeno, dialog.Prijmeni);
                    temp.Id = gt.GenerateUniqueId();
                    temp.IdKnihovna = knihovnyObs[selectedIndex].Id;
                    knihovnyObs[selectedIndex].AddOsoba(temp);
                    db.SaveOsobaToDatabase(temp);
                }
            }
        }

        private void buttonUpravitOsoba_Click(object sender, RoutedEventArgs e)
        {
            Osoba temp = listViewOsoba.SelectedItem as Osoba;
            if (temp != null)
            {
                DialogOsobaEdit dialog = new DialogOsobaEdit(temp);
                bool? result = dialog.ShowDialog();

                if (result == true)
                {
                    temp.Jmeno = dialog.Jmeno;
                    temp.Prijmeni = dialog.Prijmeni;
                    db.SaveOsobaToDatabase(temp);
                }
            }
        }

        private void buttonOdebratOsoba_Click(object sender, RoutedEventArgs e)
        {
            DialogConfirm dialog = new DialogConfirm();
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                int selectedIndexKnihovna = listViewKnihovna.SelectedIndex;
                int selectedIndexOsoba = listViewOsoba.SelectedIndex;
                db.RemoveOsobaById(knihovnyObs[selectedIndexKnihovna].RegistrovaneOsoby[selectedIndexOsoba].Id);
                knihovnyObs[selectedIndexKnihovna].RegistrovaneOsoby.RemoveAt(selectedIndexOsoba);
            }
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

                    if (item.Jmeno.ToLower().Contains(searchText) || item.Prijmeni.ToLower().Contains(searchText) || item.UzivatelskeCislo.ToLower().Contains(searchText))

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
            if (listViewKnihovna.SelectedIndex >= 0)
            {
                if (string.IsNullOrWhiteSpace(HledatListViewKniha.Text))
                {
                    SetSearchBarToDefault(HledatListViewKniha);

                }
                string searchText = HledatListViewKniha.Text.ToLower();
                List<Kniha> filteredItems = new List<Kniha>();
                if (string.IsNullOrEmpty(searchText) || HledatListViewKniha.Text == "Hledat...")
                {

                    listViewKniha.ItemsSource = knihovnyObs[listViewKnihovna.SelectedIndex].Knihy;
                }
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
            if (listViewKnihovna.SelectedIndex >= 0)
            {
                if (string.IsNullOrWhiteSpace(HledatListViewOsoba.Text))
                {
                    SetSearchBarToDefault(HledatListViewOsoba);
                }
                string searchText = HledatListViewOsoba.Text.ToLower();
                List<Osoba> filteredItems = new List<Osoba>();
                if (string.IsNullOrEmpty(searchText) || HledatListViewOsoba.Text == "Hledat...")
                {

                    listViewOsoba.ItemsSource = knihovnyObs[listViewKnihovna.SelectedIndex].RegistrovaneOsoby;
                }
            }
        }

        private void comboBoxKniha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewKnihovna.SelectedIndex >= 0)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)comboBoxKniha.SelectedItem;
                string selectedOption = selectedItem.Content.ToString();

                if (selectedOption == "Výchozí")
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

                if (selectedOption == "Výchozí")
                {
                    listViewOsoba.ItemsSource = knihovnyObs[listViewKnihovna.SelectedIndex].RegistrovaneOsoby;
                }
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
            View.DialogConfirm dialog = new View.DialogConfirm();
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                Close();
            }
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }


        private void buttonNactiData_Click(object sender, RoutedEventArgs e)
        {
            //knihovnyObs = db.LoadDataFromDatabase();
        }


        private void buttonGeneKnihovna_Click(object sender, RoutedEventArgs e)
        {
            Knihovna temp = gt.GenerateKnihovna();
            knihovnyObs.Add(temp);
            db.SaveKnihovnaToDatabase(temp);
        }

        private void buttonGeneKniha_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listViewKnihovna.SelectedIndex;
            Kniha temp = gt.GenerateKniha(knihovnyObs[selectedIndex]);
            knihovnyObs[selectedIndex].AddKniha(temp);
            db.SaveKnihaToDatabase(temp);
        }

        private void buttonGeneOsoba_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listViewKnihovna.SelectedIndex;
            Osoba temp = gt.GenerateOsoba(knihovnyObs[selectedIndex]);
            knihovnyObs[selectedIndex].AddOsoba(temp);
            db.SaveOsobaToDatabase(temp);
        }

        private void SetButtonsTo(bool boolean)
        {
            buttonOdebratKnihovna.IsEnabled = boolean;
            buttonUpravitKnihovna.IsEnabled = boolean;
            buttonPridatKniha.IsEnabled = boolean;
            buttonPridatOsoba.IsEnabled = boolean;
            buttonUpravitKniha.IsEnabled = boolean;
            buttonOdebratKniha.IsEnabled = boolean;
            buttonPridatVyp.IsEnabled = boolean;
            buttonUpravVyp.IsEnabled = boolean;
            buttonOdeberVyp.IsEnabled = boolean;
            buttonUpravitOsoba.IsEnabled = boolean;
            buttonOdebratOsoba.IsEnabled = boolean;
            buttonZobrazVypKnihyOsoba.IsEnabled = boolean;
            buttonGeneKniha.IsEnabled = boolean;
            buttonGeneOsoba.IsEnabled = boolean;
        }
        private void SetSearchBarToDefault(TextBox textBox)
        {
            textBox.Text = "Hledat...";
            textBox.Foreground = Brushes.Gray;
        }

       
    }
}
