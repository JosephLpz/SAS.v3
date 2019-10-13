﻿using SAS.v1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAS.v1.ClasesNP;
namespace SAS.v1.Services
{
    public class ProyeccionesServices
    {
        ModeloContainer db = new ModeloContainer();
        IngresoServices IngresoS = new IngresoServices();
        public List<DataPoint> CalcularProyeccionPorAsignatura(int id)
        {
            List<DataPoint> resultado=new List<DataPoint>();
            List<Alumno> AlumnosCursantes = new List<Alumno>();
            Asignatura asignatura = BuscarAsignatura(id);
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
            resultado.Add(new DataPoint(asignatura.NombreAsignatura.ToString(),AlumnosCursanteParaCampo.Count()));


            return resultado;
        }

        public List<DataPoint> CalcularProyeccionPorCarrera(int id)
        {
            List<DataPoint> resultado = new List<DataPoint>();

            List<Alumno> AlumnosCursantes = new List<Alumno>();
            Asignatura asignatura = BuscarAsignatura(id);
            Carrera carrera = IngresoS.CarreraFindById(id);
            List<PlanDeEstudio> PlanesPorCarrera = BuscarPlanesDeEstudiPorCarrera(id);
            List<PlanDeEstudio> planesConCampo = new List<PlanDeEstudio>();
            List<PlanDeEstudio> planesPreRequisito = new List<PlanDeEstudio>();
            foreach (var item in PlanesPorCarrera)
            {
                if (Int32.Parse(item.PC)> 0)
                {
                    planesConCampo.Add(item);
                }
            }


            int CantidadDeAlumnosCursantes = 0;

            foreach(var item in planesConCampo)
            {
                //Buscar plan de estudio de asignatura pre requisito
                planesPreRequisito.Add(BuscarPlanDeEstudiosPreRequisto(item.Id));
            }

            //crear clase no persistente para captar el estado del alumno junto con la asignatura
             foreach(var item in planesPreRequisito)
            {
                foreach(var result in item.PlanEstudioAlumno)
                {
                    if (result.EstadoAsignatura.Equals(EstadoAsignatura.Cursando) || result.EstadoAsignatura.Equals(EstadoAsignatura.CursandoEnSegunda)
                    || result.EstadoAsignatura.Equals(EstadoAsignatura.CursandoEnTercera) || result.EstadoAsignatura.Equals(EstadoAsignatura.CursandoEnCuarta))
                {
                    AlumnosCursantes.Add(result.Alumno);
                    CantidadDeAlumnosCursantes += 1;
                }
                }
            }

         
            //cada alumno de el plan de estudio que esta cursando esa asignatura
            //foreach (var item in plan.PlanEstudioAlumno)
            //{
                

            //}
            int[,] ContenedorEficiencia = new int[CantidadDeAlumnosCursantes, 10];
            int count = 0;

            foreach (var result in AlumnosCursantes)
            {
                foreach (var item in result.PlanEstudioAlumno)
                {
                    if (item.EstadoAsignatura == EstadoAsignatura.Aprobado)
                    {
                        ContenedorEficiencia[count, 0] += 1;
                    }
                    else if (item.EstadoAsignatura == EstadoAsignatura.AprobadoEnSegunda)
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

            for (int i = 0; i < AlumnosCursantes.Count; i++)
            {

                for (int j = 0; j < 10; j++)
                {

                    if (ContenedorEficiencia[i, j] > contenedorNumeroMax)
                    {
                        contenedorNumeroMax = ContenedorEficiencia[i, j];
                        PosicionEstado[i] = j + 1;

                    }

                }
                contenedorNumeroMax = -100;

            }
            for (int i = 0; i < PosicionEstado.Length; i++)
            {
                estadoMasprobable.Add((EstadoAsignatura)PosicionEstado[i]);
            }

            int Index = 0;
            List<Alumno> AlumnosCursanteParaCampo = new List<Alumno>();
            foreach (var item in AlumnosCursantes)
            {
                if (estadoMasprobable[Index] == EstadoAsignatura.Aprobado)
                {
                    AlumnosCursanteParaCampo.Add(item);
                }
            }
            resultado.Add(new DataPoint(asignatura.NombreAsignatura.ToString(), AlumnosCursanteParaCampo.Count()));


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

        public Asignatura BuscarAsignatura(int Id)
        {
            Asignatura asignatura = (from a in db.Asignaturas where a.Id == Id select a).FirstOrDefault();
            return asignatura;
        }
        public Alumno BuscarAlumno(int Id)
        {
            Alumno alumno = (from a in db.Alumnos where a.AlumnoId == Id select a).FirstOrDefault();
            return alumno;
        }

        public List<PlanDeEstudio>BuscarPlanesDeEstudiPorCarrera(int id)
        {
            List<PlanDeEstudio> planes = (from p in db.PlanDeEstudios where p.CarreraCarreraId == id select p).ToList();

            return planes;
        }
        
    }
}