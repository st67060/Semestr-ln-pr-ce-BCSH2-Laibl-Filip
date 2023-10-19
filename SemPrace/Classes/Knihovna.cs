using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPrace.Classes
{
    public class Knihovna : INotifyPropertyChanged
    {
        private string nazev;
        public string Nazev
        {
            get { return nazev; }
            set
            {
                if (nazev != value)
                {
                    nazev = value;
                    OnPropertyChanged(nameof(Nazev));
                }
            }
        }

        private string lokalita;
        public string Lokalita
        {
            get { return lokalita; }
            set
            {
                if (lokalita != value)
                {
                    lokalita = value;
                    OnPropertyChanged(nameof(Lokalita));
                }
            }
        }
        public ObservableCollection<Kniha> Knihy { get; }
        public ObservableCollection<Osoba> RegistrovaneOsoby { get; }

        public Knihovna(string nazev, string lokalita)
        {
            Nazev = nazev;
            Lokalita = lokalita;
            Knihy = new ObservableCollection<Kniha>();
            RegistrovaneOsoby = new ObservableCollection<Osoba>();
        }

        public void PridatKniha(Kniha kniha)
        {
            Knihy.Add(kniha);
        }

        public void PridatOsobu(Osoba osoba)
        {
            RegistrovaneOsoby.Add(osoba);
        }
        public override string ToString()
        {
            return Nazev +""+ Lokalita;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
