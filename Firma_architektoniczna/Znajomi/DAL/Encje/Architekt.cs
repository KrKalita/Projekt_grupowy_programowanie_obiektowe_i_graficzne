using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Znajomi.DAL.Encje
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

        //bardzo przydatny konstruktor tworzy obiekt na podstawie MySQLDataReader
        public Architekt(MySqlDataReader reader)
        {
            Pesel = reader["pesel"].ToString();//tostring zmienia typ na string
            Imie = reader["imię"].ToString();
            Nazwisko = reader["nazwisko"].ToString();
            Numer = reader["numer"].ToString();
        }
        //konstruktor tworzacy obiekt nie dodany jeszcze do bazy z id pustym
        public Architekt(string imie, string nazwisko, string pesel, string telefon)
        {
            Pesel = pesel.Trim();
            Imie = imie.Trim();
            Nazwisko = nazwisko.Trim();
            Numer = telefon.Trim();
        }
        //konstruktor
        public Architekt(Architekt architekt)
        {
            Pesel = architekt.Pesel;
            Imie = architekt.Imie;
            Nazwisko = architekt.Nazwisko;
            Numer = architekt.Numer;
        }

        #endregion

        #region Metody
        // ToString to jest metoda ktorą posada  każdy obiekt w C# - jakbyśmy jej tutaj nie dali, to nie mielibyśmy kontroli nad rzutowaniem obiektu na typ String
        // TStting to jest w zasadzie tylkko reprezentacja tekstowa obiektu
        public override string ToString()
        {
            return $"{Nazwisko} {Imie}, tel: {Numer}, PESEL: {Pesel}";
        }

        //metoda generuje string dla INSERT TO (nazwisko, imie, wiek, miasto)
        public string ToInsert()
        {
            return $"('{Pesel}', '{Imie}', '{Nazwisko}','{Numer}')";
        }
        // dzięki przeciążeniu tej metody, Contains (metoda wywoływana w innym miejscu w kodzie, wtedy kiedy chcemy sprawdzać czy elemernt należy do kolekcji)w liście sprawdzi czy dany obiekt do niej należy
        public override bool Equals(object obj)
        {
            //nie porównujemy ID
            var architekt = obj as Architekt;
            if (architekt is null) return false;
            if (Imie.ToLower() != architekt.Imie.ToLower()) return false;
            if (Nazwisko.ToLower() != architekt.Nazwisko.ToLower()) return false;
            if (Numer != architekt.Numer) return false;
            return true;
        }


        public override int GetHashCode()//to jak klucz glowny w bazie danych bo jest unikotowy/id identyfikujace obiekt w c#
        {
            return base.GetHashCode();//zwraca hasz kod(to id)
        }
        #endregion

    }
}
