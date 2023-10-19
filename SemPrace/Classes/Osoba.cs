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

        public string Jmeno
        {
            get { return jmeno; }
        }

        public string Prijmeni
        {
            get { return prijmeni; }
        }

        public string Id { get; }

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
            Id = GenerateUserId();
            HistorieVypujcenychKnih = new ObservableCollection<Kniha>();
        }

        public static string GenerateUserId()
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