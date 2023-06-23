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

    public partial class registrarFecha : Window
    {
        academico academicoSesion;
        public registrarFecha(academico academico)
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
                            await conexionServicios.registrarFechasTutoriaAsync(1, dpFechaSesion.SelectedDate.Value, 1, dpFechaCierre1.SelectedDate.Value, idPeriodo);
                            await conexionServicios.registrarFechasTutoriaAsync(2, dpFechaSesion2.SelectedDate.Value, 1, dpFechaCierre2.SelectedDate.Value, idPeriodo);
                            await conexionServicios.registrarFechasTutoriaAsync(3, dpFechaSesion3.SelectedDate.Value, 7, dpFechaCierre3.SelectedDate.Value, idPeriodo);
                            MessageBox.Show("Registro de fechas exitoso");
                            MainWindow main = new MainWindow(academicoSesion);
                            main.Show();
                            this.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo conectar con la base de datos. Por favor, inténtelo más tarde.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("La fecha seleccionada no concuerda con el periodo escolar");
                    }

                }
                else
                {
                    MessageBox.Show("Datos inválidos");
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

    }
}
