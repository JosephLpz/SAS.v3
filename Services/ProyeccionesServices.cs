using SAS.v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAS.v1.Services
{
    public class ProyeccionesServices
    {
        ModeloContainer db = new ModeloContainer();
        IngresoServices IngresoS = new IngresoServices();
        public int CalcularProyeccionPorAsignatura(Asignatura asignaturas)
        {
            int resultado=0;
            int TotalAlumnosCursantes=0;
            int AsignaturasAprobadasAlumno = 0;
            List<PlanEstudioAlumno> planEstudioAlumno = GetPlanesEstudio(asignaturas);
            List<Alumno> Alumnos = new List<Alumno>();
            IngresoServices AlumnoService = new IngresoServices();
            foreach(var item in planEstudioAlumno)
            {
                
                if (item.EstadoAsignatura==EstadoAsignatura.Cursando)
                {
                Alumnos.Add(BuscarAlumno(item.AlumnoAlumnoId));
                TotalAlumnosCursantes += 1;
                }
                
            }
            foreach(var item in Alumnos)
            {
                foreach(PlanEstudioAlumno plan in item.PlanEstudioAlumno)
                {
                    if (plan.EstadoAsignatura == EstadoAsignatura.Aprobado)
                    {
                        AsignaturasAprobadasAlumno += 1;
                    }
                }
            }


            return resultado;
        }
        public List<PlanEstudioAlumno> GetPlanesEstudio(Asignatura asignatura)
        {
           // RequisitosAsignatura AsignaturaCampo = new RequisitosAsignatura();
           // AsignaturaCampo = (from r in db.RequisitosAsignaturas where r.AsignaturaId == asignatura.Id select r).FirstOrDefault();

           // Asignatura asignaturaPreReq = new Asignatura();

           // asignaturaPreReq.NombreAsignatura = AsignaturaCampo.AsignaturaPreRequisito;

           // asignaturaPreReq = IngresoS.BuscarAsignatura(asignaturaPreReq);

           // RequisitosAsignatura AsignaturaPreRequisitoCampo = new RequisitosAsignatura();
           // AsignaturaPreRequisitoCampo = (from r in db.RequisitosAsignaturas where r.AsignaturaId == asignaturaPreReq.Id select r).FirstOrDefault();

           //PlanDeEstudio planesDeEstudio = new PlanDeEstudio();
           // planesDeEstudio=(from p in db.PlanDeEstudios where p.RequisitosAsignaturaId== AsignaturaPreRequisitoCampo.Id select p).FirstOrDefault();

           List<PlanEstudioAlumno> planAlumno = new List<PlanEstudioAlumno>();
            //planAlumno = (from a in db.PlanEstudioAlumnos where a.PlanDeEstudioId == planesDeEstudio.Id select a).ToList();
            return planAlumno;
        }
        public Alumno BuscarAlumno(int Id)
        {
            Alumno alumno = (from a in db.Alumnos where a.AlumnoId == Id select a).FirstOrDefault();
            return alumno;
        }

        
    }
}