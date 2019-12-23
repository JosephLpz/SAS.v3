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
    public class DocenciaHospitalariasController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: DocenciaHospitalarias
        public ActionResult Index()
        {
            return View(db.DocenciaHospitalarias.ToList());
        }

        // GET: DocenciaHospitalarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocenciaHospitalaria docenciaHospitalaria = db.DocenciaHospitalarias.Find(id);
            if (docenciaHospitalaria == null)
            {
                return HttpNotFound();
            }
            return View(docenciaHospitalaria);
        }

        // GET: DocenciaHospitalarias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocenciaHospitalarias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocenciaHospitalariaId,NombreDocenciaHospitalaria")] DocenciaHospitalaria docenciaHospitalaria)
        {
            if (ModelState.IsValid)
            {
                db.DocenciaHospitalarias.Add(docenciaHospitalaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(docenciaHospitalaria);
        }

        // GET: DocenciaHospitalarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocenciaHospitalaria docenciaHospitalaria = db.DocenciaHospitalarias.Find(id);
            if (docenciaHospitalaria == null)
            {
                return HttpNotFound();
            }
            return View(docenciaHospitalaria);
        }

        // POST: DocenciaHospitalarias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocenciaHospitalariaId,NombreDocenciaHospitalaria")] DocenciaHospitalaria docenciaHospitalaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docenciaHospitalaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(docenciaHospitalaria);
        }

        // GET: DocenciaHospitalarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocenciaHospitalaria docenciaHospitalaria = db.DocenciaHospitalarias.Find(id);
            if (docenciaHospitalaria == null)
            {
                return HttpNotFound();
            }
            return View(docenciaHospitalaria);
        }

        // POST: DocenciaHospitalarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocenciaHospitalaria docenciaHospitalaria = db.DocenciaHospitalarias.Find(id);
            db.DocenciaHospitalarias.Remove(docenciaHospitalaria);
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
