using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAS.v1.Controllers
{
    public class SolicitudDeCuposController : Controller
    {
        // GET: SolicitudDeCupos
        public ActionResult Index()
        {
            int numeroDeCupos = 19;
            string Asignatura = "Nutricon adulto";

            ViewBag.Ncupos = numeroDeCupos;
            ViewBag.Asignatura = Asignatura;

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection values)
        {
            string carrera = Request["Carrera-name"];
            string anio= Request["Año-name"];
            string institucion=Request["Institucion-name"];
            string Establecimiento= Request["Establecimiento-name"];
            string Servicio= Request["Servicio-name"];
            string cupos= Request["Cupos-name"];
            string Semanas= Request["Semanas-name"];
            string desde= Request["datepicker"];
            string hasta = Request["datepicker2"];
            string jornada = Request["Jornada-name"];
            string supervicion = Request["Supervicion-name"];
            string Asignatura = Request["Asignatura=name"];
            string observacion = Request["Observacion-name"];
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
