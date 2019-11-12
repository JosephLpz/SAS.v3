using SAS.v1.ClasesNP;
using Newtonsoft.Json;
using SAS.v1.Models;
using SAS.v1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAS.v1.Utils;

namespace SAS.v1.Controllers
{
    public class ProyeccionDeCuposController : Controller
    {
        private ModeloContainer db = new ModeloContainer();
        // GET: ProyeccionDeCupos

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.AsignaturaId= new SelectList(db.Asignaturas, "Id", "NombreAsignatura");
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano");
            return View();
        }

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpPost]
        public ActionResult Index([Bind(Include = "Id")]Asignatura Asignatura)
        {
            IngresoServices ingreso = new IngresoServices();
            ViewBag.AsignaturaId = new SelectList(db.Asignaturas, "Id", "NombreAsignatura");

            ProyeccionesServices proyeccion = new ProyeccionesServices();
            Asignatura asigantura = ingreso.AsignaturaFindById(Asignatura.Id);
           //return RedirectToAction("MuestraProyeccion", "NMuestraProyeccion", MuestraProyeccion(proyeccion.CalcularProyeccionPorAsignatura(Asignatura.Id)));
            return View("MuestraProyeccion", MuestraProyeccion(proyeccion.CalcularProyeccionPorAsignatura(Asignatura.Id),asigantura));
        }


        public ActionResult ProyeccionPorCarrera()
        {
            ViewBag.CarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera");
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano");

            return View();
        }
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpPost]
        public ActionResult ProyeccionPorCarrera([Bind(Include = "CarreraId")]Carrera carr,int AnioId)
        {
            IngresoServices ingreso = new IngresoServices();
            ViewBag.CarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera");
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano");

            ProyeccionesServices proyeccion = new ProyeccionesServices();
            Carrera carrera = ingreso.CarreraFindById(carr.CarreraId);
            List<DataPointAlumno> dataPoint = proyeccion.CalcularProyeccionPorCarrera(carrera);

            //return View("MuestraProyeccionPorCarrera", MuestraProyeccionPorCarrera(dataPoint,AnioId,carrera));
            TempData["CantidadAlumnos"] = dataPoint;
            TempData["Carrera"] = carrera;
            return RedirectToAction("MuestraProyeccionPorCarrera", new { ano = AnioId});
        }
        public ActionResult MuestraProyeccion(List<DataPointAlumno> CantidadDeAlumnos, Asignatura asignatura)
        {
           
            List<DataPointAlumno> dataPoints = CantidadDeAlumnos;
            ViewBag.Asignatura = asignatura.NombreAsignatura;
            ViewBag.Cupos = CantidadDeAlumnos[0].dataPoint.Y;
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
           

            return View();
        }

        public ActionResult MuestraProyeccionPorCarrera(int ano)
        {
            int TotalCupos=0;
            List<DataPointAlumno> dataPointsAlumno = (List<DataPointAlumno>)TempData["CantidadAlumnos"];
            List<DataPoint> data = new List<DataPoint>();
            List<Alumno> alumnos = new List<Alumno>();
            Carrera carr = (Carrera)TempData["Carrera"];

            foreach (var item in dataPointsAlumno)
            {
                TotalCupos +=(int)item.dataPoint.Y;
                data.Add(item.dataPoint);
               
            }
            ViewBag.TotalCupos = TotalCupos;
            ViewBag.data = data;
            ViewBag.AnioId = ano;
            ViewBag.Carrera = carr.CarreraId;

            //ViewBag.Asignatura = asignatura.NombreAsignatura;
            TempData["CantidadAlumnos"] = dataPointsAlumno;
            TempData["Carrera"] = carr;

            ViewBag.DataPoints = JsonConvert.SerializeObject(data);

            return View();
        }
        public ActionResult GuardarProyeccion(string Data,int AnioId, int CarreraId)
        {
            IngresoServices ingreso = new IngresoServices();
            List<DataPointAlumno> dataPoint = (List<DataPointAlumno>)TempData["CantidadAlumnos"];
            List<ProyeccionDeCupo> Proyecciones = new List<ProyeccionDeCupo>();

            //dataPoint = System.Web.Helpers.Json.Decode<List<DataPoint>>(Data);

            Carrera carr = ingreso.CarreraFindById(CarreraId);
            Anio ano = new Anio();
            ano.Id = AnioId;
            ano = ingreso.AnioFindById(ano);
            
            foreach (var item in dataPoint)
            {
                foreach(var result in item.alumno)
                {
                ProyeccionDeCupo proyeccion = new ProyeccionDeCupo();
                proyeccion.AnioId = ano.Id;
                proyeccion.CarreraCarreraId = carr.CarreraId;
                Asignatura asignatura = new Asignatura();

                asignatura.NombreAsignatura = item.dataPoint.Label;
                asignatura = ingreso.BuscarAsignatura(asignatura);

                proyeccion.AsignaturaId = asignatura.Id;
                proyeccion.CuposProyectados = item.dataPoint.Y.ToString();
                proyeccion.CuposRestantes= item.dataPoint.Y.ToString();
                
                proyeccion = ingreso.CrearProyeccion(proyeccion, 1);

                ProyeccionAlumno proyeccionAlumno = new ProyeccionAlumno();

                proyeccionAlumno.AlumnoAlumnoId = result.AlumnoId;
                proyeccionAlumno.ProyeccionDeCupoId = proyeccion.Id;

                proyeccionAlumno = ingreso.CrearProyeccionAlumno(proyeccionAlumno, 1);

                Proyecciones.Add(proyeccion);
                }
            
            }


            

            return RedirectToAction("Index","SolicitudDeCupos",new { Proyecciones = Proyecciones, CarreraId=carr.CarreraId });
        }
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: ProyeccionDeCupos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: ProyeccionDeCupos/Create
        public ActionResult Create()
        {
            return View();
        }


        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // POST: ProyeccionDeCupos/Create
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


        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: ProyeccionDeCupos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // POST: ProyeccionDeCupos/Edit/5
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


        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: ProyeccionDeCupos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // POST: ProyeccionDeCupos/Delete/5
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
