using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFSistemaTutorias.Modelo
{
    public class PeriodoEscolarDAO
    {
        public static periodoescolar recuperarPeriodosEscolaresId(int idPeriodo)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var periodosEscolaresBD = (from periodos in conexionBD.periodoescolar
                                           where periodos.idperiodoescolar == idPeriodo
                                           select periodos).FirstOrDefault();

                List<periodoescolar> periodoEscolarBD = new List<periodoescolar>();

                periodoescolar periodoId = new periodoescolar()
                {
                    nombre = periodosEscolaresBD.nombre,
                    fechainicio = periodosEscolaresBD.fechainicio,
                    fechafin = periodosEscolaresBD.fechafin
                };


                return periodoId;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<periodoescolar> recuperarPeriodosEscolares()
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var periodosEscolaresBD = (from periodos in conexionBD.periodoescolar
                                         select periodos.nombre);

                List<periodoescolar> periodoEscolarBD = new List<periodoescolar>();
                foreach (var periodoescolar in periodosEscolaresBD)
                {                   
                    periodoescolar periodos = new periodoescolar()
                    {
                        //idperiodoescolar = periodoescolar.idperiodoescolar,
                        // codigo = periodoescolar.codigo,
                        nombre = periodoescolar
                        //fechainicio = periodoescolar.fechainicio,
                        //fechafin = periodoescolar.fechafin
                    };
                    periodoEscolarBD.Add(periodos);
                }

                return periodoEscolarBD.ToList();
            }catch (Exception ex)
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