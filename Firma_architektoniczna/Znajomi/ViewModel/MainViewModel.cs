using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Znajomi.ViewModel
{
    using Znajomi.Model;
    using BaseClass;
    using DAL;
    /// <summary>
    /// Główny model widoku 
    /// </summary>
    class MainViewModel
    {
        //stworzenie instancji(obiektu) modelu
        private Model model = new Model();//model to obiekt z 3 listami

        public TabListaArchitektowViewModel TabListaArchitektowVM { get; set; }
        public TabListaKlientowViewModel TabListaKlientowVM { get; set; }
        public TabZarzadzajArchitektamiViewModel TabZarzadzajArchitektamiVM { get; set; }
        public TabZarzadzajProjektamiViewModel TabZarzadzajProjektamiVM { get; set; }
        public TabZarzadzajKlientamiViewModel TabZarzadzajKlientamiVM { get; set; }
        public TabZarzadzajUmowamiViewModel TabZarzadzajUmowamiVM { get; set; }

        public MainViewModel()
        {
            //stworzenie viemodeli pomocniczych - dla każdej karty
            //przekazanie referencji do instancji modelu tak
            //aby wszystkie obiekty modeli widoków pracowały na tym samym modelu
            TabListaArchitektowVM = new TabListaArchitektowViewModel(model);  //obiekt na polczenie modelu danych z interfejsem uzytkownika
            TabListaKlientowVM = new TabListaKlientowViewModel(model);
            TabZarzadzajArchitektamiVM = new TabZarzadzajArchitektamiViewModel(model);//obiekt na polczenie modelu danych z interfejsem uzytkownika
            TabZarzadzajProjektamiVM = new TabZarzadzajProjektamiViewModel(model);
            TabZarzadzajKlientamiVM = new TabZarzadzajKlientamiViewModel(model);
            TabZarzadzajUmowamiVM = new TabZarzadzajUmowamiViewModel(model);

        }

       
    }       
}
