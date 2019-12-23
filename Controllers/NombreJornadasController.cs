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
    public class NombreJornadasController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: NombreJornadas
        public ActionResult Index()
        {
            return View(db.NombreJornadas.ToList());
        }

        // GET: NombreJornadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NombreJornada nombreJornada = db.NombreJornadas.Find(id);
            if (nombreJornada == null)
            {
                return HttpNotFound();
            }
            return View(nombreJornada);
        }

        // GET: NombreJornadas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NombreJornadas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NombreJornadaId,Nombre")] NombreJornada nombreJornada)
        {
            if (ModelState.IsValid)
            {
                db.NombreJornadas.Add(nombreJornada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nombreJornada);
        }

        // GET: NombreJornadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NombreJornada nombreJornada = db.NombreJornadas.Find(id);
            if (nombreJornada == null)
            {
                return HttpNotFound();
            }
            return View(nombreJornada);
        }

        // POST: NombreJornadas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NombreJornadaId,Nombre")] NombreJornada nombreJornada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nombreJornada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nombreJornada);
        }

        // GET: NombreJornadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NombreJornada nombreJornada = db.NombreJornadas.Find(id);
            if (nombreJornada == null)
            {
                return HttpNotFound();
            }
            return View(nombreJornada);
        }

        // POST: NombreJornadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NombreJornada nombreJornada = db.NombreJornadas.Find(id);
            db.NombreJornadas.Remove(nombreJornada);
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
