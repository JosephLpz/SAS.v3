using SAS.v1.Models;
using System;
using System.Collections;
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
            PlanDeEstudio plan = BuscarPlanDeEstudiosPreRequisto(id);
            
            //cada alumno de el plan de estudio que esta cursando esa asignatura
            foreach(var item in plan.PlanEstudioAlumno)
            {
                if (item.EstadoAsignatura.Equals(EstadoAsignatura.Cursando) || item.EstadoAsignatura.Equals(EstadoAsignatura.CursandoEnSegunda)
                    || item.EstadoAsignatura.Equals(EstadoAsignatura.CursandoEnTercera) || item.EstadoAsignatura.Equals(EstadoAsignatura.CursandoEnCuarta))
                {
                    AlumnosCursantes.Add(item.Alumno);
                    CantidadDeAlumnosCursantes += 1;
                }

            }
            int[,] ContenedorEficiencia = new int[CantidadDeAlumnosCursantes,10];
            int count = 0;
            
            foreach (var result in AlumnosCursantes)
            {
                foreach(var item in result.PlanEstudioAlumno)
                {
                    if (item.EstadoAsignatura == EstadoAsignatura.Aprobado)
                    {
                        ContenedorEficiencia[count, 0] += 1;
                    }else if (item.EstadoAsignatura == EstadoAsignatura.AprobadoEnSegunda)
                    {
                        ContenedorEficiencia[count, 1] += 1;
                    }
                    else if (item.EstadoAsignatura == EstadoAsignatura.AprobadoEnTercera)
                    {
                        ContenedorEficiencia[count, 2] += 1;
                    }
                    else if (item.EstadoAsignatura == EstadoAsignatura.AprobadoEnCuarta)
                    {
                        ContenedorEficiencia[count, 3] += 1;
                    }
                    else if (item.EstadoAsignatura == EstadoAsignatura.Cursando)
                    {
                        ContenedorEficiencia[count, 4] += 1;
                    }
                    else if (item.EstadoAsignatura == EstadoAsignatura.CursandoEnSegunda)
                    {
                        ContenedorEficiencia[count, 5] += 1;
                    }
                    else if (item.EstadoAsignatura == EstadoAsignatura.CursandoEnTercera)
                    {
                        ContenedorEficiencia[count, 6] += 1;
                    }
                    else if (item.EstadoAsignatura == EstadoAsignatura.CursandoEnCuarta)
                    {
                        ContenedorEficiencia[count, 7] += 1;
                    }
                    else if (item.EstadoAsignatura == EstadoAsignatura.ReprobadoYNoInscrito)
                    {
                        ContenedorEficiencia[count, 8] += 1;
                    }
                    else if (item.EstadoAsignatura == EstadoAsignatura.ReprobadoYNoInscritoSegunda)
                    {
                        ContenedorEficiencia[count, 9] += 1;
                    }
                    else if (item.EstadoAsignatura == EstadoAsignatura.ReprobadoYNoInscritoTercera)
                    {
                        ContenedorEficiencia[count, 10] += 1;
                    }

                }
                count += 1;
            }
            List<EstadoAsignatura> estadoMasprobable = new List<EstadoAsignatura>();
            int[] PosicionEstado = new int[AlumnosCursantes.Count];
            int contenedorNumeroMax = -100;
       
            for(int i = 0; i < AlumnosCursantes.Count; i++)
            {
               
                for(int j = 0; j < 10; j++)
                {
                    
                        if (ContenedorEficiencia[i, j] > contenedorNumeroMax)
                        {
                        contenedorNumeroMax = ContenedorEficiencia[i, j];
                            PosicionEstado[i] = j + 1;
                            
                        }
                   
                }
                contenedorNumeroMax = -100;
                
            }
            for(int i = 0; i < PosicionEstado.Length; i++)
            {
                estadoMasprobable.Add((EstadoAsignatura)PosicionEstado[i]);
            }

            int Index=0;
            List<Alumno> AlumnosCursanteParaCampo = new List<Alumno>();
            foreach(var item in AlumnosCursantes)
            {
                if (estadoMasprobable[Index] == EstadoAsignatura.Aprobado)
                {
                    AlumnosCursanteParaCampo.Add(item);
                }
            }
            resultado = AlumnosCursanteParaCampo.Count();
            return resultado;
        }
       
        public PlanDeEstudio BuscarPlanDeEstudiosPreRequisto(int Id)
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