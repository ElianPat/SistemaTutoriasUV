using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFSistemaTutorias.Modelo;

namespace WCFSistemaTutorias
{
    public class Service1 : IService1
    {
        public academico IniciarSesion(int numeroEmpleado, string password)
        {
            return AcademicoDAO.iniciarSesion(numeroEmpleado, password);
        }

        public bool EsTutor(int numeroEmpleado)
        {
            return AcademicoDAO.esTutor(numeroEmpleado);
        }

        public bool EsJefeCarrera(int numeroEmpleado)
        {
            return AcademicoDAO.esJefeCarrera(numeroEmpleado);
        }

        public bool EsCoordinador(int numeroEmpleado)
        {
            return AcademicoDAO.esCoordinador(numeroEmpleado);
        }

        public List<estudiante> RecuperarEstudiantesSesion(int idTutor, int numeroSesion, string periodoEscolar)
        {
            List<estudiante> estudiantesBD = EstudianteDAO.recuperarEstudiantesSesion(idTutor, numeroSesion, periodoEscolar);
            return estudiantesBD;
        }

        public bool RegistrarReporteSesion(sesion Sesion, string nombre, string periodo, int numeroSesion)
        {
            return SesionDAO.registrarReporteSesion(Sesion, nombre, periodo, numeroSesion);
        }

        public int RecuperarIdSesion(string periodo, int numeroSesion)
        {
            return SesionDAO.recuperarIdSesion(periodo, numeroSesion);
        }

        public reportetutoria CalcularPorcentajesReporte(int idTutoria, int idTutor)
        {
            return ReporteTutoriaDAO.calcularPorcentajesReporte(idTutoria, idTutor);
        }

        public bool RegistrarPorcentajesReporte(int idtutoria, int idtutor, double porcentajeriesgo, double porcentajeasistencia)
        {
            return ReporteTutoriaDAO.registrarPorcentajesReporte(idtutoria, idtutor, porcentajeriesgo, porcentajeasistencia);
        }

        public bool RegistrarComentariosGenerales(int idTutoria, int idTutor, string comentariosGenerales)
        {
            return ReporteTutoriaDAO.registrarComentariosGenerales(idTutoria, idTutor, comentariosGenerales);
        }

        public List<string> RecuperarInformacionExperienciasEducativas()
        {
            List<string> experienciasEducativasBD = ExperienciaEducativaDAO.recuperarInformacionExperienciasEducativas();
            return experienciasEducativasBD;
        }

        public int RegistrarProblematica(string tipo, string nombre)
        {
            return ProblematicaDAO.registrarProblematica(tipo, nombre);
        }

        public bool RegistrarProblematicaSesion(int idProblematica, int idSesion, string descripcion, string experienciaEducativa)
        {
            return ProblematicaDAO.registrarProblematicaSesion(idProblematica, idSesion, descripcion, experienciaEducativa);
        }

        public int RecuperarIdSesionEstudiante(string periodo, int numeroSesion, string nombre)
        {
            return SesionDAO.recuperarIdSesionEstudiante(periodo, numeroSesion, nombre);
        }

        public List<problematica> RecuperarProblematicas(string periodo, string tipo)
        {
            return ProblematicaDAO.recuperarProblematicas(periodo, tipo);
        }

        public problematicasesion RecuperarProblematica(int idProblematica)
        {
            return ProblematicaDAO.recuperarProblematica(idProblematica);
        }

        public estudiante RecuperarEstudianteProblematica(int idProblematica)
        {
            return EstudianteDAO.recuperarEstudianteProblematica(idProblematica);
        }

        public reportegeneral RecuperaReporteGeneral(string periodoEscolar, int numeroSesion)
        {
            return ReporteGeneralDAO.recuperaReporteGeneral(periodoEscolar, numeroSesion);
        }

        public List<string> RecuperarProblematicasReporte(string periodoEscolar, int numeroSesion)
        {
            return ProblematicaDAO.recuperarProblematicasReporte(periodoEscolar, numeroSesion);
        }

        public List<string> RecuperarComentariosReporteGeneral(string periodoEscolar, int numeroSesion)
        {
            return ReporteGeneralDAO.recuperarComentariosReporteGeneral(periodoEscolar, numeroSesion);
        }

        public bool registrarFechasTutoria(int numeroSesion, DateTime fechaSesion, int numeroDias, DateTime fechaCierre, int idPeriodoEscolar)
        {
            return TutoriaDAO.registrarFechasTutoria(numeroSesion, fechaSesion, numeroDias, fechaCierre, idPeriodoEscolar);
        }

        public List<periodoescolar> recuperarPeriodosEscolares()
        {
            return PeriodoEscolarDAO.recuperarPeriodosEscolares();
        }

        public List<tutoria> recuperarTutorias()
        {
            return TutoriaDAO.recuperarTutorias();
        }

        public bool modificarFechasTutoria(int idTutoria, DateTime fechaCierre, DateTime fechaSesion)
        {
            return TutoriaDAO.modificarFechasTutoria(idTutoria, fechaCierre, fechaSesion);
        }
        
        public List<estudiante> recuperarEstudiantes()
        {
            return EstudianteDAO.recuperarEstudiantes();
        }

        public bool registrarHorarioSesionTutoria(int idEstudiante, int idTutoria, string horario, string lugar)
        {
            return SesionDAO.registrarHorarioSesionTutoria(idEstudiante, idTutoria, horario, lugar);
        }

        public List<estudiante> recuperarEstudiantesTutor(int idTutor)
        {
            return EstudianteDAO.recuperarEstudiantesTutor(idTutor);
        }

        public List<tutoria> recuperarTutoriasPeriodo(int idPeriodo)
        {
            return TutoriaDAO.recuperarTutoriasPeriodo(idPeriodo);
        }

        public List<estudiante> recuperarEstudiantesMatricula(string matricula)
        {
            return EstudianteDAO.recuperarEstudiantesMatricula(matricula);
        }

        public Boolean RegistrarAcademico(academico academicoRegistro)
        {
            return AcademicoDAO.guardarAcademico(academicoRegistro);
        }

        public Boolean BuscarAcademico(int numeroEmpleado)
        {
            return AcademicoDAO.buscarAcademico(numeroEmpleado);
        }

        public Boolean RegistrarEstudiante(estudiante estudianteRegistro)

        {
            return EstudianteDAO.guardarEstudiante(estudianteRegistro);
        }

        public Boolean RegistrarExperienciaEducativa(experienciaeducativa experienciaeducativa)
        {
            return ExperienciaEducativaDAO.registrarExperienciaEducativa(experienciaeducativa);
        }

        public ObservableCollection<academico> ObtenerAcademicos()
        {
            ObservableCollection<academico> academicosBD = AcademicoDAO.obtenerAcademicos();
            return academicosBD;
        }

        public List<estudiante> ObtenerEstudiantes()
        {
            return EstudianteDAO.obtenerEstudiantes();
        }

        public Boolean BuscarEstudiante(string matricula)
        {
            return EstudianteDAO.buscarEstudiante(matricula);
        }

        public estudiante RecuperarEstudiante(string matricula)
        {
            return EstudianteDAO.recuperarEstudiante(matricula);
        }

        public academico RecuperarAcademico(int numeroempleado)
        {
            return AcademicoDAO.recuperarAcademico(numeroempleado);
        }

        public Boolean BuscarExperienciaEducativa(int nrc)
        {
            return ExperienciaEducativaDAO.buscarExperienciaEducativa(nrc);
        }

        public Boolean RegistrarProgramaEducativo(string nombre, string codigo)
        {
            return ProgramaEducativoDAO.registrarProgramaEducativo(nombre, codigo);
        }

        public Boolean BuscarProgramaEducativo(string codigo)
        {
            return ProgramaEducativoDAO.buscarProgramaEducativo(codigo);
        }

        public Boolean ActualizarEstudiante(string matricula, int tutor)
        {
            return EstudianteDAO.actualizarEstudiante(matricula, tutor);
        }

        public periodoescolar recuperarPeriodosEscolaresId(int idPeriodo)
        {
            return PeriodoEscolarDAO.recuperarPeriodosEscolaresId(idPeriodo);
        }

    }
}
