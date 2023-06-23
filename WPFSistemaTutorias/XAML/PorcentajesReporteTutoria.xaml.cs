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
using WPFSistemaTutorias.Modelo;

namespace WPFSistemaTutorias.Diana
{
    public partial class PorcentajesReporteTutoria : Window
    {
        academico academicoSesion;
        int idTutoriaHere;
        string periodoHere;
        int numeroSesionHere;
        string porcentajes;

        public PorcentajesReporteTutoria(academico academicoActivo, string periodo, int numeroSesion)
        {
            InitializeComponent();
            academicoSesion = new academico()
            {
                nombre = academicoActivo.nombre,
                idacademico = academicoActivo.idacademico,
                numeroempleado = academicoActivo.numeroempleado
            };
            periodoHere = periodo;
            numeroSesionHere = numeroSesion;

            llenarProcentajes(academicoActivo.idacademico);
            btnEnviar.IsEnabled = false;

        }

        private async Task<int> recuperarId()
        {
            try
            {
                var conexionServicios = new Service1Client();
                var resultado = await conexionServicios.RecuperarIdSesionAsync(periodoHere, numeroSesionHere);
                int idTutoria = resultado;
                return idTutoria;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexión con base de datos, intente más tarde.", "Error");
                return -1;
            }
        }

        private async void llenarProcentajes(int idTutor)
        {
            idTutoriaHere = await recuperarId();
            llenarLb(idTutor, idTutoriaHere);

         }
            
        public async void llenarLb(int idTutor, int idTutoria)
        {
            var conexionServicios = new Service1Client();
            var porcentajes = await conexionServicios.CalcularPorcentajesReporteAsync(idTutoria, idTutor);
            double asistencia = (double)porcentajes.porcentajeasistencia;
            double riesgo = (double)porcentajes.porcentajeriesgo;
            lbAsistencia.Content = asistencia;
            lbRiesgo.Content = riesgo;
            registrarPorcentajes(idTutor, idTutoria, asistencia, riesgo);
        }

        public async void registrarPorcentajes(int idTutor, int idTutoria, double asis, double riesgo)
        {
            var conexionServicios = new Service1Client();

            try
            {
                bool registroPorcentajes = await conexionServicios.RegistrarPorcentajesReporteAsync(idTutoria, idTutor, riesgo, asis);
                if (registroPorcentajes == true)
                {
                    MessageBox.Show("Registro de asistencias exitoso.");
                }
                else
                {
                    MessageBox.Show("Error en el registro, intente más tarde.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void clicComentariosGenerales(object sender, RoutedEventArgs e)
        {
            ComentariosGenerales ventanaComentarios = new ComentariosGenerales(idTutoriaHere, academicoSesion);
            ventanaComentarios.Show();
            btnEnviar.IsEnabled = true;
        }

        private void clicProblematica(object sender, RoutedEventArgs e)
        {
            Problematica ventanaProblematica = new Problematica(academicoSesion, numeroSesionHere, periodoHere);
            ventanaProblematica.Show();
        }

        private void clicEnviar(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Registro completado");
            MainWindow main = new MainWindow(academicoSesion);
            main.Show();
            this.Close();
        }
    }
}
