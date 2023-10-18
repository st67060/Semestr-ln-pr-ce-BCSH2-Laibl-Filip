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
        public string Nazev { get; set; }
        public string Autor { get; set; }
        public int RokVydani { get; set; }
        public bool Vypujceni { get; set; }
        public Osoba Vypujcil { get; set; }
        public DateOnly DatumVypujceni { get; set; }
        public DateOnly DatumNavraceni { get; set; }

        public Kniha(string nazev, string autor, int rokVydani)
        {
            Nazev = nazev;
            Autor = autor;
            RokVydani = rokVydani;
            Vypujceni = false;
            DatumVypujceni = DateOnly.MinValue;
            Vypujcil = null;
            DatumNavraceni = DateOnly.MinValue;
        }
        public Kniha upravKnihu(string nazev, string autor, int rokVydani) {
            this.Nazev = nazev;
            this.Autor = autor;
            this.RokVydani = rokVydani;
            return this;
            
        }

        public void zadejVypujcku( Osoba osoba) {
            if (this.Vypujceni)
            {
                throw new ArgumentException("Kniha: " + this.Nazev + " je aktuálně vypůjčena");
            }
            this.Vypujcil = osoba;
            this.Vypujceni = true;
            this.DatumVypujceni = DateOnly.FromDateTime(DateTime.Today);
            this.DatumNavraceni = DateOnly.FromDateTime(DateTime.Today.AddDays(14));
            osoba.HistorieVypujcenychKnih.Add(this);

        }
        public void zadejVypujcku( Osoba osoba,DateOnly datumVypujceni, DateOnly datumVraceni)
        {
            if (this.Vypujceni)
            {
                throw new ArgumentException("Kniha: " + this.Nazev + " je aktuálně vypůjčena");
            }
            this.Vypujcil = osoba;
            this.Vypujceni = true;
            this.DatumVypujceni = datumVypujceni;
            this.DatumNavraceni = datumVraceni;
            osoba.HistorieVypujcenychKnih.Add(this);

        }
        public void odeberVypujcku() {
            if (!this.Vypujceni)
            {
                throw new ArgumentException("Kniha: " + this.Nazev + " není aktuálně vypůjčena");
            }
            this.Vypujcil = null;
            this.Vypujceni = false;
            this.DatumVypujceni = DateOnly.MinValue;
            this.DatumNavraceni = DateOnly.MinValue;
        }
        public void prodluzVypujcku()
        {
            if (this.Vypujceni)
            {
                throw new ArgumentException("Kniha: " + this.Nazev + " není aktuálně vypůjčena");
            }
            this.DatumNavraceni = this.DatumNavraceni.AddDays(14);

        }
    }
    

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

            return "User"+userId;
        }
    }
    
}
