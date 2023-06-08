using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFSistemaTutorias.Modelo
{
    public class AcademicoDAO
    {
        public static bool iniciarSesion(int numeroEmpleado, string password)
        {
            DataClassesTutoriaUVDataContext conexionBD = getConnection();

            var academicoSesion = (from academico in conexionBD.academico
                                 where academico.numeroempleado == numeroEmpleado 
                                 && academico.password == password
                                 select academico).FirstOrDefault();

            if (academicoSesion != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DataClassesTutoriaUVDataContext getConnection()
        {
            return new DataClassesTutoriaUVDataContext(global::System.Configuration.
                   ConfigurationManager.ConnectionStrings["tutoriasuvConnectionString"].ConnectionString);
        }
    }
}