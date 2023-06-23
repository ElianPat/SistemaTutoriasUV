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

namespace WPFSistemaTutorias.Diana
{

    public partial class ConsultaProblematica : Window
    {
        academico academicoSesion;
        public ConsultaProblematica(academico academicoActivo, int idProblematica, string tipo, string nombre)
        {
            InitializeComponent();
            recuperarProblematica(idProblematica);
            recuperarEstudiante(idProblematica);
            academicoSesion = new academico()
            {
                idacademico = academicoActivo.idacademico,
                nombre = academicoActivo.nombre,
                numeroempleado = academicoActivo.numeroempleado
            };
            tbTipoProblematica.Text = tipo;
            tbNombreProblematica.Text = nombre;
        }

        public async void recuperarProblematica(int idProblematica)
        {
            var conexionServicios = new Service1Client();
            try
            {
                var problematica = await conexionServicios.RecuperarProblematicaAsync(idProblematica);
                string descripcion = problematica.descripcion.ToString();
                string estado = problematica.estado.ToString();
                string experiencia = problematica.experienciaeducativa.ToString();
                tbDescripcionProblematica.Text = descripcion;
                tbEstadoProblematica.Text = estado;
                tbExperienciaEducativa.Text = experiencia;
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos, intente más tarde", "Error");
            }
        }

        public async void recuperarEstudiante(int idProblematica)
        {
            var conexionServicios = new Service1Client();
            try
            {
                var estudiante = await conexionServicios.RecuperarEstudianteProblematicaAsync(idProblematica);
                string nombre = estudiante.nombre.ToString();
                tbEstudiante.Text = nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos, intente más tarde", "Error");
            }
        }

        private void clicVolver(object sender, RoutedEventArgs e)
        {
            MainWindow ventanaMain = new MainWindow(academicoSesion);
            ventanaMain.Show();
            this.Close();
        }
    }
}
