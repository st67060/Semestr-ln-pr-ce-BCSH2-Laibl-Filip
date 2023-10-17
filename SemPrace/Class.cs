using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPrace
{
    public class Knihovna
    {
        public string Nazev { get; set; }
        public int IdKnihovny { get; set; }
        public string Lokalita { get; set; }
        public List<Kniha> Knihy { get; set; }
        public List<Osoba> RegistrovaneOsoby { get; set; }

        public Knihovna(string nazev, int idKnihovny, string lokalita)
        {
            Nazev = nazev;
            IdKnihovny = idKnihovny;
            Lokalita = lokalita;
            Knihy = new List<Kniha>();
            RegistrovaneOsoby = new List<Osoba>();
        }

        public void PridatKniha(Kniha kniha)
        {
            Knihy.Add(kniha);
        }

        public void PridatOsoba(Osoba osoba)
        {
            RegistrovaneOsoby.Add(osoba);
        }
    }
    public class Kniha
    {
        public string Nazev { get; set; }
        public string Autor { get; set; }
        public int RokVydani { get; set; }
        public bool Vypujceni { get; set; }
        public Osoba Vypujcil { get; set; }
        public DateTime DatumVypujceni { get; set; }
        public DateTime DatumNavraceni { get; set; }

        public Kniha(string nazev, string autor, int rokVydani)
        {
            Nazev = nazev;
            Autor = autor;
            RokVydani = rokVydani;
            Vypujceni = false;
            DatumVypujceni = DateTime.MinValue;
            Vypujcil = null;
            DatumNavraceni = DateTime.MinValue;
        }

        public Kniha(string nazev, string autor, int rokVydani, DateTime datumVypujceni, DateTime datumNavraceni)
        {
            if (datumNavraceni < datumVypujceni)
            {
                throw new ArgumentException("Datum vrácení nemůže být kratší než datum výpůjčky.");
            }

            Nazev = nazev;
            Autor = autor;
            RokVydani = rokVydani;
            Vypujceni = false;
            DatumVypujceni = datumVypujceni;
            Vypujcil = null;
            DatumNavraceni = datumNavraceni;
        }
    }

    public class Osoba
    {
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public int Id { get; set; }

        public Osoba(string jmeno, string prijmeni, int id)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Id = id;
        }
    }
}
