using projekt.DAL.Encje;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt.ViewModel
{
    using BaseClass;
    using projekt.DAL.Repozytoria;
    using System.Windows;

    class ListaArchitektowViewModel : ViewModel
    {
        public new event PropertyChangedEventHandler PropertyChanged;

        public ListaArchitektowViewModel()
        {
            //pobierz architektow z bazy danych
            Architekci = RepozytoriumArchitekci.PobierzWszystkichArchitektow();

            //ustaw index na -1, aby nic nie było wybrane
            IndeksWybranegoArchitekta = -1;
        }

        private List<Architekt> _architekci;
        public List<Architekt> Architekci
        {
            get => _architekci;
            set
            {
                _architekci = value;
                onPropertyChanged(nameof(Architekci));
            }
        }

        private Architekt _wybranyArchitekt;
        public Architekt WybranyArchitekt
        {
            get => _wybranyArchitekt;
            set
            {
                _wybranyArchitekt = value;
                onPropertyChanged(nameof(WybranyArchitekt));
            }
        }


        private int _indeksWybranegoArchitekta;
        public int IndeksWybranegoArchitekta
        {
            get => _indeksWybranegoArchitekta;
            set
            {
                _indeksWybranegoArchitekta = value;

                //przy zmianie indeksu, załaduj projekty
                if(value!=-1)
                {
                    Umowy = RepozytoriumUmowy.PobierzUmowyArchitekta(WybranyArchitekt);
                }

                onPropertyChanged(nameof(IndeksWybranegoArchitekta));
            }
        }



        private List<Umowa> _umowy;
        public List<Umowa> Umowy
        {
            get => _umowy;
            set
            {
                _umowy = value;
                onPropertyChanged(nameof(Umowy));
            }
        }
    }
}
