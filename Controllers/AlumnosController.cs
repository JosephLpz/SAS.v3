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
    public class AlumnosController : Controller
    {
    
       private ModeloContainer db = new ModeloContainer();

        // GET: Alumnos
        [HttpGet]
        public ActionResult Index()
       {
           AlumnosServices ListaAlumno = new AlumnosServices();

            //List<AlumnoNP> alumnos = ListaAlumno.ListaAlumnos(null);
            
            var alumnos = db.Alumnos.Include(p => p.Persona);
           return View(alumnos);
       }
        [HttpPost]
        public ActionResult Index(string Filtro)
        {
            AlumnosServices ListaAlumno = new AlumnosServices();
            List<Alumno> alumnos = new List<Alumno>();
            //List<AlumnoNP> alumnos = ListaAlumno.ListaAlumnos(Filtro);
            if (Filtro == null || Filtro == "")
            {
                alumnos = db.Alumnos.Include(p => p.Persona).ToList();
            }else
            {
            alumnos = db.Alumnos.Include(p => p.Persona).Where(p=>p.Persona.Rut==Filtro).ToList();
            }
            
            return View(alumnos);
        }
        // GET: Alumnos/Details/5
        public ActionResult Details(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
          //// Alumno alumno = db.Alumnos.Find(id);
          // if (alumno == null)
          // {
          //     return HttpNotFound();
          // }
                           AlumnosServices AlumnoServ = new AlumnosServices();
                           CampoClinicoAlumno CampoAlumnos = AlumnoServ.DatosCampoClinico(id);
           return View(CampoAlumnos);
       }

       public ActionResult DetalleCamposClinicos(int? id)
        {
            AlumnosServices CampoAlumnos = new AlumnosServices();
            List<CampoClinicoAlumno> listaCamposAlumnos = CampoAlumnos.DatosCampoClinicoAlumnos(id);
            return View(listaCamposAlumnos);

        }
       //// GET: Alumnos/Create
       //public ActionResult Create()
       //{
       //    ViewBag.CentroFormadorCentroFormadorId = new SelectList(db.CentroFormadors, "CentroFormadorId", "CentroFormadorId");
       //    ViewBag.InmunizacionInmunizacionId = new SelectList(db.Inmunizacions, "InmunizacionId", "NombreInmunizacion");
       //    return View();
       //}

       // POST: Alumnos/Create
       // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
       // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
       //[HttpPost]
       //[ValidateAntiForgeryToken]
       //public ActionResult Create([Bind(Include = "PersonaId,Rut,Dv,Nombre,ApPaterno,ApMaterno,AlumnoId,CursoNivel,Observaciones,InmunizacionInmunizacionId,CentroFormadorCentroFormadorId")] Alumno alumno)
       //{
       //    if (ModelState.IsValid)
       //    {
       //        db.Personas.Add(alumno);
       //        db.SaveChanges();
       //        return RedirectToAction("Index");
       //    }

       //    ViewBag.CentroFormadorCentroFormadorId = new SelectList(db.CentroFormadors, "CentroFormadorId", "CentroFormadorId", alumno.CentroFormadorCentroFormadorId);
       //    ViewBag.InmunizacionInmunizacionId = new SelectList(db.Inmunizacions, "InmunizacionId", "NombreInmunizacion", alumno.InmunizacionInmunizacionId);
       //    return View(alumno);
       //}

       // GET: Alumnos/Edit/5
       //public ActionResult Edit(int? id)
       //{
       //    if (id == null)
       //    {
       //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
       //    }
       //    Alumno alumno = (Alumno)db.Personas.Find(id);
       //    if (alumno == null)
       //    {
       //        return HttpNotFound();
       //    }
       //    ViewBag.CentroFormadorCentroFormadorId = new SelectList(db.CentroFormadors, "CentroFormadorId", "CentroFormadorId", alumno.CentroFormadorCentroFormadorId);
       //    ViewBag.InmunizacionInmunizacionId = new SelectList(db.Inmunizacions, "InmunizacionId", "NombreInmunizacion", alumno.InmunizacionInmunizacionId);
       //    return View(alumno);
       //}

       //// POST: Alumnos/Edit/5
       //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
       //// más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
       //[HttpPost]
       //[ValidateAntiForgeryToken]
       //public ActionResult Edit([Bind(Include = "PersonaId,Rut,Dv,Nombre,ApPaterno,ApMaterno,AlumnoId,CursoNivel,Observaciones,InmunizacionInmunizacionId,CentroFormadorCentroFormadorId")] Alumno alumno)
       //{
       //    if (ModelState.IsValid)
       //    {
       //        db.Entry(alumno).State = EntityState.Modified;
       //        db.SaveChanges();
       //        return RedirectToAction("Index");
       //    }
       //    ViewBag.CentroFormadorCentroFormadorId = new SelectList(db.CentroFormadors, "CentroFormadorId", "CentroFormadorId", alumno.CentroFormadorCentroFormadorId);
       //    ViewBag.InmunizacionInmunizacionId = new SelectList(db.Inmunizacions, "InmunizacionId", "NombreInmunizacion", alumno.InmunizacionInmunizacionId);
       //    return View(alumno);
       //}

       // GET: Alumnos/Delete/5
       //public ActionResult Delete(int? id)
       //{
       //    if (id == null)
       //    {
       //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
       //    }
       //    Alumno alumno = (Alumno)db.Personas.Find(id);
       //    if (alumno == null)
       //    {
       //        return HttpNotFound();
       //    }
       //    return View(alumno);
       //}

       //// POST: Alumnos/Delete/5
       //[HttpPost, ActionName("Delete")]
       //[ValidateAntiForgeryToken]
       //public ActionResult DeleteConfirmed(int id)
       //{
       //    Alumno alumno = (Alumno)db.Personas.Find(id);
       //    db.Personas.Remove(alumno);
       //    db.SaveChanges();
       //    return RedirectToAction("Index");
       //}

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
