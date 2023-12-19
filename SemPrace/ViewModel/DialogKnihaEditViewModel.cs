using SemPrace.Classes;
using SemPrace.ViewModel;
using System.Windows.Input;

namespace SemPrace.ViewModel
{
     public class DialogKnihaEditViewModel : BaseViewModel
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

        public DialogKnihaEditViewModel(KnihaViewModel kniha)
        {
            ConfirmCommand = new RelayCommand(Confirm, CanConfirm);
            CancelCommand = new RelayCommand(Cancel);

            Nazev = kniha.Nazev;
            Autor = kniha.Autor;
            RokVydani = kniha.RokVydani;
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