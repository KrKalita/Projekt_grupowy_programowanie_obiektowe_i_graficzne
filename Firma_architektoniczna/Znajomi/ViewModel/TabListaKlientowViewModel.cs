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


    class TabListaKlientowViewModel : ViewModelBase
    {
        #region Składowe prywatne

        private Model model = null;
        private ObservableCollection<Klient> klienci = null;
        private ObservableCollection<Umowa> umowy = null;

        private int indeksZaznaczonegoKlienta = -1;

        #endregion

        #region Konstruktory
        public TabListaKlientowViewModel(Model model)
        {
            this.model = model;
            Klienci = model.Klienci;
        }
        #endregion

        #region Właściwości

        public int IndeksZaznaczonegoKlienta
        {
            get => indeksZaznaczonegoKlienta;
            set
            {
                indeksZaznaczonegoKlienta = value;
                onPropertyChanged(nameof(IndeksZaznaczonegoKlienta));
            }
        }

        public Klient BiezacyKlient { get; set; }

        public ObservableCollection<Klient> Klienci
        {
            get { return klienci; }
            set
            {
                klienci = value;
                onPropertyChanged(nameof(Klienci));
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
        public void OdswiezKlientow() => Klienci = model.Klienci;

        #endregion

        #region Polecenia

        private ICommand zaladujUmowy = null;
        public ICommand ZaladujUmowy
        {
            get
            {
                if (zaladujUmowy == null)
                    zaladujUmowy = new RelayCommand(
                        arg => {
                            if (BiezacyKlient != null)
                                Umowy = model.PobierzUmowyKlienta(BiezacyKlient);
                        },
                        arg => true
                        );

                return zaladujUmowy;
            }
        }

        #endregion

    }
}
