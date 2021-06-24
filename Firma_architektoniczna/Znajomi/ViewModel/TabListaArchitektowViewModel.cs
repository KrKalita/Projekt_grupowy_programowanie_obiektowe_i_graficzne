using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Znajomi.ViewModel
{
    using Model;
    using DAL.Encje;
    using BaseClass;
    using System.Windows.Input;

    /// <summary>
    /// Model widoku dla karty Lista
    /// </summary>
    class TabListaArchitektowViewModel : ViewModelBase
    {
        #region Składowe prywatne

        private Model model = null;
        private ObservableCollection<Architekt> architekci = null;
        private ObservableCollection<Umowa> umowy = null;
        private ObservableCollection<Osoba> osoby = null;
        private ObservableCollection<Telefon> telefony = null;

        private int indeksZaznaczonegoArchitekta = -1;

        private int indeksZaznaczonejOsoby = -1;
        private int indeksZaznaczonegoTelefonu = -1;

        #endregion

        #region Konstruktory
        public TabListaArchitektowViewModel(Model model)
        {
            this.model = model;
            architekci = model.Architekci;
            umowy = model.Umowy;
            osoby = model.Osoby;
            Telefony = model.Telefony;
        }
        #endregion

        #region Właściwości

        public int IndeksZaznaczonegoArchitekta
        {
            get => indeksZaznaczonegoArchitekta;
            set
            {
                indeksZaznaczonegoArchitekta = value;
                onPropertyChanged(nameof(IndeksZaznaczonegoArchitekta));
            }
        }

        public int IndeksZaznaczonegoTelefonu 
        {
            get => indeksZaznaczonegoTelefonu;
            set { 
                indeksZaznaczonegoTelefonu = value;
                onPropertyChanged(nameof(IndeksZaznaczonegoTelefonu));
            }
        }
        
        public int IndeksZaznaczonejOsoby
        {
            get => indeksZaznaczonejOsoby;
            set
            {
                indeksZaznaczonejOsoby = value;
                onPropertyChanged(nameof(IndeksZaznaczonejOsoby));
            }
        }

        public Architekt BiezacyArchitekt { get; set; }

        public ObservableCollection<Architekt> Architekci
        {
            get { return architekci; }
            set
            {
                architekci= value;
                onPropertyChanged(nameof(Architekci));
            }
        }

        public ObservableCollection<Umowa> Umowy
        {
            get { return umowy; }
            set
            {
                umowy = value;
                onPropertyChanged(nameof(Umowy));
            }
        }

        public Osoba BiezacaOsoba { get; set; }
               
        public Telefon BiezacyTelefon {get; set;}
        
        public ObservableCollection<Osoba> Osoby { 
            get { return osoby; }
            set {
                osoby=value;
                onPropertyChanged(nameof(Osoby));
            }
        }
        
        public ObservableCollection<Telefon> Telefony
        { 
            get { return telefony; } 
             set{ 
                telefony=value;
                onPropertyChanged(nameof(Telefony)); 
            } 
        }
        #endregion

        #region Metody
        public void OdswiezArchitektow() => Architekci = model.Architekci;

        public void OdswiezOsoby() => Osoby = model.Osoby;
        #endregion

        #region Polecenia

        private ICommand zaladujWszystkichArchitektow= null;
        public ICommand ZaladujWszystkichArchitektow
        {
            get
            {
                if (zaladujWszystkichArchitektow == null)
                    zaladujWszystkichArchitektow = new RelayCommand(
                        arg =>
                        {
                            Architekci = model.Architekci;
                            IndeksZaznaczonegoTelefonu = -1;
                        },
                        arg => true
                        );

                return zaladujWszystkichArchitektow;
            }
        }

        private ICommand zaladujUmowy = null;
        public ICommand ZaladujUmowy
        {
            get
            {
                if (zaladujUmowy == null)
                    zaladujUmowy = new RelayCommand(
                        arg => {
                            if (BiezacyArchitekt != null)
                                Umowy = model.PobierzUmowyArchitekta(BiezacyArchitekt);
                        },
                        arg => true
                        );

                return zaladujUmowy;
            }
        }

        private ICommand zaladujTelefony = null;
           public ICommand ZaladujTelefony {
            get {
                if (zaladujTelefony == null)
                    zaladujTelefony = new RelayCommand(
                        arg => {if(BiezacaOsoba!=null)
                                Telefony = model.PobierzTelefonyOsoby(BiezacaOsoba); 
                               },
                        arg => true
                        ) ;

                return zaladujTelefony;
            }
        }

        private ICommand zaladujOsoby = null;
        public ICommand ZaladujOsoby
        {
            get
            {
                Console.WriteLine("y");
                if (zaladujOsoby == null)
                    zaladujOsoby = new RelayCommand(
                        arg => {
                            
                            if (BiezacyTelefon != null)
                                Osoby = model.PobierzWlascicieliTelefonu(BiezacyTelefon);
                        },
                        arg => true
                        );

                return zaladujOsoby;
            }
        }


        private ICommand zaladujWszystkieTelefony = null;
        public ICommand ZaladujWszystkieTelefony
        {
            get
            {
                if (zaladujWszystkieTelefony == null)
                    zaladujWszystkieTelefony = new RelayCommand(
                        arg =>
                        {
                            Telefony = model.Telefony;
                            IndeksZaznaczonejOsoby = -1;
                        }
                        ,
                        arg => true
                        );

                return zaladujWszystkieTelefony;
            }
        }



        private ICommand zaladujWyszystkieOsoby = null;
        public ICommand ZaladujWszystkieOsoby
        {
            get
            {    
                if (zaladujWyszystkieOsoby == null)
                    zaladujWyszystkieOsoby = new RelayCommand(
                        arg =>
                                { Osoby = model.Osoby;
                                    IndeksZaznaczonegoTelefonu = -1;
                                },
                        arg => true
                        );

                return zaladujWyszystkieOsoby;
            }
        }
        #endregion

    }
}
