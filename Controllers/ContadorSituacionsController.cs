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
    public class ContadorSituacionsController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: ContadorSituacions
        public ActionResult Index()
        {
            var contadorSituacions = db.ContadorSituacions.Include(c => c.Anio);
            return View(contadorSituacions.ToList());
        }

        // GET: ContadorSituacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContadorSituacion contadorSituacion = db.ContadorSituacions.Find(id);
            if (contadorSituacion == null)
            {
                return HttpNotFound();
            }
            return View(contadorSituacion);
        }

        // GET: ContadorSituacions/Create
        public ActionResult Create()
        {
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano");
            return View();
        }

        // POST: ContadorSituacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Vigente,RetiroTemporal,RetiroDefinitivo,EliminadoAcademica,RetractoMatricula,EiminadoNoMatricula,Abandono,AnioId")] ContadorSituacion contadorSituacion)
        {
            if (ModelState.IsValid)
            {
                db.ContadorSituacions.Add(contadorSituacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano", contadorSituacion.AnioId);
            return View(contadorSituacion);
        }

        // GET: ContadorSituacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContadorSituacion contadorSituacion = db.ContadorSituacions.Find(id);
            if (contadorSituacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano", contadorSituacion.AnioId);
            return View(contadorSituacion);
        }

        // POST: ContadorSituacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Vigente,RetiroTemporal,RetiroDefinitivo,EliminadoAcademica,RetractoMatricula,EiminadoNoMatricula,Abandono,AnioId")] ContadorSituacion contadorSituacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contadorSituacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano", contadorSituacion.AnioId);
            return View(contadorSituacion);
        }

        // GET: ContadorSituacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContadorSituacion contadorSituacion = db.ContadorSituacions.Find(id);
            if (contadorSituacion == null)
            {
                return HttpNotFound();
            }
            return View(contadorSituacion);
        }

        // POST: ContadorSituacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContadorSituacion contadorSituacion = db.ContadorSituacions.Find(id);
            db.ContadorSituacions.Remove(contadorSituacion);
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
