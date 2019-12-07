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
    public class InmunizacionsController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Inmunizacions
        public ActionResult Index()
        {
            return View(db.Inmunizacions.ToList());
        }

        // GET: Inmunizacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmunizacion inmunizacion = db.Inmunizacions.Find(id);
            if (inmunizacion == null)
            {
                return HttpNotFound();
            }
            return View(inmunizacion);
        }

        // GET: Inmunizacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inmunizacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InmunizacionId,NombreInmunizacion")] Inmunizacion inmunizacion)
        {
            if (ModelState.IsValid)
            {
                db.Inmunizacions.Add(inmunizacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inmunizacion);
        }

        // GET: Inmunizacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmunizacion inmunizacion = db.Inmunizacions.Find(id);
            if (inmunizacion == null)
            {
                return HttpNotFound();
            }
            return View(inmunizacion);
        }

        // POST: Inmunizacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InmunizacionId,NombreInmunizacion")] Inmunizacion inmunizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inmunizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inmunizacion);
        }

        // GET: Inmunizacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmunizacion inmunizacion = db.Inmunizacions.Find(id);
            if (inmunizacion == null)
            {
                return HttpNotFound();
            }
            return View(inmunizacion);
        }

        // POST: Inmunizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inmunizacion inmunizacion = db.Inmunizacions.Find(id);
            db.Inmunizacions.Remove(inmunizacion);
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
