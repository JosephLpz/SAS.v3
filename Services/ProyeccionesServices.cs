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
        public int CalcularProyeccionPorAsignatura(int id)
        {
            int resultado=0;
            List<Alumno> AlumnosCursantes = new List<Alumno>();
            int CantidadDeAlumnosCursantes=0;
            //Buscar plan de estudio de asignatura pre requisito
            PlanDeEstudio plan = BuscarPlanDeEstudioAsPreRequisto(id);

            //cada alumno de el plan de estudio que esta cursando esa asignatura
            foreach(var item in plan.PlanEstudioAlumno)
            {
                if (item.EstadoAsignatura.Equals(EstadoAsignatura.Cursando))
                {
                    AlumnosCursantes.Add(item.Alumno);
                    CantidadDeAlumnosCursantes += 1;
                }

            }
            foreach(var result in AlumnosCursantes)
            {
                foreach(var item in result.PlanEstudioAlumno)
                {

                }
            }
            return resultado;
        }
       
        public PlanDeEstudio BuscarPlanDeEstudioAsPreRequisto(int Id)
        {
            //Buscar asignatura de campo clinico
            PlanDeEstudio plan = (from p in db.PlanDeEstudios where p.AsignaturaId == Id select p).FirstOrDefault();


            //Buscar asignatura pre requisito de la anterior
            plan = (from p in db.PlanDeEstudios where p.Asignatura.NombreAsignatura.ToUpper() == plan.AsignaturaPreRequisito.ToUpper() select p).FirstOrDefault();

            return plan;

        }

        public Alumno BuscarAlumno(int Id)
        {
            Alumno alumno = (from a in db.Alumnos where a.AlumnoId == Id select a).FirstOrDefault();
            return alumno;
        }

        
    }
}