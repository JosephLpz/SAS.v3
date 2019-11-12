
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
    public class CargarPlanEstudiosController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.showSuccessAlert = true;
            ViewBag.showErrorAlert = false;
            ViewBag.EstadoDeProceso = true;
            ViewBag.CarreraId = new SelectList(db.Carreras, "NombreCarrera", "NombreCarrera");
            ViewBag.AnioId = new SelectList(db.Anios, "Ano", "Ano");

            return View();
        }

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase archivo, string CarreraId,string AnioId,string NombreHoja)
        {
            if (archivo != null && archivo.ContentLength > 0)
            {
                CargarArchivo(archivo, CarreraId, AnioId, NombreHoja);
            }
            else
            {
                ViewBag.showSuccessAlert = true;
                ViewBag.EstadoDeProceso = true;
                ViewBag.showErrorAlert =  true;
            }
            ViewBag.CarreraId = new SelectList(db.Carreras, "NombreCarrera", "NombreCarrera");
            ViewBag.AnioId = new SelectList(db.Anios, "Ano", "Ano");
            return View();
        }

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpPost]
        public ActionResult CargarArchivo(HttpPostedFileBase archivo, string carrera,string anio, string NombreHoja)
        {
            if (archivo != null && archivo.ContentLength > 0)
            {
                string NombreArchivo = Path.GetFileName(archivo.FileName);

                CargarPlanEstudio Cargar = new CargarPlanEstudio();
                if(Cargar.procesarCargaDatos(NombreArchivo, carrera, anio, NombreHoja))
                {
                    ViewBag.EstadoDeProceso = true;
                    ViewBag.showSuccessAlert = true;
                }
                else
                {
                    ViewBag.EstadoDeProceso = false;
                    ViewBag.showSuccessAlert = false;
                }
            }

            return View();
        }
    }
}
