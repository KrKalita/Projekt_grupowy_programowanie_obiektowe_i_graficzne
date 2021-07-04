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

        private int indeksZaznaczonegoArchitekta = -1;

        #endregion

        #region Konstruktory
        public TabListaArchitektowViewModel(Model model)
        {
            this.model = model;
            architekci = model.Architekci;
            umowy = model.Umowy;
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

        #endregion

        #region Metody
        public void OdswiezArchitektow() => Architekci = model.Architekci;

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

        #endregion

    }
}
