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
    public class PlanDeEstudiosController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: PlanDeEstudios
        public ActionResult Index()
        {
            var planDeEstudios = db.PlanDeEstudios.Include(p => p.RequisitosAsignatura).Include(p => p.Carrera).Include(p => p.Anio);
            return View(planDeEstudios.ToList());
        }

        // GET: PlanDeEstudios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanDeEstudio planDeEstudio = db.PlanDeEstudios.Find(id);
            if (planDeEstudio == null)
            {
                return HttpNotFound();
            }
            return View(planDeEstudio);
        }

        // GET: PlanDeEstudios/Create
        public ActionResult Create()
        {
            ViewBag.RequisitosAsignaturaId = new SelectList(db.RequisitosAsignaturas, "Id", "PorcentajeReprobacion");
            ViewBag.CarreraCarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera");
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano");
            return View();
        }

        // POST: PlanDeEstudios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RequisitosAsignaturaId,CarreraCarreraId,AnioId,UD,Catedra,Taller,LAB,PC,SCT,Materia,Curso")] PlanDeEstudio planDeEstudio)
        {
            if (ModelState.IsValid)
            {
                db.PlanDeEstudios.Add(planDeEstudio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RequisitosAsignaturaId = new SelectList(db.RequisitosAsignaturas, "Id", "PorcentajeReprobacion", planDeEstudio.RequisitosAsignaturaId);
            ViewBag.CarreraCarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera", planDeEstudio.CarreraCarreraId);
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano", planDeEstudio.AnioId);
            return View(planDeEstudio);
        }

        // GET: PlanDeEstudios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanDeEstudio planDeEstudio = db.PlanDeEstudios.Find(id);
            if (planDeEstudio == null)
            {
                return HttpNotFound();
            }
            ViewBag.RequisitosAsignaturaId = new SelectList(db.RequisitosAsignaturas, "Id", "PorcentajeReprobacion", planDeEstudio.RequisitosAsignaturaId);
            ViewBag.CarreraCarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera", planDeEstudio.CarreraCarreraId);
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano", planDeEstudio.AnioId);
            return View(planDeEstudio);
        }

        // POST: PlanDeEstudios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RequisitosAsignaturaId,CarreraCarreraId,AnioId,UD,Catedra,Taller,LAB,PC,SCT,Materia,Curso")] PlanDeEstudio planDeEstudio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planDeEstudio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RequisitosAsignaturaId = new SelectList(db.RequisitosAsignaturas, "Id", "PorcentajeReprobacion", planDeEstudio.RequisitosAsignaturaId);
            ViewBag.CarreraCarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera", planDeEstudio.CarreraCarreraId);
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano", planDeEstudio.AnioId);
            return View(planDeEstudio);
        }

        // GET: PlanDeEstudios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanDeEstudio planDeEstudio = db.PlanDeEstudios.Find(id);
            if (planDeEstudio == null)
            {
                return HttpNotFound();
            }
            return View(planDeEstudio);
        }

        // POST: PlanDeEstudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanDeEstudio planDeEstudio = db.PlanDeEstudios.Find(id);
            db.PlanDeEstudios.Remove(planDeEstudio);
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
