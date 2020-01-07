using SAS.v1.Models;
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
        public List<DataPointAlumno> CalcularProyeccionPorAsignatura(int id)
        {
            List<DataPointAlumno> resultado = new List<DataPointAlumno>();
            List<Alumno> AlumnosCursantes = new List<Alumno>();
            Asignatura asignatura = BuscarAsignatura(id);
            int CantidadDeAlumnosCursantes = 0;
            //Buscar plan de estudio de asignatura pre requisito
            PlanDeEstudio plan = BuscarPlanDeEstudiosPreRequisto(id);
            if (plan == null)
            {
                //Buscar semestre anterior para capturar a alumnos que son posibles cursantes que estan cursando en el semestre o anio anterior 
                plan = BuscarPlanDeEstudios(asignatura.Id);
                Semestre semestre = BuscarSemestre(plan.SemestreId);
                int semestreAnterior;
                if (Int32.Parse(semestre.NombreSemestre) % 2 == 0)
                {
                    semestreAnterior = Int32.Parse(semestre.NombreSemestre) - 2;
                    if (semestreAnterior == 0 || semestreAnterior < 1)
                    {
                        semestreAnterior = 1;
                    }
                }
                else
                {
                    semestreAnterior = Int32.Parse(semestre.NombreSemestre) - 1;
                    if (semestreAnterior == 0 || semestreAnterior < 1)
                    {
                        semestreAnterior = 1;
                    }
                }
                semestre = BuscarNombreSemestre(semestreAnterior.ToString());
                foreach (var item in db.PlanDeEstudios.Where(p => p.SemestreId == semestre.Id))
                {
                    foreach (var result in item.PlanEstudioAlumno)
                    {
                        if (result.EstadoAsignatura.Equals(EstadoAsignatura.Cursando) || result.EstadoAsignatura.Equals(EstadoAsignatura.CursandoEnSegunda)
                        || result.EstadoAsignatura.Equals(EstadoAsignatura.CursandoEnTercera) || result.EstadoAsignatura.Equals(EstadoAsignatura.CursandoEnCuarta))
                        {
                            if (AlumnosCursantes.Contains(result.Alumno))
                            {

                            }
                            else
                            {
                                AlumnosCursantes.Add(result.Alumno);
                                CantidadDeAlumnosCursantes += 1;
                            }

                        }
                    }
                }


                int[,] ContenedorEficiencia = new int[CantidadDeAlumnosCursantes, 11];
                int count = 0;

                #region comentario util
                //foreach (var result in AlumnosCursantes)
                //{
                //    foreach (var item in result.PlanEstudioAlumno)
                //    {
                //        if (item.EstadoAsignatura == EstadoAsignatura.Aprobado)
                //        {
                //            ContenedorEficiencia[count, 0] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.AprobadoEnSegunda)
                //        {
                //            ContenedorEficiencia[count, 1] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.AprobadoEnTercera)
                //        {
                //            ContenedorEficiencia[count, 2] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.AprobadoEnCuarta)
                //        {
                //            ContenedorEficiencia[count, 3] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.Cursando)
                //        {
                //            ContenedorEficiencia[count, 4] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.CursandoEnSegunda)
                //        {
                //            ContenedorEficiencia[count, 5] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.CursandoEnTercera)
                //        {
                //            ContenedorEficiencia[count, 6] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.CursandoEnCuarta)
                //        {
                //            ContenedorEficiencia[count, 7] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.ReprobadoYNoInscrito)
                //        {
                //            ContenedorEficiencia[count, 8] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.ReprobadoYNoInscritoSegunda)
                //        {
                //            ContenedorEficiencia[count, 9] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.ReprobadoYNoInscritoTercera)
                //        {
                //            ContenedorEficiencia[count, 10] += 1;
                //        }

                //    }
                //    count += 1;
                //}
                //List<EstadoAsignatura> estadoMasprobable = new List<EstadoAsignatura>();
                //int[] PosicionEstado = new int[AlumnosCursantes.Count];
                //int contenedorNumeroMax = -100;

                //for (int i = 0; i < AlumnosCursantes.Count; i++)
                //{

                //    for (int j = 0; j < 10; j++)
                //    {

                //        if (ContenedorEficiencia[i, j] > contenedorNumeroMax)
                //        {
                //            contenedorNumeroMax = ContenedorEficiencia[i, j];
                //            PosicionEstado[i] = j + 1;

                //        }

                //    }
                //    contenedorNumeroMax = -100;

                //}
                //for (int i = 0; i < PosicionEstado.Length; i++)
                //{
                //    estadoMasprobable.Add((EstadoAsignatura)PosicionEstado[i]);
                //}

                //int Index = 0;
                //List<Alumno> AlumnosCursanteParaCampo = new List<Alumno>();
                //foreach (var item in AlumnosCursantes)
                //{
                //    if (estadoMasprobable[Index] == EstadoAsignatura.Aprobado)
                //    {
                //        AlumnosCursanteParaCampo.Add(item);
                //    }
                //    Index += 1;
                //}
                //DataPoint dataPoint = new DataPoint(asignatura.NombreAsignatura.ToString(), AlumnosCursanteParaCampo.Count());
                //resultado.Add(new DataPointAlumno(dataPoint, AlumnosCursanteParaCampo));
                #endregion
                resultado = ProyectarAlumnos(AlumnosCursantes, asignatura);

            }
            else
            {

                #region comentario util
                //cada alumno de el plan de estudio que esta cursando esa asignatura
                //foreach (var item in plan.PlanEstudioAlumno)
                //{
                //    if (item.EstadoAsignatura.Equals(EstadoAsignatura.Cursando) || item.EstadoAsignatura.Equals(EstadoAsignatura.CursandoEnSegunda)
                //        || item.EstadoAsignatura.Equals(EstadoAsignatura.CursandoEnTercera) || item.EstadoAsignatura.Equals(EstadoAsignatura.CursandoEnCuarta))
                //    {
                //        AlumnosCursantes.Add(item.Alumno);
                //        CantidadDeAlumnosCursantes += 1;
                //    }

                //}
                //int[,] ContenedorEficiencia = new int[CantidadDeAlumnosCursantes, 11];
                //int count = 0;

                //foreach (var result in AlumnosCursantes)
                //{
                //    foreach (var item in result.PlanEstudioAlumno)
                //    {
                //        if (item.EstadoAsignatura == EstadoAsignatura.Aprobado)
                //        {
                //            ContenedorEficiencia[count, 0] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.AprobadoEnSegunda)
                //        {
                //            ContenedorEficiencia[count, 1] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.AprobadoEnTercera)
                //        {
                //            ContenedorEficiencia[count, 2] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.AprobadoEnCuarta)
                //        {
                //            ContenedorEficiencia[count, 3] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.Cursando)
                //        {
                //            ContenedorEficiencia[count, 4] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.CursandoEnSegunda)
                //        {
                //            ContenedorEficiencia[count, 5] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.CursandoEnTercera)
                //        {
                //            ContenedorEficiencia[count, 6] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.CursandoEnCuarta)
                //        {
                //            ContenedorEficiencia[count, 7] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.ReprobadoYNoInscrito)
                //        {
                //            ContenedorEficiencia[count, 8] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.ReprobadoYNoInscritoSegunda)
                //        {
                //            ContenedorEficiencia[count, 9] += 1;
                //        }
                //        else if (item.EstadoAsignatura == EstadoAsignatura.ReprobadoYNoInscritoTercera)
                //        {
                //            ContenedorEficiencia[count, 10] += 1;
                //        }

                //    }
                //    count += 1;
                //}
                //List<EstadoAsignatura> estadoMasprobable = new List<EstadoAsignatura>();
                //int[] PosicionEstado = new int[AlumnosCursantes.Count];
                //int contenedorNumeroMax = -100;

                //for (int i = 0; i < AlumnosCursantes.Count; i++)
                //{

                //    for (int j = 0; j < 10; j++)
                //    {

                //        if (ContenedorEficiencia[i, j] > contenedorNumeroMax)
                //        {
                //            contenedorNumeroMax = ContenedorEficiencia[i, j];
                //            PosicionEstado[i] = j + 1;

                //        }

                //    }
                //    contenedorNumeroMax = -100;

                //}
                //for (int i = 0; i < PosicionEstado.Length; i++)
                //{
                //    estadoMasprobable.Add((EstadoAsignatura)PosicionEstado[i]);
                //}

                //int Index = 0;
                //List<Alumno> AlumnosCursanteParaCampo = new List<Alumno>();
                //foreach (var item in AlumnosCursantes)
                //{
                //    if (estadoMasprobable[Index] == EstadoAsignatura.Aprobado)
                //    {
                //        AlumnosCursanteParaCampo.Add(item);
                //    }
                //    Index += 1;
                //}
                //DataPoint dataPoint = new DataPoint(asignatura.NombreAsignatura.ToString(), AlumnosCursanteParaCampo.Count());
                //resultado.Add(new DataPointAlumno(dataPoint, AlumnosCursanteParaCampo));
                #endregion

                AlumnosCursantes = ObtenerAlumnosCursantes(plan);
                resultado = ProyectarAlumnos(AlumnosCursantes,asignatura);
            }
            PlanDeEstudio planDeAsignaturaActual = new PlanDeEstudio();
            planDeAsignaturaActual = BuscarPlanDeEstudios(asignatura.Id);
            AlumnosCursantes = ObtenerAlumnosCursantes(planDeAsignaturaActual);
            List<DataPointAlumno>AlumnosCursandoCampo= ProyectarAlumnos(AlumnosCursantes, asignatura);
            foreach(var item in AlumnosCursandoCampo)
            {
                foreach(var result in item.alumno)
                {
                    resultado[0].alumno.Add(result);
                    resultado[0].dataPoint.Y += 1;
                }
                
            }
           
            return resultado;
        }

        public List<DataPointAlumno> CalcularProyeccionPorCarrera(Carrera carrera)
        {
            List<DataPointAlumno> resultado = new List<DataPointAlumno>();
            //DataPoint ComprobarSiExisteCampo = new DataPoint("",0);

            foreach (var result in carrera.PlanDeEstudio)
            {
                if (result.PC == "")
                {
                    result.PC = "0";
                }
                if (Int32.Parse(result.PC) > 0)
                {

                    if (CalcularProyeccionPorAsignatura(result.AsignaturaId).Count == 0)
                    {

                    }
                    else
                    {
                        resultado.Add(CalcularProyeccionPorAsignatura(result.AsignaturaId)[0]);
                    }
                }

            }


            return resultado;


        }
        public PlanDeEstudio BuscarPlanDeEstudiosPreRequisto(int Id)
        {
            //Buscar asignatura de campo clinico
            PlanDeEstudio plan = (from p in db.PlanDeEstudios where p.AsignaturaId == Id select p).FirstOrDefault();

            if (plan.AsignaturaPreRequisito.Contains("-"))
            {
                string[] NombrePlanes = plan.AsignaturaPreRequisito.Split('-');
                plan.AsignaturaPreRequisito = NombrePlanes[0];
            }
            //Buscar asignatura pre requisito de la anterior
            plan = (from p in db.PlanDeEstudios where p.Asignatura.NombreAsignatura.ToUpper() == plan.AsignaturaPreRequisito.ToUpper() select p).FirstOrDefault();

            return plan;

        }
        public PlanDeEstudio BuscarPlanDeEstudios(int Id)
        {
            //Buscar asignatura de campo clinico
            PlanDeEstudio plan = (from p in db.PlanDeEstudios where p.AsignaturaId == Id select p).FirstOrDefault();

            return plan;

        }
        public Semestre BuscarSemestre(int Id)
        {
            Semestre semestre = db.Semestres.Where(s => s.Id == Id).FirstOrDefault();
            return semestre;
        }
        public Semestre BuscarNombreSemestre(string NombreSemestre)
        {
            Semestre semestre = db.Semestres.Where(s => s.NombreSemestre == NombreSemestre).FirstOrDefault();
            return semestre;
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

        public List<PlanDeEstudio> BuscarPlanesDeEstudiPorCarrera(int id)
        {
            List<PlanDeEstudio> planes = (from p in db.PlanDeEstudios where p.CarreraCarreraId == id select p).ToList();

            return planes;
        }
        public List<Alumno> ObtenerAlumnosCursantes(PlanDeEstudio plan)
        {
            List<Alumno> AlumnosCursantes = new List<Alumno>();
            int CantidadDeAlumnosCursantes = 0;
            foreach (var item in plan.PlanEstudioAlumno)
            {
                if (item.EstadoAsignatura.Equals(EstadoAsignatura.Cursando) || item.EstadoAsignatura.Equals(EstadoAsignatura.CursandoEnSegunda)
                    || item.EstadoAsignatura.Equals(EstadoAsignatura.CursandoEnTercera) || item.EstadoAsignatura.Equals(EstadoAsignatura.CursandoEnCuarta))
                {
                    AlumnosCursantes.Add(item.Alumno);
                    CantidadDeAlumnosCursantes += 1;
                }

            }
            return AlumnosCursantes;
        }
        public List<DataPointAlumno> ProyectarAlumnos(List<Alumno>AlumCurs ,Asignatura asignatura)
        {

            List<DataPointAlumno> resultado = new List<DataPointAlumno>();
            List<Alumno> AlumnosCursantes = new List<Alumno>();
            int CantidadDeAlumnosCursantes = 0;

            AlumnosCursantes = AlumCurs;
            CantidadDeAlumnosCursantes = AlumnosCursantes.Count();
            int[,] ContenedorEficiencia = new int[CantidadDeAlumnosCursantes, 11];
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
                Index += 1;
            }
            DataPoint dataPoint = new DataPoint(asignatura.NombreAsignatura.ToString(), AlumnosCursanteParaCampo.Count());
            resultado.Add(new DataPointAlumno(dataPoint, AlumnosCursanteParaCampo));

            return resultado;
        }
   
        
    }
}