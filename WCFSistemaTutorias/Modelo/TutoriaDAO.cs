using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFSistemaTutorias.Modelo
{
    public class TutoriaDAO
    {

        public static List<tutoria> recuperarTutorias()
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var tutoriasBD = (from tutorias in conexionBD.tutoria
                                         select tutorias);

                List<tutoria> tutoriaBD = new List<tutoria>();
                foreach (var tutoria in tutoriasBD)
                {

                    tutoria tutorias = new tutoria();
                    {
                        tutorias.idtutoria = tutoria.idtutoria;
                        tutorias.idperiodoescolar = tutoria.idperiodoescolar;
                        tutorias.fechacierre = tutoria.fechacierre;
                        tutorias.numerodias = tutoria.numerodias;
                       tutorias.numerosesion = tutoria.numerosesion;
                        tutorias.fechasesion = tutoria.fechasesion;
                    };
                    tutoriaBD.Add(tutorias);
                }

                return tutoriaBD.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<tutoria> recuperarTutoriasPeriodo(int idPeriodo)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var tutoriasBD = (from tutorias in conexionBD.tutoria
                                  where tutorias.idperiodoescolar == idPeriodo
                                  select tutorias);

                List<tutoria> tutoriaBD = new List<tutoria>();
                foreach (var tutoria in tutoriasBD)
                {

                    tutoria tutorias = new tutoria();
                    {
                        tutorias.idtutoria = tutoria.idtutoria;
                        tutorias.idperiodoescolar = tutoria.idperiodoescolar;
                        tutorias.fechacierre = tutoria.fechacierre;
                        tutorias.numerodias = tutoria.numerodias;
                        tutorias.numerosesion = tutoria.numerosesion;
                        tutorias.fechasesion = tutoria.fechasesion;
                    };
                    tutoriaBD.Add(tutorias);
                }

                return tutoriaBD.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool registrarFechasTutoria(int numeroSesion, DateTime fechaSesion, int numeroDias, DateTime fechaCierre, int idPeriodoEscolar)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();


                var tutoria = new tutoria()
                {
                    numerosesion = numeroSesion,
                    fechasesion = fechaSesion,
                    numerodias = numeroDias,
                    idperiodoescolar = idPeriodoEscolar,
                    fechacierre = fechaCierre
                    
                };

                conexionBD.tutoria.InsertOnSubmit(tutoria);
                conexionBD.SubmitChanges();


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public static bool modificarFechasTutoria(int idTutoria, DateTime fechaCierre, DateTime fechaSesion)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var tutoria = (from tutorias in conexionBD.tutoria
                               where tutorias.idtutoria == idTutoria
                               select tutorias).FirstOrDefault();

                if (tutoria != null)
                {
                    tutoria.fechasesion = fechaSesion;
                    tutoria.fechacierre = fechaCierre;
                    conexionBD.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool modificarFechaCierreTutoria(int idTutoria, DateTime fechaCierre)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var tutoria = (from tutorias in conexionBD.tutoria
                               where tutorias.idtutoria == idTutoria
                               select tutorias).FirstOrDefault();

                if (tutoria != null)
                {
                    tutoria.fechacierre = fechaCierre;
                    conexionBD.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
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