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
    /// Lógica de interacción para RegistrarExperienciaEducativa.xaml
    /// </summary>
    public partial class RegistrarExperienciaEducativa : Window
    {
        public Boolean eeExistente;
        academico academicoSesion;

        public RegistrarExperienciaEducativa(academico academicoActivo)
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
            string nrc = tbNRC.Text;
            string nombre = tbNombre.Text;
            string horario = tbHorario.Text;
            string modalidad = comboModalidad.Text;

            if (validarDatosEnteros(nrc) == true && validarDatos(nombre) == true && validarDatosHorario(horario) == true && comboModalidad.SelectedIndex != -1)
            {

                buscarExperienciaEducativa(int.Parse(nrc));
                if (eeExistente == false)
                {
                    experienciaeducativa ee = new experienciaeducativa()
                    {
                        NRC = int.Parse(nrc),
                        nombre = nombre,
                        horario = horario,
                        modalidad = modalidad

                };
                    registrarExperienciaEducativa(ee);
                }
                else
                {
                    MessageBox.Show("¡El NRC que intenta registrar ya se encuentra registrado en el sistema!");
                }

            }
            else
            {
                MessageBox.Show("¡No puede haber campos vacíos o caracteres inválidos!");
            }
        }
            
        

        private async void registrarExperienciaEducativa(experienciaeducativa experienciaeducativa)
        {
            var conexionServicio = new Service1Client();

            if (conexionServicio != null)
            {

                bool resultado = await conexionServicio.RegistrarExperienciaEducativaAsync(experienciaeducativa);
                if (resultado == true)
                {
                    MessageBox.Show("Experiencia Educativa registrada con éxito");
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
        }

        private async void buscarExperienciaEducativa(int nrc)
        {
            var conexionServicio = new Service1Client();

            if (conexionServicio != null)
            {

               Boolean resultado = await conexionServicio.BuscarExperienciaEducativaAsync(nrc);

                if (resultado == true)
                {
                    eeExistente = true;
                }
                else
                {
                    eeExistente = false;
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
            Regex regex = new Regex(@"^[A-Za-z0-9\s@.]+$");

            if (cadena.Length > 0 && regex.IsMatch(cadena))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool validarDatosHorario(string cadena)
        {
            if (cadena.Length > 0)
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
