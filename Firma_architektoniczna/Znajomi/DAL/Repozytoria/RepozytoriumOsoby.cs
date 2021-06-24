using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Znajomi.DAL.Repozytoria
{
    using Encje;
    static class RepozytoriumOsoby
    {   
        #region ZAPYTANIA
        private const string WSZYSTKIE_OSOBY = "SELECT * FROM osoby";
        private const string DODAJ_OSOBE = "INSERT INTO `osoby`(`nazwisko`, `imie`, `wiek`, `miasto`) VALUES ";
        #endregion

        #region metody CRUD 
        /// <summary>
        /// CRUD - create, read, update, delete
        /// </summary>
        /// <returns></returns>
        public static List<Osoba> PobierzWszystkieOsoby()
        {
            List<Osoba> osoby = new List<Osoba>();//lista z obiektami osoby
            using (var connection = DBConnection.Instance.Connection)//wykorzystuje sie do polaczenia z baza danych/chroni przed skutkami bledow
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_OSOBY, connection);//obiekt typu mysqlcommand/tworze kwerende/klasa mysqlcommand wbudowana w system
                connection.Open();//otwiera polaczenie
                var reader=command.ExecuteReader();//wykonuje sie zapytanie do bazy danych i pobiera sie wynik z tego zapytania //dla select
                while (reader.Read())//read-odczytuje jeden wiersz wyniku
                    osoby.Add(new Osoba(reader));//dodaje do lista z obiektami osoby
                connection.Close();//zamyka polaczenie
            }
                return osoby;
        }

        public static bool DodajOsobeDoBazy(Osoba osoba)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_OSOBE} {osoba.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();//wykonuje zapytanie do bazy danych //dla insert
                stan = true;
                osoba.Id = (sbyte)command.LastInsertedId;    //dopisanie do wlasciwosci obiektu id, ktora dostala ta osoba w bazie
                connection.Close();
            }
            return stan;
        }

        public static bool EdytujOsobeWBazie(Osoba osoba, sbyte idOsoby)
        {
            bool stan = false;//informacja czy sie udalo wykonać operacje na bazie danych
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_OSOBE = $"UPDATE osoby SET imie='{osoba.Imie}', nazwisko='{osoba.Nazwisko}', " +
                    $"wiek={osoba.Wiek}, miasto='{osoba.Miasto}' WHERE id_o={idOsoby}";

                MySqlCommand command = new MySqlCommand(EDYTUJ_OSOBE, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if(n==1) stan = true;
               
                connection.Close();
            }
            return stan;
        }

        public static bool UsunOsobeZBazy(Osoba osoba)
        {
            //implementacja/mozna dodac jak sie chce
            return true;
        }
        #endregion
    }
}
