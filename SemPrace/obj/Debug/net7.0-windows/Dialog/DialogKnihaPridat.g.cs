﻿#pragma checksum "..\..\..\..\Dialog\DialogKnihaPridat.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BFC4772080D45821CB0D7ED0C0682B12D3DC5305"
//------------------------------------------------------------------------------
// <auto-generated>
//     Tento kód byl generován nástrojem.
//     Verze modulu runtime:4.0.30319.42000
//
//     Změny tohoto souboru mohou způsobit nesprávné chování a budou ztraceny,
//     dojde-li k novému generování kódu.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
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


namespace SemPrace.Dialog {
    
    
    /// <summary>
    /// DialogKnihaPridat
    /// </summary>
    public partial class DialogKnihaPridat : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\..\Dialog\DialogKnihaPridat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Dialog\DialogKnihaPridat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NazevTextBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Dialog\DialogKnihaPridat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AutorTextBox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Dialog\DialogKnihaPridat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RokVydaniTextBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Dialog\DialogKnihaPridat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ConfirmButton;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Dialog\DialogKnihaPridat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.12.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SemPrace;component/dialog/dialogknihapridat.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Dialog\DialogKnihaPridat.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.12.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.NazevTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\..\Dialog\DialogKnihaPridat.xaml"
            this.NazevTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NazevTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AutorTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\..\Dialog\DialogKnihaPridat.xaml"
            this.AutorTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.AutorTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RokVydaniTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\..\..\Dialog\DialogKnihaPridat.xaml"
            this.RokVydaniTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.RokVydaniTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ConfirmButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\Dialog\DialogKnihaPridat.xaml"
            this.ConfirmButton.Click += new System.Windows.RoutedEventHandler(this.ConfirmButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\Dialog\DialogKnihaPridat.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

