using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
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

namespace WPFSistemaTutorias
{
    /// <summary>
    /// Lógica de interacción para InicioSesion.xaml
    /// </summary>
    public partial class InicioSesion : Window
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void clicIniciarSesion(object sender, RoutedEventArgs e)
        {
            string valorTb = tbNumeroEmpleado.Text;
            string password = pbPassword.Password;
            if (valorTb.Length > 0 && password.Length > 0)
            {
                int numeroEmpleado = int.Parse(valorTb);
                verificarInicioSesion(numeroEmpleado, password);
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña requeridos para iniciar sesión", "Error");
            }
        }

        private async void verificarInicioSesion(int numeroEmpleado, string password)
        {
            try
            {
                using (var conexionServicios = new Service1Client())
                {
                    academico resultado = await conexionServicios.IniciarSesionAsync(numeroEmpleado, password);
                    if (resultado == null)
                    {
                        MessageBox.Show("Usuario no encontrado, verifique las credenciales","Credenciales incorrectas");
                    }
                    else
                    {
                        MessageBox.Show("Bienvenido(a) " + resultado.nombre + " al sistema", "Usuario verificado");
                        academico academicoActivo = new academico()
                        {
                            nombre = resultado.nombre,
                            idacademico = resultado.idacademico,
                            numeroempleado = numeroEmpleado,
                        };
                        MainWindow ventanaMain = new MainWindow(academicoActivo);
                        ventanaMain.Show();
                        this.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
