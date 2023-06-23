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
    public partial class Problematica : Window
    {
        academico academicoSesion;
        int numeroSesionHere;
        string periodoHere;
        int idSesion;
        int idProblematica;

        public Problematica(academico academicoActivo, int numeroSesion, string periodo)
        {
            InitializeComponent();
            academicoSesion = new academico()
            {
                nombre = academicoActivo.nombre,
                idacademico = academicoActivo.idacademico,
            };
            List<string> tipos = new List<string>
            {
                "Personal", "Académica"
            };

            cbTipoProblematica.ItemsSource = tipos;
            cbExperienciasEducativas.IsEnabled = false;
            tbDescripcionProblematica.IsEnabled = false;
            cbEstudiantes.IsEnabled = false;
            numeroSesionHere = numeroSesion;
            periodoHere = periodo;
        }

        public async void llenarEstudianteCb()
        {
            var conexionServicios = new Service1Client();
            var estudiantes = await conexionServicios.RecuperarEstudiantesSesionAsync(academicoSesion.idacademico, numeroSesionHere, periodoHere);
            List<string> estudiantesSesion = new List<string>();
            foreach(var s in estudiantes)
            {
                string nombre = s.nombre.ToString();
                estudiantesSesion.Add(nombre);
            }
            cbEstudiantes.ItemsSource = estudiantesSesion;
        }

        public async void llenarExperienciaCb()
        {
            var conexionServicios = new Service1Client();
            var experiencias = await conexionServicios.RecuperarInformacionExperienciasEducativasAsync();
            List<string> experienciasEd = new List<string>();
            foreach (var s in experiencias)
            {
                string nombre = s;
                experienciasEd.Add(nombre);
            }
            cbExperienciasEducativas.ItemsSource = experienciasEd;
        }

        public async Task<int> registrarProblematicaTipo()
        {
            if (tbNombreProblematica.Text.Length > 0 && cbTipoProblematica.Text.Length > 0)
            {
                string tipo = cbTipoProblematica.Text.ToString();
                string nombre = tbNombreProblematica.Text;
                try
                {
                    var conexionServicios = new Service1Client();
                    var registroProblematica = await conexionServicios.RegistrarProblematicaAsync(tipo, nombre);
                    if (registroProblematica != -1)
                    {
                        cbExperienciasEducativas.IsEnabled = true;
                        tbDescripcionProblematica.IsEnabled = true;
                        cbEstudiantes.IsEnabled = true;
                        int idProblematica = registroProblematica;
                        llenarEstudianteCb();
                        if (tipo == "Académica")
                        {
                            llenarExperienciaCb();
                        }
                    }
                    idProblematica = registroProblematica;
                    return idProblematica;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la conexión, intente más tarde", "Error");
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("Debe llenar ambos campos");
                return -1;
            }

        }

        private void clicRegistroTipo(object sender, RoutedEventArgs e)
        {
            registrarProblematicaTipo();
        }

        public async Task<int> recuperarIdSesion(string nombre)
        {
            if (cbEstudiantes.SelectedItem != null)
            {
                var conexionServicios = new Service1Client();
                var recuperacion = await conexionServicios.RecuperarIdSesionEstudianteAsync(periodoHere, numeroSesionHere, nombre);
                idSesion = recuperacion;
                return idSesion;
            }
            else
            {
                return -1;
            }
        }

        private async void registrarProblematicaSesion()
        {
            string experiencia;
            string tipo = cbTipoProblematica.Text.ToString();
            string descripcion = tbDescripcionProblematica.Text.ToString();
            if (tipo == "Personal")
            {
                experiencia = "No aplica";
            }
            else
            {
                experiencia = cbExperienciasEducativas.Text.ToString();
            }
            try
            {
                if(tbDescripcionProblematica != null && cbEstudiantes.Text.Length > 0)
                {
                    var conexionServicios = new Service1Client();
                    bool registroProblematica = await conexionServicios.RegistrarProblematicaSesionAsync(idProblematica, idSesion, descripcion, experiencia);
                    if (registroProblematica == true)
                    {
                        MessageBox.Show("Registro de problemática exitoso", "Registro exitoso");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se registró");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Debe llenar los campos", "Atención");
                }
               
            }catch(Exception ex)
            {
                MessageBox.Show("Error en la conexión, intente de nuevo más tarde", "Error");
            }
        }


        private void clicGuardar(object sender, RoutedEventArgs e)
        {
            registrarProblematicaSesion();
        }

        private void clicCancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbEstudiantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nombre = cbEstudiantes.SelectedItem.ToString();
            recuperarIdSesion(nombre);
        }
    }
}