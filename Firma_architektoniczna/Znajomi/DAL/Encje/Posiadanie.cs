using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Znajomi.DAL.Encje
{
    class Posiadanie
    {
        #region Własności
        public sbyte IdTelefonu{ get; set; }
        public sbyte IdOsoby { get; set; }
        public sbyte IdPosiadania { get; set; }

        #endregion

        #region Konstruktory
        public Posiadanie(MySqlDataReader reader)
        {
            IdPosiadania = sbyte.Parse(reader["id_p"].ToString());
            IdTelefonu = sbyte.Parse(reader["id_t"].ToString());
            IdOsoby = sbyte.Parse(reader["id_o"].ToString());
        }

        // int a = null - to zgłosi błąd, bo integer nie może mieć wartość null
        //int? a = null - to nie zgłosi błędu, bo daliśmy ? czyli umożliwiliśmy integerowi przyjmowanie wartosci null
        // Konstruktor tworzy obiekt typu Posiadanie
        public Posiadanie(sbyte? idTelefonu, sbyte? idOsoby)
        {
            if (idTelefonu != null && idOsoby != null)
            {
                IdTelefonu = (sbyte) idTelefonu; 
                IdOsoby = (sbyte) idOsoby;
            }
            
        }
        #endregion

        #region Metody

        public override string ToString()
        {
            return $"{IdPosiadania} IdTelefonu: {IdTelefonu} IdOsoby {IdOsoby}";
        }

        //metoda generuje string dla INSERT TO (nazwisko, imie, wiek, miasto) na potrzeby dodawania rekordu do bazy
        public string ToInsert()
        {
            return $"('{IdOsoby}', '{IdTelefonu}')";
        }
        //dzięki przeciążeniu tej metody Contains w liście sprawdzi czy dany obiekt do niej należy - innymi slowy robimy to po to zeby nie dodawac duplikatow do bazy danych
        public override bool Equals(object obj)
        {
            //nie porównujemy ID
            var posiadanie = obj as Posiadanie;
            if (posiadanie is null) return false;
            if (IdOsoby != posiadanie.IdOsoby) return false;
            if (IdTelefonu != posiadanie.IdTelefonu) return false;
            return true;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

    }
}
