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
using SAS.v1.ClasesNP;
using SAS.v1.Utils;

namespace SAS.v1.Controllers
{
    public class AlumnosController : Controller
    {
    
       private ModeloContainer db = new ModeloContainer();

        // GET: Alumnos
        [Authorize(Roles ="Administrador,JefeDeCarrera")]
        [HttpGet]
        public ActionResult Index(int? id)
       {
           AlumnosServices ListaAlumno = new AlumnosServices();
            ViewBag.Identificador = id;
            //List<AlumnoNP> alumnos = ListaAlumno.ListaAlumnos(null);
            
            var alumnos = db.Alumnos.Include(p => p.Persona);
           return View(alumnos);
       }
        [Authorize(Roles = "Administrador,JefeDeCarrera")]
        [HttpPost]
        public ActionResult Index(string Filtro)
        {
            //AlumnosServices ListaAlumno = new AlumnosServices();
            List<Alumno> alumnos = new List<Alumno>();
            //List<AlumnoNP> alumnos = ListaAlumno.ListaAlumnos(Filtro);
            if (Filtro == null || Filtro == "")
            {
                alumnos = db.Alumnos.Include(p => p.Persona).ToList();
            } else
            {
                alumnos = db.Alumnos.Include(p => p.Persona).Where(p => p.Persona.Rut.Contains(Filtro) || p.Persona.Nombre.Contains(Filtro) 
                || p.Persona.ApPaterno.Contains(Filtro)).ToList();
            }
            
            return View(alumnos);
        }
        [Authorize(Roles = "Administrador,JefeDeCarrera")]
        // GET: Alumnos/Details/5
        public ActionResult Details(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
          //// Alumno alumno = db.Alumnos.Find(id);
          // if (alumno == null)
          // {
          //     return HttpNotFound();
          // }
                           AlumnosServices AlumnoServ = new AlumnosServices();
                           CampoClinicoAlumno CampoAlumnos = AlumnoServ.DatosCampoClinico(id);

           return View(CampoAlumnos);
       }
        [Authorize(Roles = "Administrador,JefeDeCarrera")]
        public ActionResult DetalleCamposClinicos(int? id)
        {
            //AlumnosServices CampoAlumnos = new AlumnosServices();
            //List<CampoClinicoAlumno> listaCamposAlumnos = CampoAlumnos.DatosCampoClinicoAlumnos(id);
            Alumno listaCamposAlumnos = new Alumno();
            listaCamposAlumnos = db.Alumnos.Find(id);
            return View(listaCamposAlumnos);

        }
        [Authorize(Roles = "Administrador,JefeDeCarrera")]
        public ActionResult CamposClinicosSemestres(int? id,string selectValue)
        {
            //AlumnosServices CampoAlumnos = new AlumnosServices();
            //List<CampoClinicoAlumno> listaCamposAlumnos = CampoAlumnos.DatosCampoClinicoAlumnos(id);
            
            //Alumno listaCamposAlumnos = new Alumno();
            //listaCamposAlumnos =(Alumno) db.Alumnos.Where();
            List<CampoClinicoAlumno> CamposAlumnos = new List<CampoClinicoAlumno>();
            CamposAlumnos = db.CampoClinicoAlumnos.Where(a => a.Alumno.AlumnoId == id && a.Semestre.NombreSemestre == selectValue).ToList();
            return View(CamposAlumnos);

        }
        [Authorize(Roles = "Administrador,JefeDeCarrera")]
        // GET: MantenedorAlumnos/Create
        public ActionResult Create()
        {
            ViewBag.CarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera");
            ViewBag.NombreCentroFormadorId = new SelectList(db.NombreCentroFormadors, "NombreCentroFormadorId", "NombreCentroFormador1");
            ViewBag.CursoNivelId = new SelectList(db.CursosNiveles, "CursoNivelId", "NombreCurso");
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano");
            ViewBag.InmunizacionId = new SelectList(db.Inmunizacions, "InmunizacionId", "NombreInmunizacion");
            return View();
        }

        // POST: MantenedorAlumnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador,JefeDeCarrera")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Rut,Dv,Nombre,ApPaterno,ApMaterno,CursoNivelId,Observaciones,CarreraId,NombreCentroFormadorId,AnioId,InmunizacionId")] Persona persona,CursoNivel curso,Alumno alumno,Carrera carrera, NombreCentroFormador nombreCentroFormador,int AnioId,int InmunizacionId)
        {
            IngresoServices ingresoDatos = new IngresoServices();
            CursoAlumno cursoAlumno = new CursoAlumno();
            UtilRut ValidacionRut = new UtilRut();
          

            if (ModelState.IsValid)
            {
               
                if (ValidacionRut.validarRut((persona.Rut + "-" + persona.Dv)))
                {
                    
                    persona = ingresoDatos.CrearPersona(persona,1);
                CentroFormador centroFormador = ingresoDatos.CrearCentroFormador(nombreCentroFormador.NombreCentroFormadorId,carrera.CarreraId,AnioId,1);

                if (alumno.Observaciones==null)
                {
                    alumno.Observaciones = "";
                }
                    
                alumno = ingresoDatos.CrearAlumno(persona, alumno, centroFormador,1);
                    Inmunizacion inmunizacion = ingresoDatos.InmunizacionFindById(InmunizacionId);
                    ingresoDatos.CrearInmunizacionAlumno(alumno, inmunizacion);
                cursoAlumno = ingresoDatos.CrearCursoAlumno(alumno, curso);
                
                return RedirectToAction("Create");
                }else
                    {
                    ViewBag.Error = ("El Rut ingresado no es valido");
                    }

            }
            ViewBag.InmunizacionId = new SelectList(db.Inmunizacions, "InmunizacionId", "NombreInmunizacion");
            ViewBag.CarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera");
            ViewBag.NombreCentroFormadorId = new SelectList(db.NombreCentroFormadors, "NombreCentroFormadorId", "NombreCentroFormador1");
            ViewBag.CursoNivelId = new SelectList(db.CursosNiveles, "CursoNivelId", "NombreCurso");
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano");
            return View(alumno);
        }

        // GET: MantenedorAlumnos/Edit/5
        [Authorize(Roles = "Administrador,JefeDeCarrera")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            ViewBag.InmunizacionId = new SelectList(db.Inmunizacions, "InmunizacionId", "NombreInmunizacion");
            ViewBag.CarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera");
            ViewBag.NombreCentroFormadorId = new SelectList(db.NombreCentroFormadors, "NombreCentroFormadorId", "NombreCentroFormador1");
            ViewBag.CursoNivelId = new SelectList(db.CursosNiveles, "CursoNivelId", "NombreCurso");
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano");
            return View(alumno);
        }

        // POST: MantenedorAlumnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador,JefeDeCarrera")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Rut,Dv,Nombre,ApPaterno,ApMaterno,CursoNivelId,Observaciones,CarreraId,NombreCentroFormadorId, AnioId")] Persona persona,CursoNivel curso, Alumno alumno, Carrera carrera, NombreCentroFormador nombreCentroFormador,int AnioId)
        {
            IngresoServices ingreso = new IngresoServices();
            CursoAlumno cursoAlumno = new CursoAlumno();

            // obtengo el centro formador
            CentroFormador centroFormador = new CentroFormador();
            centroFormador = ingreso.BuscarCentroFormador(nombreCentroFormador.NombreCentroFormadorId,carrera.CarreraId,AnioId);

            // Utilizo metodo de la clase ingresoServices para poder ingresar y modificar los datos con Estado 1 que indica actualizar
            if (ModelState.IsValid)
            {
                //llamo al metodo crear persona para modificar los datos de persona con el estado 1 de modificar y utilizo el mismo objeto para enviarselo a al metodo de alumno
                persona = ingreso.CrearPersona(persona,1);
                //objeto ingreso el cual se comunica con la clase Ingreso services para modificar los datos
                alumno=ingreso.CrearAlumno(persona, alumno, centroFormador, 1);
                ingreso.CrearCursoAlumno(alumno, curso);
                return RedirectToAction("Index");
            }
            ViewBag.InmunizacionId = new SelectList(db.Inmunizacions, "InmunizacionId", "NombreInmunizacion");
            ViewBag.CarreraId = new SelectList(db.Carreras, "CarreraId", "NombreCarrera");
            ViewBag.NombreCentroFormadorId = new SelectList(db.NombreCentroFormadors, "NombreCentroFormadorId", "NombreCentroFormador1");
            ViewBag.CursoNivelId = new SelectList(db.CursosNiveles, "CursoNivelId", "NombreCurso");
            ViewBag.AnioId = new SelectList(db.Anios, "Id", "Ano");
            return View(alumno);
        }

        // GET: MantenedorAlumnos/Delete/5
        [Authorize(Roles = "Administrador,JefeDeCarrera")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: MantenedorAlumnos/Delete/5
        [Authorize(Roles = "Administrador,JefeDeCarrera")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IngresoServices ingreso = new IngresoServices();
            List<CampoClinicoAlumno> campoClinicoAlumno = db.CampoClinicoAlumnos.Where(c => c.AlumnoAlumnoId == id).ToList();
            foreach(var item in campoClinicoAlumno)
            {
                db.CampoClinicoAlumnos.Remove(item);
            }

            Alumno alumno = db.Alumnos.Find(id);
            db.Alumnos.Remove(alumno);
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
