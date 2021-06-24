using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace projekt.ViewModel
{
    using BaseClass;
    using projekt.DAL.Encje;
    using projekt.DAL.Repozytoria;
    using System.IO;
    using System.Windows;

    class MainViewModel : ViewModel
    {
        //składowa interfejsu 
        //zdarzenie wywoływane w chwili zmiany własności o której chcemy powiadomić
        //żeby zaktualizowany został widok

        public new event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {

        }

        //private MySqlConnection _connection;
        //public MySqlConnection Connection
        //{
        //    get => _connection;
        //    set
        //    {
        //        _connection = value;
        //        onPropertyChanged(nameof(Connection));
        //    }
        //}

        

    }
}
