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
    using System.Text.RegularExpressions;
    using System.Windows;


    /// <summary>
    /// Klasa reprezentująca model widoku dla karty Dodaj osoby
    /// </summary>
    class TabZarzadzajArchitektamiViewModel:ViewModelBase
    {
        #region Składowe prywatne
        //referencja do instancji(obiektu) modelu
        private Model model = null;

        private string imie="", nazwisko="", pesel="", telefon="";
        private int idZaznaczenia = -1;
        private bool dodawanieDostepne = false;
        private bool edycjaDostepna = false;
        #endregion

        #region Konstruktory
        public TabZarzadzajArchitektamiViewModel(Model model)
        {
            this.model = model;
            Architekci = model.Architekci;
        }
        #endregion

        #region Właściwości

        public Architekt BiezacyArchitekt { get; set; }
        
        public string Imie {
            get { return imie; }
            set 
            { 
                imie = value;

                onPropertyChanged(nameof(Imie));//to robie zeby zaktualizowalo kolumne imie

                SprawdzPoprawnoscDanych();
            } 
        }
        public string Nazwisko
        {
            get { return nazwisko; }
            set
            {
                nazwisko = value;

                onPropertyChanged(nameof(Nazwisko));

                SprawdzPoprawnoscDanych();
            }
        }

        public string Pesel
        {
            get { return pesel; }
            set
            {
                pesel = value;

                onPropertyChanged(nameof(Pesel));

                SprawdzPoprawnoscDanych();

                
            }
        }

        public string Telefon
        {
            get { return telefon; }
            set
            {
                telefon = value;

                onPropertyChanged(nameof(Telefon));

                SprawdzPoprawnoscDanych();
            }
        }

        public int IdZaznaczenia {
            get { return idZaznaczenia; }
            set { idZaznaczenia = value;
                onPropertyChanged(nameof(IdZaznaczenia));
            }
        }
        public ObservableCollection<Architekt> Architekci { get; set; }
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
            Telefon = "";
            Pesel = "";
            DodawanieDostepne = true;
            EdycjaDostepna = false;
        }

        private void SprawdzPoprawnoscDanych()
        {

            //wyrazenia regularne
            Regex imie_reg = new Regex("^\\w{1,30}$");
            Regex pesel_reg = new Regex("^[0-9]{11}$");
            Regex tel_reg = new Regex("^[0-9]{9}$");

            //sprawdz czy dany pesel juz nie wystepuje
            bool wystepuje = false;
            for (int i = 0; i < Architekci.Count; i++)
            {
                if (Architekci[i].Pesel == Pesel)
                {
                    wystepuje = true;
                }
            }
            

            //wszystko pasuje
            if (imie_reg.IsMatch(Imie) && imie_reg.IsMatch(Nazwisko) && pesel_reg.IsMatch(Pesel) && tel_reg.IsMatch(Telefon) && !wystepuje)
            {
                DodawanieDostepne = true;
                if(IdZaznaczenia != -1)
                    EdycjaDostepna = true;
            }
            //cos nie pasuje
            else
            {
                DodawanieDostepne = false;

                //warunki dla edycji - wszystko pasuje, a pesel jest ten sam co zaznaczonego architekta
                if (imie_reg.IsMatch(Imie) && imie_reg.IsMatch(Nazwisko) && pesel_reg.IsMatch(Pesel) && tel_reg.IsMatch(Telefon) && IdZaznaczenia != -1 && Pesel == BiezacyArchitekt.Pesel)
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

        public ICommand Dodaj {

            get {
                if (dodaj == null)
                    dodaj = new RelayCommand(
                        arg =>
                        {
                            var architekt = new Architekt(Imie, Nazwisko, Pesel, Telefon);

                            if (model.DodajArchitektaDoBazy(architekt))
                            {
                                CzyscFormularz();
                                System.Windows.MessageBox.Show("Architekt został dodany do bazy!");
                            }
                        }
                        ,
                        arg => (Imie != "") && (Nazwisko != "") && (Pesel != "") && (Telefon != "")
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
                                Imie = BiezacyArchitekt.Imie;
                                Nazwisko = BiezacyArchitekt.Nazwisko;
                                Pesel = BiezacyArchitekt.Pesel;
                                Telefon = BiezacyArchitekt.Numer;
                                DodawanieDostepne = false;
                                EdycjaDostepna = true;
                            }
                            else 
                            {
                                Imie = "";
                                Nazwisko = "";
                                Telefon = "";
                                Pesel = "";
                                DodawanieDostepne = false;
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
                            model.EdytujArchitektaWBazie(new Architekt(Imie, Nazwisko, Pesel, Telefon), BiezacyArchitekt.Pesel);
                            IdZaznaczenia = -1;
                            DodawanieDostepne = false;
                                                   }
                        ,
                   arg => (BiezacyArchitekt?.Imie != Imie)||(BiezacyArchitekt?.Nazwisko!=Nazwisko)||(BiezacyArchitekt?.Pesel!= Pesel) ||(BiezacyArchitekt?.Numer!=Telefon)
                  );


                return edytuj;
            }
        }
        #endregion
    }
}
