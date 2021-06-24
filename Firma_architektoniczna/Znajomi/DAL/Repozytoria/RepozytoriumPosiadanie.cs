using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Znajomi.DAL.Repozytoria
{
    using Encje;
    class RepozytoriumPosiadanie
    {
        #region ZAPYTANIA
        private const string WSZYSTKIE_OSOBY = "SELECT * FROM pol";
        private const string DODAJ_POSIADANIE = "INSERT INTO `pol`(`id_o`, `id_t`) VALUES ";
        #endregion


        #region OPERACJE_CRUD

        public static List<Posiadanie> PobierzWszystkiePosiadania()
        {
            List<Posiadanie> posiadanie = new List<Posiadanie>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_OSOBY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    posiadanie.Add(new Posiadanie(reader));
                connection.Close();
            }
            return posiadanie;
        }

        // Dodawanie posiadania do bazy
        public static bool DodajPosiadanieDoBazy(Posiadanie posiadanie)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_POSIADANIE} {posiadanie.ToInsert()}", connection);  // twoerzymy kwerende
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                posiadanie.IdPosiadania = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return stan;
        }
        #endregion
    }
}
