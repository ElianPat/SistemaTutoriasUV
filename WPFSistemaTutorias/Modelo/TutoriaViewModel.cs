using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSistemaTutorias.Modelo
{
    internal class TutoriaViewModel
    {
        public ObservableCollection<String> numeroSesionTutoria { get; set; }
        
        public TutoriaViewModel(int idPeriodo)
        {
            numeroSesionTutoria = new ObservableCollection<String>();
            cargarCbTutoria(idPeriodo);
        }

        public async void cargarCbTutoria(int idPeriodo)
        {
            var conexionServicios = new Service1Client();
            tutoria[] tutorias = await conexionServicios.recuperarTutoriasPeriodoAsync(idPeriodo);
            var tutoriasBD = tutorias;
            

            foreach (var tutoria in tutoriasBD)
            {

                string numeroSesion = "Sesion: " + tutoria.numerosesion.ToString();
                numeroSesionTutoria.Add(numeroSesion);
            }

        }
    }
}
