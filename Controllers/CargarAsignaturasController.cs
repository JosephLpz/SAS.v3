
using SAS.v1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SAS.v1.Models;

namespace SAS.v1.Controllers
{
    public class CargarAsignaturasController : Controller
    {
        // GET: CargarAsignaturas
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase archivo, string NombreHoja, string carrera)
        {
            if (archivo != null && archivo.ContentLength > 0)
            {
                CargarArchivo(archivo,NombreHoja,carrera);
                ViewBag.showSuccessAlert = false;
            }

            return View();
        }
        public ActionResult CargarArchivo(HttpPostedFileBase archivo,string NombreHoja,string carrera)
        {
            if (archivo != null && archivo.ContentLength > 0)
            {
                string NombreArchivo = Path.GetFileName(archivo.FileName);
                
                CargarAsignaturas Cargar = new CargarAsignaturas();
                Cargar.procesarCargaDatos(NombreArchivo,NombreHoja,carrera);
            }

            return View();
        }
        // GET: CargarAsignaturas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CargarAsignaturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CargarAsignaturas/Create
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

        // GET: CargarAsignaturas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CargarAsignaturas/Edit/5
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

        // GET: CargarAsignaturas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CargarAsignaturas/Delete/5
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
