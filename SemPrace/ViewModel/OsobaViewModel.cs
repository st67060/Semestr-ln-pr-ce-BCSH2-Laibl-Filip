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
    public class OsobaViewModel : INotifyPropertyChanged
    {
        private Osoba osoba;

        public OsobaViewModel(Osoba osoba)
        {
            this.osoba = osoba;
            if (string.IsNullOrEmpty(osoba.UzivatelskeCislo))
            {
                this.osoba.UzivatelskeCislo = GenerateUzivatelskeCislo();
            }
        }

        public int Id
        {
            get => osoba.Id;
            set
            {
                if (osoba.Id != value)
                {
                    osoba.Id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public int IdKnihovna
        {
            get => osoba.IdKnihovna;
            set
            {
                if (osoba.IdKnihovna != value)
                {
                    osoba.IdKnihovna = value;
                    OnPropertyChanged(nameof(IdKnihovna));
                }
            }
        }

        public string UzivatelskeCislo
        {
            get => osoba.UzivatelskeCislo;
            set
            {
                if (osoba.UzivatelskeCislo != value)
                {
                    osoba.UzivatelskeCislo = value;
                    OnPropertyChanged(nameof(UzivatelskeCislo));
                }
            }
        }

        public string Jmeno
        {
            get => osoba.Jmeno;
            set
            {
                if (osoba.Jmeno != value)
                {
                    osoba.Jmeno = value;
                    OnPropertyChanged(nameof(Jmeno));
                }
            }
        }

        public string Prijmeni
        {
            get => osoba.Prijmeni;
            set
            {
                if (osoba.Prijmeni != value)
                {
                    osoba.Prijmeni = value;
                    OnPropertyChanged(nameof(Prijmeni));
                }
            }
        }
        public static string GenerateUzivatelskeCislo()
        {
            Random random = new Random();
            const string chars = "0123456789";
            string userId = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());

            return "User" + userId;
        }
        public Osoba GetModel() {
            return osoba;
        }

        public ObservableCollection<Kniha> HistorieVypujcenychKnih => osoba.HistorieVypujcenychKnih;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string ToString() => osoba.ToString();
    }
}
