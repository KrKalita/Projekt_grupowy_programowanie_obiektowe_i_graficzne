using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Znajomi.ViewModel
{
    using BaseClass;
    using Znajomi.Model;
    using Znajomi.DAL.Encje;
    using System.Collections.ObjectModel;


    /// <summary>
    /// Klasa reprezentująca model widoku dla karty Dodaj osoby
    /// </summary>
    class TabDodajOsobyViewModel:ViewModelBase
    {
        #region Składowe prywatne
        //referencja do instancji(obiektu) modelu
        private Model model = null;

        private string imie, nazwisko, miasto;
        private int wiek = 20, idZaznaczenia = -1;
        private bool dodawanieDostepne = true;
        private bool edycjaDostepna = false;
        #endregion

        #region Konstruktory
        public TabDodajOsobyViewModel(Model model)
        {
            this.model = model;
            Osoby = model.Osoby;
        }
        #endregion

        #region Właściwości

        public Osoba BiezacaOsoba { get; set; }
        
        public string Imie {
            get { return imie; }
            set 
            { 
                imie = value;
                onPropertyChanged(nameof(Imie));//to robie zeby zaktualizowalo kolumne imie
            } 
        }
        public string Nazwisko
        {
            get { return nazwisko; }
            set
            {
                nazwisko = value;
                onPropertyChanged(nameof(Nazwisko));
            }
        }

        public int Wiek
        {
            get { return wiek; }
            set
            {
                wiek = value;
                onPropertyChanged(nameof(Wiek));
            }
        } 

        public string Miasto
        {
            get { return miasto; }
            set
            {
                miasto = value;
                onPropertyChanged(nameof(Miasto));
            }
        }

        public int IdZaznaczenia {
            get { return idZaznaczenia; }
            set { idZaznaczenia = value;
                onPropertyChanged(nameof(IdZaznaczenia));
            }
        }
        public ObservableCollection<Osoba> Osoby { get; set; }
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
        #endregion

        //trzeba wyczyścic pole tekstowe trzeba zeby wprowadzic nowe dane
        private void CzyscFormularz()
        {
            Imie = "";
            Nazwisko = "";
            Wiek = 20;
            Miasto = "";
            DodawanieDostepne = true;
            EdycjaDostepna = false;
        }

        #region Polecenia

        /// <summary>
        /// Polecenie Dodaj odpowiedzialne za dodane nowek osoby do bazy danych
        /// </summary>
        private ICommand dodaj = null;

        public ICommand Dodaj {

            get {
                if (dodaj == null)
                    dodaj = new RelayCommand(
                        arg =>
                        {
                            var osoba = new Osoba(Imie, Nazwisko, (sbyte)Wiek, Miasto);

                            if (model.DodajOsobeDoBazy(osoba))
                            {
                                CzyscFormularz();
                                System.Windows.MessageBox.Show("Osoba została dodana do bazy!");
                            }
                        }
                        ,
                        arg => (Imie != "") && (Nazwisko != "") && (Miasto != "")
                        ) ; 
                
                
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
                                Imie = BiezacaOsoba.Imie;
                                Nazwisko = BiezacaOsoba.Nazwisko;
                                Wiek = BiezacaOsoba.Wiek;
                                Miasto = BiezacaOsoba.Miasto;
                                DodawanieDostepne = false;
                                EdycjaDostepna = true;
                            }
                            else 
                            {
                                Imie = "";
                                Nazwisko = "";
                                Wiek = 20;
                                Miasto = "";
                                DodawanieDostepne = true;
                                EdycjaDostepna = false;
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
                   edytuj= new RelayCommand(
                   arg =>
                        {
                            model.EdytujOsobeWBazie(new Osoba(Imie, Nazwisko, (sbyte)Wiek, Miasto), (sbyte)BiezacaOsoba.Id);
                            IdZaznaczenia = -1;
                            DodawanieDostepne = true;
                                                   }
                        ,
                   arg => (BiezacaOsoba?.Imie != Imie)||(BiezacaOsoba?.Nazwisko!=Nazwisko)||(BiezacaOsoba?.Wiek!=Wiek)||(BiezacaOsoba?.Miasto!=Miasto)
                  );


                return edytuj;
            }
        }
        #endregion
    }
}
