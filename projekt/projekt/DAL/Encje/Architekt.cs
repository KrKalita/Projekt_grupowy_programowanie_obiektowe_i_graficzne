using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt.DAL.Encje
{
    class Architekt
    {
        #region Własności
            public string Pesel { get; set; }  
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public string Numer { get; set; }
        #endregion

        #region Konstruktory
        public Architekt(MySqlDataReader reader)
        {
            Pesel = reader["pesel"].ToString();
            Imie = reader["imię"].ToString();
            Nazwisko = reader["nazwisko"].ToString();
            Numer = reader["numer"].ToString();

        }

        //konstruktor tworzacy obiekt nie dodany jeszcze do bazy z id pustym
        public Architekt(string p,string i, string na, string nu)
        {
            Pesel = p.Trim();
            Imie = i.Trim();
            Nazwisko = na.Trim();
            Numer = nu.Trim();
        }


        #endregion

        #region Metody
        public override string ToString()
        {
            return $"{Imie} {Nazwisko}, pesel: {Pesel}";
        }
        #endregion
    }
}
