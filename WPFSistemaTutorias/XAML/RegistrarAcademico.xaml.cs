using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace WPFSistemaTutorias
{
    /// <summary>
    /// Lógica de interacción para RegistrarAcademico.xaml
    /// </summary>
    public partial class RegistrarAcademico : Window
    {

        public Boolean academicoExistente;
        academico academicoSesion;

        public RegistrarAcademico(academico academicoActivo)
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
            
            string numeroEmpleado = tbNumeroEmpleado.Text;
            string nombre = tbNombre.Text;
            string correoInstitucional = tbCorreoInstitucional.Text;
            string correoPersonal = tbCorreoPersonal.Text;
            string telefono = tbTelefono.Text;
            string contraseña = tbPassword.Text;

            if (validarDatosEnteros(numeroEmpleado) == true && validarDatos(nombre) == true && validarDatosCorreo(correoInstitucional) == true && validarDatosCorreo(correoPersonal) == true
                && validarDatosEnteros(telefono) == true && validarDatos(contraseña) == true)
            {

                buscarAcademico(int.Parse(numeroEmpleado));

                    if (academicoExistente == false)
                    {
                                academico academico = new academico()
                                {
                                    numeroempleado = int.Parse(numeroEmpleado),
                                    nombre = nombre,
                                    correoinstitucional = correoInstitucional,
                                    correopersonal = correoPersonal,
                                    telefono = telefono,
                                    password = contraseña
                                };
                                registrarAcademico(academico);
                    }
                    else
                    {
                        MessageBox.Show("¡El Número de empleado que intenta registrar ya se encuentra registrado en el sistema!");
                    }

            }
            else
            {
                MessageBox.Show("¡No puede haber campos vacíos o caracteres inválidos!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow ventamaMain = new MainWindow(academicoSesion);
            ventamaMain.Show();
            this.Close();
        }

        private async void registrarAcademico(academico academico)
        {

            try
            {
                var conexionServicio = new Service1Client();

                if (conexionServicio != null)
                {
                    bool resultado = await conexionServicio.RegistrarAcademicoAsync(academico);
                    if (resultado == true)
                    {
                        MessageBox.Show("Académico registrado con éxito");
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void buscarAcademico(int numeroEmpleado)
        {
            var conexionServicio = new Service1Client();

            if (conexionServicio != null)
            {
               
               Boolean resultado = await conexionServicio.BuscarAcademicoAsync(numeroEmpleado);

                if (resultado == true)
                {
                    academicoExistente =  false;
                }
                else
                {
                    academicoExistente =  true;
                }
                
            }
            else
            {
                MessageBox.Show("Ha ocurrido un problema con la base de datos");
                this.Close();
            }
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
