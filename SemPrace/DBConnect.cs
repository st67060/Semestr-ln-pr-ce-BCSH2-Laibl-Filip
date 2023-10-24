


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using SemPrace.Classes;
using SQLitePCL;


namespace SemPrace
{
    public class DBConnect
    {
        private string databasePath = "database.db";
        public ObservableCollection<Knihovna> LoadDataFromDatabase()
        {
            ObservableCollection<Knihovna> nacteneKnihovny = ReadAllKnihovnyFromDatabase();
            ObservableCollection<Osoba> nacteneOsoby = ReadAllOsobyFromDatabase();
            ObservableCollection<Kniha> nacteneKnihy = ReadAllKnihyFromDatabase(nacteneOsoby);
            AssignOsobyToKnihovny(nacteneKnihovny, nacteneOsoby);
            AssignKnihyToKnihovny(nacteneKnihovny, nacteneKnihy);
            AssignHistorieVypujcenychKnih(nacteneOsoby, nacteneKnihy);

            return nacteneKnihovny;
        }
        public void SaveDataToDatabase(ObservableCollection<Knihovna> knihovny)
        {
            SaveKnihovnyToDatabase(knihovny);
            SaveOsobyToDatabase(knihovny);
            SaveKnihyToDatabase(knihovny);
            SaveHistorieVypujcenychKnihToDatabase(knihovny);
        }
        public void SaveKnihaToDatabase(Kniha kniha)
        {
            SaveKnihyToDatabase(kniha);

        }
        public void SaveOsobaToDatabase(Osoba osoba)
        {
            SaveOsobyToDatabase(osoba);
        }
        public void SaveKnihovnaToDatabase(Knihovna knihovna) {
            SaveKnihovnyToDatabase(knihovna);
        }
        public ObservableCollection<Knihovna> ReadAllKnihovnyFromDatabase()
        {
            ObservableCollection<Knihovna> knihovny = new ObservableCollection<Knihovna>();

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Knihovna;", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Knihovna knihovna = new Knihovna();

                            knihovna.Id = Convert.ToInt32(reader["Id"]);
                            knihovna.Nazev = reader["Nazev"].ToString();
                            knihovna.Lokalita = reader["Lokalita"].ToString();


                            knihovny.Add(knihovna);
                        }
                    }
                }

                connection.Close();
            }

            return knihovny;
        }
        public ObservableCollection<Osoba> ReadAllOsobyFromDatabase()
        {
            ObservableCollection<Osoba> osoby = new ObservableCollection<Osoba>();

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Osoba;", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Osoba osoba = new Osoba();

                            osoba.Id = Convert.ToInt32(reader["Id"]);
                            osoba.Jmeno = reader["Jmeno"].ToString();
                            osoba.Prijmeni = reader["Prijmeni"].ToString();
                            osoba.IdKnihovna = Convert.ToInt32(reader["IdKnihovna"]);
                            osoba.UzivatelskeCislo = reader["UzivatelskeCislo"].ToString();


                            osoby.Add(osoba);
                        }
                    }
                }

                connection.Close();
            }

            return osoby;
        }
        public ObservableCollection<Kniha> ReadAllKnihyFromDatabase(ObservableCollection<Osoba> osoby)
        {
            ObservableCollection<Kniha> knihy = new ObservableCollection<Kniha>();

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Kniha;", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Kniha kniha = new Kniha();

                            kniha.Id = Convert.ToInt32(reader["Id"]);
                            kniha.Nazev = reader["nazev"].ToString();
                            kniha.Autor = reader["autor"].ToString();
                            kniha.RokVydani = Convert.ToInt32(reader["rokVydani"]);
                            kniha.IdKnihovna = Convert.ToInt32(reader["IdKnihovna"]);
                            kniha.Vypujceni = Convert.ToBoolean(reader["vypujceni"]);
                            kniha.DatumVypujceni = ConvertToDateTime(reader["datumVypujceni"].ToString());
                            kniha.DatumNavraceni = ConvertToDateTime(reader["datumNavraceni"].ToString());
                            if (kniha.Vypujceni)
                            {
                                kniha.Vypujcil = osoby.FirstOrDefault(o => o.Id == Convert.ToInt32(reader["Vypujcil"]));
                            }
                            else { kniha.Vypujcil = null; }

                            knihy.Add(kniha);
                        }
                    }
                }

                connection.Close();
            }

            return knihy;
        }

        public void SaveKnihovnyToDatabase(ObservableCollection<Knihovna> knihovny)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();

                foreach (var knihovna in knihovny)
                {
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "INSERT OR REPLACE INTO Knihovna (Id, Nazev, Lokalita) VALUES (@Id, @Nazev, @Lokalita);";
                        command.Parameters.AddWithValue("@Id", knihovna.Id);
                        command.Parameters.AddWithValue("@Nazev", knihovna.Nazev);
                        command.Parameters.AddWithValue("@Lokalita", knihovna.Lokalita);

                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }
        public void SaveKnihovnyToDatabase(Knihovna knihovna)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT OR REPLACE INTO Knihovna (Id, Nazev, Lokalita) VALUES (@Id, @Nazev, @Lokalita);";
                    command.Parameters.AddWithValue("@Id", knihovna.Id);
                    command.Parameters.AddWithValue("@Nazev", knihovna.Nazev);
                    command.Parameters.AddWithValue("@Lokalita", knihovna.Lokalita);

                    command.ExecuteNonQuery();
                }


                connection.Close();
            }
        }
        public void SaveOsobyToDatabase(ObservableCollection<Knihovna> knihovny)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();

                foreach (var knihovna in knihovny)
                {
                    foreach (var osoba in knihovna.RegistrovaneOsoby)
                    {
                        using (SQLiteCommand command = new SQLiteCommand(connection))
                        {
                            command.CommandText = "INSERT OR REPLACE INTO Osoba (Jmeno, Prijmeni, IdKnihovna, Id, UzivatelskeCislo) VALUES (@Jmeno, @Prijmeni, @IdKnihovna, @Id, @UzivatelskeCislo);";
                            command.Parameters.AddWithValue("@Jmeno", osoba.Jmeno);
                            command.Parameters.AddWithValue("@Prijmeni", osoba.Prijmeni);
                            command.Parameters.AddWithValue("@UzivatelskeCislo", osoba.UzivatelskeCislo);
                            command.Parameters.AddWithValue("@Id", osoba.Id);
                            command.Parameters.AddWithValue("@IdKnihovna", knihovna.Id);
                            command.ExecuteNonQuery();
                        }
                    }
                }

                connection.Close();
            }
        }
        public void SaveOsobyToDatabase(Osoba osoba)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT OR REPLACE INTO Osoba (Jmeno, Prijmeni, IdKnihovna, Id, UzivatelskeCislo) VALUES (@Jmeno, @Prijmeni, @IdKnihovna, @Id, @UzivatelskeCislo);";
                    command.Parameters.AddWithValue("@Jmeno", osoba.Jmeno);
                    command.Parameters.AddWithValue("@Prijmeni", osoba.Prijmeni);
                    command.Parameters.AddWithValue("@UzivatelskeCislo", osoba.UzivatelskeCislo);
                    command.Parameters.AddWithValue("@Id", osoba.Id);
                    command.Parameters.AddWithValue("@IdKnihovna", osoba.IdKnihovna);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        public void SaveKnihyToDatabase(ObservableCollection<Knihovna> knihovny)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();

                foreach (var knihovna in knihovny)
                {
                    foreach (var kniha in knihovna.Knihy)
                    {
                        using (SQLiteCommand command = new SQLiteCommand(connection))
                        {
                            command.CommandText = "INSERT OR REPLACE INTO Kniha (nazev, autor, rokVydani, vypujceni, datumVypujceni, datumNavraceni, IdKnihovna, Id, Vypujcil) " +
                                                 "VALUES (@Nazev, @Autor, @RokVydani, @Vypujceni, @DatumVypujceni, @DatumNavraceni, @IdKnihovna, @Id, @Vypujcil);";
                            command.Parameters.AddWithValue("@Nazev", kniha.Nazev);
                            command.Parameters.AddWithValue("@Autor", kniha.Autor);
                            command.Parameters.AddWithValue("@RokVydani", kniha.RokVydani);
                            command.Parameters.AddWithValue("@Vypujceni", ConvertToIntFromBool(kniha.Vypujceni));
                            command.Parameters.AddWithValue("@DatumVypujceni", kniha.DatumVypujceni.ToString());
                            command.Parameters.AddWithValue("@DatumNavraceni", kniha.DatumNavraceni.ToString());
                            command.Parameters.AddWithValue("@IdKnihovna", knihovna.Id);
                            command.Parameters.AddWithValue("@Id", kniha.Id);

                            if (kniha.Vypujcil != null)
                            {
                                command.Parameters.AddWithValue("@Vypujcil", kniha.Vypujcil.Id);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@Vypujcil", DBNull.Value);
                            }
                            command.ExecuteNonQuery();
                        }
                    }
                }

                connection.Close();
            }
        }
        public void SaveKnihyToDatabase(Kniha kniha)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT OR REPLACE INTO Kniha (nazev, autor, rokVydani, vypujceni, datumVypujceni, datumNavraceni, IdKnihovna, Id, Vypujcil) " +
                                         "VALUES (@Nazev, @Autor, @RokVydani, @Vypujceni, @DatumVypujceni, @DatumNavraceni, @IdKnihovna, @Id, @Vypujcil);";
                    command.Parameters.AddWithValue("@Nazev", kniha.Nazev);
                    command.Parameters.AddWithValue("@Autor", kniha.Autor);
                    command.Parameters.AddWithValue("@RokVydani", kniha.RokVydani);
                    command.Parameters.AddWithValue("@Vypujceni", ConvertToIntFromBool(kniha.Vypujceni));
                    command.Parameters.AddWithValue("@DatumVypujceni", kniha.DatumVypujceni.ToString());
                    command.Parameters.AddWithValue("@DatumNavraceni", kniha.DatumNavraceni.ToString());
                    command.Parameters.AddWithValue("@IdKnihovna", kniha.IdKnihovna);
                    command.Parameters.AddWithValue("@Id", kniha.Id);

                    if (kniha.Vypujcil != null)
                    {
                        command.Parameters.AddWithValue("@Vypujcil", kniha.Vypujcil.Id);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Vypujcil", DBNull.Value);
                    }
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        public void SaveHistorieVypujcenychKnihToDatabase(ObservableCollection<Knihovna> knihovny)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();

                foreach (var knihovna in knihovny)
                {
                    foreach (var osoba in knihovna.RegistrovaneOsoby)
                    {
                        foreach (var kniha in osoba.HistorieVypujcenychKnih)
                        {
                            using (SQLiteCommand command = new SQLiteCommand(connection))
                            {
                                command.CommandText = "SELECT COUNT(*) FROM KnihyOsoby WHERE IdOsoba = @IdOsoba AND IdKniha = @IdKniha;";
                                command.Parameters.AddWithValue("@IdOsoba", osoba.Id);
                                command.Parameters.AddWithValue("@IdKniha", kniha.Id);

                                int existingCount = Convert.ToInt32(command.ExecuteScalar());

                                if (existingCount == 0)
                                {
                                    using (SQLiteCommand insertCommand = new SQLiteCommand(connection))
                                    {
                                        insertCommand.CommandText = "INSERT INTO KnihyOsoby (IdOsoba, IdKniha) VALUES (@IdOsoba, @IdKniha);";
                                        insertCommand.Parameters.AddWithValue("@IdOsoba", osoba.Id);
                                        insertCommand.Parameters.AddWithValue("@IdKniha", kniha.Id);
                                        insertCommand.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }

                connection.Close();
            }



        }
        public void AssignOsobyToKnihovny(ObservableCollection<Knihovna> knihovny, ObservableCollection<Osoba> osoby)
        {

            foreach (var knihovna in knihovny)
            {
                knihovna.RegistrovaneOsoby.Clear();
                foreach (var osoba in osoby.Where(os => os.IdKnihovna == knihovna.Id))
                {
                    knihovna.RegistrovaneOsoby.Add(osoba);
                }
            }
        }
        public void AssignKnihyToKnihovny(ObservableCollection<Knihovna> knihovny, ObservableCollection<Kniha> knihy)
        {
            foreach (var knihovna in knihovny)
            {
                knihovna.Knihy.Clear();
                foreach (var kniha in knihy.Where(k => k.IdKnihovna == knihovna.Id))
                {
                    knihovna.Knihy.Add(kniha);
                }
            }
        }

        public void AssignHistorieVypujcenychKnih(ObservableCollection<Osoba> osoby, ObservableCollection<Kniha> knihy)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();

                foreach (var osoba in osoby)
                {
                    using (SQLiteCommand command = new SQLiteCommand("SELECT IdKniha FROM KnihyOsoby WHERE IdOsoba = @IdOsoba;", connection))
                    {
                        command.Parameters.AddWithValue("@IdOsoba", osoba.Id);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idKniha = Convert.ToInt32(reader["IdKniha"]);
                                Kniha vypujcenaKniha = knihy.FirstOrDefault(k => k.Id == idKniha);
                                if (vypujcenaKniha != null)
                                {
                                    osoba.HistorieVypujcenychKnih.Add(vypujcenaKniha);
                                }
                            }
                        }
                    }
                }

                connection.Close();
            }
        }
        private DateOnly ConvertToDateTime(string dateString)
        {

            string dateFormat = "dd.MM.yyyy";

            if (DateOnly.TryParseExact(dateString, dateFormat, null, System.Globalization.DateTimeStyles.None, out DateOnly date))
            {
                return date;
            }
            else
            {
                throw new FormatException("Nesprávný formát data.");
            }
        }
        private int ConvertToIntFromBool(bool value)
        {
            if (value) { return -1; }
            else { return 0; }

        }
        public void RemoveKnihaById(int knihaId)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();


                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DELETE FROM KnihyOsoby WHERE IdKniha = @IdKniha;";
                    command.Parameters.AddWithValue("@IdKniha", knihaId);
                    command.ExecuteNonQuery();
                }


                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DELETE FROM Kniha WHERE Id = @Id;";
                    command.Parameters.AddWithValue("@Id", knihaId);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }


        public void RemoveOsobaById(int osobaId)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();


                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DELETE FROM KnihyOsoby WHERE IdOsoba = @IdOsoba;";
                    command.Parameters.AddWithValue("@IdOsoba", osobaId);
                    command.ExecuteNonQuery();
                }

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DELETE FROM Osoba WHERE Id = @Id;";
                    command.Parameters.AddWithValue("@Id", osobaId);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void RemoveKnihovnaById(int knihovnaId)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();


                List<int> osobyKOdstraneni = new List<int>();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT Id FROM Osoba WHERE IdKnihovna = @IdKnihovna;";
                    command.Parameters.AddWithValue("@IdKnihovna", knihovnaId);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int osobaId = Convert.ToInt32(reader["Id"]);
                            osobyKOdstraneni.Add(osobaId);
                        }
                    }
                }


                foreach (int osobaId in osobyKOdstraneni)
                {

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "DELETE FROM KnihyOsoby WHERE IdOsoba = @IdOsoba;";
                        command.Parameters.AddWithValue("@IdOsoba", osobaId);
                        command.ExecuteNonQuery();
                    }


                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "DELETE FROM Osoba WHERE Id = @Id;";
                        command.Parameters.AddWithValue("@Id", osobaId);
                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DELETE FROM Kniha WHERE IdKnihovna = @IdKnihovna;";
                    command.Parameters.AddWithValue("@IdKnihovna", knihovnaId);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DELETE FROM Knihovna WHERE Id = @Id;";
                    command.Parameters.AddWithValue("@Id", knihovnaId);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }

}
