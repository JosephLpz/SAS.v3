using log4net;
using SAS.v1.ClasesNP;
using SAS.v1.Models;
using SAS.v1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPedigree.Utiles;

namespace SAS.v1.Services
{
    public class CargarAsignaturas
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(IngresoServices));


        public bool procesarCargaDatos(string archivo, string NombreHoja,string carrera)
        {

            Log.Info("Inicio proceso archivo[" + archivo + "]");
            UtilExcel utlXls = new UtilExcel();
            UtilExcelGetColor utlXlsColor = new UtilExcelGetColor();
            CountColumns ContadorDeColumnas = new CountColumns();
            string path = "C:\\Program Files\\CargaExcel\\" + archivo;
            bool continuar=false;


            if (utlXls.init(path, NombreHoja))
            {

                int filaAsignatura = 6;
                int fila = 7;
                int filaSemestre = 5;
                continuar = true;
                while (continuar)
                {
                    //Objetos que se utilizaran apra guardar informacion de excel
                    Persona persona = new Persona();
                    Alumno alumno = new Alumno();
                   // AsignaturaAlumno AsAlumno = new AsignaturaAlumno();
                    Carrera carreras = new Carrera();
                    Asignatura asignatura = new Asignatura();
                    Semestre semestre = new Semestre();
                    Anio anio = new Anio();
                    Inmunizacion inmunizacion = new Inmunizacion();
                    CentroFormador centro = new CentroFormador();
                    IngresoServices ingreso = new IngresoServices();
                    ColoresNP colores = new ColoresNP();
                    NombreCentroFormador nombreCentro = new NombreCentroFormador();
                    PlanEstudioAlumno planAlumno = new PlanEstudioAlumno();
                    PlanDeEstudio planEstudio = new PlanDeEstudio();
                    UtilNumber number = new UtilNumber();
                    // RequisitosAsignatura requisitosAsignatura = new RequisitosAsignatura();
                    //PorcentajeDeExigencia porcentaje = new PorcentajeDeExigencia();

                    List<string> ListaColumnas = ContadorDeColumnas.GetHeadColumn(utlXlsColor.getCountColumn(path));
                    //Ingreso anio
                    anio.Ano = utlXls.getCellValue(string.Concat(ListaColumnas[1],fila));

                    if (anio.Ano != null && !anio.Ano.Equals(string.Empty))
                    {

                        if (number.IsNumeric(anio.Ano))
                        {

                        
                        anio = ingreso.CrearAnio(anio);

                        // Ingreso persona

                        //string rut= utlXls.getCellValue(ListaColumnas[2]).Remove(utlXls.getCellValue(ListaColumnas[2]).Length - 1);
                        string RutCompleto = utlXls.getCellValue(string.Concat(ListaColumnas[4], fila));
                        string rut = RutCompleto.Remove(RutCompleto.Length - 1);
                        string Dv = RutCompleto.Substring(RutCompleto.Length - 1, 1);


                        persona.Rut = rut;
                        persona.Dv = Dv;
                        string NombreCompleto= utlXls.getCellValue(string.Concat(ListaColumnas[5], fila));
                        string[] NombreCompletoSeparado = NombreCompleto.Split(' ', '/');
                           
                        persona.Nombre =NombreCompletoSeparado[0];
                        persona.ApPaterno = NombreCompletoSeparado[2];
                        persona.ApMaterno = NombreCompletoSeparado[3];

                        //Comento esto dependiendo del formato de excel
                        //persona.Nombre = utlXls.getCellValue(string.Concat(ListaColumnas[6], fila));
                        //persona.ApPaterno = utlXls.getCellValue(string.Concat(ListaColumnas[5], fila));
                        //persona.ApMaterno = utlXls.getCellValue(string.Concat(ListaColumnas[6], fila));
                        persona = ingreso.CrearPersona(persona, 1);

                        //alumno.CursoNivel = "5 anio";
                        alumno.Observaciones = "";
                        alumno.SituacionAlumno= utlXls.getCellValue(string.Concat(ListaColumnas[7], fila));
                        //inmunizacion = ingreso.CrearInmunizacion(inmunizacion.NombreInmunizacion);
                        nombreCentro.NombreCentroFormador1 = "Universidad de Viña del Mar";
                        nombreCentro = ingreso.CrearNombreCentroFormador(nombreCentro.NombreCentroFormador1, 1);
                        carreras = ingreso.CrearCarrera(carrera, 1);
                        alumno = ingreso.CrearAlumno(persona, alumno, centro, 0);

                        centro = ingreso.CrearCentroFormador(nombreCentro.NombreCentroFormadorId, carreras.CarreraId,anio.Id,1);
                        
                        // porcentaje.Porcentaje = 20;
                        // porcentaje = ingreso.CrearPorcentajeDeExigencia(porcentaje, 1);

                        for (int i = 8; i < ListaColumnas.Count(); i++)
                        {

                            int[] color = utlXlsColor.getColorCell(path, ListaColumnas[i].ToString() + fila.ToString(), NombreHoja);
                            string ValorCelda = utlXls.getCellValue(string.Concat(ListaColumnas[i], fila));
                            asignatura = new Asignatura();
                            asignatura.NombreAsignatura = utlXls.getCellValue(string.Concat(ListaColumnas[i], filaAsignatura));
                            asignatura.NombreAsignatura = asignatura.NombreAsignatura.Replace("*", "").Replace("(", "").Replace(")", "");
                            asignatura = ingreso.CrearAsignatura(asignatura, 1);

                            semestre = new Semestre();
                            semestre.NombreSemestre = utlXls.getCellValue(string.Concat(ListaColumnas[i], filaSemestre));
                            semestre = ingreso.CrearSemestre(semestre);

                            planEstudio = new PlanDeEstudio();
                            planEstudio.AsignaturaId = asignatura.Id;
                            planEstudio.SemestreId = semestre.Id;
                            planEstudio.CarreraCarreraId = carreras.CarreraId;
                            planEstudio.AnioId = anio.Id;
                            planEstudio = ingreso.BuscarPlanEstudio(planEstudio);

                            planAlumno.AlumnoAlumnoId = alumno.AlumnoId;
                            planAlumno.PlanDeEstudioId = planEstudio.Id;

                                if (ListaColumnas[i] == "A")
                                {
                                    planAlumno.EstadoAsignatura = EstadoAsignatura.Aprobado;
                                }
                                else if (ListaColumnas[i] == "A2")
                                {
                                    planAlumno.EstadoAsignatura = EstadoAsignatura.AprobadoEnSegunda;
                                }
                                else if (ListaColumnas[i] == "A3")
                                {
                                    planAlumno.EstadoAsignatura = EstadoAsignatura.AprobadoEnTercera;
                                }
                                else if (ListaColumnas[i] == "A4")
                                {
                                    planAlumno.EstadoAsignatura = EstadoAsignatura.AprobadoEnCuarta;
                                }
                                else if (ListaColumnas[i] == "C")
                                {
                                    planAlumno.EstadoAsignatura = EstadoAsignatura.Cursando;
                                }
                                else if (ListaColumnas[i] == "C2")
                                {
                                    planAlumno.EstadoAsignatura = EstadoAsignatura.CursandoEnSegunda;
                                }
                                else if (ListaColumnas[i] == "C3")
                                {
                                    planAlumno.EstadoAsignatura = EstadoAsignatura.CursandoEnTercera;
                                }
                                else if (ListaColumnas[i] == "C4")
                                {
                                    planAlumno.EstadoAsignatura = EstadoAsignatura.CursandoEnCuarta;
                                }
                                else if (ListaColumnas[i] == "" || ListaColumnas[i] == " " || ListaColumnas[i] == null)
                                {
                                    planAlumno.EstadoAsignatura = EstadoAsignatura.NoCursado;
                                }
                                else if (ListaColumnas[i] == "R")
                                {
                                    planAlumno.EstadoAsignatura = EstadoAsignatura.ReprobadoYNoInscrito;
                                }
                                else if (ListaColumnas[i] == "R2")
                                {
                                    planAlumno.EstadoAsignatura = EstadoAsignatura.ReprobadoYNoInscritoSegunda;
                                }
                                else if (ListaColumnas[i] == "R3")
                                {
                                    planAlumno.EstadoAsignatura = EstadoAsignatura.ReprobadoYNoInscritoTercera;
                                }

                                //if (colores.Amarillo[0] == color[0] && colores.Amarillo[1] == color[1] && colores.Amarillo[2] == color[2] &&
                                //    colores.Amarillo[3] == color[3] && ValorCelda == "")
                                //{
                                //    planAlumno.EstadoAsignatura = EstadoAsignatura.Aprobado;
                                //}
                                //else if (colores.Amarillo[0] == color[0] && colores.Amarillo[1] == color[1] && colores.Amarillo[2] == color[2] &&
                                //   colores.Amarillo[3] == color[3] && ValorCelda == "2")
                                //{
                                //    planAlumno.EstadoAsignatura = EstadoAsignatura.AprobadoEnSegunda;
                                //}
                                //else if (colores.Amarillo[0] == color[0] && colores.Amarillo[1] == color[1] && colores.Amarillo[2] == color[2] &&
                                //   colores.Amarillo[3] == color[3] && ValorCelda == "3")
                                //{
                                //    planAlumno.EstadoAsignatura = EstadoAsignatura.AprobadoEnTercera;
                                //}
                                //else if (colores.Amarillo[0] == color[0] && colores.Amarillo[1] == color[1] && colores.Amarillo[2] == color[2] &&
                                //    colores.Amarillo[3] == color[3] && ValorCelda == "4")
                                //{
                                //    planAlumno.EstadoAsignatura = EstadoAsignatura.AprobadoEnCuarta;
                                //}
                                //else if (colores.Azul[0] == color[0] && colores.Azul[1] == color[1] && colores.Azul[2] == color[2] &&
                                //    colores.Azul[3] == color[3] && ValorCelda == "")
                                //{
                                //    planAlumno.EstadoAsignatura = EstadoAsignatura.Cursando;
                                //}
                                //else if (colores.Azul[0] == color[0] && colores.Azul[1] == color[1] && colores.Azul[2] == color[2] &&
                                //    colores.Azul[3] == color[3] && ValorCelda == "2")
                                //{
                                //    planAlumno.EstadoAsignatura = EstadoAsignatura.CursandoEnSegunda;
                                //}
                                //else if (colores.Azul[0] == color[0] && colores.Azul[1] == color[1] && colores.Azul[2] == color[2] &&
                                //    colores.Azul[3] == color[3] && ValorCelda == "3")
                                //{
                                //    planAlumno.EstadoAsignatura = EstadoAsignatura.CursandoEnTercera;
                                //}
                                //else if (colores.Azul[0] == color[0] && colores.Azul[1] == color[1] && colores.Azul[2] == color[2] &&
                                //    colores.Azul[3] == color[3] && ValorCelda == "4")
                                //{
                                //    planAlumno.EstadoAsignatura = EstadoAsignatura.CursandoEnCuarta;
                                //}
                                //else if (colores.Blanco[1] == color[1] && colores.Blanco[2] == color[2] &&
                                //    colores.Blanco[3] == color[3] && ValorCelda == "")
                                //{
                                //    planAlumno.EstadoAsignatura = EstadoAsignatura.NoCursado;
                                //}
                                //else if (colores.Blanco[1] == color[1] && colores.Blanco[2] == color[2] &&
                                //    colores.Blanco[3] == color[3] && ValorCelda == "1")
                                //{
                                //    planAlumno.EstadoAsignatura = EstadoAsignatura.ReprobadoYNoInscrito;
                                //}
                                //else if (colores.Blanco[1] == color[1] && colores.Blanco[2] == color[2] &&
                                //    colores.Blanco[3] == color[3] && ValorCelda == "2")
                                //{
                                //    planAlumno.EstadoAsignatura = EstadoAsignatura.ReprobadoYNoInscritoSegunda;
                                //}
                                //else if (colores.Blanco[1] == color[1] && colores.Blanco[2] == color[2] &&
                                //    colores.Blanco[3] == color[3] && ValorCelda == "3")
                                //{
                                //    planAlumno.EstadoAsignatura = EstadoAsignatura.ReprobadoYNoInscritoTercera;
                                //}

                                planAlumno = ingreso.CrearPlanEstudioAlumno(planAlumno, 1);
                            // AsAlumno = ingreso.CrearAsignaturaAlumnos(AsAlumno,1);


                                 }

                            }
                        fila++;       
                        }
                    else
                            {
                                continuar = false;
                            }
                    
                }    
            }
            return continuar;
        }
    }
}