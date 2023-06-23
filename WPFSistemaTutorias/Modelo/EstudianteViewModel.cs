using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WPFSistemaTutorias.Modelo
{
    internal class EstudianteViewModel
    {

        public ObservableCollection<estudiante> estudiantesBD { get; set; }

        public EstudianteViewModel(academico academico, int numeroSesion, string periodo)
        {
            cargarEstudiantes(academico);
            estudiantesBD = new ObservableCollection<estudiante>();
            solicitarInformacionServicio();

        }

        public async void cargarEstudiantes(academico academico)
        {
            var conexionServicios = new Service1Client();
            var estudiantes = await conexionServicios.recuperarEstudiantesTutorAsync(academico.idacademico);
        }

        private async void solicitarInformacionServicio()
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                estudiante[] estudianteService = await conexionServicios.ObtenerEstudiantesAsync();
                foreach (estudiante estudianteObtenido in estudianteService)
                {
                    estudiantesBD.Add(estudianteObtenido);
                }
            }
        }
    }
}
