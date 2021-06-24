using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt.DAL.Repozytoria
{
    using Encje;
    using MySqlConnector;
    using System.Windows;

    static class RepozytoriumUmowy
    {
        #region ZAPYTANIA
        private const string WSZYSTKIE_UMOWY = "SELECT * FROM umowy";
        #endregion


        public static List<Umowa> PobierzUmowyArchitekta(Architekt architekt)
        {
            
            List<Umowa> umowy = new List<Umowa>();

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
