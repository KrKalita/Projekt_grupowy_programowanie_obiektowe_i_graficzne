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
    class TabZarzadzajUmowamiViewModel : ViewModelBase
    {
        #region Składowe prywatne
        //referencja do instancji(obiektu) modelu
        private Model model = null;

        private string nazwa_umowy = "";
        private ObservableCollection <Architekt> architekci;
        private ObservableCollection <Projekt> projekty;
        private ObservableCollection <Klient> klienci;
        private ObservableCollection <Umowa> umowy;
        DateTime dataZawarcia;
        DateTime termin;
        private Architekt architekt;
        private Projekt projekt;
        private Klient klient;
        private int idZaznaczenia = -1;
        private bool dodawanieDostepne = false;
        private bool usunDostepne = false;
        private bool edycjaDostepna = false;
        #endregion

        #region Konstruktory
        public TabZarzadzajUmowamiViewModel(Model model)
        {
            this.model = model;
            Klienci = model.Klienci;
            Architekci = model.Architekci;
            Projekty = model.Projekty;
            Umowy = model.Umowy;
            Architekt = Architekci[0];
            Projekt = Projekty[0];
            Klient = Klienci[0];
            DataZawarcia = DateTime.Now;
            Termin = DateTime.Now;
        }
        #endregion

        #region Właściwości

        public Umowa BiezacaUmowa { get; set; }

        public string Nazwa_umowy
        {
            get { return nazwa_umowy; }
            set
            {
                nazwa_umowy = value;
                onPropertyChanged(nameof(Nazwa_umowy));

                SprawdzPoprawnoscDanych();
            }
        }

        public Klient Klient
        {
            get { return klient; }
            set
            {
                klient = value;
                onPropertyChanged(nameof(Klient));
            }
        }
        public Projekt Projekt
        {
            get { return projekt; }
            set
            {
                projekt = value;
                onPropertyChanged(nameof(Projekt));
            }
        }
        public Architekt Architekt
        {
            get { return architekt; }
            set
            {
                architekt = value;
                onPropertyChanged(nameof(Architekt));
            }
        }


        public DateTime DataZawarcia
        {
            get { return dataZawarcia; }
            set
            {
                dataZawarcia = value;
                onPropertyChanged(nameof(DataZawarcia));

                SprawdzPoprawnoscDanych();
            }
        }

        public DateTime Termin
        {
            get { return termin; }
            set
            {
                termin = value;
                onPropertyChanged(nameof(Termin));

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
        public ObservableCollection<Architekt> Architekci { get; set; }
        public ObservableCollection<Projekt> Projekty { get; set; }
        public ObservableCollection<Umowa> Umowy { get; set; }
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

        //trzeba wyczyścic pole tekstowe trzeba zeby wprowadzic nowe dane
        private void CzyscFormularz()
        {
            Nazwa_umowy = "";
            IdZaznaczenia = -1;
            DodawanieDostepne = false;
            EdycjaDostepna = false;
            UsunDostepne = false;
        }
        
        private void SprawdzPoprawnoscDanych()
        {
            //wszystko pasuje
            if (DateTime.Compare(DataZawarcia,Termin)<0 && Nazwa_umowy!="")
            {
                DodawanieDostepne = true;
                if (IdZaznaczenia != -1)
                    EdycjaDostepna = true;
            }
            //cos nie pasuje
            else
            {
                DodawanieDostepne = false;
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
                            var umowa = new Umowa(Projekt.Nazwa_projektu, Klient.Nazwa_klienta, Architekt.Pesel, Nazwa_umowy, DataZawarcia.ToString("yyyy'-'MM'-'dd"), Termin.ToString("yyyy'-'MM'-'dd"));

                            if (model.DodajUmoweDoBazy(umowa))
                            {
                                CzyscFormularz();
                                System.Windows.MessageBox.Show("Umowa została dodany do bazy!");
                            }
                        }
                        ,
                        arg => (true)
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
                                Nazwa_umowy = BiezacaUmowa.Nazwa;
                                DataZawarcia = Convert.ToDateTime(BiezacaUmowa.DataZawarcia);
                                Termin = Convert.ToDateTime(BiezacaUmowa.TerminOstateczny);

                                for (int i = 0; i < Architekci.Count; i++)
                                {
                                    if (Architekci[i].Pesel == BiezacaUmowa.PeselArchitekta)
                                    {
                                        Architekt = Architekci[i];
                                        break;
                                    }
                                }

                                for (int i=0;i<Klienci.Count;i++)
                                {
                                    if(Klienci[i].Nazwa_klienta==BiezacaUmowa.Klient)
                                    {
                                        Klient = Klienci[i];
                                        break;
                                    }
                                }

                                for (int i = 0; i < Projekty.Count; i++)
                                {
                                    if (Projekty[i].Nazwa_projektu == BiezacaUmowa.NazwaProjektu)
                                    {
                                        Projekt = Projekty[i];
                                        break;
                                    }
                                }

                                DodawanieDostepne = false;
                                EdycjaDostepna = true;
                            }
                            else
                            {
                                Nazwa_umowy = "";
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
                        model.EdytujUmoweWBazie(new Umowa(Projekt.Nazwa_projektu, Klient.Nazwa_klienta, Architekt.Pesel, Nazwa_umowy, DataZawarcia.ToString("yyyy'-'MM'-'dd"), Termin.ToString("yyyy'-'MM'-'dd")),BiezacaUmowa.Id);
                        CzyscFormularz();
                        System.Windows.MessageBox.Show("Umowa została zmodyfikowana!");
                    }
                         ,
                    arg => (true)
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
                        if (MessageBox.Show("Jesteś pewien, że chcesz usunąć Umowę?", "Czy chcesz usunąć?", MessageBoxButton.YesNo, MessageBoxImage.Warning)
                        == MessageBoxResult.Yes)
                        {
                            model.UsunUmoweZBazy(BiezacaUmowa.Id);
                            CzyscFormularz();
                            System.Windows.MessageBox.Show("Umowa została usunięta!");
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
