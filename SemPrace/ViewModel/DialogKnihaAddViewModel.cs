using SemPrace.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SemPrace.ViewModel
{
    public class DialogKnihaAddViewModel : BaseViewModel
    {
        private string nazev;
        private string autor;
        private int rokVydani;

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

        public string Autor
        {
            get { return autor; }
            set
            {
                if (autor != value)
                {
                    autor = value;
                    OnPropertyChanged(nameof(Autor));
                    ((RelayCommand)ConfirmCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public int RokVydani
        {
            get { return rokVydani; }
            set
            {
                if (rokVydani != value)
                {
                    rokVydani = value;
                    OnPropertyChanged(nameof(RokVydani));
                    ((RelayCommand)ConfirmCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        public DialogKnihaAddViewModel()
        {
            ConfirmCommand = new RelayCommand(Confirm, CanConfirm);
            CancelCommand = new RelayCommand(Cancel);

            Nazev = nazev;
            Autor = autor;
            RokVydani = rokVydani;
        }

        private bool CanConfirm()
        {
            return !string.IsNullOrWhiteSpace(Nazev) && !string.IsNullOrWhiteSpace(Autor) && IsNumeric(RokVydani.ToString());
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
