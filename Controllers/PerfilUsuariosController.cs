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
    public class PerfilUsuariosController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: PerfilUsuarios

        [Authorize(Roles = ("Administrador"))]
        public ActionResult Index()
        {
            var perfilUsuarios = db.PerfilUsuarios.Include(p => p.Usuario);
            return View(perfilUsuarios.ToList());
        }

        [Authorize(Roles = ("Administrador"))]
        // GET: PerfilUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilUsuario perfilUsuario = db.PerfilUsuarios.Find(id);
            if (perfilUsuario == null)
            {
                return HttpNotFound();
            }
            return View(perfilUsuario);
        }

        [Authorize(Roles = ("Administrador"))]
        // GET: PerfilUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Cuenta");
            return View();
        }

        // POST: PerfilUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = ("Administrador"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Perfil,Estado")] PerfilUsuario perfilUsuario)
        {
            if (ModelState.IsValid)
            {
                db.PerfilUsuarios.Add(perfilUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Cuenta", perfilUsuario.UsuarioId);
            return View(perfilUsuario);
        }

        [Authorize(Roles = ("Administrador"))]
        // GET: PerfilUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilUsuario perfilUsuario = db.PerfilUsuarios.Find(id);
            if (perfilUsuario == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Cuenta", perfilUsuario.UsuarioId);
            return View(perfilUsuario);
        }

        // POST: PerfilUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = ("Administrador"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Perfil,Estado,UsuarioId")] PerfilUsuario perfilUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfilUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Cuenta", perfilUsuario.UsuarioId);
            return View(perfilUsuario);
        }

        [Authorize(Roles = ("Administrador"))]
        // GET: PerfilUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilUsuario perfilUsuario = db.PerfilUsuarios.Find(id);
            if (perfilUsuario == null)
            {
                return HttpNotFound();
            }
            return View(perfilUsuario);
        }

        [Authorize(Roles = ("Administrador"))]
        // POST: PerfilUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PerfilUsuario perfilUsuario = db.PerfilUsuarios.Find(id);
            db.PerfilUsuarios.Remove(perfilUsuario);
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
