using SAS.v1.Models;
using SAS.v1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAS.v1.Controllers
{
    public class ProyeccionesDeCuposController : Controller
    {
        ModeloContainer db = new ModeloContainer();
        // GET: ProyeccionesDeCupos
        public ActionResult Index()
        {
            
            return View(db.Asignaturas.ToList());
        }

        // GET: ProyeccionesDeCupos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProyeccionesDeCupos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProyeccionesDeCupos/Create
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

        // GET: ProyeccionesDeCupos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProyeccionesDeCupos/Edit/5
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

        // GET: ProyeccionesDeCupos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProyeccionesDeCupos/Delete/5
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

        public ActionResult ProyectarCuposParaAsignatura(int id)
        {
            ProyeccionesServices proyeccion = new ProyeccionesServices();

            proyeccion.CalcularProyeccionPorAsignatura(id);

            return View();
        }
    }
}
