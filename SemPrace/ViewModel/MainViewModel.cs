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

        private string _searchKnihaText = "Hledat...";
        private string _searchOsobaText = "Hledat...";
        private KnihovnaViewModel? _selectedKnihovna;
        private KnihaViewModel? _selectedKniha;
        private OsobaViewModel? _selectedOsoba;
        public string SearchKnihaText
        {
            get { return _searchKnihaText; }
            set
            {
                if (_searchKnihaText != value)
                {
                    _searchKnihaText = value;
                    OnPropertyChanged(nameof(SearchKnihaText));
                    UpdateKnihaFilter();
                    OnPropertyChanged(nameof(Knihy));
                }
            }
        }
        public string SearchOsobaText
        {
            get { return _searchOsobaText; }
            set
            {
                if (_searchOsobaText != value)
                {
                    _searchOsobaText = value;
                    OnPropertyChanged(nameof(SearchOsobaText));
                    UpdateOsobaFilter();
                    OnPropertyChanged(nameof(Osoby));
                }
            }
        }
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

            AddKnihaCommand = new RelayCommand(AddKniha, CanAddNewItem);
            EditKnihaCommand = new RelayCommand(EditKniha, CanEditKniha);
            RemoveKnihaCommand = new RelayCommand(RemoveKniha, CanRemoveKniha);

            AddOsobaCommand = new RelayCommand(AddOsoba, CanAddNewItem);
            EditOsobaCommand = new RelayCommand(EditOsoba, CanEditOsoba);
            RemoveOsobaCommand = new RelayCommand(RemoveOsoba, CanRemoveOsoba);

            AddBorrowCommand = new RelayCommand(AddBorrow, CanAddBorrow);
            EditBorrowCommand = new RelayCommand(EditBorrow, CanEditBorrow);
            RemoveBorrowCommand = new RelayCommand(RemoveBorrow, CanRemoveBorrow);

            BorrowedBooksCommand = new RelayCommand(BorrowedBooks, CanBorrowedBooks);

            GenerateKnihovnaCommand = new RelayCommand(GenerateKnihovna);
            GenerateKnihaCommand = new RelayCommand(GenerateKniha, CanGenerate);
            GenerateOsobaCommand = new RelayCommand(GenerateOsoba, CanGenerate);

            MinimizeCommand = new RelayCommand(Minimize);
            CloseCommand = new RelayCommand(Close);
        }
        private bool CanEditKnihovna() { return _selectedKnihovna != null; }
        private bool CanRemoveKnihovna() { return _selectedKnihovna != null; }
        private bool CanEditKniha() { return _selectedKniha != null; }
        private bool CanRemoveKniha() { return _selectedKniha != null; }
        private bool CanEditOsoba() { return _selectedOsoba != null; }
        private bool CanRemoveOsoba() { return _selectedOsoba != null; }
        private bool CanEditBorrow() { return _selectedKniha != null && _selectedKniha.Vypujceni; }
        private bool CanAddBorrow() { return _selectedKniha != null && !_selectedKniha.Vypujceni; }
        private bool CanRemoveBorrow() { return _selectedKniha != null && _selectedKniha.Vypujceni; }
        private bool CanBorrowedBooks() { return _selectedOsoba != null; }
        private bool CanGenerate() { return _selectedKnihovna != null; }
        private bool CanAddNewItem() { return _selectedKnihovna != null; }
        private void AddKnihovna()
        {
            var dialogViewModel = new DialogKnihovnaAddViewModel();
            var dialog = new DialogKnihovnaAdd(dialogViewModel);
            if (dialog.ShowDialog() == true)
            {
                var newKnihovna = new Knihovna(dialogViewModel.Nazev, dialogViewModel.Lokalita)
                {
                    Id = generator.GenerateUniqueId()
                };
                Knihovny.Add(new KnihovnaViewModel(newKnihovna));
                connect.SaveKnihovnaToDatabase(newKnihovna);
            }
        }

        private void EditKnihovna()
        {
            if (SelectedKnihovna == null)
            {
                return;
            }

            var dialogViewModel = new DialogKnihovnaEditViewModel(SelectedKnihovna);
            var dialog = new DialogKnihovnaEdit(dialogViewModel);
            if (dialog.ShowDialog() == true)
            {
                SelectedKnihovna.Nazev = dialogViewModel.Nazev;
                SelectedKnihovna.Lokalita = dialogViewModel.Lokalita;
                connect.SaveKnihovnaToDatabase(SelectedKnihovna.GetModel());
            }
        }

        private void RemoveKnihovna()
        {
            if (SelectedKnihovna == null)
            {
                return;
            }

            var dialog = new DialogConfirm();
            if (dialog.ShowDialog() == true)
            {
                connect.RemoveKnihovnaById(SelectedKnihovna.Id);
                Knihovny.Remove(SelectedKnihovna);
            }
        }


        private void AddKniha()
        {
            var dialogViewModel = new DialogKnihaAddViewModel();
            var dialog = new DialogKnihaAdd(dialogViewModel);
            if (dialog.ShowDialog() == true)
            {
                var newKniha = new Kniha(dialogViewModel.Nazev, dialogViewModel.Autor, dialogViewModel.RokVydani)
                {
                    Id = generator.GenerateUniqueId(),
                    IdKnihovna = SelectedKnihovna.Id
                };

                Knihy.Add(new KnihaViewModel(newKniha));
                connect.SaveKnihaToDatabase(newKniha);
            }
        }

        private void EditKniha()
        {
            if (SelectedKniha == null)
            {
                return;
            }

            var dialogViewModel = new DialogKnihaEditViewModel(SelectedKniha);
            var dialog = new DialogKnihaEdit(dialogViewModel);
            if (dialog.ShowDialog() == true)
            {
                SelectedKniha.Nazev = dialogViewModel.Nazev;
                SelectedKniha.Autor = dialogViewModel.Autor;
                SelectedKniha.RokVydani = dialogViewModel.RokVydani;
                connect.SaveKnihaToDatabase(SelectedKniha.GetModel());
            }
        }
        
        private void RemoveKniha()
        {
            connect.RemoveKnihaById(SelectedKniha.Id);
            SelectedKnihovna.Knihy.Remove(SelectedKniha);

        }
        

        private void AddOsoba()
        {
            var dialogViewModel = new DialogOsobaAddViewModel();
            var dialog = new DialogOsobaAdd(dialogViewModel);
            if (dialog.ShowDialog() == true)
            {
                var newOsoba = new Osoba(dialogViewModel.Jmeno, dialogViewModel.Prijmeni)
                {
                    Id = generator.GenerateUniqueId(),
                    IdKnihovna = SelectedKnihovna.Id
                };
                Osoby.Add(new OsobaViewModel(newOsoba));
                connect.SaveOsobaToDatabase(newOsoba);
            }
        }
        private void EditOsoba()
        {
            if (SelectedOsoba == null)
            {
                return;
            }

            var dialogViewModel = new DialogOsobaEditViewModel(SelectedOsoba);
            var dialog = new DialogOsobaEdit(dialogViewModel);
            if (dialog.ShowDialog() == true)
            {
                SelectedOsoba.Jmeno = dialogViewModel.Jmeno;
                SelectedOsoba.Prijmeni = dialogViewModel.Prijmeni;
                connect.SaveOsobaToDatabase(SelectedOsoba.GetModel());
            }
        }
        
        private void RemoveOsoba()
        {
            connect.RemoveOsobaById(SelectedOsoba.Id);
            SelectedKnihovna.RegistrovaneOsoby.Remove(SelectedOsoba);
        }
        

        private void AddBorrow()
        {
            var viewModel = new DialogVypujckaAddViewModel(Osoby);
            var dialog = new DialogVypujckaAdd(viewModel);
            if (dialog.ShowDialog() == true && SelectedKniha != null)
            {
                SelectedKniha.SetVypujcka(viewModel.SelectedOsoba.GetModel(),
                                          DateOnly.FromDateTime(viewModel.StartDate),
                                          DateOnly.FromDateTime(viewModel.EndDate));
                connect.SaveDataToDatabase(Knihovny);
            }
        }
        private void EditBorrow() { SelectedKniha.ExtendVypujcka(); connect.SaveKnihaToDatabase(SelectedKniha.GetModel()); }
        
        private void RemoveBorrow() { SelectedKniha.RemoveVypujcka(); connect.SaveKnihaToDatabase(SelectedKniha.GetModel()); }
        
        private void BorrowedBooks()
        {
            DialogOsobaListKnihyViewModel viewModel = new DialogOsobaListKnihyViewModel(SelectedOsoba.HistorieVypujcenychKnih);
            DialogOsobaKnihy dialog = new DialogOsobaKnihy(viewModel);
            bool? result = dialog.ShowDialog();

        }
        
        private void GenerateKnihovna()
        {
            KnihovnaViewModel viewModel = generator.GenerateKnihovna();
            Knihovny.Add(viewModel);
            connect.SaveKnihovnaToDatabase(viewModel.GetModel());
        }
        private void GenerateKniha()
        {
            KnihaViewModel viewModel = generator.GenerateKniha(SelectedKnihovna.GetModel());
            SelectedKnihovna.AddKniha(viewModel);
            connect.SaveKnihaToDatabase(viewModel.GetModel());
        }
        private void GenerateOsoba()
        {
            OsobaViewModel viewModel = generator.GenerateOsoba(SelectedKnihovna.GetModel());
            SelectedKnihovna.AddOsoba(viewModel);
            connect.SaveOsobaToDatabase(viewModel.GetModel());
        
        }

        private new void Minimize() => base.Minimize();
        private new void Close() => base.Close();

        private void UpdateKnihaFilter()
        {
            if (SelectedKnihovna == null)
            {
                return;
            }

            var filteredKnihy = _selectedKnihovna.Knihy
                .Where(kniha => SearchKnihaText == "Hledat..."
                                || String.IsNullOrEmpty(SearchKnihaText)
                                || kniha.ToString().Contains(SearchKnihaText, StringComparison.OrdinalIgnoreCase));

            Knihy = new ObservableCollection<KnihaViewModel>(filteredKnihy);
        }
        private void UpdateOsobaFilter()
        {
            if (SelectedKnihovna == null)
            {
                return;
            }

            var filteredOsoby = _selectedKnihovna.RegistrovaneOsoby
                .Where(osoba => SearchOsobaText == "Hledat..."
                                || String.IsNullOrEmpty(SearchOsobaText)
                                || osoba.ToString().Contains(SearchOsobaText, StringComparison.OrdinalIgnoreCase));

            Osoby = new ObservableCollection<OsobaViewModel>(filteredOsoby);
        }

        internal void UpdateSortingKniha(string? selectedItem)
        {
            if (_selectedKnihovna == null)
            {
                return;
            }

            IEnumerable<KnihaViewModel> sortedList = selectedItem switch
            {
                "Výchozí" => _selectedKnihovna.Knihy,
                "Vypůjčené knihy" => _selectedKnihovna.Knihy.Where(k => k.Vypujceni),
                "Nevypůjčené knihy" => _selectedKnihovna.Knihy.Where(k => !k.Vypujceni),
                "Název" => _selectedKnihovna.Knihy.OrderBy(k => k.Nazev),
                "Autor" => _selectedKnihovna.Knihy.OrderBy(k => k.Autor),
                "Rok Vydání" => _selectedKnihovna.Knihy.OrderBy(k => k.RokVydani),
                _ => _selectedKnihovna.Knihy
            };

            Knihy = new ObservableCollection<KnihaViewModel>(sortedList);
            OnPropertyChanged(nameof(Knihy));
        }

        internal void UpdateSortingOsoba(string? selectedItem)
        {
            if (_selectedKnihovna == null || _selectedKnihovna.RegistrovaneOsoby == null)
            {
                return;
            }

            IEnumerable<OsobaViewModel> sortedList = selectedItem switch
            {
                "Výchozí" => _selectedKnihovna.RegistrovaneOsoby,
                "Jméno" => _selectedKnihovna.RegistrovaneOsoby.OrderBy(k => k.Jmeno),
                "Příjmení" => _selectedKnihovna.RegistrovaneOsoby.OrderBy(k => k.Prijmeni),
                _ => _selectedKnihovna.RegistrovaneOsoby
            };

            Osoby = new ObservableCollection<OsobaViewModel>(sortedList);
            OnPropertyChanged(nameof(Osoby));
        }
    }

}
