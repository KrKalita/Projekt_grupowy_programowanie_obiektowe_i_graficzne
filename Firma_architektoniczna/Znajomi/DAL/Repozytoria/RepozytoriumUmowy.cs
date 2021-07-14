using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Znajomi.DAL.Encje;

namespace Znajomi.DAL.Repozytoria
{
    static class RepozytoriumUmowy
    {
        #region ZAPYTANIA
        private const string WSZYSTKIE_UMOWY = "SELECT * FROM umowy";
        private const string DODAJ_UMOWE = "INSERT INTO `firma_architektoniczna`.`umowy`(`nazwa_projektu`, `nazwa_klienta`, `pesel`,`nazwa_umowy`,`data_zawarcia`,`termin_ostateczny_do_zrealizowania_projektu`) VALUES ";

        #endregion


        public static ObservableCollection<Umowa> PobierzWszystkieUmowy()
        {
            ObservableCollection<Umowa> umowy = new ObservableCollection<Umowa>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_UMOWY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    umowy.Add(new Umowa(reader));
                connection.Close();
            }
            return umowy;
        }

        public static ObservableCollection<Umowa> PobierzUmowyArchitekta(Architekt architekt)
        {

            ObservableCollection<Umowa> umowy = new ObservableCollection<Umowa>();

            if (architekt == null)
                return umowy;

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"SELECT * FROM umowy WHERE pesel=\"{architekt.Pesel}\"", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    umowy.Add(new Umowa(reader));
                connection.Close();
            }
            return umowy;
        }
        public static ObservableCollection<Umowa> PobierzUmowyKlienta(Klient klient)
        {

            ObservableCollection<Umowa> umowy = new ObservableCollection<Umowa>();

            if (klient == null)
                return umowy;

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"SELECT * FROM umowy WHERE nazwa_klienta=\"{klient.Nazwa_klienta}\"", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    umowy.Add(new Umowa(reader));
                connection.Close();
            }
            return umowy;
        }



        public static bool DodajUmoweDoBazy(Umowa umowa)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_UMOWE} {umowa.ToInsert()}", connection);
                connection.Open();
                command.ExecuteNonQuery();//wykonuje zapytanie do bazy danych //dla insert
                stan = true;
                connection.Close();
            }
            return stan;
        }

        public static bool EdytujUmoweWBazie(Umowa umowa, string id)
        {
            bool stan = false;//informacja czy sie udalo wykonać operacje na bazie danych
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_UMOWE = $"UPDATE umowy SET pesel='{umowa.PeselArchitekta}', nazwa_projektu='{umowa.NazwaProjektu}', nazwa_klienta='{umowa.Klient}', " +
                    $"nazwa_umowy='{umowa.Nazwa}', data_zawarcia='{umowa.DataZawarcia}', termin_ostateczny_do_zrealizowania_projektu='{umowa.TerminOstateczny}' WHERE id='{id}'";

                MySqlCommand command = new MySqlCommand(EDYTUJ_UMOWE, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }

        public static bool UsunUmoweZBazy(string id)
        {
            bool stan = false;//informacja czy sie udalo wykonać operacje na bazie danych
            using (var connection = DBConnection.Instance.Connection)
            {
                string USUN_UMOWE = $"DELETE FROM `umowy` WHERE id={id}";

                MySqlCommand command = new MySqlCommand(USUN_UMOWE, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }
    }
}
