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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        academico IniciarSesion(int numeroEmpleado, string password);

        [OperationContract]
        Boolean EsTutor(int numeroEmpleado);

        [OperationContract]
        Boolean EsJefeCarrera(int numeroEmpleado);

        [OperationContract]
        Boolean EsCoordinador(int numeroEmpleado);

        [OperationContract]
        List<estudiante> RecuperarEstudiantesSesion(int idTutor, int numeroSesion, string periodoEscolar);

        [OperationContract]
        Boolean RegistrarReporteSesion(sesion Sesion, string nombre, string periodo, int numeroSesion);

        [OperationContract]
        int RecuperarIdSesion(string periodo, int numeroSesion);

        [OperationContract]
        reportetutoria CalcularPorcentajesReporte(int idTutoria, int idTutor);

        [OperationContract]
        Boolean RegistrarPorcentajesReporte(int idtutoria, int idtutor, double porcentajeriesgo, double porcentajeasistencia);

        [OperationContract]
        Boolean RegistrarComentariosGenerales(int idTutoria, int idTutor, string comentariosGenerales);

        [OperationContract]
        List<string> RecuperarInformacionExperienciasEducativas();

        [OperationContract]
        int RegistrarProblematica(string tipo, string nombre);

        [OperationContract]
        Boolean RegistrarProblematicaSesion(int idProblematica, int idSesion, string descripcion, string experienciaEducativa);

        [OperationContract]
        int RecuperarIdSesionEstudiante(string periodo, int numeroSesion, string nombre);

        [OperationContract]
        List<problematica> RecuperarProblematicas(string periodo, string tipo);

        [OperationContract]
        problematicasesion RecuperarProblematica(int idProblematica);

        [OperationContract]
        estudiante RecuperarEstudianteProblematica(int idProblematica);

        [OperationContract]
        reportegeneral RecuperaReporteGeneral(string periodoEscolar, int numeroSesion);

        [OperationContract]
        List<string> RecuperarProblematicasReporte(string periodoEscolar, int numeroSesion);

        [OperationContract]
        List<string> RecuperarComentariosReporteGeneral(string periodoEscolar, int numeroSesion);

        [OperationContract]
        List<periodoescolar> recuperarPeriodosEscolares();

        [OperationContract]
        List<tutoria> recuperarTutorias();

        [OperationContract]
        Boolean registrarFechasTutoria(int numeroSesion, DateTime fechaSesion, int numeroDias, DateTime fechaCierre, int idPeriodoEscolar);

        [OperationContract]
        Boolean modificarFechasTutoria(int idTutoria, DateTime fechaCierre, DateTime fechaSesion);

        [OperationContract]
        Boolean registrarHorarioSesionTutoria(int idEstudiante, int idTutoria, string horario, string lugar);

        [OperationContract]
        List<estudiante> recuperarEstudiantes();

        [OperationContract]
        List<estudiante> recuperarEstudiantesTutor(int idTutor);

        [OperationContract]
        List<tutoria> recuperarTutoriasPeriodo(int idPeriodo);

        [OperationContract]
        List<estudiante> recuperarEstudiantesMatricula(string matricula);

        //ok

        [OperationContract]
        Boolean RegistrarAcademico(academico academicoRegistro);

        [OperationContract]
        Boolean BuscarAcademico(int numeroEmpleado);

        [OperationContract]
        Boolean RegistrarEstudiante(estudiante estudianteRegistro);

        [OperationContract]
        Boolean RegistrarExperienciaEducativa(experienciaeducativa experienciaeducativa);

        [OperationContract]
        ObservableCollection<academico> ObtenerAcademicos();

        [OperationContract]
        List<estudiante> ObtenerEstudiantes();

        [OperationContract]
        Boolean BuscarEstudiante(string matricula);

        [OperationContract]
        estudiante RecuperarEstudiante(string matricula);

        [OperationContract]
        academico RecuperarAcademico(int numeroempleado);

        [OperationContract]
        Boolean BuscarExperienciaEducativa(int nrc);

        [OperationContract]
        Boolean RegistrarProgramaEducativo(string nombre, string codigo);

        [OperationContract]
        Boolean BuscarProgramaEducativo(string codigo);

        [OperationContract]
        Boolean ActualizarEstudiante(string matricula, int tutor);

        [OperationContract]
        periodoescolar recuperarPeriodosEscolaresId(int idPeriodo);
    }
}
