using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPrace.Classes
{
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
        //Metoda pro upravu parametru knihy
        public Kniha upravKnihu(string nazev, string autor, int rokVydani)
        {
            this.Nazev = nazev;
            this.Autor = autor;
            this.RokVydani = rokVydani;
            return this;

        }
        //Metoda pro zadání výpujčky, datum je vygenerovan
        public void zadejVypujcku(Osoba osoba)
        {
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
        public void zadejVypujcku(Osoba osoba, DateOnly datumVypujceni, DateOnly datumVraceni)
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
        //Metoda pro odebrání výpujčky z knihy
        public void odeberVypujcku()
        {
            if (!this.Vypujceni)
            {
                throw new ArgumentException("Kniha: " + this.Nazev + " není aktuálně vypůjčena");
            }
            this.Vypujcil = null;
            this.Vypujceni = false;
            this.DatumVypujceni = DateOnly.MinValue;
            this.DatumNavraceni = DateOnly.MinValue;
        }
        //Metoda pro prodluzovani casu vypujcky, vzdy posune datum o 14 dni
        public void prodluzVypujcku()
        {
            if (this.Vypujceni)
            {
                throw new ArgumentException("Kniha: " + this.Nazev + " není aktuálně vypůjčena");
            }
            this.DatumNavraceni = this.DatumNavraceni.AddDays(14);

        }
    }
}
