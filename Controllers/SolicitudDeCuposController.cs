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
        public ActionResult Index(string Proyecciones, int CarreraId)
        {
            int[] proyeccion = (int[])TempData["Proyeccion"];
            UtilSolicitudDeCupos util = new UtilSolicitudDeCupos();
            List<DataPoint> dataPoint= new List<DataPoint>();
            int[] proy= System.Web.Helpers.Json.Decode<int[]>(Proyecciones);
            if (proyeccion.Count()==0)
            {
               ViewBag.Error= "No se ha Realizado ninguna proyeccion de cupos";
            }
            else
            {
            //dataPoint = System.Web.Helpers.Json.Decode<List<DataPoint>>(Data);
                ViewBag.DataPoint = dataPoint;
            }
            ViewBag.Index = 0;
            

            //List<SolicitudDeCupo> solicitud = db.SolicitudDeCupos.ToList();

            List<ProyeccionDeCupo> ListaProyecciones = util.GetProyecciones(proyeccion);


            ViewBag.CarreraId = CarreraId;
            ViewBag.InstitucionId = new SelectList(db.Institucions, "NombreInstitucion", "NombreInstitucion");
            ViewBag.NombreJornadaId = new SelectList(db.NombreJornadas, "NombreJornadaId", "Nombre");
            ViewBag.NombreCampoId = new SelectList(db.NombreCampoClinicoSet, "NombreCampo", "NombreCampo");
            
            TempData["Proyeccion"] = proyeccion;

            return View(ListaProyecciones);
        }

        [HttpPost]
        public ActionResult Index(string Solicitudes, string index, string DataPoint,[Bind(Include ="CarreraId,NombreCampoId,CuposAlumnos,Observacion,TotalSemanaPorGrupo,FechaInicio,FechaTermino,NombreJornadaId,NombreAsignatura,ServicioId,SupervisionId")]
      Carrera carrera, SolicitudDeCupo solicitudCupo, Periodo periodo, NombreJornada jornada, int AsignaturaId, string InstitucionId,string NombreCampoId,int CarreraId,int ServicioId,int SupervisionId)
        {
            IngresoServices ingreso = new IngresoServices();
        
            
           
            

            Institucion institucion = new Institucion();
            NombreCampoClinico nombreCampo = new NombreCampoClinico();

            Servicio serv = new Servicio();
            serv.Id = ServicioId;
            serv = ingreso.SevicioFindById(serv);

            Supervision superv = new Supervision();
            superv.Id = SupervisionId;
            superv = ingreso.SupervisionFindById(superv);

            SolicitudDeCuposNP solicitud = new SolicitudDeCuposNP();
            UtilSolicitudDeCupos util = new UtilSolicitudDeCupos();
            Carrera carr = new Carrera();
            int[] proyeccion = (int[])TempData["Proyeccion"];

            //Obtener proyecciones segun IDs
            List<ProyeccionDeCupo> ListaSolicitudes = util.GetProyecciones(proyeccion);


            int i = Int32.Parse(index);
            List<DataPoint> dataPoint = System.Web.Helpers.Json.Decode<List<DataPoint>>(DataPoint);

            if ((Int32.Parse(ListaSolicitudes[i].CuposRestantes) - solicitudCupo.CuposAlumnos) < 0)
            {
                ViewBag.Error = "El numero de estudiantes asignado fue sobrepasado sobrepasado - solo quedan"+" "+ (Int32.Parse(ListaSolicitudes[i].CuposRestantes) + " "+"Cupos");
            }else
            {
            ListaSolicitudes[i].CuposRestantes = ((Int32.Parse(ListaSolicitudes[i].CuposRestantes)) - solicitudCupo.CuposAlumnos).ToString();
            //Resta los cupos solicitados
            ingreso.CrearProyeccion(ListaSolicitudes[i],1);


            serv = ingreso.CrearServicio(serv, 1);
            superv = ingreso.CrearSupervision(superv, 1);
            //asignatura = ingreso.AsignaturaFindById(asignatura.Id);
            carr = ingreso.CarreraFindById(carrera.CarreraId);
            solicitudCupo.CarreraCarreraId = carr.CarreraId;
            solicitudCupo.ServicioId = serv.Id;
            periodo = ingreso.CrearPeriodos(periodo, jornada);
            solicitudCupo.PeriodoPeriodoId = periodo.PeriodoId;
            solicitudCupo.SupervisionId = superv.Id;
            solicitudCupo.AsignaturaId = AsignaturaId;
            institucion = ingreso.CrearInstitucion(InstitucionId,1);
            nombreCampo = ingreso.CrearNombreCampoClinico(NombreCampoId,1,institucion);
            solicitudCupo.NombreCampoClinicoId = nombreCampo.Id;
            
            
            solicitudCupo.ProyeccionDeCupoId = proyeccion[i];
            solicitudCupo = ingreso.CrearSolicitud(solicitudCupo, 1);

            }

            ViewBag.DataPoint = dataPoint;
            ViewBag.CarreraId = CarreraId;

           
            ViewBag.InstitucionId = new SelectList(db.Institucions, "NombreInstitucion", "NombreInstitucion");
            ViewBag.NombreJornadaId = new SelectList(db.NombreJornadas, "NombreJornadaId", "Nombre");
            ViewBag.NombreCampoId = new SelectList(db.NombreCampoClinicoSet, "NombreCampo", "NombreCampo");

            
            TempData["Proyeccion"] = proyeccion;

            return View(ListaSolicitudes);
        }
        public ActionResult Modal(int index, string DataPoint,int CarreraId,int AsignaturaId)
        {
            int[] proyeccion = (int[])TempData["Proyeccion"];

            List<DataPoint> dataPoint = System.Web.Helpers.Json.Decode<List<DataPoint>>(DataPoint);

            ViewBag.dataPoint = dataPoint;
            ViewBag.IndexSelected = index;
            ViewBag.CarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera",CarreraId);
            ViewBag.InstitucionId = new SelectList(db.Institucions, "NombreInstitucion", "NombreInstitucion");
            ViewBag.NombreJornadaId = new SelectList(db.NombreJornadas, "NombreJornadaId", "Nombre");
            ViewBag.NombreCampoId = new SelectList(db.NombreCampoClinicoSet, "NombreCampo", "NombreCampo");
            ViewBag.AsignaturaId = new SelectList(db.Asignaturas, "Id", "NombreAsignatura", AsignaturaId);
            ViewBag.SupervisionId = new SelectList(db.Supervicions, "Id", "NombreSupervision");
            ViewBag.ServicioId = new SelectList(db.Servicios, "Id", "NombreServicio");
            //ViewBag.Asignatura = db.Asignaturas.Where(a => a.Id == AsignaturaId).FirstOrDefault();
            TempData["Proyeccion"] = proyeccion;

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
