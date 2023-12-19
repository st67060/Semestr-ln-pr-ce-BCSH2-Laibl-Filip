using System;
using System.ComponentModel;
using System.Windows.Input;

namespace SemPrace.ViewModel
{
    public class DialogConfirmViewModel : BaseViewModel
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
           base.Confirm();
           
        }

        private void Cancel()
        {
            base.Cancel();
        }
      

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        

    }
}
