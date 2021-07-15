using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Znajomi.DAL.Encje
{
    public class Umowa
    {
        #region Własności
        public string Nazwa { get; set; }
        public string Klient { get; set; }
        public string NazwaProjektu { get; set; }
        public string PeselArchitekta { get; set; }
        public string DataZawarcia { get; set; }
        public string TerminOstateczny { get; set; }
        public string Id { get; set; }
        #endregion

        #region Konstruktory
        public Umowa(MySqlDataReader reader)
        {
            PeselArchitekta = reader["pesel"].ToString();
            Nazwa = reader["nazwa_umowy"].ToString();
            Klient = reader["nazwa_klienta"].ToString();
            NazwaProjektu = reader["nazwa_projektu"].ToString();
            DataZawarcia = reader.GetDateTime("data_zawarcia").ToString("yyyy'-'MM'-'dd");
            TerminOstateczny = reader.GetDateTime("termin_ostateczny_do_zrealizowania_projektu").ToString("yyyy'-'MM'-'dd");
            Id = reader["id"].ToString();

        }

        //konstruktor tworzacy obiekt nie dodany jeszcze do bazy z id pustym
        public Umowa(string np, string k, string p, string n, string d, string t)
        {
            PeselArchitekta = p.Trim();
            Nazwa = n.Trim();
            NazwaProjektu = np.Trim();
            Klient = k.Trim();
            DataZawarcia = d.Trim();
            TerminOstateczny = t.Trim();
        }


        #endregion

        #region Metody
        public override string ToString()
        {
            return $"{Nazwa}, projekt: {NazwaProjektu}, termin: {TerminOstateczny}";
        }

        public string ToInsert()
        {
            return $"('{NazwaProjektu}','{Klient}','{PeselArchitekta}','{Nazwa}','{DataZawarcia}','{TerminOstateczny}')";
        }
        #endregion
    }
}
