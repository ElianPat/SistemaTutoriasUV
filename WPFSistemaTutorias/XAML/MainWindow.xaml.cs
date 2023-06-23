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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFSistemaTutorias.XAML;

namespace WPFSistemaTutorias
{
    public partial class MainWindow : Window
    {
        academico academicoSesion;

        public MainWindow(academico academicoActivo)
        {
            InitializeComponent();
            tabJefe.IsEnabled = false;
            tabTutor.IsEnabled = false;
            tabCoordinador.IsEnabled = false;
            tabAdministrador.IsEnabled = false;

            academicoSesion = new academico() { 
                nombre = academicoActivo.nombre,
                idacademico = academicoActivo.idacademico,
                numeroempleado = academicoActivo.numeroempleado
            };

            habilitarInicio((int)academicoActivo.numeroempleado);
        }

        public async void habilitarInicio(int numeroEmpleado)
        {
            using (var conexionServicios = new Service1Client())
            {
                if (numeroEmpleado == 666)
                {
                    tabAdministrador.IsEnabled = true;
                }
                else
                {                    
                    bool esTutor = await conexionServicios.EsTutorAsync(numeroEmpleado);
                    bool esJefe = await conexionServicios.EsJefeCarreraAsync(numeroEmpleado);
                    bool esCoordinador = await conexionServicios.EsCoordinadorAsync(numeroEmpleado);
                    if (esTutor.Equals(true))
                    {
                        tabTutor.IsEnabled = true;
                    }
                    if (esCoordinador.Equals(true))
                    {
                        tabCoordinador.IsEnabled = true;
                    }
                    if (esJefe.Equals(true))
                    {
                        tabJefe.IsEnabled = true;
                    }
                }
            }
        }

        private void clicCerrarSesion(object sender, RoutedEventArgs e)
        {
            InicioSesion ventanaInicio = new InicioSesion();
            ventanaInicio.Show();
            this.Close();
        }

        private void clicLlenarReporteTutoria(object sender, RoutedEventArgs e)
        {
            SeleccionarPeriodoSesion ventanaSeleccion = new SeleccionarPeriodoSesion(academicoSesion);
            ventanaSeleccion.Show();
            this.Close();
        }

        private void clicRegistrarHorarioSesionTutoria(object sender, RoutedEventArgs e)
        {
            registrarHorarioSesion ventanaHorarioSesion = new registrarHorarioSesion(academicoSesion);
            ventanaHorarioSesion.Show();
            this.Close();
        }

        private void clicConsultarProblematica(object sender, RoutedEventArgs e)
        {
            RecuperarProblematicas ventanaProblematica = new RecuperarProblematicas(academicoSesion);
            ventanaProblematica.Show();
            this.Close();
        }

        private void clicConsultarReporteGeneral(object sender, RoutedEventArgs e)
        {
            ReporteGeneral ventanaReporteGeneral = new ReporteGeneral(academicoSesion);
            ventanaReporteGeneral.Show();
            this.Close();
        }

        private void clicRegistrarFechas(object sender, RoutedEventArgs e)
        {
            registrarFecha ventanaFechas = new registrarFecha(academicoSesion);
            ventanaFechas.Show();
            this.Close();
        }

        private void clicModificarFechas(object sender, RoutedEventArgs e)
        {
            modificarFecha ventanaModificarFechas = new modificarFecha(academicoSesion);
            ventanaModificarFechas.Show();
            this.Close();
        }

        private void clicRegistrarEstudiante(object sender, RoutedEventArgs e)
        {
            RegistrarEstudiante ventanaEstudiante = new RegistrarEstudiante(academicoSesion);
            ventanaEstudiante.Show();
            this.Close();
        }

        private void clicAsignarTutorado(object sender, RoutedEventArgs e)
        {
            AsignarTutorAEstudiante ventanaTutorado = new AsignarTutorAEstudiante(academicoSesion);
            ventanaTutorado.Show();
            this.Close();
        }

        private void clicRegistrarExperiencia(object sender, RoutedEventArgs e)
        {
            RegistrarExperienciaEducativa ventanaRegistroExperiencia = new RegistrarExperienciaEducativa(academicoSesion);
            ventanaRegistroExperiencia.Show();
            this.Close();
        }

        private void clicRegistrarAcademico(object sender, RoutedEventArgs e)
        {
            RegistrarAcademico ventanaAcademico = new RegistrarAcademico(academicoSesion);
            ventanaAcademico.Show();
            this.Close();
        }

        private void clicRegistrarPrograma(object sender, RoutedEventArgs e)
        {
            RegistrarProgramaEducativo ventanaPrograma = new RegistrarProgramaEducativo(academicoSesion);
            ventanaPrograma.Show();
            this.Close();
        }
    }
}
