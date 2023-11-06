using System;
using System.ComponentModel;
using System.Windows.Input;

namespace SemPrace.ViewModel
{
    public class DialogConfirmViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool? dialogResult;

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

   

        public DialogConfirmViewModel()
        {
            ConfirmCommand = new RelayCommand(Confirm);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Confirm()
        {
            RequestDialogResult?.Invoke(this, true);
            RequestClose?.Invoke(this, EventArgs.Empty);
           
        }

        private void Cancel()
        {
            RequestDialogResult?.Invoke(this, false);
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event EventHandler RequestClose;

        private void Close()
        {
            if (RequestClose != null)
            {
                RequestClose(this, EventArgs.Empty);
            }
        }

        public event EventHandler<bool> RequestDialogResult;

    }
}
