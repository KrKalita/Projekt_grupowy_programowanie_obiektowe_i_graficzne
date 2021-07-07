using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Znajomi.DAL.Encje;
using Znajomi.ViewModel.BaseClass;

namespace Znajomi.ViewModel
{
    using Znajomi.Model;
    class TabZarzadzajKlientamiViewModel : ViewModelBase
    {
        #region Składowe prywatne
        //referencja do instancji(obiektu) modelu
        private Model model = null;

        private string nazwa_klienta = "", ilosc_pracownikow = "", wartosc_na_rynku = "";
        private int idZaznaczenia = -1;
        private bool dodawanieDostepne = false;
        private bool usunDostepne = false;
        private bool edycjaDostepna = false;
        #endregion

        #region Konstruktory
        public TabZarzadzajKlientamiViewModel(Model model)
        {
            this.model = model;
            Klienci = model.Klienci;
        }
        #endregion

        #region Właściwości

        public Klient BiezacyKlient { get; set; }

        public string Nazwa_klienta
        {
            get { return nazwa_klienta; }
            set
            {
                nazwa_klienta = value;

                onPropertyChanged(nameof(Nazwa_klienta));//to robie zeby zaktualizowalo kolumne imie

                SprawdzPoprawnoscDanych();
            }
        }
        public string Ilosc_pracownikow
        {
            get { return ilosc_pracownikow; }
            set
            {
                ilosc_pracownikow = value;

                onPropertyChanged(nameof(Ilosc_pracownikow));//to robie zeby zaktualizowalo kolumne imie

                SprawdzPoprawnoscDanych();
            }
        }
        public string Wartosc_na_rynku
        {
            get { return wartosc_na_rynku; }
            set
            {
                wartosc_na_rynku = value;

                onPropertyChanged(nameof(Wartosc_na_rynku));//to robie zeby zaktualizowalo kolumne imie

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
        public ObservableCollection<Klient> Klienci { get; set; }
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
            Nazwa_klienta = "";
            Ilosc_pracownikow = "";
            Wartosc_na_rynku = "";
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
                //zmiana na kropke, bo tak tylko przyjmuje(wpisujesz w aplikacji ".", a w bazie jest "," )
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
            for (int i = 0; i < Klienci.Count; i++)
            {
                if (Klienci[i].Nazwa_klienta == Nazwa_klienta)
                {
                    wystepuje = true;
                }
            }


            //wszystko pasuje
            if (Sprawdzenie3(Nazwa_klienta) && Sprawdzenie2(Ilosc_pracownikow) && Sprawdzenie1(Wartosc_na_rynku) && !wystepuje)
            {
                DodawanieDostepne = true;
                if (IdZaznaczenia != -1 && Nazwa_klienta == BiezacyKlient.Nazwa_klienta)
                    EdycjaDostepna = true;
                else
                    EdycjaDostepna = false;
            }
            //cos nie pasuje
            else
            {
                DodawanieDostepne = false;
                //warunki dla edycji - wszystko pasuje, a pesel jest ten sam co zaznaczonego architekta
                if (Sprawdzenie3(Nazwa_klienta) && Sprawdzenie2(Ilosc_pracownikow) && Sprawdzenie1(Wartosc_na_rynku) && IdZaznaczenia != -1 && Nazwa_klienta == BiezacyKlient.Nazwa_klienta)
                    EdycjaDostepna = true;
                else
                    EdycjaDostepna = false;
            }

        }

        #region Polecenia

        /// <summary>
        /// Polecenie Dodaj odpowiedzialne za dodane nowek osoby do bazy danych
        /// </summary>
        private ICommand dodaj = null;

        public ICommand Dodaj
        {

            get
            {
                if (dodaj == null)
                    dodaj = new RelayCommand(
                        arg =>
                        {
                            var klient = new Klient(Nazwa_klienta, Ilosc_pracownikow, Wartosc_na_rynku);

                            if (model.DodajKlientaDoBazy(klient))
                            {
                                CzyscFormularz();
                                System.Windows.MessageBox.Show("Klient został dodany do bazy!");
                            }
                        }
                        ,
                        arg => (Nazwa_klienta != "") && (Ilosc_pracownikow != "") && (Wartosc_na_rynku != "")
                        );


                return dodaj;
            }

        }
        /// <summary>
        /// Laduj formularz odpowiada za załadowanie formularz zaznaczoną pozycją w tabeli
        /// </summary>
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
                                Nazwa_klienta = BiezacyKlient.Nazwa_klienta;
                                Ilosc_pracownikow = BiezacyKlient.Ilosc_pracownikow;
                                Wartosc_na_rynku = BiezacyKlient.Wartosc_na_rynku;
                                DodawanieDostepne = false;
                                EdycjaDostepna = true;
                            }
                            else
                            {
                                Nazwa_klienta = "";
                                Ilosc_pracownikow = "";
                                Wartosc_na_rynku = "";
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

        private ICommand edytuj = null;
        /// <summary>
        /// Edycja - polecenie odpowiedzialne za edycję dancyh w bazie 
        /// dla zaznaczonej pozycji w tabeli 
        ///  BRAK IMPLEMENTACJI
        /// </summary>
        public ICommand Edytuj
        {
            get
            {
                if (edytuj == null)
                    edytuj = new RelayCommand(
                    arg =>
                    {
                        model.EdytujKlientaWBazie(new Klient(Nazwa_klienta, Ilosc_pracownikow, Wartosc_na_rynku), BiezacyKlient.Nazwa_klienta);
                        CzyscFormularz();
                        System.Windows.MessageBox.Show("Klient został zmodyfikowany!");
                    }
                         ,
                    arg => (BiezacyKlient?.Nazwa_klienta != Nazwa_klienta) || (BiezacyKlient?.Ilosc_pracownikow != Ilosc_pracownikow) || (BiezacyKlient?.Wartosc_na_rynku != Wartosc_na_rynku)
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
                        if (MessageBox.Show("Jesteś pewien, że chcesz usunąć Klienta?", "Czy chcesz usunąć?", MessageBoxButton.YesNo, MessageBoxImage.Warning)
                        == MessageBoxResult.Yes)
                        {
                            model.UsunKlientaZBazy(BiezacyKlient.Nazwa_klienta);
                            CzyscFormularz();
                            System.Windows.MessageBox.Show("Klient został usunięty!");
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
