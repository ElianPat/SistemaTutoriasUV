using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace WCFSistemaTutorias.Modelo
{
    public class AcademicoDAO
    {
        public static academico iniciarSesion(int numeroEmpleado, string password)
        {
            DataClassesTutoriaUVDataContext conexionBD = getConnection();

            var academicoSesion = (from academico in conexionBD.academico
                                 where academico.numeroempleado == numeroEmpleado 
                                 && academico.password == password
                                 select academico).FirstOrDefault();

            academico academicoInicio = new academico()
            {
                nombre = academicoSesion.nombre,
                idacademico = academicoSesion.idacademico,
                numeroempleado = academicoSesion.numeroempleado
            };

            if (academicoSesion != null)
            {
                return academicoInicio;
            }
            else
            {
                return null;
            }
        }
        
        public static bool esTutor(int numeroEmpleado)
        {
            DataClassesTutoriaUVDataContext conexionBD = getConnection();

            var resultado = (from academico in conexionBD.academico
                             join estudiante in conexionBD.estudiante
                             on academico.idacademico equals estudiante.idtutor
                             where academico.numeroempleado == numeroEmpleado
                             select academico).FirstOrDefault();
            if (resultado != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool esJefeCarrera(int numeroEmpleado)
        {
            DataClassesTutoriaUVDataContext conexionBD = getConnection();

            var resultado = (from academico in conexionBD.academico
                             join programaeducativo in conexionBD.programaeducativo
                             on academico.idacademico equals programaeducativo.idjefecarrera
                             where academico.numeroempleado == numeroEmpleado
                             select academico).FirstOrDefault();
            if (resultado != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool esCoordinador(int numeroEmpleado)
        {
            DataClassesTutoriaUVDataContext conexionBD = getConnection();

            var resultado = (from academico in conexionBD.academico
                             join programaeducativo in conexionBD.programaeducativo
                             on academico.idacademico equals programaeducativo.idcoordinador
                             where academico.numeroempleado == numeroEmpleado
                             select academico).FirstOrDefault();
            if (resultado != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool guardarAcademico(academico academicoRegistro)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                conexionBD.academico.InsertOnSubmit(academicoRegistro);
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool buscarAcademico(int numeroEmpleado)
        {
            try
            {
                DataClassesTutoriaUVDataContext conexionBD = getConnection();

                var academico = (from academicoQuery in conexionBD.academico
                                 where academicoQuery.numeroempleado == numeroEmpleado
                                 select academicoQuery).FirstOrDefault();

                if (academico != null)
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

        public static academico recuperarAcademico(int numeroempleado)
        {
            DataClassesTutoriaUVDataContext conexionBD = getConnection();

            var academicoBD = (from academicoQuery in conexionBD.academico
                                                where academicoQuery.numeroempleado == numeroempleado
                                                select academicoQuery).FirstOrDefault();
            return academicoBD;
        }

        public static ObservableCollection<academico> obtenerAcademicos()
        {
            DataClassesTutoriaUVDataContext conexionBD = getConnection();

            IQueryable<academico> academicosBD = from academicoQuery in conexionBD.academico
                                                 select academicoQuery;
            ObservableCollection<academico> academicos = new ObservableCollection<academico>();

            foreach (academico academico in academicosBD)
            {
                academico academicoAgregar = new academico()
                {
                    idacademico = academico.idacademico,
                    numeroempleado = academico.numeroempleado,
                    nombre = academico.nombre,
                    correoinstitucional = academico.correoinstitucional,
                    correopersonal = academico.correopersonal,
                    telefono = academico.telefono,
                    password = academico.password
                };
                academicos.Add(academicoAgregar);
            }
            return academicos;
        }

        public static DataClassesTutoriaUVDataContext getConnection()
        {
            return new DataClassesTutoriaUVDataContext(global::System.Configuration.
                   ConfigurationManager.ConnectionStrings["tutoriasuvConnectionString"].ConnectionString);
        }
    }
}