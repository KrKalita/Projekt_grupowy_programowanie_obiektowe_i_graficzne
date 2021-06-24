using projekt.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projekt.View
{
    /// <summary>
    /// Logika interakcji dla klasy ListaArchitektow.xaml
    /// </summary>
    public partial class ListaArchitektow : UserControl
    {
        public ListaArchitektow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ArchitekciProperty =
            DependencyProperty.Register(
                nameof(Architekci),
                typeof(List<Architekt>),
                typeof(ListaArchitektow),
                new PropertyMetadata(null));

        public List<Architekt> Architekci
        {
            get => (List<Architekt>)GetValue(ArchitekciProperty);
            set => SetValue(ArchitekciProperty, value);
        }



        public static readonly DependencyProperty WybranyArchitektProperty =
            DependencyProperty.Register(
                nameof(WybranyArchitekt),
                typeof(Architekt),
                typeof(ListaArchitektow),
                new PropertyMetadata(null));

        public Architekt WybranyArchitekt
        {
            get => (Architekt)GetValue(WybranyArchitektProperty);
            set => SetValue(WybranyArchitektProperty, value);
        }




        public static readonly DependencyProperty IndeksWybranegoArchitektaProperty =
            DependencyProperty.Register(
                nameof(IndeksWybranegoArchitekta),
                typeof(int),
                typeof(ListaArchitektow),
                new PropertyMetadata(null));

        public int IndeksWybranegoArchitekta
        {
            get => (int)GetValue(IndeksWybranegoArchitektaProperty);
            set => SetValue(IndeksWybranegoArchitektaProperty, value);
        }



        public static readonly DependencyProperty UmowyProperty =
            DependencyProperty.Register(
                nameof(Umowy),
                typeof(List<Umowa>),
                typeof(ListaArchitektow),
                new PropertyMetadata(null));

        public List<Umowa> Umowy
        {
            get => (List<Umowa>)GetValue(UmowyProperty);
            set => SetValue(UmowyProperty, value);
        }
    }
}
