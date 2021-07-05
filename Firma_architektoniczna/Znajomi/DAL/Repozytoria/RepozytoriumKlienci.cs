using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Znajomi.DAL.Encje;

namespace Znajomi.DAL.Repozytoria
{
    static class RepozytoriumKlienci
    {
        #region ZAPYTANIA
        private const string WSZYSCY_KLIENCI = "SELECT * FROM klienci";
        private const string DODAJ_KLIENTA = "INSERT INTO `firma_architektoniczna`.`klienci`(`nazwa_klienta`, `ilość_pracowników`, `wartość_na_rynku`) VALUES ";
        #endregion

        #region metody CRUD 
        /// <summary>
        /// CRUD - create, read, update, delete
        /// </summary>
        /// <returns></returns>
        public static List<Klient> PobierzWszystkichKlientow()
        {
            List<Klient> klienci = new List<Klient>();//lista z obiektami osoby
            using (var connection = DBConnection.Instance.Connection)//wykorzystuje sie do polaczenia z baza danych/chroni przed skutkami bledow
            {
                MySqlCommand command = new MySqlCommand(WSZYSCY_KLIENCI, connection);//obiekt typu mysqlcommand/tworze kwerende/klasa mysqlcommand wbudowana w system
                connection.Open();//otwiera polaczenie
                var reader = command.ExecuteReader();//wykonuje sie zapytanie do bazy danych i pobiera sie wynik z tego zapytania //dla select
                while (reader.Read())//read-odczytuje jeden wiersz wyniku
                    klienci.Add(new Klient(reader));//dodaje do lista z obiektami osoby
                connection.Close();//zamyka polaczenie
            }
            return klienci;
        }

        public static bool DodajKlientaDoBazy(Klient klient)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_KLIENTA} {klient.ToInsert()}", connection);
                connection.Open();
                command.ExecuteNonQuery();//wykonuje zapytanie do bazy danych //dla insert
                stan = true;
                connection.Close();
            }
            return stan;
        }

        public static bool EdytujKlientaWBazie(Klient klient, string nazwa_klienta)
        {
            bool stan = false;//informacja czy sie udalo wykonać operacje na bazie danych
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_KLIENTA = $"UPDATE klienci SET nazwa_klienta='{klient.Nazwa_klienta}', ilość_pracowników='{klient.Ilosc_pracownikow}', " +
                    $"wartość_na_rynku='{klient.Wartosc_na_rynku}' WHERE nazwa_klienta='{nazwa_klienta}'";

                MySqlCommand command = new MySqlCommand(EDYTUJ_KLIENTA, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }

        public static bool UsunKlientaZBazy(string nazwa_klienta)
        {
            bool stan = false;//informacja czy sie udalo wykonać operacje na bazie danych
            using (var connection = DBConnection.Instance.Connection)
            {
                string USUN_KLIENTA = $"DELETE FROM `klienci` WHERE nazwa_klienta='{nazwa_klienta}'";

                MySqlCommand command = new MySqlCommand(USUN_KLIENTA, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }

        #endregion
    }
}
