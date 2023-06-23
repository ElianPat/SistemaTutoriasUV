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

namespace WPFSistemaTutorias
{
    /// <summary>
    /// Lógica de interacción para registrarFecha.xaml
    /// </summary>
    public partial class modificarFecha : Window
    {
        academico academicoSesion;
        public modificarFecha(academico academico)
        {
            InitializeComponent();
            PeriodoEscolarViewModel periodo = new PeriodoEscolarViewModel();
            cbPeriodos.ItemsSource = periodo.nombrePeriodo;
            academicoSesion = new academico()
            {
                idacademico = academico.idacademico,
                nombre = academico.nombre,
                numeroempleado = academico.numeroempleado
            };
        }


        private async void guardarFecha(object sender, RoutedEventArgs e)
        {
            var conexionServicios = new Service1Client();

            if (dpFechaSesion.SelectedDate.HasValue
                && dpFechaSesion2.SelectedDate.HasValue
                && dpFechaSesion3.SelectedDate.HasValue
                && dpFechaCierre1.SelectedDate.HasValue
                && dpFechaCierre2.SelectedDate.HasValue
                && dpFechaCierre3.SelectedDate.HasValue)
            {
                if (dpFechaSesion.SelectedDate >= DateTime.Now.Date
                && dpFechaSesion2.SelectedDate >= dpFechaSesion.SelectedDate
                && dpFechaSesion3.SelectedDate >= dpFechaSesion2.SelectedDate
                && dpFechaCierre1.SelectedDate >= dpFechaSesion.SelectedDate
                && dpFechaCierre2.SelectedDate >= dpFechaSesion2.SelectedDate
                && dpFechaCierre3.SelectedDate >= dpFechaSesion3.SelectedDate)
                {

                    int idPeriodo = cbPeriodos.SelectedIndex + 1;

                    periodoescolar periodos = await conexionServicios.recuperarPeriodosEscolaresIdAsync(idPeriodo);


                    if (dpFechaSesion.SelectedDate >= periodos.fechainicio
                    && dpFechaSesion2.SelectedDate >= periodos.fechainicio
                    && dpFechaSesion3.SelectedDate >= periodos.fechainicio
                    && dpFechaSesion.SelectedDate <= periodos.fechafin
                    && dpFechaSesion2.SelectedDate <= periodos.fechafin
                    && dpFechaSesion3.SelectedDate <= periodos.fechafin
                    && dpFechaCierre1.SelectedDate >= periodos.fechainicio
                    && dpFechaCierre2.SelectedDate >= periodos.fechainicio
                    && dpFechaCierre3.SelectedDate >= periodos.fechainicio
                    && dpFechaCierre1.SelectedDate <= periodos.fechafin
                    && dpFechaCierre2.SelectedDate <= periodos.fechafin
                    && dpFechaCierre3.SelectedDate <= periodos.fechafin)
                    {

                        try
                        {
                            int periodosRecuperar = cbPeriodos.SelectedIndex + 1;
                            var tutoriasBD = await conexionServicios.recuperarTutoriasPeriodoAsync(periodosRecuperar);
                            await conexionServicios.modificarFechasTutoriaAsync(tutoriasBD[0].idtutoria, dpFechaSesion.SelectedDate.Value, dpFechaCierre1.SelectedDate.Value);
                            await conexionServicios.modificarFechasTutoriaAsync(tutoriasBD[1].idtutoria, dpFechaSesion2.SelectedDate.Value, dpFechaCierre2.SelectedDate.Value);
                            await conexionServicios.modificarFechasTutoriaAsync(tutoriasBD[2].idtutoria, dpFechaSesion3.SelectedDate.Value, dpFechaCierre3.SelectedDate.Value);
                            MessageBox.Show("Modificacion de fechas exitoso");
                            MainWindow main = new MainWindow(academicoSesion);
                            main.Show();
                            this.Close();

                            this.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La fecha seleccionada no concuerda con el periodo escolar");
                    }
                }
                else
                {
                    MessageBox.Show("Datos invÃ¡lidos");
                }
            }
            else
            {
                MessageBox.Show("Campos vacios");
            }

        }

        private void cancelarRegistro(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Registro de fechas cancelado");
            MainWindow main = new MainWindow(academicoSesion);
            main.Show();
            this.Close();
        }

        private async void cbPeriodos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int periodos = cbPeriodos.SelectedIndex + 1;
            if (periodos > 0)
            {
                var conexionServicios = new Service1Client();

                try
                {
                    var tutoriasBD = await conexionServicios.recuperarTutoriasPeriodoAsync(periodos);
                    dpFechaSesion.SelectedDate = tutoriasBD[0].fechasesion;
                    dpFechaSesion2.SelectedDate = tutoriasBD[1].fechasesion;
                    dpFechaSesion3.SelectedDate = tutoriasBD[2].fechasesion;

                    dpFechaCierre1.SelectedDate = tutoriasBD[0].fechacierre;
                    dpFechaCierre2.SelectedDate = tutoriasBD[1].fechacierre;
                    dpFechaCierre3.SelectedDate = tutoriasBD[2].fechacierre;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("El periodo no tiene fechas de tutoría asignadas");
                }
            }
        }
    }
}
