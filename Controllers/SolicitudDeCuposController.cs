using SAS.v1.Models;
using SAS.v1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAS.v1.ClasesNP;
using System.Web.Routing;
using SAS.v1.Utils;
using Newtonsoft.Json;

namespace SAS.v1.Controllers
{
    public class SolicitudDeCuposController : Controller
    {

        private static List<SolicitudDeCuposNP> solicitudes = new List<SolicitudDeCuposNP>();

        private ModeloContainer db = new ModeloContainer();
        // GET: SolicitudDeCupos

        [HttpGet]
        public ActionResult Index(string Data)
        {
            UtilSolicitudDeCupos util = new UtilSolicitudDeCupos();
            List<DataPoint> dataPoint= new List<DataPoint>();

            if (Data==null)
            {
               ViewBag.Error= "No se ha Realizado ninguna proyeccion de cupos";
            }
            else
            {
            dataPoint = System.Web.Helpers.Json.Decode<List<DataPoint>>(Data);

            ViewBag.DataPoint = dataPoint;
            }
            ViewBag.Index = 0;
            ViewBag.CarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera");
            ViewBag.InstitucionId = new SelectList(db.Institucions, "NombreInstitucion", "NombreInstitucion");
            ViewBag.NombreJornadaId = new SelectList(db.NombreJornadas, "NombreJornadaId", "Nombre");
            ViewBag.NombreCampoId = new SelectList(db.NombreCampoClinicoSet, "NombreInstitucion", "NombreCampo");

            List<SolicitudDeCupo> solicitud = db.SolicitudDeCupos.ToList();
            List<SolicitudDeCuposNP> ListaSolicitudes = util.GetSolicitudes(dataPoint);



            return View(ListaSolicitudes);
        }

        [HttpPost]
        public ActionResult Index(string Solicitudes, string index, string DataPoint,[Bind(Include ="CarreraId,NombreCampoId,NombreServicio,CuposAlumnos,Observacion,TotalSemanaPorGrupo,FechaInicio,FechaTermino,NombreJornadaId,NombreSupervision,NombreAsignatura")]
      Carrera carrera, Servicio servicio, SolicitudDeCupo solicitudCupo, Periodo periodo, NombreJornada jornada, Supervision supervision, Asignatura asignatura,string InstitucionId,string NombreCampoId)
        {
            IngresoServices ingreso = new IngresoServices();
            CampoClinico campo = new CampoClinico();
            Institucion institucion = new Institucion();
            NombreCampoClinico nombreCampo = new NombreCampoClinico();
            Servicio serv = new Servicio();
            Supervision superv = new Supervision();
            SolicitudDeCuposNP solicitud = new SolicitudDeCuposNP();
            UtilSolicitudDeCupos util = new UtilSolicitudDeCupos();
            Carrera carr = new Carrera();


            int i = Int32.Parse(index);
            List<DataPoint> dataPoint = System.Web.Helpers.Json.Decode<List<DataPoint>>(DataPoint);

           

            if ((dataPoint[i].Y - solicitudCupo.CuposAlumnos) < 0)
            {
                ViewBag.Error = "El numero de estudiantes asignado fue sobrepasado sobrepasado - solo quedan"+" "+dataPoint[i].Y + " "+"Cupos";
            }else
            {
            dataPoint[i].Y = (dataPoint[i].Y - solicitudCupo.CuposAlumnos);
            serv = ingreso.CrearServicio(servicio, 1);
            superv = ingreso.CrearSupervision(supervision, 1);
            asignatura = ingreso.CrearAsignatura(asignatura, 1);
            carr = ingreso.CarreraFindById(carrera.CarreraId);
            solicitudCupo.CarreraCarreraId = carr.CarreraId;
            solicitudCupo.ServicioId = serv.Id;
            periodo = ingreso.CrearPeriodos(periodo, jornada);
            solicitudCupo.PeriodoPeriodoId = periodo.PeriodoId;
            solicitudCupo.SupervisionId = superv.Id;
            solicitudCupo.AsignaturaId = asignatura.Id;
            institucion = ingreso.CrearInstitucion(InstitucionId,1);
            nombreCampo = ingreso.CrearNombreCampoClinico(NombreCampoId,1);

            campo = ingreso.CrearCampoClinico(nombreCampo,institucion,1);
            solicitudCupo.CampoClinicoId = campo.Id;

            solicitudCupo = ingreso.CrearSolicitud(solicitudCupo, 1);

            }

            ViewBag.DataPoint = dataPoint;

            ViewBag.CarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera");
            ViewBag.InstitucionId = new SelectList(db.Institucions, "NombreInstitucion", "NombreInstitucion");
            ViewBag.NombreJornadaId = new SelectList(db.NombreJornadas, "NombreJornadaId", "Nombre");
            ViewBag.NombreCampoId = new SelectList(db.NombreCampoClinicoSet, "NombreCampo", "NombreCampo");
            
           List<SolicitudDeCuposNP>ListaSolicitudes = util.GetSolicitudes(i,solicitudes,solicitud,dataPoint,solicitudCupo);

            return View(ListaSolicitudes);
        }
        public ActionResult Modal(int index, string DataPoint)
        {

            List<DataPoint> dataPoint = System.Web.Helpers.Json.Decode<List<DataPoint>>(DataPoint);

            ViewBag.dataPoint = dataPoint;
            ViewBag.IndexSelected = index;
            ViewBag.CarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera");
            ViewBag.InstitucionId = new SelectList(db.Institucions, "NombreInstitucion", "NombreInstitucion");
            ViewBag.NombreJornadaId = new SelectList(db.NombreJornadas, "NombreJornadaId", "Nombre");
            ViewBag.NombreCampoId = new SelectList(db.NombreCampoClinicoSet, "NombreCampo", "NombreCampo");
            return View();
        }


        // GET: SolicitudDeCupos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SolicitudDeCupos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SolicitudDeCupos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SolicitudDeCupos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SolicitudDeCupos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SolicitudDeCupos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SolicitudDeCupos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
