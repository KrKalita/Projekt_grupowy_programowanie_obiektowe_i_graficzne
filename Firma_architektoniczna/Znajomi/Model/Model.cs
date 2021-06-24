﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Znajomi.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;

    class Model
    {
        //stan bazy
        public ObservableCollection<Architekt> Architekci { get; set; } = new ObservableCollection<Architekt>();//przechowuje liste osob z bazy danych

        public ObservableCollection<Osoba> Osoby { get; set; } = new ObservableCollection<Osoba>();//przechowuje liste osob z bazy danych
        public ObservableCollection<Telefon> Telefony { get; set; } = new ObservableCollection<Telefon>();//przechowuje liste telefonow z bazy danych
        public ObservableCollection<Posiadanie> Posiadanie { get; set; } = new ObservableCollection<Posiadanie>();
        

        public Model()
        {
            //pobranie dabych z bazy do kolekcji
            var architekci = RepozytoriumArchitekci.PobierzWszystkichArchitektow();//var-typ automatyczny, c# sam wykmini jaki to typ
            foreach (var a in architekci)
                Architekci.Add(a);//dodanie architekta

            //var osoby= RepozytoriumOsoby.PobierzWszystkieOsoby();//var-typ automatyczny, c# sam wykmini jaki to typ
            //foreach (var o in osoby)
            //    Osoby.Add(o);//dodanie osoby
            //var telefony = RepozytoriumTelefony.PonierzWszystkieTelefony();
            //foreach (var t in telefony)
            //    Telefony.Add(t);
            //var posiadanie = RepozytoriumPosiadanie.PobierzWszystkiePosiadania();//pol to posiadanie w bazie danych
            //foreach (var p in posiadanie)
            //    Posiadanie.Add(p);
        }



        private Telefon ZnajdzTelefonPoId(sbyte id)
        {
            foreach (var t in Telefony) // iterujemy po kolekcji Telfony, w zmiennej t mamy dostęp do aktulanego telefonu wybranego z kolekcji Telefony
            {
                if (t.Id == id)
                    return t;
            }
            return null;
        }

        private Osoba ZnajdzOsobePoId(sbyte id)
        {
            foreach (var o in Osoby)
            {
                if (o.Id == id)
                    return o;
            }
            return null;
        }

        public ObservableCollection<Telefon> PobierzTelefonyOsoby(Osoba osoba)
        {
            var telefony = new ObservableCollection<Telefon>();
            foreach (var posiada in Posiadanie)
            {
                if (posiada.IdOsoby == osoba.Id) // szukam takiego wiersza w bazie zeby Id osoby dla ktorej szukam bylo takie same jak Id skojarzone z Id telefonu w tabeli posiadanie
                {
                    telefony.Add(ZnajdzTelefonPoId(posiada.IdTelefonu));
                }
            }

            return telefony;
        }

        public ObservableCollection<Osoba> PobierzWlascicieliTelefonu(Telefon telefon)
        {
            var osoby = new ObservableCollection<Osoba>();
            foreach (var posiada in Posiadanie)
            {
                if (posiada.IdTelefonu == telefon.Id) // szukam takiego wiersza w bazie zeby Id telefonu dla ktorego szukam bylo takie same jak Id skojarzone z Id osoby w tabeli posiadanie
                {
                    osoby.Add(ZnajdzOsobePoId(posiada.IdOsoby));
                }
            }

            return osoby;
        }

        public bool CzyOsobaJestJuzWRepozytorium(Osoba osoba)=>Osoby.Contains(osoba);  // tu "niejawnie" wywoła się metoda Equals
        

        public bool DodajOsobeDoBazy(Osoba osoba)
        {
            if (!CzyOsobaJestJuzWRepozytorium(osoba))
            {
                if (RepozytoriumOsoby.DodajOsobeDoBazy(osoba))
                {
                    Osoby.Add(osoba);
                    return true;
                }
            }
            return false;
        }

        // Dodawanie telefonu do bazy danych
        public bool CzyTelefonJestJuzWRepozytorium(Telefon telefon) => Telefony.Contains(telefon);

        public bool DodajTelefonDoBazy(Telefon telefon)
        {
            if (!CzyTelefonJestJuzWRepozytorium(telefon))
            {
                if (RepozytoriumTelefony.DodajTelefonDoBazy(telefon))
                {
                    Telefony.Add(telefon);  // dodalismy telefon do bazy wiec aktualizujemy liste telefonow w programie (bo w bazie danych juz zaktualizowalem wczesniej)
                    return true;
                }
            }
            return false;
        }

        // Dodawanie posiadania telefonu (polaczenie pomiedzy telefonem a wlascicielem)
        public bool CzyPosiadanieJestJuzWRepozytorium(Posiadanie posiadanie) => Posiadanie.Contains(posiadanie);

        public bool DodajPosiadanieDoBazy(Posiadanie posiadanie)
        {
            if (!CzyPosiadanieJestJuzWRepozytorium(posiadanie))
            {
                if (RepozytoriumPosiadanie.DodajPosiadanieDoBazy(posiadanie))
                {
                    Posiadanie.Add(posiadanie);  // aktualizujem liste posiadań (bo w bazie juz zaktualizowałem dopiero co)
                    return true;
                }
            }
            return false;
        }


        public bool EdytujOsobeWBazie(Osoba osoba, sbyte idOsoby)
        {
            if (RepozytoriumOsoby.EdytujOsobeWBazie(osoba,idOsoby))
            {
                for(int i=0;i<Osoby.Count;i++)
                {
                    if (Osoby[i].Id == idOsoby)
                    {
                        osoba.Id = idOsoby;
                        Osoby[i] = new Osoba(osoba);
                    }
                }
                return true;
            }
            return false;
        }

    }
}
