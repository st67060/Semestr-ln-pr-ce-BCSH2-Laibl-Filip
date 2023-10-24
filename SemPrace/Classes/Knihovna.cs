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
        private string lokalita;
        public ObservableCollection<Kniha> Knihy { get; set; }
        public ObservableCollection<Osoba> RegistrovaneOsoby { get; set; }
        public int Id { get; set; }
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

        public Knihovna()
        {
            Nazev = null;
            Lokalita = null;
            Knihy = new ObservableCollection<Kniha>();
            RegistrovaneOsoby = new ObservableCollection<Osoba>();
        }
        public Knihovna(string nazev, string lokalita)
        {
            Nazev = nazev;
            Lokalita = lokalita;
            Knihy = new ObservableCollection<Kniha>();
            RegistrovaneOsoby = new ObservableCollection<Osoba>();
        }

        public void AddKniha(Kniha kniha)
        {
            Knihy.Add(kniha);
        }

        public void AddOsoba(Osoba osoba)
        {
            RegistrovaneOsoby.Add(osoba);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
