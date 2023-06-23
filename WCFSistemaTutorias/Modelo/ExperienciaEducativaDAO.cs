using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFSistemaTutorias.Modelo
{
    public class ExperienciaEducativaDAO
    {
        public static List<string> recuperarInformacionExperienciasEducativas()
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                List<string> experienciaLista = new List<string>();

                var experienciasEducativas = from experiencias in conexionBD.experienciaeducativa
                                             join profesores in conexionBD.academico
                                             on experiencias.idprofesor equals profesores.idacademico
                                             select new
                                             {
                                                 nrcExperiencia = experiencias.NRC,
                                                 nombreExperiencia = experiencias.nombre,
                                                 nombreAcademico = profesores.nombre
                                             };
                foreach (var experienciasEdu in experienciasEducativas)
                {
                    string datosExperiencia = experienciasEdu.nrcExperiencia + ", "
                        + experienciasEdu.nombreExperiencia + ", "
                        + experienciasEdu.nombreAcademico;
                    experienciaLista.Add(datosExperiencia);
                }
                return experienciaLista.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Boolean registrarExperienciaEducativa(experienciaeducativa experienciaeducativa)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                conexionBD.experienciaeducativa.InsertOnSubmit(experienciaeducativa);
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool buscarExperienciaEducativa(int nrc)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var ee = (from eeQuery in conexionBD.experienciaeducativa
                          where eeQuery.NRC == nrc
                          select eeQuery).FirstOrDefault();

                if (ee != null)
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