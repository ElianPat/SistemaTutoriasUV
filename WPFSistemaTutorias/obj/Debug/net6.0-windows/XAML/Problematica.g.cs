﻿#pragma checksum "..\..\..\..\XAML\Problematica.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42ABD2E8B92D02223F2E3345B3B9B9BA2E47C07F"
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
using WPFSistemaTutorias.Diana;


namespace WPFSistemaTutorias.Diana {
    
    
    /// <summary>
    /// Problematica
    /// </summary>
    public partial class Problematica : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\XAML\Problematica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTipoProblematica;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\XAML\Problematica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNombreProblematica;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\XAML\Problematica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbEstudiantes;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\XAML\Problematica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbDescripcionProblematica;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\XAML\Problematica.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbExperienciasEducativas;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFSistemaTutorias;component/xaml/problematica.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\XAML\Problematica.xaml"
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
            this.cbTipoProblematica = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.tbNombreProblematica = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 15 "..\..\..\..\XAML\Problematica.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicRegistroTipo);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbEstudiantes = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\..\..\XAML\Problematica.xaml"
            this.cbEstudiantes.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbEstudiantes_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbDescripcionProblematica = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.cbExperienciasEducativas = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            
            #line 24 "..\..\..\..\XAML\Problematica.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicGuardar);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 25 "..\..\..\..\XAML\Problematica.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicCancelar);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

