using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Znajomi.DAL.Encje
{
    class Projekt
    {
        #region Własności
        public string Nazwa_projektu { get; set; }
        public string Cena { get; set; }
        public string Czas_wykonania { get; set; }
        #endregion

        #region Konstruktory

        //bardzo przydatny konstruktor tworzy obiekt na podstawie MySQLDataReader
        public Projekt(MySqlDataReader reader)
        {
            Nazwa_projektu = reader["nazwa_projektu"].ToString();//tostring zmienia typ na string
            Cena = reader["cena"].ToString();
            Czas_wykonania = reader["czas_wykonania"].ToString();
        }
        //konstruktor tworzacy obiekt nie dodany jeszcze do bazy z id pustym
        public Projekt(string nazwa_projektu,  string cena, string czas_wykonania)
        {
            Nazwa_projektu = nazwa_projektu.Trim();
            Cena = cena.Trim();
            Czas_wykonania = czas_wykonania.Trim();
        }

        public Projekt(Projekt projekt)
        {
            Nazwa_projektu = projekt.Nazwa_projektu;
            Cena = projekt.Cena;
            Czas_wykonania = projekt.Czas_wykonania;
        }

        #endregion

        #region Metody
        // ToString to jest metoda ktorą posada  każdy obiekt w C# - jakbyśmy jej tutaj nie dali, to nie mielibyśmy kontroli nad rzutowaniem obiektu na typ String
        // TStting to jest w zasadzie tylkko reprezentacja tekstowa obiektu
        public override string ToString()
        {
            return $"{Nazwa_projektu}, cena: {Cena}zł";
        }

        //metoda generuje string dla INSERT TO (nazwisko, imie, wiek, miasto)
        public string ToInsert()
        {
            return $"('{Nazwa_projektu}', '{Cena}','{Czas_wykonania}')";
        }
        // dzięki przeciążeniu tej metody, Contains (metoda wywoływana w innym miejscu w kodzie, wtedy kiedy chcemy sprawdzać czy elemernt należy do kolekcji)w liście sprawdzi czy dany obiekt do niej należy
        public override bool Equals(object obj)
        {
            //nie porównujemy ID
            var projekt = obj as Projekt;
            if (projekt is null) return false;
            if (Nazwa_projektu.ToLower() != projekt.Nazwa_projektu.ToLower()) return false;
            if (Czas_wykonania != projekt.Czas_wykonania) return false;
            if (Cena != projekt.Cena) return false;
            return true;
        }


        public override int GetHashCode()//to jak klucz glowny w bazie danych bo jest unikotowy/id identyfikujace obiekt w c#
        {
            return base.GetHashCode();//zwraca hasz kod(to id)
        }
        #endregion

    }
}
