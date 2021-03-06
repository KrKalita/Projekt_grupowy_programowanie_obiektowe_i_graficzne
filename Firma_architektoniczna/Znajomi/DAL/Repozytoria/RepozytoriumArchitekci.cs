using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Znajomi.DAL.Repozytoria
{
    using Encje;
    using System.Windows;

    static class RepozytoriumArchitekci
    {   
        #region ZAPYTANIA
        private const string WSZYSCY_ARCHITEKCI = "SELECT * FROM architekci";
        private const string POBIERZ_ARCHITEKTA = "SELECT * FROM architekci WHERE pesel=";
        private const string DODAJ_ARCHITEKTA = "INSERT INTO `firma_architektoniczna`.`architekci`(`pesel`, `imię`, `nazwisko`, `numer`) VALUES ";
        #endregion

        #region metody CRUD 
        /// <summary>
        /// CRUD - create, read, update, delete
        /// </summary>
        /// <returns></returns>
        public static List<Architekt> PobierzWszystkichArchitektow()
        {
            List<Architekt> architekci = new List<Architekt>();//lista z obiektami architekta
            using (var connection = DBConnection.Instance.Connection)//wykorzystuje sie do polaczenia z baza danych/chroni przed skutkami bledow
            {
                MySqlCommand command = new MySqlCommand(WSZYSCY_ARCHITEKCI, connection);//obiekt typu mysqlcommand/tworze kwerende/klasa mysqlcommand wbudowana w system
                connection.Open();//otwiera polaczenie
                var reader=command.ExecuteReader();//wykonuje sie zapytanie do bazy danych i pobiera sie wynik z tego zapytania //dla select
                while (reader.Read())//read-odczytuje jeden wiersz wyniku
                    architekci.Add(new Architekt(reader));//dodaje do lista z obiektami architekta
                connection.Close();//zamyka polaczenie
            }
                return architekci;
        }

        public static bool DodajArchitektaDoBazy(Architekt architekt)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_ARCHITEKTA} {architekt.ToInsert()}", connection);
                connection.Open();
                command.ExecuteNonQuery();//wykonuje zapytanie do bazy danych //dla insert
                stan = true;
                connection.Close();
            }
            return stan;
        }

        public static bool EdytujArchitektaWBazie(Architekt architekt, string pesel)
        {
            bool stan = false;//informacja czy sie udalo wykonać operacje na bazie danych
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_ARCHITEKTA = $"UPDATE architekci SET pesel='{architekt.Pesel}', imię='{architekt.Imie}', nazwisko='{architekt.Nazwisko}', " +
                    $"numer='{architekt.Numer}' WHERE pesel='{pesel}'";

                MySqlCommand command = new MySqlCommand(EDYTUJ_ARCHITEKTA, connection);//tworzymy zapytanie
                connection.Open();
                var n = command.ExecuteNonQuery();//wykonujemy zapytanie do bazy danych 
                if (n==1) stan = true;//sprawdzamy czy sie wykonało zapytanie poprawnie

                connection.Close();
            }
            return stan;
        }

        public static bool UsunArchitektaZBazy(string pesel)
        {
            bool stan = false;//informacja czy sie udalo wykonać operacje na bazie danych
            using (var connection = DBConnection.Instance.Connection)
            {
                string USUN_ARCHITEKTA = $"DELETE FROM `architekci` WHERE pesel='{pesel}'";
                string USUN_UMOWE = $"DELETE FROM `umowy` WHERE pesel={pesel};";
                MySqlCommand command2 = new MySqlCommand(USUN_UMOWE, connection);
                MySqlCommand command = new MySqlCommand(USUN_ARCHITEKTA, connection);
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
