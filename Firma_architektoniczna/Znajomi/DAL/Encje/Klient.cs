using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Znajomi.DAL.Encje
{
    class Klient
    {
        #region Własności
        public string Nazwa_klienta { get; set; }       
        public string Ilosc_pracownikow { get; set; }
        public string Wartosc_na_rynku { get; set; }
        #endregion

        #region Konstruktory

        //bardzo przydatny konstruktor tworzy obiekt na podstawie MySQLDataReader
        public Klient(MySqlDataReader reader)
        {
            Nazwa_klienta = reader["nazwa_klienta"].ToString();//tostring zmienia typ na string
            Ilosc_pracownikow = reader["ilość_pracowników"].ToString();//tu string sam
            Wartosc_na_rynku = reader["wartość_na_rynku"].ToString();
        }
        //konstruktor tworzacy obiekt nie dodany jeszcze do bazy z id pustym
        public Klient(string nazwa_klienta, string ilosc_pracownikow, string wartosc_na_rynku)
        {
            Nazwa_klienta = nazwa_klienta.Trim();
            Ilosc_pracownikow = ilosc_pracownikow.Trim();
            Wartosc_na_rynku = wartosc_na_rynku.Trim();
        }

        public Klient(Klient klient)
        {
            Nazwa_klienta = klient.Nazwa_klienta;
            Ilosc_pracownikow = klient.Ilosc_pracownikow;
            Wartosc_na_rynku = klient.Wartosc_na_rynku;
        }

        #endregion

        #region Metody
        // ToString to jest metoda ktorą posada  każdy obiekt w C# - jakbyśmy jej tutaj nie dali, to nie mielibyśmy kontroli nad rzutowaniem obiektu na typ String
        // TStting to jest w zasadzie tylkko reprezentacja tekstowa obiektu
        public override string ToString()
        {
            return $"{Nazwa_klienta}";
        }

        //metoda generuje string dla INSERT TO (nazwisko, imie, wiek, miasto)
        public string ToInsert()
        {
            return $"('{Nazwa_klienta}', '{Ilosc_pracownikow}', '{Wartosc_na_rynku}')";
        }
        // dzięki przeciążeniu tej metody, Contains (metoda wywoływana w innym miejscu w kodzie, wtedy kiedy chcemy sprawdzać czy elemernt należy do kolekcji)w liście sprawdzi czy dany obiekt do niej należy
        public override bool Equals(object obj)
        {
            //nie porównujemy ID
            var klient = obj as Klient;
            if (klient is null) return false;
            if (Nazwa_klienta.ToLower() != klient.Nazwa_klienta.ToLower()) return false;
            if (Ilosc_pracownikow != klient.Ilosc_pracownikow) return false;
            if (Wartosc_na_rynku != klient.Wartosc_na_rynku) return false;
            return true;
        }


        public override int GetHashCode()//to jak klucz glowny w bazie danych bo jest unikotowy/id identyfikujace obiekt w c#
        {
            return base.GetHashCode();//zwraca hasz kod(to id)
        }
        #endregion

    }
}
