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
    public class SupervisionsController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Supervisions
        public ActionResult Index()
        {
            return View(db.Supervicions.ToList());
        }

        // GET: Supervisions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supervision supervision = db.Supervicions.Find(id);
            if (supervision == null)
            {
                return HttpNotFound();
            }
            return View(supervision);
        }

        // GET: Supervisions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supervisions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreSupervision")] Supervision supervision)
        {
            if (ModelState.IsValid)
            {
                db.Supervicions.Add(supervision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supervision);
        }

        // GET: Supervisions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supervision supervision = db.Supervicions.Find(id);
            if (supervision == null)
            {
                return HttpNotFound();
            }
            return View(supervision);
        }

        // POST: Supervisions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreSupervision")] Supervision supervision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supervision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supervision);
        }

        // GET: Supervisions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supervision supervision = db.Supervicions.Find(id);
            if (supervision == null)
            {
                return HttpNotFound();
            }
            return View(supervision);
        }

        // POST: Supervisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supervision supervision = db.Supervicions.Find(id);
            db.Supervicions.Remove(supervision);
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
