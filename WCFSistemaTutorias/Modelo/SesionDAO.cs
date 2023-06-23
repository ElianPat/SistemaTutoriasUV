using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFSistemaTutorias.Modelo
{
    public class SesionDAO
    {
        public static Boolean registrarReporteSesion(sesion Sesion, string nombre, string periodo, int numeroSesion)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var sesion = (from sesionRegistro in conexionBD.sesion
                              join estudianteSesion in conexionBD.estudiante on sesionRegistro.idestudiante equals estudianteSesion.idestudiante
                              join tutoria in conexionBD.tutoria on sesionRegistro.idtutoria equals tutoria.idtutoria
                              join periodoescolar in conexionBD.periodoescolar on tutoria.idperiodoescolar equals periodoescolar.idperiodoescolar
                              where periodoescolar.nombre == periodo && estudianteSesion.nombre == nombre && tutoria.numerosesion == numeroSesion
                              select sesionRegistro).FirstOrDefault();
                if (sesion != null)
                {
                    sesion.asistencia = Sesion.asistencia;
                    sesion.riesgo = Sesion.riesgo;
                    sesion.observaciones = Sesion.observaciones;
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

        public static int recuperarIdSesion(string periodo, int numeroSesion)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var id = (from sesionRegistro in conexionBD.sesion
                          join tutoria in conexionBD.tutoria on sesionRegistro.idtutoria equals tutoria.idtutoria
                          join periodoescolar in conexionBD.periodoescolar on tutoria.idperiodoescolar equals periodoescolar.idperiodoescolar
                          where periodoescolar.nombre == periodo && tutoria.numerosesion == numeroSesion
                          select sesionRegistro.idtutoria).FirstOrDefault();

                return id.Value;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static int recuperarIdSesionEstudiante(string periodo, int numeroSesion, string nombre)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var idSes = (from sesionRegistro in conexionBD.sesion
                                join tutoria in conexionBD.tutoria on sesionRegistro.idtutoria equals tutoria.idtutoria
                                join estudiante in conexionBD.estudiante on sesionRegistro.idestudiante equals estudiante.idestudiante
                                join periodoescolar in conexionBD.periodoescolar on tutoria.idperiodoescolar equals periodoescolar.idperiodoescolar
                                where periodoescolar.nombre == periodo && tutoria.numerosesion == numeroSesion && estudiante.nombre == nombre
                                select sesionRegistro.idsesion).FirstOrDefault();

                int id = idSes;
                return id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static bool registrarHorarioSesionTutoria(int idEstudiante, int idTutoria, string horario, string lugar)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();


                var sesion = new sesion()
                {
                    idestudiante = idEstudiante,
                    idtutoria = idTutoria,
                    horario = horario,
                    lugar = lugar
                };

                conexionBD.sesion.InsertOnSubmit(sesion);
                conexionBD.SubmitChanges();


                return true;
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