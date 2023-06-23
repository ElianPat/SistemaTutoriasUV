using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSistemaTutorias.Modelo
{
    internal class EstudianteSesion
    {
        public int idEstudianteSesion { get; set; }
        public string nombreSesion { get; set; }
        public string observacionesSesion { get; set; }
        public bool asistenciaSeleccion { get; set; }
        public bool riesgoSeleccion { get; set; }
        public int idTutoriaSesion { get; set; }


    }
}
