using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SemPrace.ViewModel
{
    public class DialogKnihovnaAddViewModel: BaseViewModel
    {
        private string nazev;
        private string lokalita;


        public string Nazev
        {
            get { return nazev; }
            set
            {
                if (nazev != value)
                {
                    nazev = value;
                    OnPropertyChanged(nameof(Nazev));
                    ((RelayCommand)ConfirmCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public string Lokalita
        {
            get { return lokalita; }
            set
            {
                if (lokalita != value)
                {
                    lokalita = value;
                    OnPropertyChanged(nameof(Lokalita));
                    ((RelayCommand)ConfirmCommand).RaiseCanExecuteChanged();
                }
            }
        }


        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        public DialogKnihovnaAddViewModel()
        {
            ConfirmCommand = new RelayCommand(Confirm, CanConfirm);
            CancelCommand = new RelayCommand(Cancel);

        }

        private bool CanConfirm()
        {
            return !string.IsNullOrWhiteSpace(Nazev) && !string.IsNullOrWhiteSpace(Lokalita);
        }

        private void Confirm()
        {
            base.Confirm();
        }

        private void Cancel()
        {
            base.Cancel();
        }

        private bool IsNumeric(string text)
        {
            return int.TryParse(text, out _);
        }
    }
}
