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
        public ActionResult Index()
        {
            ViewBag.AsignaturaId= new SelectList(db.Asignaturas, "Id", "NombreAsignatura");
            return View();
        }

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpPost]
        public ActionResult Index([Bind(Include = "Id")]Asignatura Asignatura)
        {
            ViewBag.AsignaturaId = new SelectList(db.Asignaturas, "Id", "NombreAsignatura");

            ProyeccionesServices proyeccion = new ProyeccionesServices();
            proyeccion.CalcularProyeccionPorAsignatura(Asignatura.Id);
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
