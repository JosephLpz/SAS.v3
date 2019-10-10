using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAS.v1.Models;
using SAS.v1.Services;
using SAS.v1.ClasesNP;

namespace SAS.v1.Controllers
{
    public class InstitucionsController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: Institucions
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Institucions.ToList());
        }

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpPost]
        public ActionResult Index(string Filtro)
        {

            return View(db.Institucions.Where(i=>i.NombreInstitucion.Contains(Filtro)).ToList());
        }

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: Institucions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Institucion institucion = db.Institucions.Find(id);
            //if (institucion == null)
            //{
            //    return HttpNotFound();
            //}
            InstitucionServices institucion = new InstitucionServices();
            return View(institucion.BuscarCampoClinico(id));
        }

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        public ActionResult DetallesUnidadServicio(int? id)
        {
            //UnidadDeServicioServices unidadServicio = new UnidadDeServicioServices();
            CampoClinico Campos = db.CampoClinicos.Find(id);
            return View(Campos);
        }
        //public ActionResult UnidadServicioAlumnos(int id)
        //{
        //    //UnidadDeServicioServices UnidadAlumnos = new UnidadDeServicioServices();
        //    UnidadDeServicio UnidadAlumnos = db.UnidadDeServicios.Find(id);
        //    return View(UnidadAlumnos);
        //}


        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        //GET: Institucions/Create
        public ActionResult Create()
       {
           return View();
       }

        // POST: Institucions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Create([Bind(Include = "Id,NombreInstitucion")] Institucion institucion)
       {
           if (ModelState.IsValid)
           {
               db.Institucions.Add(institucion);
               db.SaveChanges();
               return RedirectToAction("Index");
           }

           return View(institucion);
       }


        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: Institucions/Edit/5
        public ActionResult Edit(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           Institucion institucion = db.Institucions.Find(id);
           if (institucion == null)
           {
               return HttpNotFound();
           }
           return View(institucion);
       }

        // POST: Institucions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Edit([Bind(Include = "Id,NombreInstitucion")] Institucion institucion)
       {
           if (ModelState.IsValid)
           {
               db.Entry(institucion).State = EntityState.Modified;
               db.SaveChanges();
               return RedirectToAction("Index");
           }
           return View(institucion);
       }

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: Institucions/Delete/5
        public ActionResult Delete(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           Institucion institucion = db.Institucions.Find(id);
           if (institucion == null)
           {
               return HttpNotFound();
           }
           return View(institucion);
       }
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // POST: Institucions/Delete/5
        [HttpPost, ActionName("Delete")]
       [ValidateAntiForgeryToken]
       public ActionResult DeleteConfirmed(int id)
       {
           Institucion institucion = db.Institucions.Find(id);
           db.Institucions.Remove(institucion);
           db.SaveChanges();
           return RedirectToAction("Index");
       }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
