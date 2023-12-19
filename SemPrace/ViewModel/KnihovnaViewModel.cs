
using SemPrace.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPrace.ViewModel
{
    public class KnihovnaViewModel : INotifyPropertyChanged
    {
        private Knihovna knihovna;

        public ObservableCollection<KnihaViewModel> Knihy => knihovna.Knihy;
        public ObservableCollection<OsobaViewModel> RegistrovaneOsoby => knihovna.RegistrovaneOsoby;

        public int Id
        {
            get => knihovna.Id;
            set
            {
                if (knihovna.Id != value)
                {
                    knihovna.Id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public string Nazev
        {
            get => knihovna.Nazev;
            set
            {
                if (knihovna.Nazev != value)
                {
                    knihovna.Nazev = value;
                    OnPropertyChanged(nameof(Nazev));
                }
            }
        }

        public string Lokalita
        {
            get => knihovna.Lokalita;
            set
            {
                if (knihovna.Lokalita != value)
                {
                    knihovna.Lokalita = value;
                    OnPropertyChanged(nameof(Lokalita));
                }
            }
        }

        public KnihovnaViewModel(Knihovna knihovna)
        {
            this.knihovna = knihovna;
        }

        public void AddKniha(KnihaViewModel kniha)
        {
            knihovna.AddKniha(kniha);
            OnPropertyChanged(nameof(Knihy));
        }

        public void AddOsoba(OsobaViewModel osoba)
        {
            knihovna.AddOsoba(osoba);
            OnPropertyChanged(nameof(RegistrovaneOsoby));
        }

        public Knihovna GetModel() {
        return knihovna;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
