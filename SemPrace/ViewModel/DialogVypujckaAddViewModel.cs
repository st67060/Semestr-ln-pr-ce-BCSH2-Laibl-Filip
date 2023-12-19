using SemPrace.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SemPrace.ViewModel
{
    public class DialogVypujckaAddViewModel : BaseViewModel
    {
        private OsobaViewModel _selectedOsoba;
        private DateTime _startDate;
        private DateTime _endDate;

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
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

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }

        public ObservableCollection<OsobaViewModel> Osoby { get; set; }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        public DialogVypujckaAddViewModel(ObservableCollection<OsobaViewModel> osoby)
        {
            ConfirmCommand = new RelayCommand(Confirm, CanConfirm);
            CancelCommand = new RelayCommand(Cancel);

            Osoby = osoby;


        }

        private bool CanConfirm()
        {
            return StartDate !=null && EndDate != null && SelectedOsoba !=null;
        }

        private void Confirm()
        {
            base.Confirm();
        }

        private void Cancel()
        {
            base.Cancel();
        }


    }
}

