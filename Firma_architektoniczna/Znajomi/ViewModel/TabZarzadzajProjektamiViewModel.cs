using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Znajomi.DAL.Encje;
using Znajomi.ViewModel.BaseClass;


namespace Znajomi.ViewModel
{
    using Znajomi.Model;
    class TabZarzadzajProjektamiViewModel : ViewModelBase
    {
        #region Składowe prywatne
        //referencja do instancji(obiektu) modelu
        private Model model = null;

        private string nazwa_projektu = "", cena = "", czas_wykonania = "";
        private int idZaznaczenia = -1;
        private bool dodawanieDostepne = false;
        private bool usunDostepne = false;
        private bool edycjaDostepna = false;
        #endregion

        #region Konstruktory
        public TabZarzadzajProjektamiViewModel(Model model)
        {
            this.model = model;
            Projekty = model.Projekty;
        }
        #endregion

        #region Właściwości

        public Projekt BiezacyProjekt { get; set; }

        public string Nazwa_projektu
        {
            get { return nazwa_projektu; }
            set
            {
                nazwa_projektu = value;

                onPropertyChanged(nameof(Nazwa_projektu));//to robie zeby zaktualizowalo kolumne imie

                SprawdzPoprawnoscDanych();
            }
        }

        public string Cena
        {
            get { return cena; }
            set
            {
                cena = value;

                onPropertyChanged(nameof(Cena));

                SprawdzPoprawnoscDanych();


            }
        }
        public string Czas_wykonania
        {
            get { return czas_wykonania; }
            set
            {
                czas_wykonania = value;

                onPropertyChanged(nameof(Czas_wykonania));

                SprawdzPoprawnoscDanych();


            }
        }

        public int IdZaznaczenia
        {
            get { return idZaznaczenia; }
            set
            {
                idZaznaczenia = value;
                onPropertyChanged(nameof(IdZaznaczenia));

                if (idZaznaczenia == -1)
                    UsunDostepne = false;
                else
                    UsunDostepne = true;
            }
        }
        public ObservableCollection<Projekt> Projekty { get; set; }
        //ta wlasciwosc jest potrzebna czy mozna kliknąć przycisk dodawania do bazy

        public bool DodawanieDostepne
        {
            get { return dodawanieDostepne; }
            set
            {
                dodawanieDostepne = value;
                onPropertyChanged(nameof(DodawanieDostepne));
            }
        }


        public bool EdycjaDostepna
        {
            get { return edycjaDostepna; }
            set
            {
                edycjaDostepna = value;
                onPropertyChanged(nameof(EdycjaDostepna));
            }
        }

        public bool UsunDostepne
        {
            get { return usunDostepne; }
            set
            {
                usunDostepne = value;
                onPropertyChanged(nameof(UsunDostepne));
            }
        }
        #endregion

        //trzeba wyczyścic pole tekstowe zeby wprowadzic nowe dane
        private void CzyscFormularz()
        {
            Nazwa_projektu = "";
            Cena = "";
            Czas_wykonania = "";
            IdZaznaczenia = -1;
            DodawanieDostepne = false;
            EdycjaDostepna = false;
            UsunDostepne = false;
        }
        private bool Sprawdzenie1(string Cena)
        {
            char[] arr;

            arr = Cena.ToCharArray(0, Cena.Length);
            int b = 0;
            for (int i = 0; i < Cena.Length; i++)
            {
                char[] arrr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '.', '9' };
                for (int j = 0; j < 11; j++)
                {
                    if (arr[i] != arrr[j])
                    {
                        b = b + 1;
                    }
                    if (b == 11)
                    {
                        return false;
                    }
                }
                b = 0;
            }
            return true;
        }
        private bool Sprawdzenie2(string Czas_wykonania)
        {
            char[] arr;

            arr = Czas_wykonania.ToCharArray(0, Czas_wykonania.Length);
            int b = 0;
            for (int i = 0; i < Czas_wykonania.Length; i++)
            {
                char[] arrr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                for (int j = 0; j < 10; j++)
                {
                    if (arr[i] != arrr[j])
                    {
                        b = b + 1;
                    }
                    if (b == 10)
                    {
                        return false;
                    }
                }
                b = 0;
            }
            return true;
        }
        private bool Sprawdzenie3(string Nazwa_projektu)
        {
            if (Nazwa_projektu.Length > 255)
            {
                return false;
            }
            return true;
        }
        private void SprawdzPoprawnoscDanych()
        {
            //sprawdz czy dany nazwa_projektu juz nie wystepuje
            bool wystepuje = false;
            for (int i = 0; i < Projekty.Count; i++)
            {
                if (Projekty[i].Nazwa_projektu == Nazwa_projektu)
                {
                    wystepuje = true;
                }
            }


            //wszystko pasuje
            if (Sprawdzenie3(Nazwa_projektu) && Sprawdzenie1(Cena) && Sprawdzenie2(Czas_wykonania) && !wystepuje)
            {
                DodawanieDostepne = true;
                if (IdZaznaczenia != -1 && Nazwa_projektu == BiezacyProjekt.Nazwa_projektu)
                    EdycjaDostepna = true;
                else
                    EdycjaDostepna = false;
            }
            //cos nie pasuje
            else
            {
                DodawanieDostepne = false;
                //warunki dla edycji - wszystko pasuje, a nazwa projektu jest ta sama co zaznaczonego projektu
                if (Sprawdzenie3(Nazwa_projektu) && Sprawdzenie1(Cena) && Sprawdzenie2(Czas_wykonania) && IdZaznaczenia != -1 && Nazwa_projektu == BiezacyProjekt.Nazwa_projektu)
                    EdycjaDostepna = true;
                else
                    EdycjaDostepna = false;
            }

        }

        #region Polecenia


        //Polecenie Dodaj odpowiedzialne za dodane nowego projektu do bazy danych
        private ICommand dodaj = null;

        public ICommand Dodaj
        {

            get
            {
                if (dodaj == null)
                    dodaj = new RelayCommand(
                        arg =>
                        {
                            var projekt = new Projekt(Nazwa_projektu, Cena, Czas_wykonania);

                            if (model.DodajProjektDoBazy(projekt))
                            {
                                CzyscFormularz();
                                System.Windows.MessageBox.Show("Projekt został dodany do bazy!");
                            }
                        }
                        ,
                        arg => (Nazwa_projektu != "") && (Cena != "") && (Czas_wykonania != "")
                        );


                return dodaj;
            }

        }


        //Laduj formularz odpowiada za załadowanie formularz zaznaczoną pozycją w tabeli
        private ICommand ladujFormularz = null;
        public ICommand LadujFormularz
        {

            get
            {
                if (ladujFormularz == null)
                    ladujFormularz = new RelayCommand(
                        arg =>
                        {
                            if (IdZaznaczenia > -1)
                            {
                                Nazwa_projektu = BiezacyProjekt.Nazwa_projektu;
                                Cena = BiezacyProjekt.Cena;
                                Czas_wykonania = BiezacyProjekt.Czas_wykonania;
                                DodawanieDostepne = false;
                                EdycjaDostepna = true;
                            }
                            else
                            {
                                Nazwa_projektu = "";
                                Cena = "";
                                Czas_wykonania = "";
                                DodawanieDostepne = false;
                                EdycjaDostepna = false;
                                UsunDostepne = false;
                            }
                        }
                        ,
                        arg => true
                        );


                return ladujFormularz;
            }

        }


        //Edycja - polecenie odpowiedzialne za edycję dancyh w bazie 
        private ICommand edytuj = null;
        public ICommand Edytuj
        {
            get
            {
                if (edytuj == null)
                    edytuj = new RelayCommand(
                    arg =>
                    {
                        model.EdytujProjektWBazie(new Projekt(Nazwa_projektu, Cena, Czas_wykonania), BiezacyProjekt.Nazwa_projektu);
                        CzyscFormularz();
                        System.Windows.MessageBox.Show("Projekt został zmodyfikowany!");
                    }
                         ,
                    arg => (BiezacyProjekt?.Nazwa_projektu != Nazwa_projektu) || (BiezacyProjekt?.Cena != Cena) || (BiezacyProjekt?.Czas_wykonania != Czas_wykonania)
                   );


                return edytuj;
            }
        }

        private ICommand usun = null;
        public ICommand Usun
        {
            get
            {
                if (usun == null)
                    usun = new RelayCommand(
                    arg =>
                    {
                        if (MessageBox.Show("Jesteś pewien, że chcesz usunąć Projekt i umowy z nim związane?", "Czy chcesz usunąć?", MessageBoxButton.YesNo, MessageBoxImage.Warning)
                        == MessageBoxResult.Yes)
                        {
                            model.UsunProjektZBazy(BiezacyProjekt.Nazwa_projektu);
                            CzyscFormularz();
                            System.Windows.MessageBox.Show("Projekt został usunięty i jesli mial umowe to tez zostala usunieta!");
                        }
                    }
                         ,
                    arg => (true)
                   );


                return usun;
            }
        }
        #endregion
    }
}
