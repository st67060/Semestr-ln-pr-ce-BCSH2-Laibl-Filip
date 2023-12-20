using SemPrace.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SemPrace.ViewModel
{
    public class DialogOsobaListKnihyViewModel:BaseViewModel
    {

        public ObservableCollection<Kniha> Knihy { get; set; }

        public ICommand ConfirmCommand { get; }

        public DialogOsobaListKnihyViewModel(ObservableCollection<Kniha> knihy)
        {
            ConfirmCommand = new RelayCommand(Confirm); 
             Knihy = knihy;


        }


        private new void Confirm()
        {
            base.Confirm();
        }

        


    }


}
