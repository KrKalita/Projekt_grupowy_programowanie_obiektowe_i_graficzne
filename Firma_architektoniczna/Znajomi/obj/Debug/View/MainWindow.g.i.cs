﻿#pragma checksum "..\..\..\View\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6F7C89C7C3C6BFA1CAE323BBF5C1DF367F7B2E6B7E5B02C7FAE675037BA7DCFF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Znajomi;
using Znajomi.ViewModel;


namespace Znajomi {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem lista_architektow;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView architekci_listview;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn kolumna_Nazwisko_architekt;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView projekty;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem zarzadzajArchitektami;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox imie;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nazwisko;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pesel;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox telefon;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Dodaj;
        
        #line default
        #line hidden
        
        
        #line 185 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Edytuj;
        
        #line default
        #line hidden
        
        
        #line 191 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Usun;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_osoby;
        
        #line default
        #line hidden
        
        
        #line 227 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem zarzadzajProjektami;
        
        #line default
        #line hidden
        
        
        #line 235 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nazwa_projektu;
        
        #line default
        #line hidden
        
        
        #line 237 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox cena;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox czas_wykonania;
        
        #line default
        #line hidden
        
        
        #line 246 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Dodaj2;
        
        #line default
        #line hidden
        
        
        #line 251 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Edytuj2;
        
        #line default
        #line hidden
        
        
        #line 257 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Usun2;
        
        #line default
        #line hidden
        
        
        #line 265 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_osoby2;
        
        #line default
        #line hidden
        
        
        #line 292 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem zarzadzajKlientami;
        
        #line default
        #line hidden
        
        
        #line 300 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nazwa_klienta;
        
        #line default
        #line hidden
        
        
        #line 302 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ilosc_pracownikow;
        
        #line default
        #line hidden
        
        
        #line 304 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox wartosc_na_rynku;
        
        #line default
        #line hidden
        
        
        #line 311 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Dodaj3;
        
        #line default
        #line hidden
        
        
        #line 316 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Edytuj3;
        
        #line default
        #line hidden
        
        
        #line 322 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Usun3;
        
        #line default
        #line hidden
        
        
        #line 330 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_osoby3;
        
        #line default
        #line hidden
        
        
        #line 358 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem zarzadzajUmowami;
        
        #line default
        #line hidden
        
        
        #line 366 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nazwa_umowy;
        
        #line default
        #line hidden
        
        
        #line 383 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Dodaj4;
        
        #line default
        #line hidden
        
        
        #line 388 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Edytuj4;
        
        #line default
        #line hidden
        
        
        #line 394 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Usun4;
        
        #line default
        #line hidden
        
        
        #line 402 "..\..\..\View\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_osoby4;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Znajomi;component/view/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lista_architektow = ((System.Windows.Controls.TabItem)(target));
            return;
            case 2:
            this.architekci_listview = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.kolumna_Nazwisko_architekt = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 4:
            this.projekty = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.zarzadzajArchitektami = ((System.Windows.Controls.TabItem)(target));
            return;
            case 6:
            this.imie = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.nazwisko = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.pesel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.telefon = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.button_Dodaj = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.button_Edytuj = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.button_Usun = ((System.Windows.Controls.Button)(target));
            return;
            case 13:
            this.dg_osoby = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 14:
            this.zarzadzajProjektami = ((System.Windows.Controls.TabItem)(target));
            return;
            case 15:
            this.nazwa_projektu = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.cena = ((System.Windows.Controls.TextBox)(target));
            return;
            case 17:
            this.czas_wykonania = ((System.Windows.Controls.TextBox)(target));
            return;
            case 18:
            this.button_Dodaj2 = ((System.Windows.Controls.Button)(target));
            return;
            case 19:
            this.button_Edytuj2 = ((System.Windows.Controls.Button)(target));
            return;
            case 20:
            this.button_Usun2 = ((System.Windows.Controls.Button)(target));
            return;
            case 21:
            this.dg_osoby2 = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 22:
            this.zarzadzajKlientami = ((System.Windows.Controls.TabItem)(target));
            return;
            case 23:
            this.nazwa_klienta = ((System.Windows.Controls.TextBox)(target));
            return;
            case 24:
            this.ilosc_pracownikow = ((System.Windows.Controls.TextBox)(target));
            return;
            case 25:
            this.wartosc_na_rynku = ((System.Windows.Controls.TextBox)(target));
            return;
            case 26:
            this.button_Dodaj3 = ((System.Windows.Controls.Button)(target));
            return;
            case 27:
            this.button_Edytuj3 = ((System.Windows.Controls.Button)(target));
            return;
            case 28:
            this.button_Usun3 = ((System.Windows.Controls.Button)(target));
            return;
            case 29:
            this.dg_osoby3 = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 30:
            this.zarzadzajUmowami = ((System.Windows.Controls.TabItem)(target));
            return;
            case 31:
            this.nazwa_umowy = ((System.Windows.Controls.TextBox)(target));
            return;
            case 32:
            this.button_Dodaj4 = ((System.Windows.Controls.Button)(target));
            return;
            case 33:
            this.button_Edytuj4 = ((System.Windows.Controls.Button)(target));
            return;
            case 34:
            this.button_Usun4 = ((System.Windows.Controls.Button)(target));
            return;
            case 35:
            this.dg_osoby4 = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

