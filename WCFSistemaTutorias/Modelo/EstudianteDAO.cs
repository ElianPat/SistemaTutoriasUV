using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace WCFSistemaTutorias.Modelo
{
    public class EstudianteDAO
    {
        public static List<estudiante> recuperarEstudiantes()
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var estudiantesBD = (from estudiante in conexionBD.estudiante
                                         select estudiante);

                List<estudiante> estudianteBD = new List<estudiante>();
                foreach (var estudiantes in estudiantesBD)
                {

                    estudiante estudiante = new estudiante()
                    {
                        matricula = estudiantes.matricula,
                        nombre = estudiantes.nombre,
                        correoinstitucional = estudiantes.correoinstitucional,
                        correopersonal = estudiantes.correopersonal,
                        telefono = estudiantes.telefono,
                        idtutor = estudiantes.idtutor,
                        idprogramaeducativo = estudiantes.idprogramaeducativo
                    };
                    estudianteBD.Add(estudiante);
                }

                return estudianteBD.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<estudiante> recuperarEstudiantesTutor(int idTutor)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var estudiantesRecuperados = (from estudiantes in conexionBD.estudiante
                                                              where estudiantes.idtutor == idTutor
                                                              select estudiantes);

                List<estudiante> estudianteLista = new List<estudiante>();
                foreach (var estudianteTutoria in estudiantesRecuperados)
                {
                    estudiante estudiante = new estudiante();
                    estudiante.matricula = estudianteTutoria.matricula;
                    estudiante.nombre = estudianteTutoria.nombre;
                    estudianteLista.Add(estudiante);
                }
                return estudianteLista.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<estudiante> recuperarEstudiantesMatricula(string matricula)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var estudiantesRecuperados = (from estudiantes in conexionBD.estudiante
                                              where estudiantes.matricula == matricula
                                              select estudiantes);

                List<estudiante> estudianteLista = new List<estudiante>();
                foreach (var estudianteTutoria in estudiantesRecuperados)
                {
                    estudiante estudiante = new estudiante();
                    estudiante.idestudiante = estudianteTutoria.idestudiante;
                    estudiante.matricula = estudianteTutoria.matricula;
                    estudiante.nombre = estudianteTutoria.nombre;
                    estudianteLista.Add(estudiante);
                }
                return estudianteLista.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<estudiante> recuperarEstudiantesSesion(int idTutor, int numeroSesion, string periodoEscolar)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var estudiantesRecuperados = (from estudiantes in conexionBD.estudiante
                                              join sesion in conexionBD.sesion on estudiantes.idestudiante equals sesion.idestudiante
                                              join tutoria in conexionBD.tutoria on sesion.idtutoria equals tutoria.idtutoria
                                              join periodoescolar in conexionBD.periodoescolar on tutoria.idperiodoescolar equals periodoescolar.idperiodoescolar
                                              where estudiantes.idtutor == idTutor
                                              && tutoria.numerosesion == numeroSesion
                                              && periodoescolar.nombre == periodoEscolar
                                              select estudiantes);

                List<estudiante> estudianteLista = new List<estudiante>();

                foreach (var estudianteTutoria in estudiantesRecuperados)
                {
                    estudiante tutorados = new estudiante();
                    tutorados.nombre = estudianteTutoria.nombre;
                    tutorados.idestudiante = estudianteTutoria.idestudiante;

                    estudianteLista.Add(tutorados);
                }
                return estudianteLista.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static estudiante recuperarEstudianteProblematica(int idProblematica)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var consulta = (from estudiante in conexionBD.estudiante
                                join sesion in conexionBD.sesion on estudiante.idestudiante equals sesion.idestudiante
                                join problematicaSesion in conexionBD.problematicasesion on sesion.idsesion equals problematicaSesion.idsesion
                                join problematica in conexionBD.problematica on problematicaSesion.idproblematica equals problematica.idproblematica
                                where problematica.idproblematica == idProblematica
                                select estudiante).FirstOrDefault();

                estudiante estudianteProblematica = new estudiante()
                {
                    nombre = consulta.nombre
                };
                return estudianteProblematica;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Boolean guardarEstudiante(estudiante estudianteLocal)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();
                estudiante estudianteNuevo = new estudiante()
                {
                    matricula = estudianteLocal.matricula,
                    nombre = estudianteLocal.nombre,
                    correoinstitucional = estudianteLocal.correoinstitucional,
                    correopersonal = estudianteLocal.correopersonal,
                    telefono = estudianteLocal.telefono
                };

                conexionBD.estudiante.InsertOnSubmit(estudianteNuevo);
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static List<estudiante> obtenerEstudiantes()
        {
            DataClassesTutoriaUVDataContext conexionBD = getConnection();

            IQueryable<estudiante> estudiantesBD = from estudianteQuery in conexionBD.estudiante
                                                   where estudianteQuery.idtutor == null
                                                   select estudianteQuery;
            return estudiantesBD.ToList();
        }

        public static estudiante recuperarEstudiante(string matricula)
        {
            DataClassesTutoriaUVDataContext conexionBD = getConnection();

            var estudianteBD = (from estudianteQuery in conexionBD.estudiante
                                                  where estudianteQuery.matricula == matricula
                                                  select estudianteQuery).FirstOrDefault();
            return estudianteBD;
        }

        public static Boolean actualizarEstudiante(string matricula, int tutor)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var estudiante = (from estudianteQuery in conexionBD.estudiante
                                  where estudianteQuery.matricula == matricula
                                  select estudianteQuery).FirstOrDefault();

                if (estudiante != null)
                {
                    estudiante.idtutor = tutor;
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

        public static Boolean buscarEstudiante(string matricula)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var estudiante = (from estudianteQuery in conexionBD.estudiante
                                  where estudianteQuery.matricula == matricula
                                  select estudianteQuery).FirstOrDefault();

                if (estudiante != null)
                {
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