﻿#pragma checksum "..\..\..\..\XAML\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8517F834801CF13F572135C6E91AD5672DC42038"
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
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\XAML\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabTutor;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\XAML\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabJefe;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\XAML\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabCoordinador;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\XAML\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabAdministrador;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFSistemaTutorias;component/xaml/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\XAML\MainWindow.xaml"
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
            this.tabTutor = ((System.Windows.Controls.TabItem)(target));
            return;
            case 2:
            
            #line 13 "..\..\..\..\XAML\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicLlenarReporteTutoria);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 14 "..\..\..\..\XAML\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicConsultarProblematica);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 15 "..\..\..\..\XAML\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicRegistrarHorarioSesionTutoria);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tabJefe = ((System.Windows.Controls.TabItem)(target));
            return;
            case 6:
            this.tabCoordinador = ((System.Windows.Controls.TabItem)(target));
            return;
            case 7:
            
            #line 27 "..\..\..\..\XAML\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicConsultarReporteGeneral);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 28 "..\..\..\..\XAML\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicRegistrarFechas);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 29 "..\..\..\..\XAML\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicModificarFechas);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 30 "..\..\..\..\XAML\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicRegistrarEstudiante);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 31 "..\..\..\..\XAML\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicAsignarTutorado);
            
            #line default
            #line hidden
            return;
            case 12:
            this.tabAdministrador = ((System.Windows.Controls.TabItem)(target));
            return;
            case 13:
            
            #line 40 "..\..\..\..\XAML\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicRegistrarExperiencia);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 41 "..\..\..\..\XAML\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicRegistrarAcademico);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 42 "..\..\..\..\XAML\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicRegistrarPrograma);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 46 "..\..\..\..\XAML\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clicCerrarSesion);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
