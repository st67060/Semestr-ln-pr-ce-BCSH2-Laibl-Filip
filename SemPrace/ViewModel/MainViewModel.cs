using SemPrace.Model;
using SemPrace.Utility;
using SemPrace.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SemPrace.ViewModel
{

    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<KnihovnaViewModel> Knihovny { get; set; }
        public ObservableCollection<KnihaViewModel> Knihy { get; set; }
        public ObservableCollection<OsobaViewModel> Osoby { get; set; }
        public ICommand AddKnihovnaCommand { get; private set; }
        public ICommand EditKnihovnaCommand { get; private set; }
        public ICommand RemoveKnihovnaCommand { get; private set; }
        public ICommand AddKnihaCommand { get; private set; }
        public ICommand EditKnihaCommand { get; private set; }
        public ICommand RemoveKnihaCommand { get; private set; }
        public ICommand AddOsobaCommand { get; private set; }
        public ICommand EditOsobaCommand { get; private set; }
        public ICommand RemoveOsobaCommand { get; private set; }
        public ICommand AddBorrowCommand { get; private set; }
        public ICommand EditBorrowCommand { get; private set; }
        public ICommand RemoveBorrowCommand { get; private set; }
        public ICommand BorrowedBooksCommand { get; private set; }
        public ICommand GenerateKnihovnaCommand { get; private set; }
        public ICommand GenerateKnihaCommand { get; private set; }
        public ICommand GenerateOsobaCommand { get; private set; }
        public ICommand MinimizeCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }


        private KnihovnaViewModel _selectedKnihovna;
        private KnihaViewModel _selectedKniha;
        private OsobaViewModel _selectedOsoba;
        public KnihovnaViewModel SelectedKnihovna
        {
            get { return _selectedKnihovna; }
            set
            {
                if (_selectedKnihovna != value)
                {
                    _selectedKnihovna = value;
                    OnPropertyChanged(nameof(SelectedKnihovna));
                    Knihy = SelectedKnihovna?.Knihy;
                    Osoby = SelectedKnihovna?.RegistrovaneOsoby;
                    OnPropertyChanged(nameof(Knihy));
                    OnPropertyChanged(nameof(Osoby));
                }
            }
        }
        public KnihaViewModel SelectedKniha
        {
            get { return _selectedKniha; }
            set
            {
                if (_selectedKniha != value)
                {
                    _selectedKniha = value;
                    OnPropertyChanged(nameof(SelectedKniha));
                }
            }
        }
        public OsobaViewModel SelectedOsoba
        {
            get { return _selectedOsoba; }
            set
            {
                if (_selectedOsoba != value)
                {
                    _selectedOsoba = value;
                    OnPropertyChanged(nameof(SelectedOsoba));
                }
            }
        }
        private DBConnect connect;
        private GeneratorDat generator;
        public MainViewModel()
        {
            generator = new GeneratorDat();
            connect = new DBConnect();
            Knihovny = connect.LoadDataFromDatabase();
            Knihy = new ObservableCollection<KnihaViewModel>();
            Osoby = new ObservableCollection<OsobaViewModel>();

            AddKnihovnaCommand = new RelayCommand(AddKnihovna);
            EditKnihovnaCommand = new RelayCommand(EditKnihovna, CanEditKnihovna);
            RemoveKnihovnaCommand = new RelayCommand(RemoveKnihovna, CanRemoveKnihovna);

            AddKnihaCommand = new RelayCommand(AddKniha);
            EditKnihaCommand = new RelayCommand(EditKniha, CanEditKniha);
            RemoveKnihaCommand = new RelayCommand(RemoveKniha, CanRemoveKniha);

            AddOsobaCommand = new RelayCommand(AddOsoba);
            EditOsobaCommand = new RelayCommand(EditOsoba, CanEditOsoba);
            RemoveOsobaCommand = new RelayCommand(RemoveOsoba, CanRemoveOsoba);

            AddBorrowCommand = new RelayCommand(AddBorrow, CanEditBorrow);
            EditBorrowCommand = new RelayCommand(EditBorrow, CanEditBorrow);
            RemoveBorrowCommand = new RelayCommand(RemoveBorrow, CanRemoveBorrow);

            BorrowedBooksCommand = new RelayCommand(BorrowedBooks, CanBorrowedBooks);

            GenerateKnihovnaCommand = new RelayCommand(GenerateKnihovna);
            GenerateKnihaCommand = new RelayCommand(GenerateKniha);
            GenerateOsobaCommand = new RelayCommand(GenerateOsoba);

            MinimizeCommand = new RelayCommand(Minimize);
            CloseCommand = new RelayCommand(Close);
        }

        private void AddKnihovna()
        {
            DialogKnihovnaAddViewModel dialogKnihaAddViewModel = new DialogKnihovnaAddViewModel();
            DialogKnihovnaAdd dialog = new DialogKnihovnaAdd(dialogKnihaAddViewModel);
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                Knihovna temp = new Knihovna(dialogKnihaAddViewModel.Nazev, dialogKnihaAddViewModel.Lokalita);
                temp.Id = generator.GenerateUniqueId();
                KnihovnaViewModel knihaViewModel = new KnihovnaViewModel(temp);
                Knihovny.Add(knihaViewModel);
                connect.SaveKnihovnaToDatabase(temp);

            }

        }
        private void EditKnihovna() 
        {
            DialogKnihovnaEditViewModel dialogKnihaEditViewModel = new DialogKnihovnaEditViewModel(SelectedKnihovna);
            DialogKnihovnaEdit dialog = new DialogKnihovnaEdit(dialogKnihaEditViewModel);
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                SelectedKnihovna.Nazev = dialogKnihaEditViewModel.Nazev;
                SelectedKnihovna.Lokalita = dialogKnihaEditViewModel.Lokalita;
                connect.SaveKnihovnaToDatabase(SelectedKnihovna.GetModel());

            }
        }
        private bool CanEditKnihovna() { return _selectedKnihovna != null; }
        private void RemoveKnihovna()
        {
            connect.RemoveKnihovnaById(SelectedKnihovna.Id);
            Knihovny.Remove(SelectedKnihovna);
        }
        private bool CanRemoveKnihovna() { return _selectedKnihovna != null; }

        private void AddKniha()
        {
            DialogKnihaAddViewModel dialogKnihaAddViewModel = new DialogKnihaAddViewModel();
            DialogKnihaAdd dialog = new DialogKnihaAdd(dialogKnihaAddViewModel);
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                Kniha temp = new Kniha(dialogKnihaAddViewModel.Nazev, dialogKnihaAddViewModel.Autor, dialogKnihaAddViewModel.RokVydani);
                temp.Id = generator.GenerateUniqueId();
                temp.IdKnihovna = SelectedKnihovna.Id;
                KnihaViewModel knihaViewModel = new KnihaViewModel(temp);
                Knihy.Add(knihaViewModel);
                connect.SaveKnihaToDatabase(temp);

            }

        }
        private void EditKniha()
        {
            DialogKnihaEditViewModel dialogKnihaEditViewModel = new DialogKnihaEditViewModel(SelectedKniha);
            DialogKnihaEdit dialog = new DialogKnihaEdit(dialogKnihaEditViewModel);
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                SelectedKniha.Nazev = dialogKnihaEditViewModel.Nazev;
                SelectedKniha.Autor = dialogKnihaEditViewModel.Autor;
                SelectedKniha.RokVydani = dialogKnihaEditViewModel.RokVydani;
                connect.SaveKnihaToDatabase(SelectedKniha.GetModel());

            }

        }
        private bool CanEditKniha() { return _selectedKniha != null; }
        private void RemoveKniha()
        {
            connect.RemoveKnihaById(SelectedKniha.Id);
            SelectedKnihovna.Knihy.Remove(SelectedKniha);

        }
        private bool CanRemoveKniha() { return _selectedKniha != null; }

        private void AddOsoba()
        {
            DialogOsobaAddViewModel dialogOsobaAddViewModel = new DialogOsobaAddViewModel();
            DialogOsobaAdd dialog = new DialogOsobaAdd(dialogOsobaAddViewModel);
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                Osoba temp = new Osoba(dialogOsobaAddViewModel.Jmeno, dialogOsobaAddViewModel.Prijmeni);
                temp.Id = generator.GenerateUniqueId();
                temp.IdKnihovna = SelectedKnihovna.Id;
                OsobaViewModel osobaViewModel = new OsobaViewModel(temp);
                Osoby.Add(osobaViewModel);
                connect.SaveOsobaToDatabase(temp);

            }

        }
        private void EditOsoba()
        {
            DialogOsobaEditViewModel dialogOsobaEditViewModel = new DialogOsobaEditViewModel(SelectedOsoba);
            DialogOsobaEdit dialog = new DialogOsobaEdit(dialogOsobaEditViewModel);
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                SelectedOsoba.Jmeno = dialogOsobaEditViewModel.Jmeno;
                SelectedOsoba.Prijmeni = dialogOsobaEditViewModel.Prijmeni;
                connect.SaveOsobaToDatabase(SelectedOsoba.GetModel());

            }

        }
        private bool CanEditOsoba() { return _selectedOsoba != null; }
        private void RemoveOsoba()
        {
            connect.RemoveOsobaById(SelectedOsoba.Id);
            SelectedKnihovna.RegistrovaneOsoby.Remove(SelectedOsoba);
        }
        private bool CanRemoveOsoba() { return _selectedOsoba != null; }

        private void AddBorrow() { /* Logika pro přidání knihy */ }
        private void EditBorrow() { /* Logika pro úpravu knihy */ }
        private bool CanEditBorrow() { return _selectedKniha != null && _selectedKniha.Vypujceni; }
        private void RemoveBorrow() { /* Logika pro odebrání knihy */ }
        private bool CanRemoveBorrow() { return _selectedKniha != null && _selectedKniha.Vypujceni; }
        private void BorrowedBooks() { /* Logika pro odebrání knihy */ }
        private bool CanBorrowedBooks() { return _selectedOsoba != null; }
        private void GenerateKnihovna() { /* Logika pro odebrání knihy */ }
        private void GenerateKniha() { /* Logika pro odebrání knihy */ }
        private void GenerateOsoba() { /* Logika pro odebrání knihy */ }

        private new void Minimize() => base.Minimize();
        private new void Close() => base.Close();


    }
}
