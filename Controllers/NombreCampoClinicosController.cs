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
    public class NombreCampoClinicosController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: NombreCampoClinicos
        public ActionResult Index()
        {
            var nombreCampoClinicoSet = db.NombreCampoClinicoSet.Include(n => n.Institucion);
            return View(nombreCampoClinicoSet.ToList());
        }

        // GET: NombreCampoClinicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NombreCampoClinico nombreCampoClinico = db.NombreCampoClinicoSet.Find(id);
            if (nombreCampoClinico == null)
            {
                return HttpNotFound();
            }
            return View(nombreCampoClinico);
        }

        // GET: NombreCampoClinicos/Create
        public ActionResult Create()
        {
            ViewBag.InstitucionId = new SelectList(db.Institucions, "Id", "NombreInstitucion");
            return View();
        }

        // POST: NombreCampoClinicos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreCampo,InstitucionId")] NombreCampoClinico nombreCampoClinico)
        {
            if (ModelState.IsValid)
            {
                db.NombreCampoClinicoSet.Add(nombreCampoClinico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstitucionId = new SelectList(db.Institucions, "Id", "NombreInstitucion", nombreCampoClinico.InstitucionId);
            return View(nombreCampoClinico);
        }

        // GET: NombreCampoClinicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NombreCampoClinico nombreCampoClinico = db.NombreCampoClinicoSet.Find(id);
            if (nombreCampoClinico == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstitucionId = new SelectList(db.Institucions, "Id", "NombreInstitucion", nombreCampoClinico.InstitucionId);
            return View(nombreCampoClinico);
        }

        // POST: NombreCampoClinicos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreCampo,InstitucionId")] NombreCampoClinico nombreCampoClinico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nombreCampoClinico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstitucionId = new SelectList(db.Institucions, "Id", "NombreInstitucion", nombreCampoClinico.InstitucionId);
            return View(nombreCampoClinico);
        }

        // GET: NombreCampoClinicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NombreCampoClinico nombreCampoClinico = db.NombreCampoClinicoSet.Find(id);
            if (nombreCampoClinico == null)
            {
                return HttpNotFound();
            }
            return View(nombreCampoClinico);
        }

        // POST: NombreCampoClinicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NombreCampoClinico nombreCampoClinico = db.NombreCampoClinicoSet.Find(id);
            db.NombreCampoClinicoSet.Remove(nombreCampoClinico);
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
