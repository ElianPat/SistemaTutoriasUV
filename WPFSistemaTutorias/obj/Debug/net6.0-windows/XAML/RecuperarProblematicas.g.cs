﻿#pragma checksum "..\..\..\..\XAML\RecuperarProblematicas.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "806C356DD78403646D1102E2B25053B27D06F4EE"
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
    /// RecuperarProblematicas
    /// </summary>
    public partial class RecuperarProblematicas : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\XAML\RecuperarProblematicas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPeriodoEscolar;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\XAML\RecuperarProblematicas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTipoProblematica;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\XAML\RecuperarProblematicas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgProblematicas;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFSistemaTutorias;component/xaml/recuperarproblematicas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\XAML\RecuperarProblematicas.xaml"
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
            this.cbPeriodoEscolar = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.cbTipoProblematica = ((System.Windows.Controls.ComboBox)(target));
            
            #line 11 "..\..\..\..\XAML\RecuperarProblematicas.xaml"
            this.cbTipoProblematica.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbTipoProblematica_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dgProblematicas = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            
            #line 21 "..\..\..\..\XAML\RecuperarProblematicas.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicConsultar);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 22 "..\..\..\..\XAML\RecuperarProblematicas.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicCerrar);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

