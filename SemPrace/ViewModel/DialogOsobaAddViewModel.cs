using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SemPrace.ViewModel
{
    public class DialogOsobaAddViewModel: BaseViewModel
    {
        private string jmeno;
        private string prijmeni;

        public string Jmeno
        {
            get { return jmeno; }
            set
            {
                if (jmeno != value)
                {
                    jmeno = value;
                    OnPropertyChanged(nameof(Jmeno));
                    ((RelayCommand)ConfirmCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public string Prijmeni
        {
            get { return prijmeni; }
            set
            {
                if (prijmeni != value)
                {
                    prijmeni = value;
                    OnPropertyChanged(nameof(Prijmeni));
                    ((RelayCommand)ConfirmCommand).RaiseCanExecuteChanged();
                }
            }
        }


        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        public DialogOsobaAddViewModel()
        {
            ConfirmCommand = new RelayCommand(Confirm, CanConfirm);
            CancelCommand = new RelayCommand(Cancel);

            Jmeno = jmeno;
            Prijmeni = prijmeni;

        }

        private bool CanConfirm()
        {
            return !string.IsNullOrWhiteSpace(Jmeno) && !string.IsNullOrWhiteSpace(Prijmeni);
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
