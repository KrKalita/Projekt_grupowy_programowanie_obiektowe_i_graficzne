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

        public TabListaViewModel TabListaVM { get; set; }
        public TabDodajOsobyViewModel TabDodajOsobyVM { get; set; }

        public TabDodajTelefonViewModel TabDodajTelefonVM { get; set; } // Dodajemy DodajTelefonViewModel do DataContextu mainVM

        public MainViewModel()
        {
            //stworzenie viemodeli pomocniczych - dla każdej karty
            //przekazanie referencji do instancji modelu tak
            //aby wszystkie obiekty modeli widoków pracowały na tym samym modelu
            TabListaArchitektowVM = new TabListaArchitektowViewModel(model);  //obiekt na polczenie modelu danych z interfejsem uzytkownika

            TabListaVM  = new TabListaViewModel(model);  //obiekt na polczenie modelu danych z interfejsem uzytkownika
            TabDodajOsobyVM = new TabDodajOsobyViewModel(model);//obiekt na polczenie modelu danych z interfejsem uzytkownika

            TabDodajTelefonVM = new TabDodajTelefonViewModel(model);//obiekt na polczenie modelu danych z interfejsem uzytkownika

        }

       
    }       
}
