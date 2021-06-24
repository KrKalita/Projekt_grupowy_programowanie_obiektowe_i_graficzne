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
    class TabDodajTelefonViewModel : ViewModelBase
    {
        #region Składowe prywatne
        //referencja do instancji modelu
        private Model model = null;

        private string imie, nazwisko, miasto;
        private int wiek = 20, idZaznaczenia = -1;
        private bool dodawanieDostepne = true;
        private bool edycjaDostepna = false;

        private string numer, typ, operatorAddPhone; // kazda wlasciwosc ma swoja skladowa prywatna

        #endregion

        #region Konstruktory
        public TabDodajTelefonViewModel(Model model)
        {
            this.model = model;
            Osoby = model.Osoby;
        }
        #endregion

        #region Właściwości

        public Osoba BiezacaOsoba { get; set; }

        public string Imie
        {
            get { return imie; }
            set
            {
                imie = value;
                onPropertyChanged(nameof(Imie));
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

        public int IdZaznaczenia
        {
            get { return idZaznaczenia; }
            set
            {
                idZaznaczenia = value;
                onPropertyChanged(nameof(IdZaznaczenia));
            }
        }

        // Properties zwiazane z dodawaniem telefonu
        public string Numer
        {
            get { return numer; }
            set
            {
                numer = value;
                onPropertyChanged(nameof(Numer));
            }
        }

        public string Typ
        {
            get { return typ; }
            set
            {
                typ = value;
                onPropertyChanged(nameof(Typ));
            }
        }

        public string Operator
        {
            get { return operatorAddPhone; }
            set
            {
                operatorAddPhone = value;
                onPropertyChanged(nameof(Operator));
            }
        }

        // Koniec propertiesów dla dodawania telefonu



        public ObservableCollection<Osoba> Osoby { get; set; }


        // Property ktore decyduje, czy mozna dodac numer telefonu
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


        private void CzyscFormularz()
        {
            Imie = "";
            Nazwisko = "";
            Wiek = 20;
            Miasto = "";
            Operator = "";
            Typ = "";
            Numer = "";
            DodawanieDostepne = true;
            EdycjaDostepna = false;
        }

        #region Polecenia

        /// <summary>
        /// Polecenie Dodaj odpowiedzialne za dodane nowego telefonu osoby do bazy danych
        /// </summary>
        private ICommand dodaj = null;


        // Tabela pol wiaze nam ze soba tabele osoby (podług id_o) i tabele telefony (podług id_t)
        public ICommand Dodaj
        {

            get
            {
                if (dodaj == null)
                    dodaj = new RelayCommand(
                        arg =>
                        {
                            var telefon = new Telefon(Numer, Typ, Operator);

                            if (model.DodajTelefonDoBazy(telefon))
                            {
                                System.Windows.MessageBox.Show("Telefon został dodany do bazy!");

                                var posiadanie = new Posiadanie(telefon.Id, BiezacaOsoba.Id);  // posiadanie to obiekt ktory zawieraw sobie Id dodanego dopiero co telefonu oraz Id osoby ktorej ten telefon przydzielamy
                                if (model.DodajPosiadanieDoBazy(posiadanie))
                                {
                                    CzyscFormularz();
                                    System.Windows.MessageBox.Show("Telefon i posiadanie zostały dodane do bazy!");
                                }
                            }
                        }
                        ,
                        arg => (Numer != "")  && (Typ != "") && (Operator != "")  // (Imie != "") && (Nazwisko != "") && (Miasto != "")
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
                                Numer = "";
                                Typ = "";
                                Operator = "";
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
                    edytuj = new RelayCommand(
                    arg =>
                    {
                        model.EdytujOsobeWBazie(new Osoba(Imie, Nazwisko, (sbyte)Wiek, Miasto), (sbyte)BiezacaOsoba.Id);
                        IdZaznaczenia = -1;
                        DodawanieDostepne = true;
                    }
                         ,
                    arg => (BiezacaOsoba?.Imie != Imie) || (BiezacaOsoba?.Nazwisko != Nazwisko) || (BiezacaOsoba?.Wiek != Wiek) || (BiezacaOsoba?.Miasto != Miasto)
                   );


                return edytuj;
            }
        }
        #endregion
    }
}
