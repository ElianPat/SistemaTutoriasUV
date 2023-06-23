using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSistemaTutorias.Modelo
{
    internal class EstudianteSesionViewModel
    {
        public ObservableCollection<EstudianteSesion> estudiantesSesion { get; set; } = new ObservableCollection<EstudianteSesion>();
        
        public EstudianteSesionViewModel(int idTutor, int numeroSesion, string periodo)
        {
            estudiantesSesion = new ObservableCollection<EstudianteSesion>();
            recuperarEstudiantesSesion(idTutor, numeroSesion, periodo);

        } 

        private async void recuperarEstudiantesSesion(int idTutor, int numeroSesion, string periodo)
        {
            var conexionServicios = new Service1Client();
            if(conexionServicios != null)
            {
                estudiante[] estudian = await conexionServicios.RecuperarEstudiantesSesionAsync(idTutor, numeroSesion, periodo);
                foreach(estudiante obtenido in estudian)
                {
                    var EstudianteSesion = new EstudianteSesion()
                    {
                        idEstudianteSesion = obtenido.idestudiante,
                        nombreSesion = obtenido.nombre
                    };
                    estudiantesSesion.Add(EstudianteSesion);
                }
            }
        } 
    }
}
