using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAS.v1.Models;

namespace SAS.v1.Controllers
{
    public class PlanEstudioAlumnosController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: PlanEstudioAlumnos
        public ActionResult Index(int? id)
        {
            Alumno planEstudioAlumnos = db.Alumnos.Include(p=>p.Persona).Where(p=>p.AlumnoId==id).FirstOrDefault();
            return View(planEstudioAlumnos);
        }

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: PlanEstudioAlumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanEstudioAlumno planEstudioAlumno = db.PlanEstudioAlumnos.Find(id);
            if (planEstudioAlumno == null)
            {
                return HttpNotFound();
            }
            return View(planEstudioAlumno);
        }

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: PlanEstudioAlumnos/Create
        public ActionResult Create()
        {
            ViewBag.PlanDeEstudioId = new SelectList(db.PlanDeEstudios, "Id", "UD");
            ViewBag.AlumnoAlumnoId = new SelectList(db.Alumnos, "AlumnoId", "Observaciones");
            return View();
        }

        // POST: PlanEstudioAlumnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PlanDeEstudioId,AlumnoAlumnoId,EstadoAsignatura")] PlanEstudioAlumno planEstudioAlumno)
        {
            if (ModelState.IsValid)
            {
                db.PlanEstudioAlumnos.Add(planEstudioAlumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlanDeEstudioId = new SelectList(db.PlanDeEstudios, "Id", "UD", planEstudioAlumno.PlanDeEstudioId);
            ViewBag.AlumnoAlumnoId = new SelectList(db.Alumnos, "AlumnoId", "Observaciones", planEstudioAlumno.AlumnoAlumnoId);
            return View(planEstudioAlumno);
        }


        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: PlanEstudioAlumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanEstudioAlumno planEstudioAlumno = db.PlanEstudioAlumnos.Find(id);
            if (planEstudioAlumno == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlanDeEstudioId = new SelectList(db.PlanDeEstudios, "Id", "UD", planEstudioAlumno.PlanDeEstudioId);
            ViewBag.AlumnoAlumnoId = new SelectList(db.Alumnos, "AlumnoId", "Observaciones", planEstudioAlumno.AlumnoAlumnoId);
            return View(planEstudioAlumno);
        }

        // POST: PlanEstudioAlumnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PlanDeEstudioId,AlumnoAlumnoId,EstadoAsignatura")] PlanEstudioAlumno planEstudioAlumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planEstudioAlumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlanDeEstudioId = new SelectList(db.PlanDeEstudios, "Id", "UD", planEstudioAlumno.PlanDeEstudioId);
            ViewBag.AlumnoAlumnoId = new SelectList(db.Alumnos, "AlumnoId", "Observaciones", planEstudioAlumno.AlumnoAlumnoId);
            return View(planEstudioAlumno);
        }

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: PlanEstudioAlumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanEstudioAlumno planEstudioAlumno = db.PlanEstudioAlumnos.Find(id);
            if (planEstudioAlumno == null)
            {
                return HttpNotFound();
            }
            return View(planEstudioAlumno);
        }

        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // POST: PlanEstudioAlumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanEstudioAlumno planEstudioAlumno = db.PlanEstudioAlumnos.Find(id);
            db.PlanEstudioAlumnos.Remove(planEstudioAlumno);
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
