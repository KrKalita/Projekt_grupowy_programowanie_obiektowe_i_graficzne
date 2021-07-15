using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Znajomi.DAL.Encje;

namespace Znajomi.DAL.Repozytoria
{
    static class RepozytoriumProjekty
    {
        #region ZAPYTANIA
        private const string WSZYSTKIE_PROJEKTY = "SELECT * FROM projekty";
        private const string DODAJ_PROJEKT = "INSERT INTO `firma_architektoniczna`.`projekty`(`nazwa_projektu`, `cena`, `czas_wykonania`) VALUES ";
        #endregion

        #region metody CRUD 
        /// <summary>
        /// CRUD - create, read, update, delete
        /// </summary>
        /// <returns></returns>
        public static List<Projekt> PobierzWszystkieProjekty()
        {
            List<Projekt> projekty = new List<Projekt>();//lista z obiektami osoby
            using (var connection = DBConnection.Instance.Connection)//wykorzystuje sie do polaczenia z baza danych/chroni przed skutkami bledow
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_PROJEKTY, connection);//obiekt typu mysqlcommand/tworze kwerende/klasa mysqlcommand wbudowana w system
                connection.Open();//otwiera polaczenie
                var reader = command.ExecuteReader();//wykonuje sie zapytanie do bazy danych i pobiera sie wynik z tego zapytania //dla select
                while (reader.Read())//read-odczytuje jeden wiersz wyniku
                    projekty.Add(new Projekt(reader));//dodaje do lista z obiektami osoby
                connection.Close();//zamyka polaczenie
            }
            return projekty;
        }

        public static bool DodajProjektDoBazy(Projekt projekt)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_PROJEKT} {projekt.ToInsert()}", connection);
                connection.Open();
                command.ExecuteNonQuery();//wykonuje zapytanie do bazy danych //dla insert
                stan = true;
                connection.Close();
            }
            return stan;
        }

        public static bool EdytujProjektWBazie(Projekt projekt, string Nazwa_projektu)
        {
            bool stan = false;//informacja czy sie udalo wykonać operacje na bazie danych
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_PROJEKT = $"UPDATE projekty SET nazwa_projektu='{projekt.Nazwa_projektu}', cena='{projekt.Cena}', " +
                    $"czas_wykonania='{projekt.Czas_wykonania}' WHERE nazwa_projektu='{Nazwa_projektu}'";

                MySqlCommand command = new MySqlCommand(EDYTUJ_PROJEKT, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }

        public static bool UsunProjektZBazy(string Nazwa_projektu)
        {
            bool stan = false;//informacja czy sie udalo wykonać operacje na bazie danych
            using (var connection = DBConnection.Instance.Connection)
            {
                string USUN_PROJEKT = $"DELETE FROM `projekty` WHERE nazwa_projektu='{Nazwa_projektu}'";
                string USUN_UMOWE = $"DELETE FROM `umowy` WHERE nazwa_projektu={"\"" + Nazwa_projektu+"\""};";
                MySqlCommand command2 = new MySqlCommand(USUN_UMOWE, connection);
                MySqlCommand command = new MySqlCommand(USUN_PROJEKT, connection);
                connection.Open();
                var n1 = command2.ExecuteNonQuery();
                var n2 = command.ExecuteNonQuery();
                if (n1 == 1) stan = true;
                if (n2 == 1) stan = true;

                connection.Close();
            }
            return stan;
        }

        #endregion
    }
}
