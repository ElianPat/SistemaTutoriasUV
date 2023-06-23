using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WCFSistemaTutorias.Modelo
{
    public class ProblematicaDAO
    {
        public static List<problematica> recuperarProblematicas(string periodo, string tipo)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var resultados = from p in conexionBD.problematica
                                 join pc in conexionBD.problematicasesion on p.idproblematica equals pc.idproblematica
                                 join s in conexionBD.sesion on pc.idsesion equals s.idsesion
                                 join t in conexionBD.tutoria on s.idtutoria equals t.idtutoria
                                 join pe in conexionBD.periodoescolar on t.idperiodoescolar equals pe.idperiodoescolar
                                 where p.tipo == tipo && pe.nombre == periodo
                                 select new
                                 {
                                     p.tipo,
                                     p.nombre,
                                     p.idproblematica
                                 };

                List<problematica> problematicasLista = new List<problematica>();

                foreach (var problematicas in resultados)
                {
                    problematica problematicasTipo = new problematica()
                    {
                        tipo = problematicas.tipo,
                        nombre = problematicas.nombre,
                        idproblematica = problematicas.idproblematica
                    };

                    problematicasLista.Add(problematicasTipo);
                }
                return problematicasLista.ToList();
            }
            catch
            {
                return null;
            }
        }

        public static problematicasesion recuperarProblematica(int idProblematica)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var resultado = (from problematicasesion in conexionBD.problematicasesion
                                 join problematica in conexionBD.problematica on problematicasesion.idproblematica equals problematica.idproblematica
                                 where problematicasesion.idproblematica == idProblematica
                                 select problematicasesion).FirstOrDefault();

                problematicasesion problematicaContenido = new problematicasesion()
                {
                    descripcion = resultado.descripcion,
                    estado = resultado.estado,
                    experienciaeducativa = resultado.experienciaeducativa
                };

                return problematicaContenido;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static int registrarProblematica(string tipo, string nombre)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var tipoProblematica = new problematica()
                {
                    tipo = tipo,
                    nombre = nombre
                };
                conexionBD.problematica.InsertOnSubmit(tipoProblematica);
                conexionBD.SubmitChanges();

                int id = tipoProblematica.idproblematica;
                return id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static Boolean registrarProblematicaSesion(int idProblematica, int idSesion, string descripcion, string experienciaEducativa)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();
                    var problematica = new problematicasesion()
                    {
                        idproblematica = idProblematica,
                        idsesion = idSesion,
                        estado = "Pendiente",
                        descripcion = descripcion,
                        experienciaeducativa = experienciaEducativa
                    };
                    conexionBD.problematicasesion.InsertOnSubmit(problematica);
                    conexionBD.SubmitChanges();
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<string> recuperarProblematicasReporte(string periodoEscolar, int numeroSesion)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var resultados = from problematica in conexionBD.problematica
                                 join problematicasesion in conexionBD.problematicasesion on problematica.idproblematica equals problematicasesion.idproblematica
                                 join sesion in conexionBD.sesion on problematicasesion.idsesion equals sesion.idsesion
                                 join tutoria in conexionBD.tutoria on sesion.idtutoria equals tutoria.idtutoria
                                 join periodoescolar in conexionBD.periodoescolar on tutoria.idperiodoescolar equals periodoescolar.idperiodoescolar
                                 where periodoescolar.nombre == periodoEscolar && tutoria.numerosesion == numeroSesion
                                 select problematica;

                List<string> problematicasLista = new List<string>();

                foreach (var problematicas in resultados)
                {
                    string problematica = problematicas.tipo + ", " + problematicas.nombre;

                    problematicasLista.Add(problematica);
                }
                return problematicasLista.ToList();
            }
            catch
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