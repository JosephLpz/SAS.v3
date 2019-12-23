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
    public class CampoClinicoAlumnosController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: CampoClinicoAlumnos
        [Authorize(Roles =("Administrador,JefeDeCarrera"))]
        [HttpGet]
        public ActionResult Index()
        {
            var campoClinicoAlumnos = db.CampoClinicoAlumnos.Include(c => c.Alumno).Include(c => c.Periodo).Include(c => c.Asignatura).Include(c => c.Semestre).Include(c => c.Anio).Include(c => c.NombreCampoClinico).Include(c => c.ProfesionalDocenteGuia);
            return View(campoClinicoAlumnos.ToList());
        }
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        [HttpPost]
        public ActionResult Index(string filtro,string semestre)
        {
            List<CampoClinicoAlumno> campoClinicoAlumnos = new List<CampoClinicoAlumno>();
            if (filtro == "" && semestre != "")
            {
                campoClinicoAlumnos = db.CampoClinicoAlumnos.Include(c => c.Alumno).Include(c => c.Periodo).Include(c => c.Asignatura).Include(c => c.Semestre).Include(c => c.Anio).Include(c => c.NombreCampoClinico).Include(c => c.ProfesionalDocenteGuia).Where(c=>c.Semestre.NombreSemestre==semestre).ToList();

            }else if (semestre == "" && filtro != "")
            {
                campoClinicoAlumnos = db.CampoClinicoAlumnos.Include(c => c.Alumno).Include(c => c.Periodo).Include(c => c.Asignatura).Include(c => c.Semestre).Include(c => c.Anio).Include(c => c.NombreCampoClinico).Include(c => c.ProfesionalDocenteGuia).Where(c => c.Alumno.Persona.Nombre.Contains(filtro)
                ||c.Alumno.Persona.Rut.Contains(filtro)||c.Alumno.Persona.ApPaterno.Contains(filtro)||c.Asignatura.NombreAsignatura.Contains(filtro)||c.NombreCampoClinico.NombreCampo.Contains(filtro)||
                c.NombreCampoClinico.Institucion.NombreInstitucion.Contains(filtro)||c.Anio.Ano.Contains(filtro)).ToList();

            }else
            {
                campoClinicoAlumnos = db.CampoClinicoAlumnos.Include(c => c.Alumno).Include(c => c.Periodo).Include(c => c.Asignatura).Include(c => c.Semestre).Include(c => c.Anio).Include(c => c.NombreCampoClinico).Include(c => c.ProfesionalDocenteGuia).Where(c => c.Alumno.Persona.Nombre.Contains(filtro)
                || c.Alumno.Persona.Rut.Contains(filtro) || c.Alumno.Persona.ApPaterno.Contains(filtro) ||c.Asignatura.NombreAsignatura.Contains(filtro) || c.NombreCampoClinico.NombreCampo.Contains(filtro) ||
                c.NombreCampoClinico.Institucion.NombreInstitucion.Contains(filtro)&&c.Semestre.NombreSemestre==semestre).ToList();
            }
            // var campoClinicoAlumnos = db.CampoClinicoAlumnos.Include(c => c.Alumno).Include(c => c.ProfesionalSupervidor).Include(c => c.Periodo).Include(c => c.Asignatura).Include(c => c.Semestre).Include(c => c.Anio).Include(c => c.CampoClinico).Include(c => c.ProfesionalDocenteGuia);
            return View(campoClinicoAlumnos.ToList());
        }
        [Authorize(Roles = ("Administrador,JefeDeCarrera"))]
        // GET: CampoClinicoAlumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampoClinicoAlumno campoClinicoAlumno = db.CampoClinicoAlumnos.Find(id);
            if (campoClinicoAlumno == null)
            {
                return HttpNotFound();
            }
            return View(campoClinicoAlumno);
        }

        //// GET: CampoClinicoAlumnos/Create
        //public ActionResult Create()
        //{
        //    ViewBag.AlumnoAlumnoId = new SelectList(db.Alumnos, "AlumnoId", "CursoNivel");
        //    ViewBag.ProfesionalSupervidorProfesionalSupervisorId = new SelectList(db.ProfesionalSupervisorSet, "ProfesionalSupervisorId", "Observaciones");
        //    ViewBag.PeriodoPeriodoId = new SelectList(db.Periodos, "PeriodoId", "PeriodoId");
        //    ViewBag.AsignaturaId = new SelectList(db.Asignaturas, "Id", "NombreAsignatura");
        //    ViewBag.SemestreId = new SelectList(db.Semestres, "Id", "NombreSemestre");
        //    ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano");
        //    ViewBag.CampoClinicoId = new SelectList(db.CampoClinicos, "Id", "Id");
        //    ViewBag.ProfesionalDocenteGuiaProfesionalDocenteGuiaId = new SelectList(db.ProfesionalDocenteGuias, "ProfesionalDocenteGuiaId", "Profesion");
        //    return View();
        //}

        //// POST: CampoClinicoAlumnos/Create
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,AlumnoAlumnoId,ProfesionalSupervidorProfesionalSupervisorId,UnidadDeServicioUnidadDeServicioId,PeriodoPeriodoId,AsignaturaId,SemestreId,AnioId,CampoClinicoId,ProfesionalDocenteGuiaProfesionalDocenteGuiaId")] CampoClinicoAlumno campoClinicoAlumno)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CampoClinicoAlumnos.Add(campoClinicoAlumno);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.AlumnoAlumnoId = new SelectList(db.Alumnos, "AlumnoId", "CursoNivel", campoClinicoAlumno.AlumnoAlumnoId);
        //    ViewBag.ProfesionalSupervidorProfesionalSupervisorId = new SelectList(db.ProfesionalSupervisorSet, "ProfesionalSupervisorId", "Observaciones", campoClinicoAlumno.ProfesionalSupervidorProfesionalSupervisorId);
        //    ViewBag.PeriodoPeriodoId = new SelectList(db.Periodos, "PeriodoId", "PeriodoId", campoClinicoAlumno.PeriodoPeriodoId);
        //    ViewBag.AsignaturaId = new SelectList(db.Asignaturas, "Id", "NombreAsignatura", campoClinicoAlumno.AsignaturaId);
        //    ViewBag.SemestreId = new SelectList(db.Semestres, "Id", "NombreSemestre", campoClinicoAlumno.SemestreId);
        //    ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano", campoClinicoAlumno.AnioId);
        //    ViewBag.CampoClinicoId = new SelectList(db.CampoClinicos, "Id", "Id", campoClinicoAlumno.CampoClinicoId);
        //    ViewBag.ProfesionalDocenteGuiaProfesionalDocenteGuiaId = new SelectList(db.ProfesionalDocenteGuias, "ProfesionalDocenteGuiaId", "Profesion", campoClinicoAlumno.ProfesionalDocenteGuiaProfesionalDocenteGuiaId);
        //    return View(campoClinicoAlumno);
        //}

        //// GET: CampoClinicoAlumnos/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CampoClinicoAlumno campoClinicoAlumno = db.CampoClinicoAlumnos.Find(id);
        //    if (campoClinicoAlumno == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.AlumnoAlumnoId = new SelectList(db.Alumnos, "AlumnoId", "CursoNivel", campoClinicoAlumno.AlumnoAlumnoId);
        //    ViewBag.ProfesionalSupervidorProfesionalSupervisorId = new SelectList(db.ProfesionalSupervisorSet, "ProfesionalSupervisorId", "Observaciones", campoClinicoAlumno.ProfesionalSupervidorProfesionalSupervisorId);
        //    ViewBag.PeriodoPeriodoId = new SelectList(db.Periodos, "PeriodoId", "PeriodoId", campoClinicoAlumno.PeriodoPeriodoId);
        //    ViewBag.AsignaturaId = new SelectList(db.Asignaturas, "Id", "NombreAsignatura", campoClinicoAlumno.AsignaturaId);
        //    ViewBag.SemestreId = new SelectList(db.Semestres, "Id", "NombreSemestre", campoClinicoAlumno.SemestreId);
        //    ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano", campoClinicoAlumno.AnioId);
        //    ViewBag.CampoClinicoId = new SelectList(db.CampoClinicos, "Id", "Id", campoClinicoAlumno.CampoClinicoId);
        //    ViewBag.ProfesionalDocenteGuiaProfesionalDocenteGuiaId = new SelectList(db.ProfesionalDocenteGuias, "ProfesionalDocenteGuiaId", "Profesion", campoClinicoAlumno.ProfesionalDocenteGuiaProfesionalDocenteGuiaId);
        //    return View(campoClinicoAlumno);
        //}

        //// POST: CampoClinicoAlumnos/Edit/5
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,AlumnoAlumnoId,ProfesionalSupervidorProfesionalSupervisorId,UnidadDeServicioUnidadDeServicioId,PeriodoPeriodoId,AsignaturaId,SemestreId,AnioId,CampoClinicoId,ProfesionalDocenteGuiaProfesionalDocenteGuiaId")] CampoClinicoAlumno campoClinicoAlumno)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(campoClinicoAlumno).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.AlumnoAlumnoId = new SelectList(db.Alumnos, "AlumnoId", "CursoNivel", campoClinicoAlumno.AlumnoAlumnoId);
        //    ViewBag.ProfesionalSupervidorProfesionalSupervisorId = new SelectList(db.ProfesionalSupervisorSet, "ProfesionalSupervisorId", "Observaciones", campoClinicoAlumno.ProfesionalSupervidorProfesionalSupervisorId);
        //    ViewBag.PeriodoPeriodoId = new SelectList(db.Periodos, "PeriodoId", "PeriodoId", campoClinicoAlumno.PeriodoPeriodoId);
        //    ViewBag.AsignaturaId = new SelectList(db.Asignaturas, "Id", "NombreAsignatura", campoClinicoAlumno.AsignaturaId);
        //    ViewBag.SemestreId = new SelectList(db.Semestres, "Id", "NombreSemestre", campoClinicoAlumno.SemestreId);
        //    ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano", campoClinicoAlumno.AnioId);
        //    ViewBag.CampoClinicoId = new SelectList(db.CampoClinicos, "Id", "Id", campoClinicoAlumno.CampoClinicoId);
        //    ViewBag.ProfesionalDocenteGuiaProfesionalDocenteGuiaId = new SelectList(db.ProfesionalDocenteGuias, "ProfesionalDocenteGuiaId", "Profesion", campoClinicoAlumno.ProfesionalDocenteGuiaProfesionalDocenteGuiaId);
        //    return View(campoClinicoAlumno);
        //}

        //// GET: CampoClinicoAlumnos/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CampoClinicoAlumno campoClinicoAlumno = db.CampoClinicoAlumnos.Find(id);
        //    if (campoClinicoAlumno == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(campoClinicoAlumno);
        //}

        //// POST: CampoClinicoAlumnos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CampoClinicoAlumno campoClinicoAlumno = db.CampoClinicoAlumnos.Find(id);
        //    db.CampoClinicoAlumnos.Remove(campoClinicoAlumno);
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
