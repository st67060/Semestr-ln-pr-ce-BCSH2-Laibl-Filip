using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPrace.Classes
{
    public class Knihovna
    {
        public string Nazev { get; }
        public string Lokalita { get; }
        public List<Kniha> Knihy { get; set; }
        public List<Osoba> RegistrovaneOsoby { get; set; }

        public Knihovna(string nazev, string lokalita)
        {
            Nazev = nazev;
            Lokalita = lokalita;
            Knihy = new List<Kniha>();
            RegistrovaneOsoby = new List<Osoba>();
        }

        public void PridatKniha(Kniha kniha)
        {
            Knihy.Add(kniha);
        }

        public void PridatOsobu(Osoba osoba)
        {
            RegistrovaneOsoby.Add(osoba);
        }
    }
}
