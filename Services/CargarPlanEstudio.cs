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
    public class CargarPlanEstudio
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(IngresoServices));


        public bool procesarCargaDatos(string archivo, string carrera,string anio,string NombreHoja)
        {

            Log.Info("Inicio proceso archivo[" + archivo + "]");
            UtilExcel utlXls = new UtilExcel();
            UtilExcelGetColor utlXlsColor = new UtilExcelGetColor();
            CountColumns ContadorDeColumnas = new CountColumns();
            string path = "C:\\Program Files\\CargaExcel\\" + archivo;
            IngresoServices ingreso = new IngresoServices();
            bool continuar = false;
            if (utlXls.init(path, NombreHoja))
            {
                
             
                int fila = 8;
                continuar = true;
                while (continuar)
                {
                    Asignatura asignaturas = new Asignatura();
                    Semestre semestres = new Semestre();
                    PlanDeEstudio planEstudios = new PlanDeEstudio();
                    UtilNumber number = new UtilNumber();
                   // RequisitosAsignatura reqAsignaturas = new RequisitosAsignatura();
                    Carrera carreras = new Carrera();
                    Anio anios = new Anio();

                    string semestre= utlXls.getCellValue(string.Format("B{0}", fila));
                    if (!number.IsNumeric(semestre))
                    {
                        semestre = null;
                    }
                    if (semestre !=null&&!semestre.Equals(string.Empty))
                    {
                       // string codigoAsignatura= utlXls.getCellValue(string.Format("D{0}", fila));

                        string asignatura = utlXls.getCellValue(string.Format("C{0}", fila));

                        

                        string catedra = utlXls.getCellValue(string.Format("E{0}", fila));
                        if (catedra == "")
                        {
                            catedra = "0";
                        }

                        string taller = utlXls.getCellValue(string.Format("F{0}", fila));

                        if (taller == "")
                        {
                            taller = "0";
                        }
                        string laboratorio= utlXls.getCellValue(string.Format("G{0}", fila));

                        if (laboratorio == "")
                        {
                            laboratorio = "0";
                        }

                        string PracticaCurricular= utlXls.getCellValue(string.Format("H{0}", fila));

                        string SCT= utlXls.getCellValue(string.Format("I{0}", fila));

                        string asignaturaRequisito= utlXls.getCellValue(string.Format("J{0}", fila));
                        

                        string UD =  (Int32.Parse(catedra)+Int32.Parse(taller)+Int32.Parse(laboratorio)).ToString() ;

                        //string aula= utlXls.getCellValue(string.Format("G{0}", fila));




                        #region ingreso semestre
                        semestres.NombreSemestre = semestre;

                        semestres = ingreso.CrearSemestre(semestres);
                        #endregion

                        #region ingreso asignatura
                        asignaturas.CodigoAsignatura = "";
                        asignaturas.NombreAsignatura = asignatura;
                        asignaturas = ingreso.CrearAsignatura(asignaturas, 1);
                        #endregion

                        //#region ingreso requerisitoss asignatura
                        //reqAsignaturas.AsignaturaId = asignaturas.Id;
                        //reqAsignaturas.PorcentajeReprobacion = "";
                        //reqAsignaturas.AsignaturaPreRequisito = asignaturaRequisito;
                        //reqAsignaturas.SemestreId = semestres.Id;

                        //reqAsignaturas = ingreso.CrearReqAsignatura(reqAsignaturas);
                        //#endregion


                        #region ingreso Carrera
                        carreras.NombreCarrera = carrera;
                        carreras = ingreso.CrearCarrera(carrera, 1);
                        #endregion

                        #region crear anio

                        anios.Ano = anio;
                        anios = ingreso.CrearAnio(anios);
                        #endregion

                        #region ingreso plan de estudios

                        //planEstudios.RequisitosAsignaturaId = reqAsignaturas.Id;
                        planEstudios.AsignaturaId = asignaturas.Id;
                        planEstudios.PorcentajeReprobacion = "0";
                        planEstudios.AsignaturaPreRequisito = asignaturaRequisito;
                        planEstudios.SemestreId = semestres.Id;
                        planEstudios.CarreraCarreraId = carreras.CarreraId;
                        planEstudios.AnioId = anios.Id;
                        planEstudios.UD = UD;
                        planEstudios.Catedra = catedra;
                        planEstudios.Taller = taller;
                        planEstudios.LAB = laboratorio;
                        planEstudios.PC = PracticaCurricular;
                        planEstudios.SCT =SCT;
                        planEstudios.Materia = "";
                        planEstudios.Curso = "";

                        planEstudios = ingreso.CrearPlanEstudio(planEstudios);
                        #endregion 

                        fila++;
                    }

                    else { continuar = false; }
                   
                }
                 

            }
            return continuar;
        }
    }
}