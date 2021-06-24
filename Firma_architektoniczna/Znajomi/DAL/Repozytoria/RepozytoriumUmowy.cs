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
    }
}
