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

    static class RepozytoriumArchitekci
    {
        #region ZAPYTANIA
        private const string WSZYSCY_ARCHITEKCI = "SELECT * FROM architekci";
        #endregion


        public static List<Architekt> PobierzWszystkichArchitektow()
        {
            List<Architekt> architekci = new List<Architekt>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSCY_ARCHITEKCI, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    architekci.Add(new Architekt(reader));
                connection.Close();
            }
            return architekci;
        }
    }
}
