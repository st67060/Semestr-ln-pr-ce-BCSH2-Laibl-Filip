

using SemPrace.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPrace.ViewModel
{
    public class KnihaViewModel : INotifyPropertyChanged
    {
        private Kniha kniha;

        public KnihaViewModel(Kniha kniha)
        {
            this.kniha = kniha;
        }

        public int Id
        {
            get => kniha.Id;
            set
            {
                if (kniha.Id != value)
                {
                    kniha.Id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public int IdKnihovna
        {
            get => kniha.IdKnihovna;
            set
            {
                if (kniha.IdKnihovna != value)
                {
                    kniha.IdKnihovna = value;
                    OnPropertyChanged(nameof(IdKnihovna));
                }
            }
        }

        public string Nazev
        {
            get => kniha.Nazev;
            set
            {
                if (kniha.Nazev != value)
                {
                    kniha.Nazev = value;
                    OnPropertyChanged(nameof(Nazev));
                }
            }
        }

        public string Autor
        {
            get => kniha.Autor;
            set
            {
                if (kniha.Autor != value)
                {
                    kniha.Autor = value;
                    OnPropertyChanged(nameof(Autor));
                }
            }
        }

        public int RokVydani
        {
            get => kniha.RokVydani;
            set
            {
                if (kniha.RokVydani != value)
                {
                    kniha.RokVydani = value;
                    OnPropertyChanged(nameof(RokVydani));
                }
            }
        }

        public bool Vypujceni
        {
            get => kniha.Vypujceni;
            set
            {
                if (kniha.Vypujceni != value)
                {
                    kniha.Vypujceni = value;
                    OnPropertyChanged(nameof(Vypujceni));
                }
            }
        }

        public DateOnly DatumVypujceni
        {
            get => kniha.DatumVypujceni;
            set
            {
                if (kniha.DatumVypujceni != value)
                {
                    kniha.DatumVypujceni = value;
                    OnPropertyChanged(nameof(DatumVypujceni));
                }
            }
        }

        public DateOnly DatumNavraceni
        {
            get => kniha.DatumNavraceni;
            set
            {
                if (kniha.DatumNavraceni != value)
                {
                    kniha.DatumNavraceni = value;
                    OnPropertyChanged(nameof(DatumNavraceni));
                }
            }
        }

        public Osoba Vypujcil
        {
            get => kniha.Vypujcil;
            set
            {
                if (kniha.Vypujcil != value)
                {
                    kniha.Vypujcil = value;
                    OnPropertyChanged(nameof(Vypujcil));
                }
            }
        }

        // Metoda pro nastavení výpůjčky
        public void SetVypujcka(Osoba osoba)
        {
           

            kniha.Vypujcil = osoba;
            kniha.Vypujceni = true;
            kniha.DatumVypujceni = DateOnly.FromDateTime(DateTime.Today);
            kniha.DatumNavraceni = DateOnly.FromDateTime(DateTime.Today.AddDays(14));

 

            OnPropertyChanged(nameof(Vypujcil));
            OnPropertyChanged(nameof(DatumVypujceni));
            OnPropertyChanged(nameof(DatumNavraceni));
            OnPropertyChanged(nameof(Vypujceni));
        }

        // Metoda pro nastavení výpůjčky s datem
        public void SetVypujcka(Osoba osoba, DateOnly datumVypujceni, DateOnly datumNavraceni)
        {
            if (kniha.Vypujceni)
            {
                throw new ArgumentException("Kniha: " + kniha.Nazev + " je aktuálně vypůjčena");
            }

            kniha.Vypujcil = osoba;
            kniha.Vypujceni = true;
            kniha.DatumVypujceni = datumVypujceni;
            kniha.DatumNavraceni = datumNavraceni;

            // osoba.HistorieVypujcenychKnih.Add(kniha);

            OnPropertyChanged(nameof(Vypujcil));
            OnPropertyChanged(nameof(DatumVypujceni));
            OnPropertyChanged(nameof(DatumNavraceni));
            OnPropertyChanged(nameof(Vypujceni));
        }

        // Metoda pro odebrání výpůjčky
        public void RemoveVypujcka()
        {
            if (!kniha.Vypujceni)
            {
                throw new ArgumentException("Kniha: " + kniha.Nazev + " není aktuálně vypůjčena");
            }

            kniha.Vypujcil = null;
            kniha.Vypujceni = false;
            kniha.DatumVypujceni = DateOnly.MinValue;
            kniha.DatumNavraceni = DateOnly.MinValue;

            OnPropertyChanged(nameof(Vypujcil));
            OnPropertyChanged(nameof(DatumVypujceni));
            OnPropertyChanged(nameof(DatumNavraceni));
            OnPropertyChanged(nameof(Vypujceni));
        }

        // Metoda pro prodloužení výpůjčky
        public void ExtendVypujcka()
        {
            if (!kniha.Vypujceni)
            {
                throw new ArgumentException("Kniha: " + kniha.Nazev + " není aktuálně vypůjčena");
            }

            kniha.DatumNavraceni = kniha.DatumNavraceni.AddDays(14);
            OnPropertyChanged(nameof(DatumNavraceni));
        }

        public Kniha GetModel() {
        return kniha;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
