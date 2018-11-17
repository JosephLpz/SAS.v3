using SAS.v1.ClasesNP;
using SAS.v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAS.v1.Services
{
    public class AlumnosServices
    {
      ModeloContainer db = new ModeloContainer();

        //devuelve todos los datos de alumno pasando por una clase no persistente
        //public List<AlumnoNP> ListaAlumnos(string rut)
        //{
        //    List<AlumnoNP> ListaAlumno= new List<AlumnoNP>();
        //    if (rut == null|| rut=="") {
        //        ListaAlumno = (from p in db.Personas join 
        //                                  al in db.Alumnos on p.PersonaId equals al.PersonaPersonaId 
        //                                  select new AlumnoNP
        //                                  {
        //                                      PersonaId=p.PersonaId,
        //                                      Rut=p.Rut,
        //                                      Dv=p.Dv,
        //                                      Nombre=p.Nombre,
        //                                      ApPaterno=p.ApPaterno,
        //                                      ApMaterno=p.ApMaterno,
        //                                      AlumnoId=al.AlumnoId,
        //                                      CursoNivel=al.CursoNivel,
        //                                      Carrera=al.CentroFormador.Carrera.NombreCarrera,
        //                                      Inmunizacion=al.Inmunizacion.NombreInmunizacion
        //                                  }).ToList();
        //        return ListaAlumno;
        //    }else
        //    {
        //        ListaAlumno = (from p in db.Personas
        //                       join
        //            al in db.Alumnos on p.PersonaId equals al.PersonaPersonaId where p.Rut==rut
        //                       select new AlumnoNP
        //                       {
        //                           PersonaId = p.PersonaId,
        //                           Rut = p.Rut,
        //                           Dv = p.Dv,
        //                           Nombre = p.Nombre,
        //                           ApPaterno = p.ApPaterno,
        //                           ApMaterno = p.ApMaterno,
        //                           AlumnoId = al.AlumnoId,
        //                           CursoNivel = al.CursoNivel,
        //                           Carrera = al.CentroFormador.Carrera.NombreCarrera,
        //                           Inmunizacion = al.Inmunizacion.NombreInmunizacion
        //                       }).ToList();
        //        return ListaAlumno;
        //    }

        //    return ListaAlumno;
        //}


        //Devulve todos los campos clinicos por almuno seleccionado
              public List<CampoClinicoAlumno> DatosCampoClinicoAlumnos(int? id)
              {
                  List<CampoClinicoAlumno> DatosCampoClinicoAl = (from da in db.CampoClinicoAlumnos where da.AlumnoAlumnoId == id select da).ToList();
                  return DatosCampoClinicoAl;
              }
               public CampoClinicoAlumno DatosCampoClinico(int? id)
                {
            CampoClinicoAlumno DatosCampo = (from ca in db.CampoClinicoAlumnos where ca.Id == id select ca).FirstOrDefault();
            return DatosCampo;
                }
              public List<CampoClinicoAlumnoDias> Dias(int? id)
              {
                  List<CampoClinicoAlumnoDias> dia = (from d in db.CampoClinicoAlumnoDiasSet where d.CampoClinicoAlumnoId == id select d).ToList();
                  return dia;
              }
        }
}