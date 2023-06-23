using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFSistemaTutorias.Modelo
{
    public class ReporteTutoriaDAO
    {
        public static reportetutoria calcularPorcentajesReporte(int idTutoria, int idTutor)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var resultado = from sesion in conexionBD.sesion
                                join estudiante in conexionBD.estudiante
                                on sesion.idestudiante equals estudiante.idestudiante
                                where sesion.idtutoria == idTutoria && estudiante.idtutor == idTutor
                                select new
                                {
                                    sesion.asistencia,
                                    sesion.riesgo
                                };
                int totalRegistrosAsistencia = resultado.Count(r => r.asistencia.HasValue);
                int totalRegistrosRiesgo = resultado.Count(r => r.riesgo.HasValue);
                int asistenciaConteo = resultado.Count(r => r.asistencia == 1);
                int riesgoConteo = resultado.Count(r => r.riesgo == 1);

                double porcentajeAsistencia = (double)asistenciaConteo / totalRegistrosAsistencia * 100;
                double porcentajeRiesgo = (double)riesgoConteo / totalRegistrosRiesgo * 100;

                reportetutoria reporte = new reportetutoria()
                {
                    porcentajeasistencia = porcentajeAsistencia,
                    porcentajeriesgo = porcentajeRiesgo
                };

                return reporte;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Boolean registrarPorcentajesReporte(int idtutoria, int idtutor, double porcentajeriesgo, double porcentajeasistencia)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();


                DateTime fechaActual = DateTime.Now.Date;

                var reporte = new reportetutoria()
                {
                    idtutoria = idtutoria,
                    porcentajeasistencia = porcentajeasistencia,
                    porcentajeriesgo = porcentajeriesgo,
                    fechacreacion = fechaActual,
                    idtutor = idtutor
                };
                conexionBD.reportetutoria.InsertOnSubmit(reporte);
                conexionBD.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Boolean registrarComentariosGenerales(int idTutoria, int idTutor, string comentariosGenerales)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var resultado = (from reportetuto in conexionBD.reportetutoria
                                 where reportetuto.idtutor == idTutor &&
                                 reportetuto.idtutoria == idTutoria
                                 select reportetuto).FirstOrDefault();

                if (resultado != null)
                {
                    resultado.comentariosgenerales = comentariosGenerales;
                    conexionBD.SubmitChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
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