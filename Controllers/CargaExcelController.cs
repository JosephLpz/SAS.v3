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
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult IngresoArchivo()
        {
            ViewBag.showSuccessAlert = false;
            return View();
        }
        [HttpPost]
        public ActionResult IngresoArchivo(HttpPostedFileBase archivo, string selectValue, int selectValueAccion)
        {
            if (selectValueAccion==1)
            {
                TruncateServices truncate = new TruncateServices();
                truncate.truncatedTablas();
                if (archivo != null && archivo.ContentLength > 0)
                {
                    CargarArchivo(archivo, selectValue, selectValueAccion);
                    ViewBag.showSuccessAlert = false;
                }
                else
                {
                    ViewBag.showSuccessAlert = true;
                }

            }
            else
            {
            if (archivo != null && archivo.ContentLength > 0)
            {
                CargarArchivo(archivo, selectValue,selectValueAccion);
                ViewBag.showSuccessAlert = false;
            }
            else
            {
                ViewBag.showSuccessAlert = true;
            }
            }

            
            return View();
        }
        
        public ActionResult CargarArchivo(HttpPostedFileBase archivo, string selectValue, int selectValueAccion)
        {
             if (archivo != null && archivo.ContentLength > 0)
            {
                string NombreArchivo = Path.GetFileName(archivo.FileName);
                CargaDatosServices CargaDatos = new CargaDatosServices();
                CargaDatos.procesarCargaDatos(NombreArchivo,selectValue, selectValueAccion);
            }
            
            return View();
        }
    }
}