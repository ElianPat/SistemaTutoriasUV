using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace WCFSistemaTutorias.Modelo
{
    public class ProgramaEducativoDAO
    {
        public static ObservableCollection<programaeducativo> obtenerProgramasEducativos()
        {
            DataClassesTutoriaUVDataContext conexionBD = getConnection();

            IQueryable<programaeducativo> programasBD = from programa in conexionBD.programaeducativo
                                                        select programa;

            ObservableCollection<programaeducativo> programasEducativos = new ObservableCollection<programaeducativo>();

            foreach (programaeducativo programa in programasBD)
            {
                programaeducativo programaAgregar = new programaeducativo()
                {
                    idprogramaeducativo = programa.idprogramaeducativo,
                    codigo = programa.codigo,
                    nombre = programa.nombre,
                    idcoordinador = programa.idcoordinador,
                    idjefecarrera = programa.idjefecarrera
                };
                programasEducativos.Add(programaAgregar);

            }

            return programasEducativos;
        }

        public static Boolean registrarProgramaEducativo(programaeducativo programaeducativo)
        {
            try
            {

                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                programaeducativo programaNuevo = new programaeducativo()
                {
                    nombre = programaeducativo.nombre,
                    codigo = programaeducativo.codigo,
                    idcoordinador = programaeducativo.idcoordinador,
                    idjefecarrera = programaeducativo.idjefecarrera

                };

                conexionBD.programaeducativo.InsertOnSubmit(programaNuevo);
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool buscarProgramaEducativo(string codigo)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var programa = (from programaQuery in conexionBD.programaeducativo
                                where programaQuery.codigo == codigo
                                select programaQuery).FirstOrDefault();

                if (programa != null)
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

        public static Boolean registrarProgramaEducativo(string nombre, string codigo)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var programaNuevo = new programaeducativo()
                {
                    nombre = nombre,
                    codigo = codigo
                };

                conexionBD.programaeducativo.InsertOnSubmit(programaNuevo);
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