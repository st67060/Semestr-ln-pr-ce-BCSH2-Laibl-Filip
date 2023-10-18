using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPrace.Classes
{
    public class Osoba
    {
        public string Jmeno { get; }
        public string Prijmeni { get; }
        public string Id { get; }

        public List<Kniha> HistorieVypujcenychKnih { get; }

        public Osoba(string jmeno, string prijmeni, Knihovna knihovna)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Id = GenerateUserId();
            knihovna.PridatOsobu(this);
        }
        public static string GenerateUserId()
        {
            Random random = new Random();
            const string chars = "0123456789";
            string userId = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());

            return "User" + userId;
        }
    }
}
