using SemPrace.Classes;
using SemPrace.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPrace.Model
{
    public class Knihovna
    {
        public ObservableCollection<KnihaViewModel> Knihy { get; set; }
        public ObservableCollection<OsobaViewModel> RegistrovaneOsoby { get; set; }
        public int Id { get; set; }
        public string Nazev { get; set; }
        public string Lokalita { get; set; }

        public Knihovna()
        {
            Knihy = new ObservableCollection<KnihaViewModel>();
            RegistrovaneOsoby = new ObservableCollection<OsobaViewModel>();
        }

        public Knihovna(string nazev, string lokalita) : this()
        {
            Nazev = nazev;
            Lokalita = lokalita;
        }

        public void AddKniha(KnihaViewModel kniha)
        {
            Knihy.Add(kniha);
        }

        public void AddOsoba(OsobaViewModel osoba)
        {
            RegistrovaneOsoby.Add(osoba);
        }
    }
}
