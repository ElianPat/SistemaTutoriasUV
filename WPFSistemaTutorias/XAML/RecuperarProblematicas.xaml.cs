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
using WPFSistemaTutorias.XAML;
using WPFSistemaTutorias.Modelo;

namespace WPFSistemaTutorias { 

    public partial class RecuperarProblematicas : Window
    {
        academico academicoSesion;
        public RecuperarProblematicas(academico academicoActivo)
        {
            InitializeComponent();
            academicoSesion = new academico()
            {
                idacademico = academicoActivo.idacademico,
                nombre = academicoActivo.nombre,
                numeroempleado = academicoActivo.numeroempleado
            };

            PeriodoEscolarViewModel periodo = new PeriodoEscolarViewModel();
            cbPeriodoEscolar.ItemsSource = periodo.nombrePeriodo;
            List<string> tipo = new List<string> {"Académica", "Personal"};
            cbTipoProblematica.ItemsSource = tipo;
        }

        public async void cargarProblematicas()
        {
            string periodo = cbPeriodoEscolar.SelectedItem.ToString();
            string tipo = cbTipoProblematica.SelectedItem.ToString();

            var conexionServicios = new Service1Client();
            var problematicas = await conexionServicios.RecuperarProblematicasAsync(periodo, tipo);
            dgProblematicas.ItemsSource = problematicas;
        }

        private void cbTipoProblematica_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cargarProblematicas();
        }

        private void clicConsultar(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgProblematicas.SelectedCells.Count > 0)
                {
                    var problematicaSeleccionada = dgProblematicas.SelectedItem as problematica;
                    if(problematicaSeleccionada != null)
                    {
                        int idProblematica = problematicaSeleccionada.idproblematica;
                        ConsultaProblematica ventanaConsulta = new ConsultaProblematica(academicoSesion, idProblematica, problematicaSeleccionada.tipo, problematicaSeleccionada.nombre);
                        ventanaConsulta.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una problemática");
                }

            }catch(Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos, intente más tarde", "Error");
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
