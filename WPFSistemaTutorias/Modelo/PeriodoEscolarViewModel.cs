using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSistemaTutorias.Modelo
{
    internal class PeriodoEscolarViewModel
    {

        public ObservableCollection<String> nombrePeriodo { get; set; }

        public PeriodoEscolarViewModel()
        {
            nombrePeriodo = new ObservableCollection<String>();
            cargarCbPeriodos();
        }

        private async void cargarCbPeriodos()
        {
            var conexionServicios = new Service1Client();
            periodoescolar[] periodoescolars = await conexionServicios.recuperarPeriodosEscolaresAsync();
            var periodosBD = periodoescolars;
            

            foreach (var periodo in periodosBD)
            {
                int idPeriodo = periodo.idperiodoescolar;
                String nombre = periodo.nombre;
                nombrePeriodo.Add(nombre);
            }
            
        }
    }
}
