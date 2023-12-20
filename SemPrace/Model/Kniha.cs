
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPrace.Model
{
    public class Kniha
    {
        public int Id { get; set; }
        public int IdKnihovna { get; set; }
        public string Nazev { get; set; }
        public string Autor { get; set; }
        public int RokVydani { get; set; }
        public bool Vypujceni { get; set; }
        public DateOnly DatumVypujceni { get; set; }
        public DateOnly DatumNavraceni { get; set; }
        public Osoba Vypujcil { get; set; }

        public Kniha(string nazev,
                     string autor,
                     int rokVydani)
        {
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

        public override string ToString()
        {
            return Nazev + " " + Autor + " " + RokVydani + " " + (Vypujceni ? "ANO" : "NE");
        }
    }
}
