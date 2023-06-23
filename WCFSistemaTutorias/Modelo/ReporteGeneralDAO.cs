using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFSistemaTutorias.Modelo
{
    public class ReporteGeneralDAO
    {
        public static reportegeneral recuperaReporteGeneral(string periodoEscolar, int numeroSesion)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var resultado = (from reportegeneral in conexionBD.reportegeneral
                                join reportehastutoria in conexionBD.reportegeneral_has_reportetutoria on reportegeneral.idreportegeneral equals reportehastutoria.reportegeneral_idreportegeneral
                                join reportetutoria in conexionBD.reportetutoria on reportehastutoria.reporteetutoria_idreportetutoria equals reportetutoria.idreportetutoria
                                join sesion in conexionBD.sesion on reportetutoria.idtutoria equals sesion.idtutoria
                                join tutoria in conexionBD.tutoria on reportetutoria.idtutoria equals tutoria.idtutoria
                                join periodoescolar in conexionBD.periodoescolar on tutoria.idperiodoescolar equals periodoescolar.idperiodoescolar
                                where periodoescolar.nombre == periodoEscolar && tutoria.numerosesion == numeroSesion
                                select reportegeneral).FirstOrDefault();

                reportegeneral reportegeneralo = new reportegeneral()
                {
                    porcentajeasistencia = resultado.porcentajeasistencia,
                    porcentajeriesgo = resultado.porcentajeriesgo
                };
                return reportegeneralo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<string> recuperarComentariosReporteGeneral(string periodoEscolar, int numeroSesion)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var consulta = from reportetutoria in conexionBD.reportetutoria
                               join tutoria in conexionBD.tutoria on reportetutoria.idtutoria equals tutoria.idtutoria
                               join periodoescolar in conexionBD.periodoescolar on tutoria.idperiodoescolar equals periodoescolar.idperiodoescolar
                               where periodoescolar.nombre == periodoEscolar && tutoria.numerosesion == numeroSesion
                               select reportetutoria.comentariosgenerales;

                List<string> listaComentarios = new List<string>(); 

                foreach (var comentariosgenerales in consulta)
                {
                    string comen = comentariosgenerales;
                    listaComentarios.Add(comen);
                }
                return listaComentarios.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataClassesTutoriaUVDataContext getConnection()
        {
            return new DataClassesTutoriaUVDataContext(global::System.Configuration.
                   ConfigurationManager.ConnectionStrings["tutoriasuvConnectionString"].ConnectionString);
        }
    }
}