using log4net;
using SAS.v1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPedigree.Utiles;

namespace SAS.v1.Utils
{
    public class CargaExcelPSeguimiento
    {

        private static readonly ILog Log = LogManager.GetLogger(typeof(IngresoServices));


        public void procesarCargaDatos(string archivo, string semestre, int Estado)
        {

            Log.Info("Inicio proceso archivo[" + archivo + "]");
            UtilExcel utlXls = new UtilExcel();
            string path = "C:\\Program Files\\CargaExcel\\" + archivo;
            if (utlXls.init(path, "Pregrado"))
            {

                int fila = 5;
                bool continuar = true;
                while (continuar)
                {
                    


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




                    }
                }
            }
        }
    }
}