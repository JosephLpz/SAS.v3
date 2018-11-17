using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using WebPedigree.Utiles;
using SAS.v1.Models;

namespace SAS.v1.Services
{
    public class CargaDatosServices
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(IngresoServices));

        
        public void procesarCargaDatos(string archivo)
        {
            Log.Info("Inicio proceso archivo[" + archivo + "]");
            UtilExcel utlXls = new UtilExcel();
            string path = System.Web.HttpContext.Current.Server.MapPath("~") + "\\Archivos\\" + archivo;
            if (utlXls.init(path, "Ordenado"))
            {

                int fila = 5;
                bool continuar = true;
                while (continuar)
                {
                    //Crear Objetos
                    Persona personaAlumno = new Persona();
                    Persona personaDocenteGuia = new Persona();
                    Persona personaSupervisor = new Persona();
                    Alumno Alumn = new Alumno();
                ProfesionalSupervisor Supervisor = new ProfesionalSupervisor();
                UnidadDeServicio UServicio = new UnidadDeServicio();
                Inmunizacion inmun = new Inmunizacion();
                CentroFormador CentroF = new CentroFormador();
                NombreCentroFormador NCentroF = new NombreCentroFormador();
                Carrera Carr = new Carrera();
                Periodo Per = new Periodo();
                NombreJornada Njornada = new NombreJornada();
                Dias dia = new Dias();
                DocenciaHospitalaria DocHospitalaria = new DocenciaHospitalaria();
                Institucion institucion = new Institucion();
                NombreCampoClinico NCampo = new NombreCampoClinico();
                CampoClinico Campo = new CampoClinico();
                NombreUnidadDeServicio NUnidadDeServicio = new NombreUnidadDeServicio();
                CampoClinicoAlumno CampoAlumnos = new CampoClinicoAlumno();
                IngresoServices ingreso = new IngresoServices();



                    string CentroFormador = utlXls.getCellValue(string.Format("B{0}", fila));
                    if (CentroFormador != null && !CentroFormador.Equals(string.Empty))
                    {
                        //capturando Carrera
                        string Carrera = utlXls.getCellValue(string.Format("C{0}", fila));

                        //Institucion
                        string Institucion = utlXls.getCellValue(string.Format("D{0}", fila));

                        //Campo Clinico
                        string NombCampoClinico = utlXls.getCellValue(string.Format("E{0}", fila));

                        //Unidad de servicio
                        string UnidadServicio = utlXls.getCellValue(string.Format("F{0}", fila));

                        //Rut Alumno
                        string RutAlumno = utlXls.getCellValue(string.Format("G{0}", fila));

                        //DV-Alumno
                        string DvAlumno = utlXls.getCellValue(string.Format("H{0}", fila));

                        //ApellidoAlumno
                        string ApellidoPaAlumno = utlXls.getCellValue(string.Format("I{0}", fila));

                        //ApellidoMaternoAlumno
                        string ApellidoMaAlumno = utlXls.getCellValue(string.Format("J{0}", fila));

                        //Nombre alumno
                        string NombreAlumno = utlXls.getCellValue(string.Format("K{0}", fila));

                        //Curso/nivel alumno
                        string CursoNivel = utlXls.getCellValue(string.Format("L{0}", fila));

                        //Fecha Inicio 
                        DateTime FechaInicio = DateTime.Parse(utlXls.getCellValue(string.Format("M{0}", fila)) + "-" + utlXls.getCellValue(string.Format("N{0}", fila)) + "-" + utlXls.getCellValue(string.Format("O{0}", fila)));

                        //Fecha termino
                        DateTime FechaTermino = DateTime.Parse(utlXls.getCellValue(string.Format("P{0}", fila)) + "-" + utlXls.getCellValue(string.Format("Q{0}", fila)) + "-" + utlXls.getCellValue(string.Format("R{0}", fila)));

                        //Nombre Jornada 
                        string NombreJornada = utlXls.getCellValue(string.Format("S{0}", fila));

                        //Dia lunes
                        string lunes = utlXls.getCellValue(string.Format("T{0}", fila));

                        //Dia Martes
                        string Martes = utlXls.getCellValue(string.Format("U{0}", fila));

                        //Dia Miercoles
                        string Miercoles = utlXls.getCellValue(string.Format("V{0}", fila));

                        //Dia Jueves
                        string Jueves = utlXls.getCellValue(string.Format("W{0}", fila));

                        //Dia Viernes
                        string Viernes = utlXls.getCellValue(string.Format("X{0}", fila));

                        //Dia Sabado
                        string Sabado = utlXls.getCellValue(string.Format("Y{0}", fila));

                        //Dia Domingo
                        string Domingo = utlXls.getCellValue(string.Format("Z{0}", fila));


                        //falta la jornada tipo 2

                        //Inmunizaciones 
                        string Inmunizaciones = utlXls.getCellValue(string.Format("AI{0}", fila));

                        //Docencia Hospitalaria
                        string DocenciaHospitalaria = utlXls.getCellValue(string.Format("AJ{0}", fila));

                        //Rut Docente Guia
                        string RutDocenteGuia = utlXls.getCellValue(string.Format("AK{0}", fila));

                        //DV-Profesional docente guia
                        string DvProfesionalDocenteGuia = utlXls.getCellValue(string.Format("AL{0}", fila));

                        //Apellido paterno Profesional docente guia
                        string ApPaternoDocenteGuia = utlXls.getCellValue(string.Format("AM{0}", fila));

                        //Apellido Materno Profesional docente guia
                        string ApMaternoDocenteGuia = utlXls.getCellValue(string.Format("AN{0}", fila));

                        //Nombre Profresional docente guia
                        string NombreProfesionalDocenteGuia = utlXls.getCellValue(string.Format("AO{0}", fila));

                        //Profesion Docente guia
                        string ProfesionDocenteGuia = utlXls.getCellValue(string.Format("AP{0}", fila));

                        //n° Registro superintendencia de prestadores
                        string Nregistro = utlXls.getCellValue(string.Format("AQ{0}", fila));

                        //Telefono docente guia
                        string TelefonoDocenteGuia = utlXls.getCellValue(string.Format("AR{0}", fila));

                        //Correo Docente Guia
                        string CorreoDocenteGuia = utlXls.getCellValue(string.Format("AS{0}", fila));

                        //Inmunización docente guia
                        string InmunizacionDocenteGuia = utlXls.getCellValue(string.Format("AT{0}", fila));

                        //RutProfesionalSpuervisor
                        string RutProfesionalSupervisor = utlXls.getCellValue(string.Format("AU{0}", fila));

                        //Dv Profesional supervisor
                        string DvProfesionalSupervisor = utlXls.getCellValue(string.Format("AV{0}", fila));

                        //Apellido paterno profesional supervisor
                        string ApPaternoProfesionalSupervisor = utlXls.getCellValue(string.Format("AW{0}", fila));

                        //Apellido Materno profesional supervisor
                        string ApMaternoProfesionalSupervisor = utlXls.getCellValue(string.Format("AX{0}", fila));

                        //Nombre Profesiona Supervisor
                        string NombreProfesionalSupervisor = utlXls.getCellValue(string.Format("AY{0}", fila));

                        //Valor profesional supervisor
                        string ValorProfesionalSupervisor = utlXls.getCellValue(string.Format("AZ{0}", fila));

                        //Observaciones profesional supervisor
                        string ObservacionesProfesionalSupervisor = utlXls.getCellValue(string.Format("BA{0}", fila));

                        //Ingreso de datos
                        #region Alumno
                        //crear Nombre Centro Formador
                        NCentroF = ingreso.CrearNombreCentroFormador(CentroFormador);

                        //Crear inmunización
                        inmun = ingreso.CrearInmunizacion(Inmunizaciones);

                        //Crear Carrea
                        Carr = ingreso.CrearCarrera(Carrera);

                        //crear Centro formador
                        CentroF = ingreso.CrearCentroFormador(NCentroF.NombreCentroFormadorId, Carr.CarreraId);



                        //Ingreso Persona Alumno 
                        personaAlumno.Rut = RutAlumno;
                        personaAlumno.Dv = DvAlumno;
                        personaAlumno.Nombre = NombreAlumno;
                        personaAlumno.ApPaterno = ApellidoPaAlumno;
                        personaAlumno.ApMaterno = ApellidoMaAlumno;
                        Alumn.CursoNivel = CursoNivel;

                        // personAlumno=ingreso.CrearPersona(personAlumno);
                        personaAlumno = ingreso.CrearPersona(personaAlumno);
                        Alumn = ingreso.CrearAlumno(personaAlumno,Alumn, inmun, CentroF);
                        #endregion


                        #region Jornada
                        //Jornada

                        //Periodo 
                        Per.FechaInicio = FechaInicio;
                        Per.FechaTermino = FechaTermino;
                        

                        //NombreJornada
                        Njornada.Nombre = NombreJornada;
                        Njornada = ingreso.crearNombreJornada(Njornada);
                        Per = ingreso.CrearPeriodos(Per,Njornada);
                        //Dias
                        string[] dias = new string[7];
                        dias[0] = lunes;
                        dias[1] = Martes;
                        dias[2] = Miercoles;
                        dias[3] = Jueves;
                        dias[4] = Viernes;
                        dias[5] = Sabado;
                        dias[6] = Domingo;

                        List<Dias> Listdia = ingreso.CrearDias();

                       /* //Jornada
                        Jor = ingreso.CrearJornada(Njornada, Per, Alumn);


                        //JornadaDias 
                        Jdias = ingreso.crearJornadaDias(Jor, dia, dias);*/


                        #endregion

                        #region ProfesionalDocenteGuia

                        //Capturar inmunizacion docente guia
                        inmun = ingreso.CrearInmunizacion(InmunizacionDocenteGuia);
                        //Capturar docencia hospitalaria
                        DocHospitalaria = ingreso.CrearDocenciaHospitalaria(DocenciaHospitalaria);
                        //Capturar datos  Persona docente guia
                        ProfesionalDocenteGuia DocenteGuia = new ProfesionalDocenteGuia();

                        personaDocenteGuia.Rut = RutDocenteGuia;
                        personaDocenteGuia.Dv = DvProfesionalDocenteGuia;
                        personaDocenteGuia.Nombre = NombreProfesionalDocenteGuia;
                        personaDocenteGuia.ApPaterno = ApPaternoDocenteGuia;
                        personaDocenteGuia.ApMaterno = ApMaternoDocenteGuia;
                        //Capturar datos profesional docnete guia
                        DocenteGuia.Profesion = ProfesionDocenteGuia;
                        DocenteGuia.NumeroSuperintendencia = Int32.Parse(Nregistro);
                        DocenteGuia.Telefono = Int64.Parse(TelefonoDocenteGuia);
                        DocenteGuia.Correo = CorreoDocenteGuia;
                        DocenteGuia.ValorDocente = 0;
                        personaDocenteGuia = ingreso.CrearPersona(personaDocenteGuia);
                        DocenteGuia = ingreso.CrearProfesionalDocenteGuia(personaDocenteGuia,DocenteGuia, inmun, DocHospitalaria);

                        #endregion

                        //if (DocenteGuia == null)
                        //{
                        //    DocenteGuia = new ProfesionalDocenteGuia();
                        //    DocenteGuia.Rut = RutDocenteGuia;
                        //    DocenteGuia.Dv = DvProfesionalDocenteGuia;
                        //    DocenteGuia.Nombre = NombreProfesionalDocenteGuia;
                        //    DocenteGuia.ApPaterno = ApPaternoDocenteGuia;
                        //    DocenteGuia.ApMaterno = ApMaternoDocenteGuia;
                        //    //Capturar datos profesional docnete guia
                        //    DocenteGuia.Profesion = ProfesionDocenteGuia;
                        //    DocenteGuia.NumeroSuperintendencia = Int32.Parse(Nregistro);
                        //    DocenteGuia.Telefono = Int32.Parse(TelefonoDocenteGuia);
                        //    DocenteGuia.Correo = CorreoDocenteGuia;
                        //    DocenteGuia.ValorDocente = "";
                        //    DocenteGuia = ingreso.CrearProfesionalDocenteGuia(DocenteGuia, inmun, DocHospitalaria);
                        //}

                        #region ProfesionalSupervisor
                        personaSupervisor.Rut = RutProfesionalSupervisor;
                        personaSupervisor.Dv = DvProfesionalSupervisor;
                        personaSupervisor.Nombre = NombreProfesionalSupervisor;
                        personaSupervisor.ApPaterno = ApPaternoProfesionalSupervisor;
                        personaSupervisor.ApMaterno = ApMaternoProfesionalSupervisor;
                        Supervisor.ValorSupervisor = Int32.Parse(ValorProfesionalSupervisor);
                        Supervisor.Observaciones = "";

                        personaSupervisor = ingreso.CrearPersona(personaSupervisor);
                        Supervisor = ingreso.crearProfesionalSupervisor(personaSupervisor,Supervisor);
                        #endregion

                        //if (Supervisor == null)
                        //{
                        //    Supervisor = new ProfesionalSupervisor();
                        //    Supervisor.Rut = RutProfesionalSupervisor;
                        //    Supervisor.Dv = DvProfesionalSupervisor;
                        //    Supervisor.Nombre = NombreProfesionalSupervisor;
                        //    Supervisor.ApPaterno = ApPaternoProfesionalSupervisor;
                        //    Supervisor.ApMaterno = ApMaternoProfesionalSupervisor;
                        //    Supervisor.ValorSupervisor = Int32.Parse(ValorProfesionalSupervisor);
                        //    Supervisor.Observaciones = "";

                        //    Supervisor = ingreso.crearProfesionalSupervisor(Supervisor);
                        //}

                        #region institución
                        //institucion.NombreInstitucion = Institucion;
                        institucion = ingreso.CrearInstitucion(Institucion);
                        #endregion
                        #region NombreCampoClinico
                        NCampo = ingreso.CrearNombreCampoClinico(NombCampoClinico);
                        #endregion

                        #region CampoClinico
                        Campo = ingreso.CrearCampoClinico(NCampo,institucion);
                        #endregion

                        #region NombreUnidadDeServicio
                        NUnidadDeServicio = ingreso.CrearNombreUnidadDeServicio(UnidadServicio);
                        #endregion

                        #region UnidadDeServicio
                        UServicio = ingreso.CrearUnidadDeServicio(NUnidadDeServicio, Campo);
                        #endregion


                        #region CampoClinicosAlumnos
                        CampoAlumnos = ingreso.CrearCampoClinicoAlumno(Alumn,DocenteGuia,Supervisor,Per,UServicio);
                        #endregion


                        if (lunes.ToUpper().Trim() == "X")
                        {
                            ingreso.CrearCampoClinicoAlumnosDias(CampoAlumnos,"Lunes");
                        }
                        if (Martes.ToUpper().Trim() == "X")
                        {
                            ingreso.CrearCampoClinicoAlumnosDias(CampoAlumnos, "Martes");

                        } if(Miercoles.ToUpper().Trim() == "X")
                        {
                            ingreso.CrearCampoClinicoAlumnosDias(CampoAlumnos, "Miercoles");

                        } if(Jueves.ToUpper().Trim() == "X")
                        {
                            ingreso.CrearCampoClinicoAlumnosDias(CampoAlumnos, "Jueves");

                        } if(Viernes.ToUpper().Trim() == "X")
                        {
                            ingreso.CrearCampoClinicoAlumnosDias(CampoAlumnos, "Viernes");

                        } if(Sabado.ToUpper().Trim() == "X")
                        {
                            ingreso.CrearCampoClinicoAlumnosDias(CampoAlumnos, "Sabado");

                        } if (Domingo.ToUpper().Trim() == "X")
                        {
                            ingreso.CrearCampoClinicoAlumnosDias(CampoAlumnos, "Domingo");

                        }
                        fila++;

                    }else{ continuar = false; }
                }
            }
        }
    }
}