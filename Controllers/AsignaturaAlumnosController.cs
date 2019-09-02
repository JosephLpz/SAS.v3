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
    public class AsignaturaAlumnosController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: AsignaturaAlumnos
        public ActionResult Index()
        {
            var asignaturasAlumnos = db.AsignaturasAlumnos.Include(a => a.Alumno).Include(a => a.Asignatura).Include(a => a.Anio).Include(a => a.Semestre).Include(a => a.PorcentajeDeExigencia).Include(a => a.Carrera);
            return View(asignaturasAlumnos.ToList());
        }

        // GET: AsignaturaAlumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignaturaAlumno asignaturaAlumno = db.AsignaturasAlumnos.Find(id);
            if (asignaturaAlumno == null)
            {
                return HttpNotFound();
            }
            return View(asignaturaAlumno);
        }

        // GET: AsignaturaAlumnos/Create
        public ActionResult Create()
        {
            ViewBag.AlumnoAlumnoId = new SelectList(db.Alumnos, "AlumnoId", "CursoNivel");
            ViewBag.AsignaturaId = new SelectList(db.Asignaturas, "Id", "NombreAsignatura");
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano");
            ViewBag.SemestreId = new SelectList(db.Semestres, "Id", "NombreSemestre");
            ViewBag.PorcentajeDeExigenciaId = new SelectList(db.PorcentajesDeExigencias, "Id", "Id");
            ViewBag.CarreraCarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera");
            return View();
        }

        // POST: AsignaturaAlumnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AlumnoAlumnoId,AsignaturaId,AnioId,SemestreId,EstadoAsignatura,AsignaturaPreRequisito,PorcentajeDeExigenciaId,CarreraCarreraId")] AsignaturaAlumno asignaturaAlumno)
        {
            if (ModelState.IsValid)
            {
                db.AsignaturasAlumnos.Add(asignaturaAlumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlumnoAlumnoId = new SelectList(db.Alumnos, "AlumnoId", "CursoNivel", asignaturaAlumno.AlumnoAlumnoId);
            ViewBag.AsignaturaId = new SelectList(db.Asignaturas, "Id", "NombreAsignatura", asignaturaAlumno.AsignaturaId);
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano", asignaturaAlumno.AnioId);
            ViewBag.SemestreId = new SelectList(db.Semestres, "Id", "NombreSemestre", asignaturaAlumno.SemestreId);
            ViewBag.PorcentajeDeExigenciaId = new SelectList(db.PorcentajesDeExigencias, "Id", "Id", asignaturaAlumno.PorcentajeDeExigenciaId);
            ViewBag.CarreraCarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera", asignaturaAlumno.CarreraCarreraId);
            return View(asignaturaAlumno);
        }

        // GET: AsignaturaAlumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignaturaAlumno asignaturaAlumno = db.AsignaturasAlumnos.Find(id);
            if (asignaturaAlumno == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlumnoAlumnoId = new SelectList(db.Alumnos, "AlumnoId", "CursoNivel", asignaturaAlumno.AlumnoAlumnoId);
            ViewBag.AsignaturaId = new SelectList(db.Asignaturas, "Id", "NombreAsignatura", asignaturaAlumno.AsignaturaId);
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano", asignaturaAlumno.AnioId);
            ViewBag.SemestreId = new SelectList(db.Semestres, "Id", "NombreSemestre", asignaturaAlumno.SemestreId);
            ViewBag.PorcentajeDeExigenciaId = new SelectList(db.PorcentajesDeExigencias, "Id", "Id", asignaturaAlumno.PorcentajeDeExigenciaId);
            ViewBag.CarreraCarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera", asignaturaAlumno.CarreraCarreraId);
            return View(asignaturaAlumno);
        }

        // POST: AsignaturaAlumnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AlumnoAlumnoId,AsignaturaId,AnioId,SemestreId,EstadoAsignatura,AsignaturaPreRequisito,PorcentajeDeExigenciaId,CarreraCarreraId")] AsignaturaAlumno asignaturaAlumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignaturaAlumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlumnoAlumnoId = new SelectList(db.Alumnos, "AlumnoId", "CursoNivel", asignaturaAlumno.AlumnoAlumnoId);
            ViewBag.AsignaturaId = new SelectList(db.Asignaturas, "Id", "NombreAsignatura", asignaturaAlumno.AsignaturaId);
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano", asignaturaAlumno.AnioId);
            ViewBag.SemestreId = new SelectList(db.Semestres, "Id", "NombreSemestre", asignaturaAlumno.SemestreId);
            ViewBag.PorcentajeDeExigenciaId = new SelectList(db.PorcentajesDeExigencias, "Id", "Id", asignaturaAlumno.PorcentajeDeExigenciaId);
            ViewBag.CarreraCarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera", asignaturaAlumno.CarreraCarreraId);
            return View(asignaturaAlumno);
        }

        // GET: AsignaturaAlumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignaturaAlumno asignaturaAlumno = db.AsignaturasAlumnos.Find(id);
            if (asignaturaAlumno == null)
            {
                return HttpNotFound();
            }
            return View(asignaturaAlumno);
        }

        // POST: AsignaturaAlumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignaturaAlumno asignaturaAlumno = db.AsignaturasAlumnos.Find(id);
            db.AsignaturasAlumnos.Remove(asignaturaAlumno);
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
