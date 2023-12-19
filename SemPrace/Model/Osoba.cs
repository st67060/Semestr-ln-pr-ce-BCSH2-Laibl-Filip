using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPrace.Model
{
    public class Osoba
    {
        public int Id { get; set; }
        public int IdKnihovna { get; set; }
        public string UzivatelskeCislo { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public ObservableCollection<Kniha> HistorieVypujcenychKnih { get; set; }

        public Osoba(string jmeno, string prijmeni)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            UzivatelskeCislo = GenerateUzivatelskeCislo();
            HistorieVypujcenychKnih = new ObservableCollection<Kniha>();
        }

        public Osoba()
        {
            HistorieVypujcenychKnih = new ObservableCollection<Kniha>();
        }

        public string GenerateUzivatelskeCislo()
        {
            Random random = new Random();
            const string chars = "0123456789";
            string userId = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());

            return "User" + userId;
        }
    }
}
