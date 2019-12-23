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

        
        public bool procesarCargaDatos(string archivo,string semestre, int Estado)
        {
            
                Log.Info("Inicio proceso archivo[" + archivo + "]");
                UtilExcel utlXls = new UtilExcel();
                string path = "C:\\Program Files\\CargaExcel\\" + archivo;
                bool continuar= false;
                if (utlXls.init(path, "Pregrado"))
                {

                    int fila = 5;
                     continuar = true;
                    while (continuar)
                    {
                        //Crear Objetos
                        Persona personaAlumno = new Persona();
                        Persona personaDocenteGuia = new Persona();
                        Persona personaSupervisor = new Persona();
                        Alumno Alumn = new Alumno();
                        //ProfesionalSupervisor Supervisor = new ProfesionalSupervisor();
                        // UnidadDeServicio UServicio = new UnidadDeServicio();
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
                   
                        // NombreUnidadDeServicio NUnidadDeServicio = new NombreUnidadDeServicio();
                        CampoClinicoAlumno CampoAlumnos = new CampoClinicoAlumno();
                        IngresoServices ingreso = new IngresoServices();
                        Asignatura Asignaturas = new Asignatura();
                        Semestre Semestres = new Semestre();
                        Anio Ano = new Anio();
                        InmunizacionAlumno inmunizacionAl = new InmunizacionAlumno();
                        CursoNivel curso = new CursoNivel();
                        CursoAlumno cursoAlumno = new CursoAlumno();

                        string CentroFormador = utlXls.getCellValue(string.Format("B{0}", fila));
                        if (CentroFormador != null && !CentroFormador.Equals(string.Empty))
                        {
                            //capturando Asignatura 
                            string Asignatura = utlXls.getCellValue(string.Format("A{0}", fila));
                            //capturando Carrera
                            string Carrera = utlXls.getCellValue(string.Format("C{0}", fila));
                            
                            //Institucion
                            string Institucion = utlXls.getCellValue(string.Format("D{0}", fila));

                            //Campo Clinico
                            string NombCampoClinico = utlXls.getCellValue(string.Format("E{0}", fila));

                            //Unidad de servicio
                            // string UnidadServicio = utlXls.getCellValue(string.Format("F{0}", fila));

                            //Rut Alumno
                            string RutAlumno = utlXls.getCellValue(string.Format("F{0}", fila));

                            //DV-Alumno
                            string DvAlumno = utlXls.getCellValue(string.Format("G{0}", fila));

                            //ApellidoAlumno
                            string ApellidoPaAlumno = utlXls.getCellValue(string.Format("H{0}", fila));

                            //ApellidoMaternoAlumno
                            string ApellidoMaAlumno = utlXls.getCellValue(string.Format("I{0}", fila));

                            //Nombre alumno
                            string NombreAlumno = utlXls.getCellValue(string.Format("J{0}", fila));

                            //Curso/nivel alumno
                            string CursoNivel = utlXls.getCellValue(string.Format("K{0}", fila));

                            //anio periodo
                            string anio = utlXls.getCellValue(string.Format("N{0}", fila));
                            //Fecha Inicio 
                            DateTime FechaInicio = DateTime.Parse(utlXls.getCellValue(string.Format("L{0}", fila)) + "-" + utlXls.getCellValue(string.Format("M{0}", fila)) + "-" + utlXls.getCellValue(string.Format("N{0}", fila)));

                            //Fecha termino
                            DateTime FechaTermino = DateTime.Parse(utlXls.getCellValue(string.Format("O{0}", fila)) + "-" + utlXls.getCellValue(string.Format("P{0}", fila)) + "-" + utlXls.getCellValue(string.Format("Q{0}", fila)));

                            //Nombre Jornada 
                            string NombreJornada = utlXls.getCellValue(string.Format("R{0}", fila));

                            //Dia lunes
                            string lunes = utlXls.getCellValue(string.Format("S{0}", fila));

                            //Dia Martes
                            string Martes = utlXls.getCellValue(string.Format("T{0}", fila));

                            //Dia Miercoles
                            string Miercoles = utlXls.getCellValue(string.Format("U{0}", fila));

                            //Dia Jueves
                            string Jueves = utlXls.getCellValue(string.Format("V{0}", fila));

                            //Dia Viernes
                            string Viernes = utlXls.getCellValue(string.Format("W{0}", fila));

                            //Dia Sabado
                            string Sabado = utlXls.getCellValue(string.Format("X{0}", fila));

                            //Dia Domingo
                            string Domingo = utlXls.getCellValue(string.Format("Y{0}", fila));


                            //falta la jornada tipo 2

                            //Inmunizaciones 
                            string Inmunizaciones = utlXls.getCellValue(string.Format("AP{0}", fila));

                            //Observaciones alumno                 
                            string ObservacionAlumno = utlXls.getCellValue(string.Format("AQ{0}", fila));

                            //Docencia Hospitalaria
                            string DocenciaHospitalaria = utlXls.getCellValue(string.Format("AR{0}", fila));

                            //Rut Docente Guia
                            string RutDocenteGuia = utlXls.getCellValue(string.Format("AS{0}", fila));

                            //DV-Profesional docente guia
                            string DvProfesionalDocenteGuia = utlXls.getCellValue(string.Format("AT{0}", fila));

                            //Apellido paterno Profesional docente guia
                            string ApPaternoDocenteGuia = utlXls.getCellValue(string.Format("AU{0}", fila));

                            //Apellido Materno Profesional docente guia
                            string ApMaternoDocenteGuia = utlXls.getCellValue(string.Format("AV{0}", fila));

                            //Nombre Profresional docente guia
                            string NombreProfesionalDocenteGuia = utlXls.getCellValue(string.Format("AW{0}", fila));

                            //Profesion Docente guia
                            string ProfesionDocenteGuia = utlXls.getCellValue(string.Format("AX{0}", fila));

                            //n° Registro superintendencia de prestadores
                            string Nregistro = utlXls.getCellValue(string.Format("AY{0}", fila));

                            //Telefono docente guia
                            string TelefonoDocenteGuia = utlXls.getCellValue(string.Format("AZ{0}", fila));

                            //Correo Docente Guia
                            string CorreoDocenteGuia = utlXls.getCellValue(string.Format("BA{0}", fila));

                            //Inmunización docente guia
                            string InmunizacionDocenteGuia = utlXls.getCellValue(string.Format("BB{0}", fila));

                            //Observaciones DocenteGuia 
                            string ObservacionesDocente = utlXls.getCellValue(string.Format("BC{0}", fila));

                            //cumplimiento de requisitos
                            string Cumple = utlXls.getCellValue(string.Format("BD{0}", fila));

                            //ValorDocenteGuia
                            string valorDocenteGuia = utlXls.getCellValue(string.Format("EZ{0}", fila));

                            //Observaciones pago docente
                            string ObservacionesPagoDocente = utlXls.getCellValue(string.Format("FA{0}", fila));

                            //RutProfesionalSpuervisor
                            string RutProfesionalSupervisor = utlXls.getCellValue(string.Format("FB{0}", fila));

                            //Dv Profesional supervisor
                            string DvProfesionalSupervisor = utlXls.getCellValue(string.Format("FC{0}", fila));

                            //Apellido paterno profesional supervisor
                            string ApPaternoProfesionalSupervisor = utlXls.getCellValue(string.Format("FD{0}", fila));

                            //Apellido Materno profesional supervisor
                            string ApMaternoProfesionalSupervisor = utlXls.getCellValue(string.Format("FE{0}", fila));

                            //Nombre Profesiona Supervisor
                            string NombreProfesionalSupervisor = utlXls.getCellValue(string.Format("FF{0}", fila));

                            //Valor profesional supervisor
                            string ValorProfesionalSupervisor = utlXls.getCellValue(string.Format("FG{0}", fila));

                            //Observaciones profesional supervisor
                            string ObservacionesProfesionalSupervisor = utlXls.getCellValue(string.Format("FH{0}", fila));

                            //Ingreso de datos
                            #region Alumno
                            //crear Nombre Centro Formador
                            NCentroF = ingreso.CrearNombreCentroFormador(CentroFormador ,Estado);

                            //Crear inmunización
                            inmun = ingreso.CrearInmunizacion(Inmunizaciones);

                            //Crear Carrea
                            Carr = ingreso.CrearCarrera(Carrera, Estado);


                        //buscar anio
                        #region anio
                        Ano.Ano = anio;
                        Ano = ingreso.CrearAnio(Ano);
                        #endregion

                        //crear Centro formador
                        CentroF = ingreso.CrearCentroFormador(NCentroF.NombreCentroFormadorId, Carr.CarreraId,Ano.Id,1);



                            //Ingreso Persona Alumno 
                            personaAlumno.Rut = RutAlumno;
                            personaAlumno.Dv = DvAlumno;
                            personaAlumno.Nombre = NombreAlumno;
                            personaAlumno.ApPaterno = ApellidoPaAlumno;
                            personaAlumno.ApMaterno = ApellidoMaAlumno;
                            //Alumn.CursoNivel = CursoNivel;
                            Alumn.Observaciones = ObservacionAlumno;
                        if (ObservacionAlumno == "")
                        {
                            Alumn.Observaciones = " ";
                        }
                            // personAlumno=ingreso.CrearPersona(personAlumno);
                            personaAlumno = ingreso.CrearPersona(personaAlumno,Estado);
                            
                            Alumn = ingreso.CrearAlumno(personaAlumno, Alumn, CentroF, Estado);
                        #endregion

                        #region CursoNivel
                        curso = ingreso.CrearCursoNivel(CursoNivel);
                        cursoAlumno = ingreso.CrearCursoAlumno(Alumn, curso);

                        #endregion

                        #region inmunizacion
                        // Creando inmunizacion Alumno
                        inmunizacionAl = ingreso.CrearInmunizacionAlumno(Alumn,inmun);
                        #endregion
                        #region Jornada
                        //Jornada

                        //Periodo 
                        Per.FechaInicio = FechaInicio;
                            Per.FechaTermino = FechaTermino;


                            //NombreJornada
                            Njornada.Nombre = NombreJornada;
                            Njornada = ingreso.crearNombreJornada(Njornada, Estado);
                            Per = ingreso.CrearPeriodos(Per, Njornada);
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
                            DocHospitalaria = ingreso.CrearDocenciaHospitalaria(DocenciaHospitalaria, Estado);
                            //Capturar datos  Persona docente guia
                            ProfesionalDocenteGuia DocenteGuia = new ProfesionalDocenteGuia();

                            personaDocenteGuia.Rut = RutDocenteGuia;
                            personaDocenteGuia.Dv = DvProfesionalDocenteGuia;
                            personaDocenteGuia.Nombre = NombreProfesionalDocenteGuia;
                            personaDocenteGuia.ApPaterno = ApPaternoDocenteGuia;
                            personaDocenteGuia.ApMaterno = ApMaternoDocenteGuia;
                            //Capturar datos profesional docnete guia
                            DocenteGuia.Profesion = ProfesionDocenteGuia;
                            if (Nregistro == "")
                            {
                                DocenteGuia.NumeroSuperintendencia = 0;
                            }
                            else
                            {
                                DocenteGuia.NumeroSuperintendencia = Int64.Parse(Nregistro);
                            }

                            if (TelefonoDocenteGuia == "")
                            {
                                DocenteGuia.Telefono = 0;
                            }
                            else
                            {
                            //TelefonoDocenteGuia = TelefonoDocenteGuia.Replace(" ","");
                                DocenteGuia.Telefono = Convert.ToInt64(TelefonoDocenteGuia.Trim());
                            }

                            DocenteGuia.Correo = CorreoDocenteGuia;
                            if (valorDocenteGuia == "")
                            {
                                valorDocenteGuia = "0";
                            }else if(valorDocenteGuia=="sin pago")
                            {
                            valorDocenteGuia = "0";
                            }
                            DocenteGuia.ValorDocente = Int64.Parse(valorDocenteGuia);
                            DocenteGuia.CumpleDatos = Cumple;
                            if (RutDocenteGuia == "" && DvProfesionalDocenteGuia == "" && NombreProfesionalDocenteGuia == "")
                            {
                                personaDocenteGuia.Rut = "Ninguno";
                                personaDocenteGuia.Dv = "Ninguno";
                                personaDocenteGuia.Nombre = "Ninguno";
                                personaDocenteGuia.ApPaterno = "Ninguno";
                                personaDocenteGuia.ApMaterno = "Ninguno";
                                DocenteGuia.NumeroSuperintendencia = 0;
                                DocenteGuia.Correo = "Ninguno";
                                DocenteGuia.ValorDocente = 0;

                            }
                            personaDocenteGuia = ingreso.CrearPersona(personaDocenteGuia,Estado);
                            DocenteGuia = ingreso.CrearProfesionalDocenteGuia(personaDocenteGuia, DocenteGuia, inmun, DocHospitalaria, Estado);

                            #endregion

                          
                        

                            #region ProfesionalSupervisor
                            //personaSupervisor.Rut = RutProfesionalSupervisor;
                            //personaSupervisor.Dv = DvProfesionalSupervisor;
                            //personaSupervisor.Nombre = NombreProfesionalSupervisor;
                            //personaSupervisor.ApPaterno = ApPaternoProfesionalSupervisor;
                            //personaSupervisor.ApMaterno = ApMaternoProfesionalSupervisor;
                            //if (ValorProfesionalSupervisor == "")
                            //{
                            //    Supervisor.ValorSupervisor = 0;
                            //}
                            //else
                            //{
                            //    Supervisor.ValorSupervisor = Int32.Parse(ValorProfesionalSupervisor);
                            //}

                            //Supervisor.Observaciones = ObservacionesProfesionalSupervisor;

                            //if (personaSupervisor.Rut == "" && personaSupervisor.Dv == "" && personaSupervisor.Nombre == "")
                            //{
                            //    personaSupervisor.Rut = "Ninguno";
                            //    personaSupervisor.Dv = "Ninguno";
                            //    personaSupervisor.Nombre = "Ninguno";
                            //    personaSupervisor.ApPaterno = "Ninguno";
                            //    personaSupervisor.ApMaterno = "Ninguno";
                            //    Supervisor.Observaciones = "Ninguno";
                            //}
                            //personaSupervisor = ingreso.CrearPersona(personaSupervisor,Estado);
                            //Supervisor = ingreso.crearProfesionalSupervisor(personaSupervisor, Supervisor, Estado);
                            #endregion

                           
                            #region CampoClinico
                            #region institución
                            //institucion.NombreInstitucion = Institucion;
                            institucion = ingreso.CrearInstitucion(Institucion, Estado);
                            #endregion
                            #region NombreCampoClinico
                            NCampo = ingreso.CrearNombreCampoClinico(NombCampoClinico, Estado,institucion);
                            #endregion

                            #endregion

                           

                            #region Asignatura 
                            Asignaturas.NombreAsignatura = Asignatura;
                            Asignaturas = ingreso.BuscarAsignatura(Asignaturas);
                            #endregion

                            #region Semestre 

                            Semestres.NombreSemestre = semestre;
                            Semestres = ingreso.CrearSemestre(Semestres);
                            #endregion

                           

                            #region CampoClinicosAlumnos
                            CampoAlumnos = ingreso.CrearCampoClinicoAlumno(Alumn, DocenteGuia, Per, Asignaturas, Semestres, Ano, NCampo);
                            #endregion


                            if (lunes.ToUpper().Trim() == "X")
                            {
                                ingreso.CrearCampoClinicoAlumnosDias(CampoAlumnos, "Lunes");
                            }
                            if (Martes.ToUpper().Trim() == "X")
                            {
                                ingreso.CrearCampoClinicoAlumnosDias(CampoAlumnos, "Martes");

                            }
                            if (Miercoles.ToUpper().Trim() == "X")
                            {
                                ingreso.CrearCampoClinicoAlumnosDias(CampoAlumnos, "Miercoles");

                            }
                            if (Jueves.ToUpper().Trim() == "X")
                            {
                                ingreso.CrearCampoClinicoAlumnosDias(CampoAlumnos, "Jueves");

                            }
                            if (Viernes.ToUpper().Trim() == "X")
                            {
                                ingreso.CrearCampoClinicoAlumnosDias(CampoAlumnos, "Viernes");

                            }
                            if (Sabado.ToUpper().Trim() == "X")
                            {
                                ingreso.CrearCampoClinicoAlumnosDias(CampoAlumnos, "Sabado");

                            }
                            if (Domingo.ToUpper().Trim() == "X")
                            {
                                ingreso.CrearCampoClinicoAlumnosDias(CampoAlumnos, "Domingo");

                            }
                            fila++;

                        }
                        else { continuar = false; }
                    }
                }

            return continuar;
        }
    }
}