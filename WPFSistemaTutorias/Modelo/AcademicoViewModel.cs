using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace WPFSistemaTutorias.Modelo
{
    internal class AcademicoViewModel
    {
        public ObservableCollection<academico> academicosBD { get; set; }

        public AcademicoViewModel()
        {
            academicosBD = new ObservableCollection<academico>();
            solicitarInformacionServicio();
        }
        private async void solicitarInformacionServicio()
        {
            var conexionServicios = new Service1Client();

            if (conexionServicios != null)
            {
                academico[] academicoService = await conexionServicios.ObtenerAcademicosAsync();
                foreach (academico academicoObtenido in academicoService)
                {
                    academicosBD.Add(academicoObtenido);
                }
            }
            else
            {
                academicosBD = null;
            }
        }
    }
}