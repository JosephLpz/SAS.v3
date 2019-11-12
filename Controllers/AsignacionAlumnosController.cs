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
            ViewBag.Solicitud = sol.Id;
            List<Alumno> alumnos = db.Alumnos.Include(p => p.Persona).Where(p => p.CentroFormador.Carrera.CarreraId == sol.CarreraCarreraId).ToList();


            
            return View(alumnos);
        }

     
        public ActionResult AsignarAlumno(int AlumnoId, int Solicitud)
        {
            Alumno alumno = db.Alumnos.Include(p=>p.Persona).Where(a => a.AlumnoId == AlumnoId).FirstOrDefault();
            ViewBag.Alumno = alumno;
            ViewBag.AlumnoId = alumno.AlumnoId;
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
                    Text = person.Nombre.ToString() + person.ApPaterno.ToString(),
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
            ViewBag.Solicitud = Solicitud;

            ViewBag.Semestre = new SelectList(db.Semestres, "Id", "NombreSemestre");
            ViewBag.Ano = new SelectList(db.Anios, "Id", "Ano");
            return View();

        }
        [HttpPost]
        public ActionResult AsignarAlumno(string[]check, string ProfesorSupervisor, string ProfesorGuia, int Solicitud,int AlumnoId,int Semestre, int Ano)
        {
            IngresoServices ingreso = new IngresoServices();
            int profesorGuiaId = Int32.Parse(ProfesorGuia);
            int profesorSupervisorId = Int32.Parse(ProfesorSupervisor);
            ProfesionalDocenteGuia DocenteGuia = db.ProfesionalDocenteGuias.Include(p=>p.Persona).Where(p => p.ProfesionalDocenteGuiaId== profesorGuiaId).FirstOrDefault();
            ProfesionalSupervisor DocenteSupervisor = db.ProfesionalSupervisorSet.Include(p => p.Persona).Where(p => p.ProfesionalSupervisorId == profesorSupervisorId).FirstOrDefault();
            SolicitudDeCupo SolicitudCupo = db.SolicitudDeCupos.Where(s => s.Id == Solicitud).FirstOrDefault();
            Alumno alumno = db.Alumnos.Include(p => p.Persona).Where(a => a.AlumnoId == AlumnoId).FirstOrDefault();
            Anio anio = db.Anios.Where(a => a.Id == Ano).FirstOrDefault();
            Semestre semestre = db.Semestres.Where(s => s.Id == Semestre).FirstOrDefault();

           CampoClinicoAlumno campoClinico= ingreso.CrearCampoClinicoAlumno(alumno, DocenteGuia, DocenteSupervisor, SolicitudCupo.Periodo, SolicitudCupo.Asignatura, semestre, anio, SolicitudCupo.CampoClinico);
           
                foreach(var result in check)
                {                  
                        ingreso.CrearCampoClinicoAlumnosDias(campoClinico,result);               
                }
            
      
            return Redirect("Index?SolicitudId="+Solicitud);
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
