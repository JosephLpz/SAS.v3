
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


        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase archivo, string carrera,string anio,string NombreHoja)
        {
            if (archivo != null && archivo.ContentLength > 0)
            {
                CargarArchivo(archivo, carrera,anio,NombreHoja);
                ViewBag.showSuccessAlert = false;
            }

            return View();
        }
        [HttpPost]
        public ActionResult CargarArchivo(HttpPostedFileBase archivo, string carrera,string anio, string NombreHoja)
        {
            if (archivo != null && archivo.ContentLength > 0)
            {
                string NombreArchivo = Path.GetFileName(archivo.FileName);

                CargarPlanEstudio Cargar = new CargarPlanEstudio();
                Cargar.procesarCargaDatos(NombreArchivo, carrera,anio,NombreHoja);
            }

            return View();
        }
    }
}
