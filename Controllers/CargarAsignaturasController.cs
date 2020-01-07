
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
        private ModeloContainer db = new ModeloContainer();

        // GET: CargarAsignaturas
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.showSuccessAlert = false;
            ViewBag.EstadoDeProceso = false;
            ViewBag.CarreraId = new SelectList(db.Carreras, "NombreCarrera", "NombreCarrera");

            return View();
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        public ActionResult Index(HttpPostedFileBase archivo, string NombreHoja, string CarreraId)
        {
            if (archivo != null && archivo.ContentLength > 0)
            {
                try
                {
                CargarArchivo(archivo,NombreHoja, CarreraId);
                
                }
                catch (ArgumentException ex)
                {
                    ViewBag.Exception =  ex.Message+" "+"Nombre:"+NombreHoja;
                    
                }
                catch (FormatException ex)
                {
                    ViewBag.Exception =  ex.Message;
                }
                catch (IOException ex)
                {
                    ViewBag.Exception =   ex.Message;
                }
                catch (NullReferenceException ex)
                {
                    ViewBag.Exception =  ex.Message;
                }

            }
            else
            {
                ViewBag.showSuccessAlert = true;
            }
            ViewBag.CarreraId = new SelectList(db.Carreras, "NombreCarrera", "NombreCarrera");
            ViewBag.showSuccessAlert = false;
            ViewBag.EstadoDeProceso = false;
            return View();
        }
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        public ActionResult CargarArchivo(HttpPostedFileBase archivo,string NombreHoja,string carrera)
        {
           
           
            if (archivo != null && archivo.ContentLength > 0)
            {
                string NombreArchivo = Path.GetFileName(archivo.FileName);
                
                CargarAsignaturas Cargar = new CargarAsignaturas();
                try
                {
             
                   if(Cargar.procesarCargaDatos(NombreArchivo, NombreHoja, carrera))
                    {
                        ViewBag.EstadoDeProceso = true;
                    }
                    else
                    {
                        ViewBag.EstadoDeProceso = false;
                        ViewBag.Exception = "Existe un problema con el formato del archivo o no es el archivo correcto!";
                    }
                }
                catch (System.IO.IOException )
                {
                    throw new IOException("Existe un error con el archivo");
                }
            }
            
            return View();
        }
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: CargarAsignaturas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: CargarAsignaturas/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
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

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: CargarAsignaturas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
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

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: CargarAsignaturas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
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
