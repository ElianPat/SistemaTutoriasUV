﻿#pragma checksum "..\..\..\..\XAML\ModificarFecha.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8171BF9C9887CEB3B5DEDE0A243487055173F71F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
using WPFSistemaTutorias;


namespace WPFSistemaTutorias {
    
    
    /// <summary>
    /// modificarFecha
    /// </summary>
    public partial class modificarFecha : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\XAML\ModificarFecha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPeriodos;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\XAML\ModificarFecha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpFechaSesion;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\XAML\ModificarFecha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpFechaSesion2;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\XAML\ModificarFecha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpFechaSesion3;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\XAML\ModificarFecha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpFechaCierre1;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\XAML\ModificarFecha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpFechaCierre2;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\XAML\ModificarFecha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpFechaCierre3;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPFSistemaTutorias;component/xaml/modificarfecha.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\XAML\ModificarFecha.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cbPeriodos = ((System.Windows.Controls.ComboBox)(target));
            
            #line 11 "..\..\..\..\XAML\ModificarFecha.xaml"
            this.cbPeriodos.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbPeriodos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dpFechaSesion = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.dpFechaSesion2 = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.dpFechaSesion3 = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.dpFechaCierre1 = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.dpFechaCierre2 = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.dpFechaCierre3 = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            
            #line 18 "..\..\..\..\XAML\ModificarFecha.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.cancelarRegistro);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 19 "..\..\..\..\XAML\ModificarFecha.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.guardarFecha);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
