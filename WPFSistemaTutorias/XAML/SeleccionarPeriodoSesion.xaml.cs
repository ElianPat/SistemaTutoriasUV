using ServiceReference1;
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
using System.Windows.Shapes;
using WPFSistemaTutorias.Diana;
using WPFSistemaTutorias.Modelo;

namespace WPFSistemaTutorias.XAML
{
    /// <summary>
    /// Lógica de interacción para SeleccionarPeriodoSesion.xaml
    /// </summary>
    public partial class SeleccionarPeriodoSesion : Window
    {
        academico academicoSesion;
        string fechalimite = "Enero 2023 - Julio 2023";
        int numeroSesion = 2;
        public SeleccionarPeriodoSesion(academico academicoActivo)
        {
            InitializeComponent();
            academicoSesion = new academico()
            {
                idacademico = academicoActivo.idacademico,
                nombre = academicoActivo.nombre,
                numeroempleado = academicoActivo.numeroempleado
            };
            PeriodoEscolarViewModel periodo = new PeriodoEscolarViewModel();
            cbPeriodo.ItemsSource = periodo.nombrePeriodo;
            List<int> numeros = new List<int> { 1, 2, 3 };
            cbNumeroSesion.ItemsSource = numeros;
        }

        private void clicContinuar(object sender, RoutedEventArgs e)
        {
            if (cbNumeroSesion.Text.Length > 0 && cbPeriodo.Text.Length > 0)
            {
                string fechaCb = cbPeriodo.Text.ToString();
                if (fechaCb == fechalimite)
                {
                    int sesionNum = (int)cbNumeroSesion.SelectedItem;
                    if (sesionNum > numeroSesion)
                    {
                        int numeroSesion = cbNumeroSesion.SelectedIndex + 1;
                        ReporteTutoriaAca ventanaReporte = new ReporteTutoriaAca(academicoSesion, numeroSesion, cbPeriodo.SelectedItem.ToString());
                        ventanaReporte.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("La entrega del reporte se sesión ya pasó", "Atención");
                    }
                }
                else
                {
                    MessageBox.Show("La fecha de cierre de entrega de reporte ya pasó o no ha sido activada", "Atención");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar ambos parámetros", "Atención");
            }
        }

        private void cbPeriodos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TutoriaViewModel tutoria = new TutoriaViewModel(cbPeriodo.SelectedIndex + 1);
            cbNumeroSesion.ItemsSource = tutoria.numeroSesionTutoria;
        }

        private void clicVolver(object sender, RoutedEventArgs e)
        {
            MainWindow ventanaMain = new MainWindow(academicoSesion);
            ventanaMain.Show();
            this.Close();
        }
    }
}
