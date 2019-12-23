using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAS.v1.Models;
using SAS.v1.Services;
using SAS.v1.Utils;

namespace SAS.v1.Controllers
{
    public class ProfesionalDocenteGuiasController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        [Authorize(Roles = ("Administrador"))]
        // GET: ProfesionalDocenteGuias
        public ActionResult Index()
        {
            var profesionalDocenteGuias = db.ProfesionalDocenteGuias.Include(p => p.Persona).Include(p => p.DocenciaHospitalaria).Include(p => p.Inmunizacion);
            return View(profesionalDocenteGuias.ToList());
        }

        [Authorize(Roles = ("Administrador"))]
        [HttpPost]
        public ActionResult Index(string Filtro)
        {
            var profesionalDocenteGuias = db.ProfesionalDocenteGuias.Include(p => p.Persona).Include(p => p.DocenciaHospitalaria).Include(p => p.Inmunizacion).Where(p => p.Persona.Rut.Contains(Filtro)
            || p.Profesion.Contains(Filtro) || p.Persona.Nombre.Contains(Filtro) || p.Persona.ApPaterno.Contains(Filtro) || p.DocenciaHospitalaria.NombreDocenciaHospitalaria.Contains(Filtro));
            return View(profesionalDocenteGuias.ToList());
        }
        // GET: ProfesionalDocenteGuias/Details/5

        [Authorize(Roles = ("Administrador"))]
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfesionalDocenteGuia profesionalDocenteGuia = db.ProfesionalDocenteGuias.Find(id);
            if (profesionalDocenteGuia == null)
            {
                return HttpNotFound();
            }
            //profesionalDocenteGuia


            DocenteGuiaServices DocenteGuia = new DocenteGuiaServices();
            //
            return View(profesionalDocenteGuia);
        }

        [Authorize(Roles = ("Administrador"))]
        [HttpPost]
        public ActionResult Details(int? id,string Filtro)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfesionalDocenteGuia profesionalDocenteGuia = db.ProfesionalDocenteGuias.Find(id);
            if (profesionalDocenteGuia == null)
            {
                return HttpNotFound();
            }
            //profesionalDocenteGuia


            DocenteGuiaServices DocenteGuia = new DocenteGuiaServices();
            //
            return View(profesionalDocenteGuia);
        }


        [Authorize(Roles = ("Administrador"))]
        // GET: ProfesionalDocenteGuias/Create
        public ActionResult Create()
       {
          ViewBag.NombreDocenciaHospitalaria = new SelectList(db.DocenciaHospitalarias, "NombreDocenciaHospitalaria", "NombreDocenciaHospitalaria");
           ViewBag.InmunizacionId = new SelectList(db.Inmunizacions, "InmunizacionId", "NombreInmunizacion");
           return View();
       }

        // POST: ProfesionalDocenteGuias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = ("Administrador"))]
        [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Create([Bind(Include = "Rut, Dv, Nombre, ApPaterno, ApMaterno, Profesion,NumeroSuperintendencia,Telefono,Correo,ValorDocente,CumpleDatos,NombreDocenciaHospitalaria,InmunizacionId,TipoDocente")] Persona persona, ProfesionalDocenteGuia profesionalDocenteGuia,DocenciaHospitalaria docenciaHospitalaria, Inmunizacion inmunizacion,int TipoDocente)
       {
            IngresoServices ingresoDatos = new IngresoServices();
            ValidacionCorreo validar = new ValidacionCorreo();
            UtilRut ValidacionRut = new UtilRut();
            if (TipoDocente == 1)
            {
            profesionalDocenteGuia.TipoDocente = Models.TipoDocente.DocenteGuia;
            }else if (TipoDocente == 2)
            {
            profesionalDocenteGuia.TipoDocente = Models.TipoDocente.DocenteSupervisor;
            }
            
            if (ModelState.IsValid)
           {
                if (ValidacionRut.validarRut((persona.Rut + "-" + persona.Dv)))
                {
                    if (validar.ValidateEmail(profesionalDocenteGuia.Correo))
                    {
                    persona = ingresoDatos.CrearPersona(persona,1);
                    docenciaHospitalaria = ingresoDatos.CrearDocenciaHospitalaria(docenciaHospitalaria.NombreDocenciaHospitalaria,1);
                    profesionalDocenteGuia = ingresoDatos.CrearProfesionalDocenteGuia(persona, profesionalDocenteGuia, inmunizacion, docenciaHospitalaria, 1);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.EmailValidation = "Correo inválido";
                   
                    }

                    //return View();
                }
                else
                {
                    ViewBag.Error = ("El Rut ingresado no es valido");
                }
            }
            ViewBag.NombreDocenciaHospitalaria = new SelectList(db.DocenciaHospitalarias, "NombreDocenciaHospitalaria", "NombreDocenciaHospitalaria");
            ViewBag.InmunizacionId = new SelectList(db.Inmunizacions, "InmunizacionId", "NombreInmunizacion");
            return View(profesionalDocenteGuia);
       }

        [Authorize(Roles = ("Administrador"))]
        // GET: ProfesionalDocenteGuias/Edit/5
        public ActionResult Edit(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           ProfesionalDocenteGuia profesionalDocenteGuia = db.ProfesionalDocenteGuias.Find(id);
           if (profesionalDocenteGuia == null)
           {
               return HttpNotFound();
           }
           //Comentado por si se necesita despues

            //ViewBag.PersonaPersonaId = new SelectList(db.Personas, "PersonaId", "Rut", profesionalDocenteGuia.PersonaPersonaId);
            //ViewBag.DocenciaHospitalariaDocenciaHospitalariaId = new SelectList(db.DocenciaHospitalarias, "DocenciaHospitalariaId", "NombreDocenciaHospitalaria", profesionalDocenteGuia.DocenciaHospitalariaDocenciaHospitalariaId);
            //ViewBag.InmunizacionInmunizacionId = new SelectList(db.Inmunizacions, "InmunizacionId", "NombreInmunizacion", profesionalDocenteGuia.InmunizacionInmunizacionId);

            ViewBag.NombreDocenciaHospitalaria = new SelectList(db.DocenciaHospitalarias, "NombreDocenciaHospitalaria", "NombreDocenciaHospitalaria");
            ViewBag.InmunizacionId = new SelectList(db.Inmunizacions, "InmunizacionId", "NombreInmunizacion");
            return View(profesionalDocenteGuia);
       }

        // POST: ProfesionalDocenteGuias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = ("Administrador"))]
        [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Edit([Bind(Include = "ProfesionalDocenteGuiaId,Profesion,NumeroSuperintendencia,Telefono,Correo,ValorDocente,PersonaPersonaId,DocenciaHospitalariaDocenciaHospitalariaId,InmunizacionInmunizacionId")] ProfesionalDocenteGuia profesionalDocenteGuia)
       {
           if (ModelState.IsValid)
           {
               db.Entry(profesionalDocenteGuia).State = EntityState.Modified;
               db.SaveChanges();
               return RedirectToAction("Index");
           }
            //ViewBag.PersonaPersonaId = new SelectList(db.Personas, "PersonaId", "Rut", profesionalDocenteGuia.PersonaPersonaId);
            //ViewBag.DocenciaHospitalariaDocenciaHospitalariaId = new SelectList(db.DocenciaHospitalarias, "DocenciaHospitalariaId", "NombreDocenciaHospitalaria", profesionalDocenteGuia.DocenciaHospitalariaDocenciaHospitalariaId);
            //ViewBag.InmunizacionInmunizacionId = new SelectList(db.Inmunizacions, "InmunizacionId", "NombreInmunizacion", profesionalDocenteGuia.InmunizacionInmunizacionId);


            ViewBag.NombreDocenciaHospitalaria = new SelectList(db.DocenciaHospitalarias, "NombreDocenciaHospitalaria", "NombreDocenciaHospitalaria");
            ViewBag.InmunizacionId = new SelectList(db.Inmunizacions, "InmunizacionId", "NombreInmunizacion");
            return View(profesionalDocenteGuia);
       }

        [Authorize(Roles = ("Administrador"))]
        // GET: ProfesionalDocenteGuias/Delete/5
        public ActionResult Delete(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           ProfesionalDocenteGuia profesionalDocenteGuia = db.ProfesionalDocenteGuias.Find(id);
           if (profesionalDocenteGuia == null)
           {
               return HttpNotFound();
           }
           return View(profesionalDocenteGuia);
       }

        // POST: ProfesionalDocenteGuias/Delete/5
        [Authorize(Roles = ("Administrador"))]
        [HttpPost, ActionName("Delete")]
       [ValidateAntiForgeryToken]
       public ActionResult DeleteConfirmed(int id)
       {
           ProfesionalDocenteGuia profesionalDocenteGuia = db.ProfesionalDocenteGuias.Find(id);
           db.ProfesionalDocenteGuias.Remove(profesionalDocenteGuia);
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
