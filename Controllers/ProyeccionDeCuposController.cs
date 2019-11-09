using SAS.v1.ClasesNP;
using Newtonsoft.Json;
using SAS.v1.Models;
using SAS.v1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpPost]
        public ActionResult ProyeccionPorCarrera([Bind(Include = "CarreraId")]Carrera carr)
        {
            IngresoServices ingreso = new IngresoServices();
            ViewBag.CarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera");

            ProyeccionesServices proyeccion = new ProyeccionesServices();
            Carrera carrera = ingreso.CarreraFindById(carr.CarreraId);


            return View("MuestraProyeccionPorCarrera", MuestraProyeccionPorCarrera(proyeccion.CalcularProyeccionPorCarrera(carrera)));
        }
        public ActionResult MuestraProyeccion(List<DataPoint> CantidadDeAlumnos, Asignatura asignatura)
        {
           
            List<DataPoint> dataPoints = CantidadDeAlumnos;
            ViewBag.Asignatura = asignatura.NombreAsignatura;
            ViewBag.Cupos = CantidadDeAlumnos[0].Y;
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }

        public ActionResult MuestraProyeccionPorCarrera(List<DataPoint> CantidadDeAlumnos)
        {
            int TotalCupos=0;
            List<DataPoint> dataPoints = CantidadDeAlumnos;
            foreach(var item in CantidadDeAlumnos)
            {
                TotalCupos +=(int)item.Y;
            }
            ViewBag.TotalCupos = TotalCupos;
            ViewBag.data = dataPoints;
           //ViewBag.Asignatura = asignatura.NombreAsignatura;
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
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
