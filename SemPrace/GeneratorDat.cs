using SemPrace.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SemPrace
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

        public Knihovna GenerateKnihovna()
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
        "New York", "Los Angeles", "Chicago", "Houston", "Phoenix",
        "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose",
        "Austin", "Jacksonville", "San Francisco", "Columbus", "Indianapolis",
        "Seattle", "Denver", "Washington, D.C.", "Boston", "Nashville",
        "Las Vegas", "Portland", "Atlanta", "Miami", "Charlotte",
        "Minneapolis", "Orlando", "Tampa", "St. Louis", "Baltimore",
        "Salt Lake City", "Austin", "Kansas City", "Raleigh", "Cleveland",
        "Honolulu", "Pittsburgh", "Detroit", "Albuquerque", "Tucson",
        "Memphis", "Milwaukee", "Oklahoma City", "Buffalo", "New Orleans",
        "Cincinnati", "Hartford", "Rochester", "San Juan"
    };
            Knihovna knihovna = new Knihovna();

            string nazev = nazvy[random.Next(nazvy.Length)];
            string lokalita = lokace[random.Next(lokace.Length)];
            knihovna.Id = GenerateUniqueId();
            knihovna.Nazev = nazev;
            knihovna.Lokalita = lokalita;
            return knihovna;

        }
        public Kniha GenerateKniha(Knihovna knihovna)
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
            return kniha;
        }
        public Osoba GenerateOsoba(Knihovna knihovna) {
            string[] jmena = {
            "Jan", "Eva", "Petr", "Jana", "Martin",
            "Lenka", "Josef", "Marta", "Miroslav", "Alena",
            "Tomáš", "Hana", "Karel", "Lucie", "Jakub",
            "Marie", "Václav", "Veronika", "Zdeněk", "Kateřina",
            "David", "Irena", "Lukáš", "Jitka", "Filip",
            "Michaela", "Pavel", "Ivana", "Jaroslav", "Monika",
            "Patrik", "Simona", "Ondřej", "Lenka", "Adam",
            "Petra", "Radek", "Tereza", "Richard", "Markéta",
            "Michal", "Karolína", "Robert", "Šárka", "Ladislav",
            "Nikola", "Vojtěch", "Marcela", "Vladimír"
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
            Osoba osoba = new Osoba(Jmeno,prijm);
            osoba.Id = GenerateUniqueId();
            osoba.IdKnihovna = knihovna.Id;
            return osoba;
        }
        public ObservableCollection<Knihovna> GenerateAll() {
            ObservableCollection <Knihovna> knihovny = new ObservableCollection<Knihovna>();    
        for (int i = 0; i < 10; i++)
            {
                knihovny.Add(GenerateKnihovna());
            }
            foreach (Knihovna knihovna in knihovny)
            {
                for (int i = 0; i < 10; i++)
                {
                    knihovna.PridatOsobu(GenerateOsoba(knihovna));
                    knihovna.PridatKniha(GenerateKniha(knihovna));
                    
                }
            }
            return knihovny;
        }
    }
}
