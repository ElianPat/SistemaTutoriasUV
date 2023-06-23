using ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
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
using WPFSistemaTutorias.Modelo;
using WPFSistemaTutorias.XAML;

namespace WPFSistemaTutorias
{
    public partial class ReporteGeneral : Window
    {
        academico academicoSesion;
        public ReporteGeneral(academico academicoActivo)
        {
            InitializeComponent();
            InitializeComponent();
            academicoSesion = new academico()
            {
                idacademico = academicoActivo.idacademico,
                nombre = academicoActivo.nombre,
                numeroempleado = academicoActivo.numeroempleado
            };

            PeriodoEscolarViewModel periodo = new PeriodoEscolarViewModel();
            cbPeriodoEscolar.ItemsSource = periodo.nombrePeriodo;
            List<int> numeros = new List<int> {1,2,3};
            cbNumeroSesion.ItemsSource = numeros;
            btnImprimir.IsEnabled = false;
        }

        private async void clicConsultar(object sender, RoutedEventArgs e)
        {
            if (cbNumeroSesion.Text.Length > 0 && cbPeriodoEscolar.Text.Length > 0)
            {
                llenarPorcentajes();
                llenarComentarios();
                llenarProblematicas();
                btnImprimir.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Debes seleccionar ambos parámetros");
            }
        }

        private async void llenarPorcentajes()
        {
            var conexionServicios = new Service1Client();
            try
            {
                var reporte = await conexionServicios.RecuperaReporteGeneralAsync(cbPeriodoEscolar.SelectedItem.ToString(), cbNumeroSesion.SelectedIndex + 1);
                if (reporte != null)
                {
                    lbPorcentajeRiesgo.Content = reporte.porcentajeriesgo.ToString();
                    lbPorcertajeAsistenca.Content = reporte.porcentajeasistencia.ToString();
                }
                else
                {
                    MessageBox.Show("Reporte no encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos, intente más tarde", "Error");
            }
        }


        private async void llenarComentarios()
        {
            var conexionServicios = new Service1Client();
            try
            {
                var comen = await conexionServicios.RecuperarComentariosReporteGeneralAsync(cbPeriodoEscolar.SelectedItem.ToString(), cbNumeroSesion.SelectedIndex + 1);
                listBoxComentarios.ItemsSource = comen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos, intente más tarde", "Error");
            }
        }

        private async void llenarProblematicas()
        {
            var conexionServicios = new Service1Client();
            try
            {
                var proble = await conexionServicios.RecuperarProblematicasReporteAsync(cbPeriodoEscolar.SelectedItem.ToString(), cbNumeroSesion.SelectedIndex + 1);
                listBoxProblematicas.ItemsSource = proble;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos, intente más tarde", "Error");
            }
        }

        private void clicImprimir(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(this, "Impresión");
            }
        }

        private void clicCerrar(object sender, RoutedEventArgs e)
        {
            MainWindow ventanaMain = new MainWindow(academicoSesion);
            ventanaMain.Show();
            this.Close();
        }
    }
}
