using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPrace
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
    public class Kniha
    {
        public string Nazev { get; }
        public string Autor { get; }
        public int RokVydani { get; }
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
            Vypujcil = null;
            DatumVypujceni = datumVypujceni;          
            DatumNavraceni = datumNavraceni;
        }
        public void zadejVypujcku(Kniha kniha, Osoba osoba) {
            if (kniha.Vypujceni)
            {
                throw new ArgumentException("Kniha: " + kniha.Nazev + " je aktuálně vypůjčena");
            }
            kniha.Vypujcil = osoba;
            kniha.Vypujceni = true;
            kniha.DatumVypujceni = DateTime.Today;
            kniha.DatumNavraceni = DateTime.Today.AddDays(14);

        }
        public void odeberVypujcku(Kniha kniha) {
            if (!kniha.Vypujceni)
            {
                throw new ArgumentException("Kniha: " + kniha.Nazev + " není aktuálně vypůjčena");
            }
            kniha.Vypujcil = null;
            kniha.Vypujceni = false;
            kniha.DatumVypujceni = DateTime.MinValue;
            kniha.DatumNavraceni = DateTime.MinValue;
        }
    }

    public class Osoba
    {
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Id { get; set; }

        public Osoba(string jmeno, string prijmeni)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Id = GenerateUserId();
        }
        public static string GenerateUserId()
        {
            Random random = new Random();
            const string chars = "0123456789";
            string userId = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());

            return "User"+userId;
        }
    }
    
}
