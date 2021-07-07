using System;
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

        public ObservableCollection<Umowa> Umowy { get; set; } = new ObservableCollection<Umowa>();//przechowuje liste osob z bazy danych

        public ObservableCollection<Projekt> Projekty { get; set; } = new ObservableCollection<Projekt>();//przechowuje liste osob z bazy danych
        public ObservableCollection<Klient> Klienci { get; set; } = new ObservableCollection<Klient>();//przechowuje liste osob z bazy danych


        public Model()
        {
            //pobranie dabych z bazy do kolekcji
            var architekci = RepozytoriumArchitekci.PobierzWszystkichArchitektow();//var-typ automatyczny, c# sam wykmini jaki to typ
            foreach (var a in architekci)
                Architekci.Add(a);//dodanie architekta

            var umowy = RepozytoriumUmowy.PobierzWszystkieUmowy();//var-typ automatyczny, c# sam wykmini jaki to typ
            foreach (var u in umowy)
                Umowy.Add(u);//dodanie umowy

            var projekty = RepozytoriumProjekty.PobierzWszystkieProjekty();//var-typ automatyczny, c# sam wykmini jaki to typ
            foreach (var b in projekty)
                Projekty.Add(b);//dodanie projektu

            var klienci = RepozytoriumKlienci.PobierzWszystkichKlientow();//var-typ automatyczny, c# sam wykmini jaki to typ
            foreach (var c in klienci)
                Klienci.Add(c);//dodanie klienta
        }


        public ObservableCollection<Umowa> PobierzUmowyArchitekta(Architekt architekt)
        {
            return RepozytoriumUmowy.PobierzUmowyArchitekta(architekt);
        }
        public ObservableCollection<Umowa> PobierzUmowyKlienta(Klient klient)
        {
            return RepozytoriumUmowy.PobierzUmowyKlienta(klient);
        }


        public bool CzyArchitektJestJuzWRepozytorium(Architekt architekt) =>Architekci.Contains(architekt);  // tu "niejawnie" wywoła się metoda Equals
        

        public bool DodajArchitektaDoBazy(Architekt architekt)
        {
            if (!CzyArchitektJestJuzWRepozytorium(architekt))
            {
                if (RepozytoriumArchitekci.DodajArchitektaDoBazy(architekt))
                {
                    Architekci.Add(architekt);
                    return true;
                }
            }
            return false;
        }

        public bool CzyProjektJestJuzWRepozytorium(Projekt projekt) => Projekty.Contains(projekt);  // tu "niejawnie" wywoła się metoda Equals


        public bool DodajProjektDoBazy(Projekt projekt)
        {
            if (!CzyProjektJestJuzWRepozytorium(projekt))
            {
                if (RepozytoriumProjekty.DodajProjektDoBazy(projekt))
                {
                    Projekty.Add(projekt);
                    return true;
                }
            }
            return false;
        }

        public bool CzyUmowaJestJuzWRepozytorium(Umowa umowa) => Umowy.Contains(umowa);  // tu "niejawnie" wywoła się metoda Equals


        public bool DodajUmoweDoBazy(Umowa umowa)
        {
            if (!CzyUmowaJestJuzWRepozytorium(umowa))
            {
                if (RepozytoriumUmowy.DodajUmoweDoBazy(umowa))
                {
                    Umowy.Add(umowa);
                    return true;
                }
            }
            return false;
        }


        public bool CzyKlientJestJuzWRepozytorium(Klient klient) => Klienci.Contains(klient);  // tu "niejawnie" wywoła się metoda Equals


        public bool DodajKlientaDoBazy(Klient klient)
        {
            if (!CzyKlientJestJuzWRepozytorium(klient))
            {
                if (RepozytoriumKlienci.DodajKlientaDoBazy(klient))
                {
                    Klienci.Add(klient);
                    return true;
                }
            }
            return false;
        }




        public bool EdytujArchitektaWBazie(Architekt architekt, string pesel)
        {
            if (RepozytoriumArchitekci.EdytujArchitektaWBazie(architekt, pesel))
            {
                Architekci.Clear();

                var architekci = RepozytoriumArchitekci.PobierzWszystkichArchitektow();
                foreach (var a in architekci)
                    Architekci.Add(a);

                return true;
            }
            return false;
        }

        public bool EdytujUmoweWBazie(Umowa umowa, string id)
        {
            if (RepozytoriumUmowy.EdytujUmoweWBazie(umowa, id))
            {
                Umowy.Clear();

                var umowy = RepozytoriumUmowy.PobierzWszystkieUmowy();
                foreach (var u in umowy)
                    Umowy.Add(u);

                return true;
            }
            return false;
        }

        public bool UsunArchitektaZBazy(string pesel)
        {
            if (RepozytoriumArchitekci.UsunArchitektaZBazy(pesel))
            {
                Architekci.Clear();

                var architekci = RepozytoriumArchitekci.PobierzWszystkichArchitektow();
                foreach (var a in architekci)
                    Architekci.Add(a);
                return true;
            }
            return false;
        }

        public bool UsunUmoweZBazy(string id)
        {
            if (RepozytoriumUmowy.UsunUmoweZBazy(id))
            {
                Umowy.Clear();

                var umowy = RepozytoriumUmowy.PobierzWszystkieUmowy();
                foreach (var u in umowy)
                    Umowy.Add(u);

                return true;
            }
            return false;
        }

        public bool EdytujProjektWBazie(Projekt projekt, string nazwa_projektu)
        {
            if (RepozytoriumProjekty.EdytujProjektWBazie(projekt, nazwa_projektu))
            {
                Projekty.Clear();

                var projekty = RepozytoriumProjekty.PobierzWszystkieProjekty();
                foreach (var a in projekty)
                    Projekty.Add(a);
                return true;
            }
            return false;
        }

        public bool UsunProjektZBazy(string nazwa_projektu)
        {
            if (RepozytoriumProjekty.UsunProjektZBazy(nazwa_projektu))
            {
                Projekty.Clear();

                var projekty = RepozytoriumProjekty.PobierzWszystkieProjekty();
                foreach (var a in projekty)
                    Projekty.Add(a);
                return true;
            }
            return false;
        }
        public bool EdytujKlientaWBazie(Klient klient, string nazwa_klienta)
        {
            if (RepozytoriumKlienci.EdytujKlientaWBazie(klient, nazwa_klienta))
            {
                Klienci.Clear();

                var klienci = RepozytoriumKlienci.PobierzWszystkichKlientow();
                foreach (var a in klienci)
                    Klienci.Add(a);

                return true;
            }
            return false;
        }

        public bool UsunKlientaZBazy(string nazwa_klienta)
        {
            if (RepozytoriumKlienci.UsunKlientaZBazy(nazwa_klienta))
            {
                Klienci.Clear();

                var klienci = RepozytoriumKlienci.PobierzWszystkichKlientow();
                foreach (var a in klienci)
                    Klienci.Add(a);
                return true;
            }
            return false;
        }

    }
}
