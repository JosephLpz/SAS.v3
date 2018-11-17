using SAS.v1.Services;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SAS.v1.Controllers
{
    public class CargaExcelController : Controller
    {
        // GET: CargaExcel
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IngresoArchivo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CargarArchivo(HttpPostedFileBase archivo)
        {
             if (archivo != null && archivo.ContentLength > 0)
            {
                string NombreArchivo = Path.GetFileName(archivo.FileName);
                CargaDatosServices CargaDatos = new CargaDatosServices();
                CargaDatos.procesarCargaDatos(NombreArchivo);
            }
            return View();
        }
    }
}