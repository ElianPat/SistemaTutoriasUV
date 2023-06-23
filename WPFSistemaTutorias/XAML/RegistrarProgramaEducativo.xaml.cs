using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Lógica de interacción para RegistrarProgramaEducativo.xaml
    /// </summary>
    public partial class RegistrarProgramaEducativo : Window
    {

        academico academicoSesion;
        public Boolean programaExistente;

        public RegistrarProgramaEducativo(academico academicoActivo)
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
            string nombre = tbNombre.Text;
            string codigo = tbCodigo.Text;

            if (validarDatos(nombre) == true && validarDatos(codigo) == true)
            {

                buscarProgramaEducativo(codigo);

                if(programaExistente == false)
                {
                    programaeducativo programaNuevo = new programaeducativo()
                    {
                        nombre = nombre,
                        codigo = codigo

                    };
                    registrarProgramaEducativo(nombre, codigo);
                }
                else
                {
                    MessageBox.Show("¡El codigo que intenta registrar ya se encuentra registrado en el sistema!");


                }

            }
            else
            {
                MessageBox.Show("¡No puede haber campos vacíos o caracteres inválidos!");
            }
        }

        private async void registrarProgramaEducativo(string nombre, string codigo)
        {
            var conexionServicio = new Service1Client();

            if (conexionServicio != null)
            {

                var resultado = await conexionServicio.RegistrarProgramaEducativoAsync(nombre, codigo);

                Debug.WriteLine(resultado);


                if (resultado == true)
                {
                    MessageBox.Show("Programa Educativo registrada con éxito");
                    MainWindow ventamaMain = new MainWindow(academicoSesion);
                    ventamaMain.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un problema con la base de datos 1");
                    this.Close();
                } 
            }
            else
            {
                MessageBox.Show("Ha ocurrido un problema con la base de datos 2");
                this.Close();
            }
        }

        private async void buscarProgramaEducativo(string codigo)
        {
            var conexionServicio = new Service1Client();

            if (conexionServicio != null)
            {

               Boolean resultado = await conexionServicio.BuscarProgramaEducativoAsync(codigo);
                
                if (resultado == true)
                {
                    programaExistente = true;
                }
                else
                {
                    programaExistente = false;
                }

            }
            else
            {
                MessageBox.Show("Ha ocurrido un problema con la base de datos");
                this.Close();
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
            Regex regex = new Regex("^[a-zA-Z0-9]+$");

            if ( cadena.Length > 0 && regex.IsMatch(cadena))
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
