
using SAS.v1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace SAS.v1.Controllers
{
    public class CargarPlanEstudiosController : Controller
    {

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.showSuccessAlert = true;
            ViewBag.showErrorAlert = false;
            ViewBag.EstadoDeProceso = true;
            return View();
        }

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase archivo, string carrera,string anio,string NombreHoja)
        {
            if (archivo != null && archivo.ContentLength > 0)
            {
                CargarArchivo(archivo, carrera,anio,NombreHoja);
            }
            else
            {
                ViewBag.showSuccessAlert = true;
                ViewBag.EstadoDeProceso = true;
                ViewBag.showErrorAlert =  true;
            }

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
