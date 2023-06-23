using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPFSistemaTutorias.XAML
{
    /// <summary>
    /// Lógica de interacción para registrarHorarioSesion.xaml
    /// </summary>
    public partial class registrarHorarioSesion : Window
    {
        academico academicoSesion;
        public registrarHorarioSesion(academico academico)
        {
            InitializeComponent();
            cargarEstudiantes(academico);
            PeriodoEscolarViewModel periodo = new PeriodoEscolarViewModel();
            cbPeriodos.ItemsSource = periodo.nombrePeriodo;
            academicoSesion = new academico()
            {
                idacademico = academico.idacademico,
                nombre = academico.nombre,
                numeroempleado = academico.numeroempleado
            };
        }

        public async void cargarEstudiantes(academico academico)
        {
            lblTutor.Content = "Bienvenido, "+ academico.nombre;
            var conexionServicios = new Service1Client();
            var estudiantes = await conexionServicios.recuperarEstudiantesTutorAsync(academico.idacademico);
            

            dgEstudiantes.ItemsSource = estudiantes;
        }
        

        public async void clicGuardar(object sender, RoutedEventArgs e)
        {
            
            var conexionServicios = new Service1Client();

            try
            {
                if (dgEstudiantes.SelectedCells.Count > 0) {
                    if (tbHorario.Text.Length > 0
                    && tbLugar.Text.Length > 0)
                    {
                        estudiante estudiante = dgEstudiantes.SelectedItem as estudiante;
                        var estudianteSeleccionado = await conexionServicios.recuperarEstudiantesMatriculaAsync(estudiante.matricula);

                        List<int> idEstudianteBD = new List<int>();
                        foreach (var estudianteBD in estudianteSeleccionado)
                        {
                            int idEstudiante = estudianteBD.idestudiante;
                            idEstudianteBD.Add(idEstudiante);
                        }

                        tutoria[] tutorias = await conexionServicios.recuperarTutoriasPeriodoAsync(cbPeriodos.SelectedIndex + 1);


                        conexionServicios.registrarHorarioSesionTutoriaAsync(idEstudianteBD.FirstOrDefault(), tutorias[cbSesion.SelectedIndex + 1].idtutoria, tbHorario.Text, tbLugar.Text);
                        MessageBox.Show("Registro de horario de sesión de tutoría exitoso");
                        MainWindow main = new MainWindow(academicoSesion);
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Campos vacios");
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona un estudiante");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos. Por favor, inténtelo más tarde.");
            }
        }

        private void clicCancelar(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Registro de horario cancelado");
            MainWindow main = new MainWindow(academicoSesion);
            main.Show();
            this.Close();
        }

        private void cbPeriodos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TutoriaViewModel tutoria = new TutoriaViewModel(cbPeriodos.SelectedIndex+1);
            cbSesion.ItemsSource = tutoria.numeroSesionTutoria;
        }
    }
}
