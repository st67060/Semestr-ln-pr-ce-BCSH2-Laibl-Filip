
using SemPrace.Model;
using SemPrace.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SemPrace.Utility
{
    internal class GeneratorDat
    {
        private Random random = new Random();
        public int GenerateUniqueId()
        {
            Guid guid = Guid.NewGuid();
            byte[] bytes = guid.ToByteArray();
            return BitConverter.ToInt32(bytes, 0);
        }

        public KnihovnaViewModel GenerateKnihovna()
        {
            string[] nazvy = {
        "Central", "Community", "City", "Public", "County",
        "State", "National", "Regional", "Digital", "Municipal",
        "University", "Research", "Technical", "Historical", "Science",
        "Literary", "Learning", "Cultural", "Heritage", "Special",
        "Academic", "Archives", "Media", "Virtual", "Library",
        "Book", "Reading", "Resource", "Reference", "Study",
        "Knowledge", "Information", "Public Access", "Discovery", "Community Learning",
        "Media Center", "Resource Center", "Research Center", "Knowledge Hub", "Info Hub",
        "Literacy Center", "Education Hub", "Digital Repository", "Learning Commons", "Tech Hub",
        "Civic Center", "Heritage Center", "Cultural Center", "Study Center", "Discovery Center"
    };
            string[] lokace = {
    "Praha", "Paříž", "Londýn", "Berlín", "Vídeň", "Řím", "Moskva", "Madrid", "Varšava", "Oslo",
    "Atény", "Tokio", "Dublin", "Kyjev", "Lisabon", "Budapešť", "Helsinki", "Istanbul", "Bratislava", "Ženeva",
    "Dublin", "Stockholm", "Bern", "Řím", "Oslo", "Paříž", "Ženeva", "Amsterdam", "Dublin", "Lisabon",
    "Řím", "Ženeva", "Oslo", "Paříž", "Berlín", "Istanbul", "Kyjev", "Madrid", "Vídeň", "Praha",
    "Řím", "Tokio", "Paříž", "Londýn", "Oslo", "Madrid", "Kyjev", "Varšava", "Vídeň", "Praha"
};
            Knihovna knihovna = new Knihovna();

            string nazev = nazvy[random.Next(nazvy.Length)];
            string lokalita = lokace[random.Next(lokace.Length)];
            knihovna.Id = GenerateUniqueId();
            knihovna.Nazev = nazev;
            knihovna.Lokalita = lokalita;
            KnihovnaViewModel viewModel = new KnihovnaViewModel(knihovna);
            return viewModel;

        }
        public KnihaViewModel GenerateKniha(Knihovna knihovna)
        {
            string[] nazvy = {
        "The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in the Rye",
        "Brave New World", "Moby-Dick", "War and Peace", "The Lord of the Rings", "The Hobbit",
        "The Odyssey", "The Iliad", "Crime and Punishment", "The Brothers Karamazov", "One Hundred Years of Solitude",
        "The Grapes of Wrath", "The Shining", "The Hunger Games", "The Da Vinci Code", "The Alchemist",
        "The Road", "The Kite Runner", "The Help", "The Girl with the Dragon Tattoo", "The Martian",
        "The Silent Patient", "Educated", "Where the Crawdads Sing", "The Nightingale", "The Giver",
        "The Gilded Wolves", "The Night Circus", "The Maze Runner", "The Lovely Bones", "The Ocean at the End of the Lane",
        "The Power", "The Nightingale", "The Road Less Traveled", "The Name of the Wind", "The Hunger Games",
        "The Golden Compass", "The Book Thief", "The Black Prism", "The Hobbit", "The Catcher in the Rye",
        "The Help", "The Secret Garden", "The Princess Bride", "The Road"
    };

            string[] autori = {
        "F. Scott Fitzgerald", "Harper Lee", "George Orwell", "Jane Austen", "J.D. Salinger",
        "Aldous Huxley", "Herman Melville", "Leo Tolstoy", "J.R.R. Tolkien", "J.R.R. Tolkien",
        "Homer", "Homer", "Fyodor Dostoevsky", "Fyodor Dostoevsky", "Gabriel García Márquez",
        "John Steinbeck", "Stephen King", "Suzanne Collins", "Dan Brown", "Paulo Coelho",
        "Cormac McCarthy", "Khaled Hosseini", "Kathryn Stockett", "Stieg Larsson", "Andy Weir",
        "Alex Michaelides", "Tara Westover", "Delia Owens", "Kristin Hannah", "Lois Lowry",
        "Roshani Chokshi", "Erin Morgenstern", "James Dashner", "Alice Sebold", "Neil Gaiman",
        "Naomi Alderman", "Kristin Hannah", "M. Scott Peck", "Patrick Rothfuss", "Suzanne Collins",
        "Philip Pullman", "Markus Zusak", "Brent Weeks", "J.R.R. Tolkien", "J.D. Salinger",
        "Kathryn Stockett", "Frances Hodgson Burnett", "William Goldman", "Cormac McCarthy"
    };

            string nazev = nazvy[random.Next(nazvy.Length)];
            string autor = autori[random.Next(autori.Length)];
            Kniha kniha = new Kniha(nazev, autor, random.Next(1800, 2023));
            kniha.IdKnihovna = knihovna.Id;
            kniha.Id = GenerateUniqueId();
            KnihaViewModel viewModel = new KnihaViewModel(kniha);
            return viewModel;
        }
        public OsobaViewModel GenerateOsoba(Knihovna knihovna)
        {
            string[] jmena = {
         "Jan", "Adam", "Petr", "Petr", "Martin",
           "Lukáš", "Josef", "Marta", "Miroslav", "Petr",
      "Tomáš", "Jan", "Karel", "Petr", "Jakub",
      "Jan", "Václav", "Petr", "Zdeněk", "Petr",
       "David", "Jan", "Lukáš", "Petr", "Filip",
      "Jan", "Pavel", "Jan", "Jaroslav", "Monika",
      "Patrik", "Jan", "Ondřej", "Petr", "Adam",
        "Petr", "Radek", "Tereza", "Richard", "Petr",
      "Michal", "Petr", "Robert", "Petr", "Ladislav",
      "Jan", "Vojtěch", "Petr", "Vladimír"
                };

            string[] prijmeni = {
            "Novák", "Svoboda", "Novotný", "Dvořák", "Černý",
            "Procházka", "Kučera", "Veselý", "Horák", "Němec",
            "Marek", "Král", "Říha", "Kříž", "Beneš",
            "Sedláček", "Holub", "Konečný", "Růžička", "Hájek",
            "Bartoš", "Mach", "Šimek", "Krupa", "Havlíček",
            "Vlček", "Zeman", "Malý", "Urban", "Kolář",
            "Janků", "Zámečník", "Musil", "Blažek", "Jurečka",
            "Fučík", "Svatoň", "Rybář", "Vlček", "Maláč",
            "Němeček", "Bureš", "Havel", "Kratochvíl", "Šťastný",
            "Pech", "Vávra", "Hruška", "Pospíšil"
        };
            string Jmeno = jmena[random.Next(jmena.Length)];
            string prijm = prijmeni[random.Next(prijmeni.Length)];
            Osoba osoba = new Osoba(Jmeno, prijm);
            osoba.Id = GenerateUniqueId();
            osoba.IdKnihovna = knihovna.Id;
            OsobaViewModel viewModel = new OsobaViewModel(osoba);
            return viewModel;
        }
        
    }
}
