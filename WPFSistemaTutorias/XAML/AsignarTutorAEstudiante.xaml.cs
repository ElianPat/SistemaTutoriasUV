using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
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

namespace WPFSistemaTutorias
{
    /// <summary>
    /// Lógica de interacción para AsignarTutorAEstudiante.xaml
    /// </summary>
    public partial class AsignarTutorAEstudiante : Window
    {

        academico academicoSesion;

        public AsignarTutorAEstudiante(academico academicoActivo)
        {
            InitializeComponent();

            academicoSesion = new academico()
            {
                idacademico = academicoActivo.idacademico,
                nombre = academicoActivo.nombre,
                numeroempleado = academicoActivo.numeroempleado
            };

            AcademicoViewModel academicosViewModel = new AcademicoViewModel();
            dgAcademicos.ItemsSource = academicosViewModel.academicosBD;

            EstudianteViewModel estudiantesViewModel = new EstudianteViewModel(academicoSesion, 0, null);
            dgEstudiantes.ItemsSource = estudiantesViewModel.estudiantesBD;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var conexionServicios = new Service1Client();

            MessageBox.Show("asignando...");

            try
            {
                if (dgAcademicos.SelectedCells.Count > 0 && dgEstudiantes.SelectedCells.Count > 0)
                {
                    academico academico = dgAcademicos.SelectedItem as academico;
                    
                    var academicoSeleccionado = await conexionServicios.RecuperarAcademicoAsync((int)academico.numeroempleado);

                    estudiante estudiante = dgEstudiantes.SelectedItem as estudiante;
                    var estudianteSeleccionado = await conexionServicios.RecuperarEstudianteAsync(estudiante.matricula);
                    

                    MessageBox.Show(dgAcademicos.SelectedCells.Count.ToString());

                    Boolean resultado = await conexionServicios.ActualizarEstudianteAsync(estudiante.matricula, (int)academico.idacademico);

                    if (resultado == true)
                    {
                        MessageBox.Show("Tutor asignado con exito");
                        MainWindow ventamaMain = new MainWindow(academicoSesion);
                        ventamaMain.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al asignar tutor");

                    }
                }
                else
                {
                    MessageBox.Show("Debes elegir un tutor y un academico");
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow ventamaMain = new MainWindow (academicoSesion);
            ventamaMain.Show();
            this.Close();
        }
    }
}
