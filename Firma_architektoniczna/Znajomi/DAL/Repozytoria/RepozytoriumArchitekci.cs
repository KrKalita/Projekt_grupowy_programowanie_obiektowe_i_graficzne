using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Znajomi.DAL.Repozytoria
{
    using Encje;
    static class RepozytoriumArchitekci
    {   
        #region ZAPYTANIA
        private const string WSZYSCY_ARCHITEKCI = "SELECT * FROM architekci";
        private const string DODAJ_ARCHITEKTA = "INSERT INTO `architekci`(`pesel`, `imię`, `nazwisko`, `numer`) VALUES ";
        #endregion

        #region metody CRUD 
        /// <summary>
        /// CRUD - create, read, update, delete
        /// </summary>
        /// <returns></returns>
        public static List<Architekt> PobierzWszystkichArchitektow()
        {
            List<Architekt> architekci = new List<Architekt>();//lista z obiektami osoby
            using (var connection = DBConnection.Instance.Connection)//wykorzystuje sie do polaczenia z baza danych/chroni przed skutkami bledow
            {
                MySqlCommand command = new MySqlCommand(WSZYSCY_ARCHITEKCI, connection);//obiekt typu mysqlcommand/tworze kwerende/klasa mysqlcommand wbudowana w system
                connection.Open();//otwiera polaczenie
                var reader=command.ExecuteReader();//wykonuje sie zapytanie do bazy danych i pobiera sie wynik z tego zapytania //dla select
                while (reader.Read())//read-odczytuje jeden wiersz wyniku
                    architekci.Add(new Architekt(reader));//dodaje do lista z obiektami osoby
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
                var id = command.ExecuteNonQuery();//wykonuje zapytanie do bazy danych //dla insert
                stan = true;
                connection.Close();
            }
            return stan;
        }

        public static bool EdytujrchitektaWBazie(Architekt architekt, sbyte idOsoby)
        {
            bool stan = false;//informacja czy sie udalo wykonać operacje na bazie danych
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_ARCHITEKTA = $"UPDATE osoby SET pesel='{architekt.Pesel}', imie='{architekt.Imie}', nazwisko='{architekt.Nazwisko}', " +
                    $"numer={architekt.Numer} WHERE pesel={architekt.Pesel}";

                MySqlCommand command = new MySqlCommand(EDYTUJ_ARCHITEKTA, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if(n==1) stan = true;
               
                connection.Close();
            }
            return stan;
        }

        public static bool UsunArchitektaZBazy(Osoba osoba)
        {
            //implementacja/mozna dodac jak sie chce
            return true;
        }
        #endregion
    }
}
