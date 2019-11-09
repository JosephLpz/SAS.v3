using SAS.v1.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System;
using System.Web;
using System.Web.Mvc;
using SAS.v1.Services;
using SAS.v1.ClasesNP;

namespace SAS.v1.Controllers
{
    public class AsignacionAlumnosController : Controller
    {

        private ModeloContainer db = new ModeloContainer();

        // GET: AsignacionAlumnos
        public ActionResult Index(int SolicitudId)
        {

            SolicitudDeCupo sol = db.SolicitudDeCupos.Where(s => s.Id == SolicitudId).FirstOrDefault();
            IngresoServices ingreso = new IngresoServices();

            List<SelectListItem> ProfGuia = new List<SelectListItem>();
            List<SelectListItem> ProfSup = new List<SelectListItem>();
            Persona person;


            foreach (var item in db.ProfesionalDocenteGuias)
            {
                person = new Persona();
                person = ingreso.PersonaFindById(item.PersonaPersonaId);

                ProfGuia.Add(new SelectListItem
                {
                    Text = person.Nombre.ToString()+ person.ApPaterno.ToString(),
                    Value = item.ProfesionalDocenteGuiaId.ToString()
                });
            }

            foreach (var item in db.ProfesionalSupervisorSet)
            {
                person = new Persona();
                person = ingreso.PersonaFindById(item.PersonaPersonaId);

                ProfSup.Add(new SelectListItem
                {
                    Text = person.Nombre.ToString() + person.ApPaterno.ToString(),
                    Value = item.ProfesionalSupervisorId.ToString()
                });
            }

            ViewBag.ProfesorSupervisor = ProfSup;
            ViewBag.ProfesorGuia = ProfGuia;

            List<Alumno> alumnos = db.Alumnos.Include(p => p.Persona).Where(p => p.CentroFormador.Carrera.CarreraId == sol.CarreraCarreraId).ToList();


            //List<AlumnosNP> Alumnos = new List<AlumnosNP>();
            //foreach (var item in db.Alumnos.Include(p => p.Persona).Where(p=>p.CentroFormador.Carrera.CarreraId==sol.CarreraCarreraId).ToList())
            //{
            //    AlumnosNP al = new AlumnosNP();
            //    al.alumnos = item;
            //    al.check = false;
                
            //    Alumnos.Add(al);
            //}
            return View(alumnos);
        }

     
        public ActionResult AsignarAlumno(int AlumnoId)
        {

            //string Alumnos = Request.Form["Alumnos"];
            return View();

        }
        // GET: AsignacionAlumnos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AsignacionAlumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AsignacionAlumnos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AsignacionAlumnos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AsignacionAlumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AsignacionAlumnos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AsignacionAlumnos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
