using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFSistemaTutorias.Modelo;

namespace WCFSistemaTutorias
{
    public class Service1 : IService1
    {
        public bool IniciarSesion(int numeroEmpleado, string password)
        {
            return AcademicoDAO.iniciarSesion(numeroEmpleado, password);
        }
    }
}
