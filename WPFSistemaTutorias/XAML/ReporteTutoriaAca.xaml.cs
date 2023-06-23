using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ReporteTutoriaAca : Window
    {
        academico academicoSesion;
        int numeroSesionHere;
        string periodoHere;
        int idTutorHere;
        public ReporteTutoriaAca(academico academicoActivo, int numeroSesion, string periodo)
        {
            InitializeComponent();
            academicoSesion = new academico()
            {
                idacademico = academicoActivo.idacademico,
                nombre = academicoActivo.nombre,
                numeroempleado = academicoActivo.numeroempleado
            };
            lbBienvenida.Content = "Bienvenido(a), " + academicoSesion.nombre;
            cargarEstudiantesSesiona(academicoSesion.idacademico, numeroSesion, periodo);
            numeroSesionHere = numeroSesion;
            periodoHere = periodo;
            idTutorHere = academicoActivo.idacademico;
        }

        public void cargarEstudiantesSesiona(int idTutor, int numeroSesion, string periodo)
        {
            EstudianteSesionViewModel modelo = new EstudianteSesionViewModel(idTutor, numeroSesion, periodo);
            dgEstudiantes.ItemsSource = modelo.estudiantesSesion;
        }

        private void clicGuardarRegistroReporte(object sender, RoutedEventArgs e)
        {
            registrarAsistentes();
            PorcentajesReporteTutoria ventanaPorcentajes = new PorcentajesReporteTutoria(academicoSesion, periodoHere, numeroSesionHere);
            ventanaPorcentajes.Show();
            this.Close();
        }

        private async void registrarAsistentes ()
        {
            try
            {
                var conexionServicios = new Service1Client();
                sesion sesionEstudiante = new sesion();
                foreach (EstudianteSesion estudiante in dgEstudiantes.ItemsSource)
                {
                    string nombre = estudiante.nombreSesion;
                    try
                    {
                
                        sesionEstudiante.observaciones = estudiante.observacionesSesion.ToString();

                        if (estudiante.asistenciaSeleccion == true)
                        {
                            sesionEstudiante.asistencia = 1;
                        }
                        else
                        {
                            sesionEstudiante.asistencia = 0;
                        }
                        if (estudiante.riesgoSeleccion == true)
                        {
                            sesionEstudiante.riesgo = 1;
                        }
                        else
                        {
                            sesionEstudiante.riesgo = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    bool registro = await conexionServicios.RegistrarReporteSesionAsync(sesionEstudiante, nombre, periodoHere, numeroSesionHere);
                    if (registro == true)
                    {
                        //MessageBox.Show("Registro de reporte de tutoría exitoso de " + nombre, "Registro existoso");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                        MainWindow main = new MainWindow(academicoSesion);
                        main.Show();
                        this.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void clicCancelarRegistroReporte(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Registro cancelado");
            MainWindow main = new MainWindow(academicoSesion);
            main.Show();
            this.Close();
        }
    }
}
