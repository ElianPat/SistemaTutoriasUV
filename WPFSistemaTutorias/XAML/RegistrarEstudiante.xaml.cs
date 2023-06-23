using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WPFSistemaTutorias
{
    /// <summary>
    /// Lógica de interacción para RegistrarEstudiante.xaml
    /// </summary>
    public partial class RegistrarEstudiante : Window
    {
        academico academicoSesion;

        public RegistrarEstudiante(academico academicoActivo)
        {
            InitializeComponent();

            academicoSesion = new academico()
            {
                idacademico = academicoActivo.idacademico,
                nombre = academicoActivo.nombre,
                numeroempleado = academicoActivo.numeroempleado
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string matricula = tbMatricula.Text;
            string nombre = tbNombre.Text;
            string correoInstitucional = tbCorreoInsti.Text;
            string correoPersonal = tbcorreoPersonal.Text;
            string telefono = tbTelefono.Text;

            if (validarDatos(matricula) == true && validarDatos(nombre) == true && validarDatosCorreo(correoInstitucional) == true && validarDatosCorreo(correoPersonal) == true
                && validarDatosEnteros(telefono) == true)
            {
                Boolean estudianteExistente = false;

                buscarEstudiante(matricula, estudianteExistente);

                if (estudianteExistente == true)
                    {
                        MessageBox.Show("¡La matricula que intenta registrar, ya se encuentra registrada en el sistema!");
                    }
                    else
                    {
                    estudiante estudiante = new estudiante()

                    {
                        matricula = matricula,
                        nombre = nombre,
                        correoinstitucional = correoInstitucional,
                        correopersonal = correoPersonal,
                        telefono = telefono

                        };

                        registrarEstudiante(estudiante);
                    }
            }
            else
            {
                MessageBox.Show("¡No puede haber campos vacíos o caracteres inválidos!");
            }
        }

        private async void buscarEstudiante(string matricula, Boolean estudianteExistente)
        {
            var conexionServicio = new Service1Client();

            if (conexionServicio != null)
            {

                Boolean resultado = await conexionServicio.BuscarEstudianteAsync(matricula);

                if (resultado == true)
                {
                    estudianteExistente = true;
                    MessageBox.Show("¡Estudiante encontrado!");
                }
                else
                {
                    estudianteExistente = false;
                }
            }
            else
            {
                MessageBox.Show("Ha ocurrido un problema con la base de datos");
                this.Close();
            }
        }

        private async void registrarEstudiante(estudiante estudiante)
        {
            try { 

            var conexionServicio = new Service1Client();

            if (conexionServicio != null)
            {

                bool resultado = await conexionServicio.RegistrarEstudianteAsync(estudiante);

                MessageBox.Show(resultado.ToString());

                if (resultado == true)
                {
                    MessageBox.Show("Estudiante registrado con éxito");
                    MainWindow ventamaMain = new MainWindow(academicoSesion);
                    ventamaMain.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un problema con la base de datos");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Ha ocurrido un problema con la base de datos");
       
                this.Close();
            }

            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow ventamaMain = new MainWindow(academicoSesion);
            ventamaMain.Show();
            this.Close();
        }

        static bool validarDatos(string cadena)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9\s]+$");

            if (cadena.Length > 0 && regex.IsMatch(cadena))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool validarDatosCorreo(string cadena)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9@_.]+$");

            if (cadena.Length > 0 && regex.IsMatch(cadena))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool validarDatosEnteros(string cadena)
        {
            Regex regex = new Regex(@"^\d+$");

            if (cadena.Length > 0 && regex.IsMatch(cadena))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
