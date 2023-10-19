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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

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

                Knihovna knihovna = new Knihovna(dialog.Nazev, dialog.Lokalita);
                knihovnyObs.Add(knihovna);
            }
        }

        private void buttonUpravitKnihovna_Click(object sender, RoutedEventArgs e)
        {
            Knihovna temp = listViewKnihovna.SelectedItem as Knihovna;
            DialogKnihovnaEdit dialog = new DialogKnihovnaEdit(temp);
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                int selectedIndex = listViewKnihovna.SelectedIndex;
                Knihovna vybranaKnihovna = knihovnyObs[selectedIndex];
                vybranaKnihovna.Nazev = dialog.Nazev;
                vybranaKnihovna.Lokalita = dialog.Lokalita;


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
            DialogKnihaPridat dialog = new DialogKnihaPridat();
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                Kniha kniha = new Kniha(dialog.Nazev, dialog.Autor, dialog.RokVydani);
                knihovnyObs[selectedIndex].PridatKniha(kniha);

            }
        }

        private void buttonUpravitKniha_Click(object sender, RoutedEventArgs e)
        {
            Kniha kniha = listViewKniha.SelectedItem as Kniha;
            DialogKnihaEdit dialog = new DialogKnihaEdit(kniha);
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                int selectedindexKnihovna = listViewKnihovna.SelectedIndex;
                int selectedIndexKniha = listViewKniha.SelectedIndex;
                Kniha vybranaKniha = knihovnyObs[selectedindexKnihovna].Knihy[selectedIndexKniha];
                vybranaKniha.Nazev = dialog.Nazev;
                vybranaKniha.Autor = dialog.Autor;
                vybranaKniha.RokVydani = dialog.RokVydani;


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
            int selectedIndexKnihovna = listViewKnihovna.SelectedIndex;
            int selectedIndexKniha = listViewKniha.SelectedIndex;
            DialogVypujckaPridat dialog = new DialogVypujckaPridat(knihovnyObs[selectedIndexKnihovna]);
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                Kniha vybranaKniha = knihovnyObs[selectedIndexKnihovna].Knihy[selectedIndexKniha];
                vybranaKniha.zadejVypujcku(dialog.Osoba, dialog.DateZacatek, dialog.DateKonec);
                buttonUpravVyp.IsEnabled = true;
                buttonOdeberVyp.IsEnabled = true;

            }

        }

        private void buttonUpravVyp_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndexKnihovna = listViewKnihovna.SelectedIndex;
            int selectedIndexKniha = listViewKniha.SelectedIndex;
            Kniha vybranaKniha = knihovnyObs[selectedIndexKnihovna].Knihy[selectedIndexKniha];
            vybranaKniha.prodluzVypujcku();
        }

        private void buttonOdeberVyp_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndexKnihovna = listViewKnihovna.SelectedIndex;
            int selectedIndexKniha = listViewKniha.SelectedIndex;
            Kniha vybranaKniha = knihovnyObs[selectedIndexKnihovna].Knihy[selectedIndexKniha];
            vybranaKniha.odeberVypujcku();
            buttonUpravVyp.IsEnabled = false;
            buttonOdeberVyp.IsEnabled = false;
        }

        
    }
}
