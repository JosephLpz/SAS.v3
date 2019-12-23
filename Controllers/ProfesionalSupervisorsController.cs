using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAS.v1.Models;
using SAS.v1.Utils;
using SAS.v1.Services;

namespace SAS.v1.Controllers
{
    public class ProfesionalSupervisorsController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        [Authorize(Roles = ("Administrador"))]
        [HttpGet]
        // GET: ProfesionalSupervisors
        //public ActionResult Index()
        //{
        //    var profesionalSupervisorSet = db.ProfesionalSupervisorSet.Include(p => p.Persona).Where(p=>p.Persona.Rut!="Ninguno"&&p.Persona.Nombre!="Ninguno");
        //    return View(profesionalSupervisorSet.ToList());
        //}

        //[Authorize(Roles = ("Administrador"))]
        //[HttpPost]
        //public ActionResult Index(string Filtro)
        //{
        //    List<ProfesionalSupervisor> profesionalSupervisorSet = new List<ProfesionalSupervisor>();
        //    if (Filtro=="")
        //    {
        //         profesionalSupervisorSet = db.ProfesionalSupervisorSet.Include(p => p.Persona).Where(p => p.Persona.Rut != "Ninguno" && p.Persona.Nombre != "Ninguno").ToList();
        //    }else
        //    {
        //     profesionalSupervisorSet = db.ProfesionalSupervisorSet.Include(p => p.Persona).Where(p=>p.Persona.Rut.Contains(Filtro)|| p.Persona.Nombre.Contains(Filtro)
        //    ||p.Persona.ApMaterno.Contains(Filtro)||p.Persona.ApPaterno.Contains(Filtro)).ToList();
        //    }
            

        //    return View(profesionalSupervisorSet.ToList());
        //}

        //[Authorize(Roles = ("Administrador"))]
        //// GET: ProfesionalSupervisors/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProfesionalSupervisor profesionalSupervisor = db.ProfesionalSupervisorSet.Find(id);
        //    if (profesionalSupervisor == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(profesionalSupervisor);
        //}

        //[Authorize(Roles = ("Administrador"))]
        //// GET: ProfesionalSupervisors/Create
        //public ActionResult Create()
        //{
        //    ViewBag.PersonaPersonaId = new SelectList(db.Personas, "PersonaId", "Rut");
        //    return View();
        //}

        //// POST: ProfesionalSupervisors/Create
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea http://go.microsoft.com/fwlink/?LinkId=317598.

        //[Authorize(Roles = ("Administrador"))]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Rut, Dv, Nombre, ApPaterno, ApMaterno,ProfesionalSupervisorId,ValorSupervisor,Observaciones")] Persona persona, ProfesionalSupervisor profesionalSupervisor)
        //{
        //    IngresoServices ingresoDatos = new IngresoServices();
        //    UtilRut ValidacionRut = new UtilRut();

        //    if (ModelState.IsValid)
        //    {
        //        if (ValidacionRut.validarRut((persona.Rut + "-" + persona.Dv)))
        //        {
        //            persona = ingresoDatos.CrearPersona(persona, 1);
        //            profesionalSupervisor = ingresoDatos.crearProfesionalSupervisor(persona, profesionalSupervisor, 1);

        //            //db.ProfesionalSupervisorSet.Add(profesionalSupervisor);
        //            //db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ViewBag.Error = ("El Rut ingresado no es valido");
        //        }
        //    }

        //    ViewBag.PersonaPersonaId = new SelectList(db.Personas, "PersonaId", "Rut", profesionalSupervisor.PersonaPersonaId);
        //    return View(profesionalSupervisor);
        //}

        //[Authorize(Roles = ("Administrador"))]
        //// GET: ProfesionalSupervisors/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProfesionalSupervisor profesionalSupervisor = db.ProfesionalSupervisorSet.Find(id);
        //    if (profesionalSupervisor == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.PersonaPersonaId = new SelectList(db.Personas, "PersonaId", "Rut", profesionalSupervisor.PersonaPersonaId);
        //    return View(profesionalSupervisor);
        //}

        //// POST: ProfesionalSupervisors/Edit/5
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea http://go.microsoft.com/fwlink/?LinkId=317598.

        //[Authorize(Roles = ("Administrador"))]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ProfesionalSupervisorId,ValorSupervisor,Observaciones,PersonaPersonaId")] ProfesionalSupervisor profesionalSupervisor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(profesionalSupervisor).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.PersonaPersonaId = new SelectList(db.Personas, "PersonaId", "Rut", profesionalSupervisor.PersonaPersonaId);
        //    return View(profesionalSupervisor);
        //}

        //[Authorize(Roles = ("Administrador"))]
        //// GET: ProfesionalSupervisors/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProfesionalSupervisor profesionalSupervisor = db.ProfesionalSupervisorSet.Find(id);
        //    if (profesionalSupervisor == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(profesionalSupervisor);
        //}

        //// POST: ProfesionalSupervisors/Delete/5
        //[Authorize(Roles = ("Administrador"))]
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ProfesionalSupervisor profesionalSupervisor = db.ProfesionalSupervisorSet.Find(id);
        //    db.ProfesionalSupervisorSet.Remove(profesionalSupervisor);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
