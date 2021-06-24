using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Znajomi.DAL.Repozytoria
{
    using Encje;
    static class RepozytoriumTelefony
    {
        #region ZAPYTANIA
        private const string WSZYSTKIE_TELEFONY = "SELECT * FROM telefony";
        private const string DODAJ_TELEFON = "INSERT INTO `telefony`(`numer`, `operator`, `typ`) VALUES ";
        #endregion



        #region METODY_CRUD
        public static List<Telefon> PonierzWszystkieTelefony()
        {
            List<Telefon> telefony = new List<Telefon>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_TELEFONY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    telefony.Add(new Telefon(reader));
                connection.Close();
            }
            return telefony;
        }

        // Dodawanie telefonu do bazy
        public static bool DodajTelefonDoBazy(Telefon telefon)
        {
            bool stan = false;   // zmienna przechowująca to czy udało się wykonać kwerendę do bazy danych
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_TELEFON} {telefon.ToInsert()}", connection);
                connection.Open();  // owtieramy polaczenie z bazą danych
                var id = command.ExecuteNonQuery();
                stan = true;               
                telefon.Id = (sbyte)command.LastInsertedId;  // udało się dodać telefon do bazy, więc obiektowi telefon przypisujemy Id takie jakie wynika z tabeli
                connection.Close();  // zamykamy polaczenie z baza danych
            }
            return stan;
        }
        #endregion
    }
}
