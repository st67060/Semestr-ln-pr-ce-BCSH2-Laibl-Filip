using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPrace.Classes
{
    public class Osoba : INotifyPropertyChanged
    {
        private string jmeno;
        private string prijmeni;
        private ObservableCollection<Kniha> historieVypujcenychKnih;
        public int Id { get; set; }
        public int IdKnihovna { get; set; }
        public string UzivatelskeCislo { get; set; }
        public string Jmeno
        {
            get { return jmeno; }
            set
            {
                if (jmeno != value)
                {
                    jmeno = value;
                    OnPropertyChanged(nameof(Jmeno));
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
                }
            }
        }

        

        public ObservableCollection<Kniha> HistorieVypujcenychKnih
        {
            get { return historieVypujcenychKnih; }
            set
            {
                if (historieVypujcenychKnih != value)
                {
                    historieVypujcenychKnih = value;
                    OnPropertyChanged(nameof(HistorieVypujcenychKnih));
                }
            }
        }

        public Osoba(string jmeno, string prijmeni)
        {
            this.jmeno = jmeno;
            this.prijmeni = prijmeni;
            UzivatelskeCislo = VygenerujUzivatelskeCislo();
            HistorieVypujcenychKnih = new ObservableCollection<Kniha>();
        }
        public Osoba()
        {
            this.jmeno = null;
            this.prijmeni = null;
            UzivatelskeCislo = null;
            HistorieVypujcenychKnih = new ObservableCollection<Kniha>();
        }

        public static string VygenerujUzivatelskeCislo()
        {
            Random random = new Random();
            const string chars = "0123456789";
            string userId = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());

            return "User" + userId;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}