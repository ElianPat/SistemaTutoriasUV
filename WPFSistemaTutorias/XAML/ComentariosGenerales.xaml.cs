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
    public partial class ComentariosGenerales : Window
    {
        int idTutoriaHere;
        academico academicoSesion;

        public ComentariosGenerales(int idTutoria, academico academicoActivo)
        {
            InitializeComponent();
            idTutoriaHere = idTutoria;
            academicoSesion = new academico()
            {
                idacademico = academicoActivo.idacademico,
                nombre = academicoActivo.nombre,
                numeroempleado = academicoActivo.numeroempleado
            };
        }

        private async void clicRegistrarComentarios(object sender, RoutedEventArgs e)
        {
            if (tbComentariosGenerales.Text != null)
            {
                string comentariosGenerales = tbComentariosGenerales.Text;

                var conexionServicios = new Service1Client();
                bool resultado = await conexionServicios.RegistrarComentariosGeneralesAsync(idTutoriaHere, academicoSesion.idacademico, comentariosGenerales);
                if (resultado == true)
                {
                    MessageBox.Show("Registro de comentarios exitoso", "Registro existoso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error en la conexión, intente más tarde", "Error");
                    MainWindow main = new MainWindow(academicoSesion);
                    main.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Debe llenar el campo solicitado");
            }
        }

        private void clicRegresar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
