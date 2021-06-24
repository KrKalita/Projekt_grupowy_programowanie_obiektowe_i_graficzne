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
    class TabListaViewModel : ViewModelBase
    {
        #region Składowe prywatne

        private Model model = null;
        private ObservableCollection<Osoba> osoby = null;
        private ObservableCollection<Telefon> telefony = null;
       
        private int indeksZaznaczonejOsoby = -1;
        private int indeksZaznaczonegoTelefonu = -1;

        #endregion

        #region Konstruktory
        public TabListaViewModel(Model model)
        {
            this.model = model;
            osoby = model.Osoby;
            Telefony = model.Telefony;
        }
        #endregion

        #region Właściwości

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
        public void OdswiezOsoby() => Osoby = model.Osoby;
        #endregion

        #region Polecenia

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
