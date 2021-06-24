using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Znajomi.DAL.Encje
{
    class Osoba
    {
        #region Własności
        public sbyte? Id { get; set; }
       public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public sbyte Wiek { get; set; }
        public string Miasto { get; set; }
        #endregion

        #region Konstruktory
        
        //bardzo przydatny konstruktor tworzy obiekt na podstawie MySQLDataReader
        public Osoba(MySqlDataReader reader)
        {
            Id = sbyte.Parse(reader["id_o"].ToString());//tostring zmienia typ na string//sbyte.Parse zmiana typu na sbyte//ostatecznie typ sbyte(typ liczbowy)
            Imie = reader["imie"].ToString();//tu string sam
            Nazwisko = reader["nazwisko"].ToString();
            Wiek = sbyte.Parse(reader["wiek"].ToString());
            Miasto = reader["miasto"].ToString();
        }
        //konstruktor tworzacy obiekt nie dodany jeszcze do bazy z id pustym
        public Osoba(string imie, string nazwisko, sbyte wiek, string miasto)
        {
            Id = null;
            Imie = imie.Trim();
            Nazwisko = nazwisko.Trim();
            Wiek = wiek;
            Miasto = miasto.Trim();
        }

        public Osoba(Osoba osoba)
        {
            Id = osoba.Id;
            Imie = osoba.Imie;
            Nazwisko = osoba.Nazwisko;
            Wiek = osoba.Wiek;
            Miasto = osoba.Miasto;
        }
    
        #endregion

        #region Metody
       // ToString to jest metoda ktorą posada  każdy obiekt w C# - jakbyśmy jej tutaj nie dali, to nie mielibyśmy kontroli nad rzutowaniem obiektu na typ String
       // TStting to jest w zasadzie tylkko reprezentacja tekstowa obiektu
        public override string ToString()
        {
            return $"{Nazwisko} {Imie} lat {Wiek} z {Miasto}";
        }

        //metoda generuje string dla INSERT TO (nazwisko, imie, wiek, miasto)
        public string ToInsert()
        {
            return $"('{Nazwisko}', '{Imie}', {Wiek},'{Miasto}')";
        }
        // dzięki przeciążeniu tej metody, Contains (metoda wywoływana w innym miejscu w kodzie, wtedy kiedy chcemy sprawdzać czy elemernt należy do kolekcji)w liście sprawdzi czy dany obiekt do niej należy
        public override bool Equals(object obj)
        {
            //nie porównujemy ID
            var osoba = obj as Osoba;
            if (osoba is null) return false;
            if(Imie.ToLower()!=osoba.Imie.ToLower()) return false;
            if (Nazwisko.ToLower() != osoba.Nazwisko.ToLower()) return false;
            if (Wiek != osoba.Wiek) return false;
            if (Miasto.ToLower() != osoba.Miasto.ToLower()) return false;
            return true;
        }


        public override int GetHashCode()//to jak klucz glowny w bazie danych bo jest unikotowy/id identyfikujace obiekt w c#
        {
            return base.GetHashCode();//zwraca hasz kod(to id)
        }
        #endregion

    }
}
