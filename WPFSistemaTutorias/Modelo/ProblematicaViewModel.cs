using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSistemaTutorias.Modelo
{
    internal class ProblematicaViewModel
    {
        public ProblematicaViewModel(int idProblematica, string periodo, string tipo)
        {
            recuperarProblematicas(periodo, tipo);
            recuperarProblematica(idProblematica);
        }

        public async void recuperarProblematicas(string periodo, string tipo)
        {
            var conexionServicios = new Service1Client();
            var problematicas = await conexionServicios.RecuperarProblematicasAsync(periodo, tipo);
        }

        public async void recuperarProblematica(int idProblemacita)
        {
            var conexionServicios = new Service1Client();
            var problematicas = await conexionServicios.RecuperarProblematicaAsync(idProblemacita);
        }
    }
}
