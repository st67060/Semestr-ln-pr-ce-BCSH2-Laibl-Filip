using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPrace.Classes
{
    public class Kniha : INotifyPropertyChanged
    {
        private string nazev;
        private string autor;
        private int rokVydani;
        private bool vypujceni;
        private DateOnly datumVypujceni;
        private DateOnly datumNavraceni;
        private Osoba vypujcil;
        public int Id { get; set; }
        public int IdKnihovna { get; set; }
        public string Nazev
        {
            get { return nazev; }
            set
            {
                if (nazev != value)
                {
                    nazev = value;
                    OnPropertyChanged(nameof(Nazev));
                }
            }
        }

        public string Autor
        {
            get { return autor; }
            set
            {
                if (autor != value)
                {
                    autor = value;
                    OnPropertyChanged(nameof(Autor));
                }
            }
        }

        public int RokVydani
        {
            get { return rokVydani; }
            set
            {
                if (rokVydani != value)
                {
                    rokVydani = value;
                    OnPropertyChanged(nameof(RokVydani));
                }
            }
        }

        public bool Vypujceni
        {
            get { return vypujceni; }
            set
            {
                if (vypujceni != value)
                {
                    vypujceni = value;
                    OnPropertyChanged(nameof(Vypujceni));
                }
            }
        }

        public DateOnly DatumVypujceni
        {
            get { return datumVypujceni; }
            set
            {
                if (datumVypujceni != value)
                {
                    datumVypujceni = value;
                    OnPropertyChanged(nameof(DatumVypujceni));
                }
            }
        }

        public DateOnly DatumNavraceni
        {
            get { return datumNavraceni; }
            set
            {
                if (datumNavraceni != value)
                {
                    datumNavraceni = value;
                    OnPropertyChanged(nameof(DatumNavraceni));
                }
            }
        }
        public Osoba Vypujcil
        {
            get { return vypujcil; }
            set
            {
                if (vypujcil != value)
                {
                    vypujcil = value;
                    OnPropertyChanged(nameof(vypujcil));
                }
            }
        }

        public Kniha(string nazev, string autor, int rokVydani)
        {
            Id = 0;
            IdKnihovna = 0;
            Nazev = nazev;
            Autor = autor;
            RokVydani = rokVydani;
            Vypujceni = false;
            DatumVypujceni = DateOnly.MinValue;
            DatumNavraceni = DateOnly.MinValue;
        }
        public Kniha()
        {
            Nazev = null;
            Autor = null;
            RokVydani = 0;
            Vypujceni = false;
            DatumVypujceni = DateOnly.MinValue;
            DatumNavraceni = DateOnly.MinValue;
        }
        //Metoda pro zadání výpujčky, datum je vygenerovan
        public void SetVypujcka(Osoba osoba)
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
        public void SetVypujcka(Osoba osoba, DateOnly datumVypujceni, DateOnly datumVraceni)
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
        public void RemoveVypujcka()
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
        public void ExtendVypujcka()
        {
            if (!this.Vypujceni)
            {
                throw new ArgumentException("Kniha: " + this.Nazev + " není aktuálně vypůjčena");
            }
            this.DatumNavraceni = this.DatumNavraceni.AddDays(14);

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return Nazev + " " + Autor + " " + RokVydani + " " + (Vypujceni ? "ANO" : "NE");
        }
    }
}
