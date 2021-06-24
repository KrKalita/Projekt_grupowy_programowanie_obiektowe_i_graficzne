using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Znajomi.DAL.Encje
{
    class Telefon
    {
        #region Własności
            public sbyte? Id { get; set; }  // ? oznacza typ "nullowalny", czyli ze mozne przyjmowac wartosc null
            public string Numer { get; set; }
            public string Typ { get; set; }
            public string Operator { get; set; }
        #endregion

        #region Konstruktory
        public Telefon(MySqlDataReader reader)
        {
            Id = sbyte.Parse(reader["id_t"].ToString());
            Numer = reader["numer"].ToString();
            Typ = reader["typ"].ToString();
            Operator = reader["operator"].ToString();

        }

        //konstruktor tworzacy obiekt nie dodany jeszcze do bazy z id pustym
        public Telefon(string numer, string typ, string operatorAddPhone)
        {
            Id = null;
            Numer = numer.Trim();
            Typ = typ.Trim();
            Operator = operatorAddPhone.Trim();
        }


        #endregion

        #region Metody
        public override string ToString()
        {
            return $"{Numer} typ: {Typ} oprator {Operator}";
        }

        //metoda generuje string dla INSERT TO (nazwisko, imie, wiek, miasto) na potrzeby dodawania rekordu do bazy
        public string ToInsert()
        {
            return $"('{Numer}', '{Operator}', '{Typ}')";
        }
        //dzięki przeciążeniu tej metody Contains w liście sprawdzi czy dany obiekt do niej należy
        public override bool Equals(object obj)
        {
            //nie porównujemy ID
            var telefon = obj as Telefon;
            if (telefon is null) return false;
            if (Numer.ToLower() != telefon.Numer.ToLower()) return false;
            if (Operator.ToLower() != telefon.Operator.ToLower()) return false;
            if (Typ.ToLower() != telefon.Typ.ToLower()) return false;
            return true;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
