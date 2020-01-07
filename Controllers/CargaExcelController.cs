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
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpGet]
        public ActionResult IngresoArchivo()
        {
            ViewBag.showSuccessAlert = false;
            ViewBag.EstadoDeProceso = false;
            return View();
        }
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpPost]
        public ActionResult IngresoArchivo(HttpPostedFileBase archivo, string selectValue, int selectValueAccion)
        {
            if (selectValueAccion==1)
            {
               
                if (archivo != null && archivo.ContentLength > 0)
                {
                    try
                    {
                    CargarArchivo(archivo, selectValue, selectValueAccion);
                    }
                    catch (ArgumentException ex)
                    {
                        ViewBag.Exception = "Error:" + ex.Message;

                    }
                    catch (FormatException ex)
                    {
                        ViewBag.Exception = "Error:" + ex.Message;
                    }
                    catch (IOException ex)
                    {
                        ViewBag.Exception = "Error:" + ex.Message;
                    }catch(NullReferenceException ex)
                    {
                        ViewBag.Exception = "Error:" + ex.Message;
                    }

                    ViewBag.showSuccessAlert = false;
                    ViewBag.EstadoDeProceso = false;
                }
                else
                {
                    ViewBag.showSuccessAlert = true;
                    ViewBag.EstadoDeProceso = false;
                }

            }
            else
            {
            if (archivo != null && archivo.ContentLength > 0)
            {
                CargarArchivo(archivo, selectValue,selectValueAccion);
                ViewBag.showSuccessAlert = false;
                    ViewBag.EstadoDeProceso = false;
                }
            else
            {
                ViewBag.showSuccessAlert = true;
                ViewBag.EstadoDeProceso = false;
                }
            }

            
            return View();
        }
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        public ActionResult CargarArchivo(HttpPostedFileBase archivo, string selectValue, int selectValueAccion)
        {
             if (archivo != null && archivo.ContentLength > 0)
            {
                string NombreArchivo = Path.GetFileName(archivo.FileName);
                CargaDatosServices CargaDatos = new CargaDatosServices();
               if( CargaDatos.procesarCargaDatos(NombreArchivo,selectValue, selectValueAccion))
                {
                    ViewBag.EstadoDeProceso = true;
                }else
                {
                    ViewBag.EstadoDeProceso = false;
                }

            }
            
            return View();
        }
    }
}