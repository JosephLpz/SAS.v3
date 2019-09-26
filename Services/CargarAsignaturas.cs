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


        public void procesarCargaDatos(string archivo, string NombreHoja,string carrera)
        {

            Log.Info("Inicio proceso archivo[" + archivo + "]");
            UtilExcel utlXls = new UtilExcel();
            UtilExcelGetColor utlXlsColor = new UtilExcelGetColor();
            CountColumns ContadorDeColumnas = new CountColumns();
            string path = "C:\\Program Files\\CargaExcel\\" + archivo;

            
            if (utlXls.init(path, NombreHoja))
            {

                int filaAsignatura = 8;
                int fila = 9;
                bool continuar = true;
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
                    RequisitosAsignatura requisitosAsignatura = new RequisitosAsignatura();
                    //PorcentajeDeExigencia porcentaje = new PorcentajeDeExigencia();

                    List<string> ListaColumnas = ContadorDeColumnas.GetHeadColumn(utlXlsColor.getCountColumn(path));
                    //Ingreso anio
                    anio.Ano = utlXls.getCellValue(string.Concat(ListaColumnas[2],fila));
                    anio = ingreso.CrearAnio(anio);

                    // Ingreso persona

                    //string rut= utlXls.getCellValue(ListaColumnas[2]).Remove(utlXls.getCellValue(ListaColumnas[2]).Length - 1);
                    string RutCompleto=utlXls.getCellValue(string.Concat(ListaColumnas[3], fila));
                    string rut = RutCompleto.Remove(RutCompleto.Length - 1);
                    string Dv= RutCompleto.Substring(RutCompleto.Length - 1, 1);


                    persona.Rut = rut;
                    persona.Dv = Dv;
                    persona.Nombre = utlXls.getCellValue(string.Concat(ListaColumnas[4], fila));
                    persona.ApPaterno = utlXls.getCellValue(string.Concat(ListaColumnas[5], fila));
                    persona.ApMaterno = utlXls.getCellValue(string.Concat(ListaColumnas[6], fila));
                    persona = ingreso.CrearPersona(persona,1);

                    //alumno.CursoNivel = "5 anio";
                    alumno.Observaciones = "";
                    centro.CentroFormadorId = 1;
                    //inmunizacion = ingreso.CrearInmunizacion(inmunizacion.NombreInmunizacion);
                    nombreCentro.NombreCentroFormador1 = "Universidad de Viña del Mar";
                    nombreCentro = ingreso.CrearNombreCentroFormador(nombreCentro.NombreCentroFormador1,1);
                    carreras = ingreso.CrearCarrera(carrera, 1);
                    centro = ingreso.CrearCentroFormador(nombreCentro.NombreCentroFormadorId, carreras.CarreraId);
                    alumno = ingreso.CrearAlumno(persona, alumno, centro, 0);
                    // porcentaje.Porcentaje = 20;
                    // porcentaje = ingreso.CrearPorcentajeDeExigencia(porcentaje, 1);

                    for (int i = 7; i < ListaColumnas.Count(); i++)
                    {

                        int[] color = utlXlsColor.getColorCell(path, ListaColumnas[i].ToString() + fila.ToString(), NombreHoja);
                        string ValorCelda = utlXls.getCellValue(string.Concat(ListaColumnas[i], fila));
                        asignatura = new Asignatura();
                        asignatura.NombreAsignatura = utlXls.getCellValue(string.Concat(ListaColumnas[i], filaAsignatura));
                        asignatura = ingreso.CrearAsignatura(asignatura, 1);

                        semestre = new Semestre();
                        semestre.NombreSemestre = utlXls.getCellValue(string.Concat(ListaColumnas[i], 7));
                        semestre = ingreso.CrearSemestre(semestre);

                         
                         
                        requisitosAsignatura.SemestreId = semestre.Id;
                        requisitosAsignatura.AsignaturaId = asignatura.Id;
                        requisitosAsignatura = ingreso.BuscarReqAsignatura(requisitosAsignatura);

                        planEstudio.RequisitosAsignaturaId = requisitosAsignatura.Id;
                        planEstudio.CarreraCarreraId = carreras.CarreraId;

                        planEstudio = ingreso.BuscarPlanEstudio(planEstudio);

                         planAlumno.AlumnoAlumnoId = alumno.AlumnoId;
                        planAlumno.PlanDeEstudioId = planEstudio.Id;
                           

                     

                        
                          if (colores.Amarillo[0] == color[0] && colores.Amarillo[1] == color[1] && colores.Amarillo[2] == color[2] &&
                              colores.Amarillo[3] == color[3] && ValorCelda=="")
                          {
                            planAlumno.EstadoAsignatura = EstadoAsignatura.Aprobado;
                          }else if (colores.Amarillo[0] == color[0]&& colores.Amarillo[1] == color[1] && colores.Amarillo[2] == color[2] && 
                              colores.Amarillo[3] == color[3] && ValorCelda == "2")
                          {
                            planAlumno.EstadoAsignatura = EstadoAsignatura.AprobadoEnSegunda;
                          }else if (colores.Amarillo == color && ValorCelda == "3")
                          {
                            planAlumno.EstadoAsignatura = EstadoAsignatura.AprobadoEnTercera;
                          }
                          else if (colores.Amarillo == color && ValorCelda == "4")
                          {
                            planAlumno.EstadoAsignatura = EstadoAsignatura.AprobadoEnCuarta;
                          }
                          else if (colores.Azul==color&&ValorCelda==null)
                          {
                            planAlumno.EstadoAsignatura = EstadoAsignatura.Cursando;
                          }
                          else if (colores.Azul == color && ValorCelda == "2")
                          {
                            planAlumno.EstadoAsignatura = EstadoAsignatura.CursandoEnSegunda;
                          }
                          else if (colores.Azul == color && ValorCelda == "3")
                          {
                            planAlumno.EstadoAsignatura = EstadoAsignatura.CursandoEnTercera;
                          }
                          else if (colores.Azul == color && ValorCelda == "4")
                          {
                            planAlumno.EstadoAsignatura = EstadoAsignatura.CursandoEnCuarta;
                          }
                          else if (colores.Blanco == color && ValorCelda == null)
                          {
                            planAlumno.EstadoAsignatura = EstadoAsignatura.NoCursado;
                          }
                          else if (colores.Blanco == color && ValorCelda == "1")
                          {
                            planAlumno.EstadoAsignatura = EstadoAsignatura.ReprobadoYNoInscrito;
                          }
                          else if (colores.Blanco == color && ValorCelda == "2")
                          {
                            planAlumno.EstadoAsignatura = EstadoAsignatura.ReprobadoYNoInscritoSegunda;
                          }
                          else if (colores.Blanco == color && ValorCelda == "3")
                          {
                            planAlumno.EstadoAsignatura = EstadoAsignatura.ReprobadoYNoInscritoTercera;
                          }

                        planAlumno = ingreso.CrearPlanEstudioAlumno(planAlumno);
                         // AsAlumno = ingreso.CrearAsignaturaAlumnos(AsAlumno,1);
                      }
                    
                    fila++;
                }
            }
        }
    }
}