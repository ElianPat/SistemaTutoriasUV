using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSistemaTutorias.Modelo
{
    internal class ExperienciaViewModel
    {
        public ObservableCollection<Experiencia> experiencias { get; set; } = new ObservableCollection<Experiencia>();
        public ExperienciaViewModel()
        {
            experiencias = new ObservableCollection<Experiencia> { };
            recuperarExperiencias();
        }

        private async void recuperarExperiencias()
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                string[] expe = await conexionServicios.RecuperarInformacionExperienciasEducativasAsync();
                foreach (string registro in expe)
                {
                    var Experiencia = new Experiencia()
                    {
                        datosExperiencia = registro
                    };
                    experiencias.Add(Experiencia);
                }
            }
        }

    }
}
