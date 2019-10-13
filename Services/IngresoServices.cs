using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using SAS.v1.Models;
using System.Security.Cryptography;
using System.Web.Security;
using SAS.v1.ClasesNP;
using SAS.v1.Utils;

namespace SAS.v1.Services
{
    public class IngresoServices
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CargaDatosServices));
        ModeloContainer db = new ModeloContainer();
        #region CentroFormador
        //Crear o devolver centro formador
        public CentroFormador CrearCentroFormador(int NombreCentroFormadorId, int CarreraId)
        {
            CentroFormador CentroF = BuscarCentroFormador(NombreCentroFormadorId, CarreraId);

            if (CentroF == null)
            {
                CentroF = new CentroFormador();
                CentroF.CarreraCarreraId = CarreraId;
                CentroF.NombreCentroFormadorNombreCentroFormadorId = NombreCentroFormadorId;

                db.CentroFormadors.Add(CentroF);
                db.SaveChanges();


            }
            else
            {
                CentroF = BuscarCentroFormador(NombreCentroFormadorId, CarreraId);
            }

            return CentroF;
        }
        //buscar centro formador
        public CentroFormador BuscarCentroFormador(int NombreCentroFormadorId, int CarreraId)
        {
            CentroFormador Centro = (from c in db.CentroFormadors where c.NombreCentroFormadorNombreCentroFormadorId == NombreCentroFormadorId && c.Carrera.CarreraId == CarreraId select c).FirstOrDefault();
            return Centro;
        }
        #endregion

        #region Persona
        //Crear personas
        public Persona CrearPersona(Persona Datos,int Estado)
        {
            Persona person = BuscarPersona(Datos);
            if (person != null && Estado == 1)
            {
                person.Rut=person.Rut.Replace(person.Rut,Datos.Rut);
                person.Dv=person.Dv.Replace(person.Dv, Datos.Dv);
                person.Nombre= person.Nombre.Replace(person.Nombre, Datos.Nombre);
                person.ApPaterno= person.ApPaterno.Replace(person.ApPaterno, Datos.ApPaterno);
                person.ApMaterno= person.ApMaterno.Replace(person.ApMaterno, Datos.ApMaterno);
                person.Estado = EstadoRegistro.Activo;
                db.SaveChanges();


            }
            if (person == null&&Estado==1||person==null&&Estado==0)
            {
                person = new Persona();
                person.Rut = Datos.Rut;
                person.Dv = Datos.Dv;
                person.Nombre = Datos.Nombre;
                person.ApPaterno = Datos.ApPaterno;
                person.ApMaterno = Datos.ApMaterno;
                person.Estado = EstadoRegistro.Activo;
                db.Personas.Add(person);
                db.SaveChanges();
                // person = null;
              person = BuscarPersona(Datos);
            }
            else
            {
                return person;
            }

            return person;
        }
        //Buscar Persona 
        public Persona BuscarPersona(Persona Datos)
        {
            Persona person = (from p in db.Personas where p.Rut == Datos.Rut && p.Dv == Datos.Dv && p.Nombre.ToUpper()==Datos.Nombre.ToUpper()&&p.ApPaterno.ToUpper()==
                              Datos.ApPaterno.ToUpper() select p).FirstOrDefault();
            return person;
        }
        #endregion
        #region Alumno
        public Alumno CrearAlumno(Persona person,Alumno AlumnoDatos, CentroFormador CentroFormador, int Estado)
        {
            Alumno Alumn = null;
            Alumn = BuscarAlumno(person,CentroFormador);
            if (Alumn != null && Estado == 1)
            {
              
               
                //Alumn.CursoNivel = Alumn.CursoNivel.Replace(Alumn.CursoNivel,AlumnoDatos.CursoNivel);
                Alumn.Observaciones = AlumnoDatos.Observaciones;               
                db.SaveChanges();
            }

                if (Alumn== null && Estado == 1 || Alumn == null && Estado == 0)
            {

                Alumn = new Alumno();
                
                Alumn.PersonaPersonaId = person.PersonaId;
                //Alumn.InmunizacionInmunizacionId = Inmunizacion.InmunizacionId;
                Alumn.CentroFormadorCentroFormadorId = CentroFormador.CentroFormadorId;
                //Alumn.CursoNivel = AlumnoDatos.CursoNivel;
                Alumn.Observaciones = AlumnoDatos.Observaciones;
             
                db.Alumnos.Add(Alumn);
                db.SaveChanges();

                Alumn = BuscarAlumno(person, CentroFormador);
              
            }
            else
            {
                
                return Alumn;
            }
            return Alumn;
        }
        public Alumno BuscarAlumno(Persona Datos,CentroFormador Centro)
        {
           Alumno Alumn = (from p in db.Alumnos where p.PersonaPersonaId == Datos.PersonaId && p.CentroFormadorCentroFormadorId == Centro.CentroFormadorId select p).FirstOrDefault();
            return Alumn;
        }

        #endregion
        #region Periodos
        public Periodo CrearPeriodos(Periodo periodos, NombreJornada Jornada)
        {
            Periodo periodo = BuscarPeriodo(periodos, Jornada);
            if (periodo == null)
            {
                periodo = new Periodo();
                periodo.FechaInicio = periodos.FechaInicio;
                periodo.FechaTermino = periodos.FechaTermino;
                periodo.NombreJornadaNombreJornadaId = Jornada.NombreJornadaId;
                db.Periodos.Add(periodo);
                db.SaveChanges();
            }
            else
            {
                return periodo;
            }

            return periodo;
        }
        public Periodo BuscarPeriodo(Periodo periodos, NombreJornada Jornada)
        {
            Periodo periodo = (from p in db.Periodos
                               where p.FechaInicio == periodos.FechaInicio && p.FechaTermino == periodos.FechaTermino &&
         p.NombreJornadaNombreJornadaId == Jornada.NombreJornadaId
                               select p).FirstOrDefault();
            return periodo;
        }
        #endregion
        #region Inmunizacion
        public Inmunizacion CrearInmunizacion(string Inmunizacion)
        {
            Inmunizacion inmune = BuscarInmunizacion(Inmunizacion);
            if (inmune == null)
            {
                inmune = new Inmunizacion();

                inmune.NombreInmunizacion = Inmunizacion;
                db.Inmunizacions.Add(inmune);
                db.SaveChanges();
                // inmune = null;
            }
            else
            {
                return inmune;
            }

            return inmune;
        }
        public Inmunizacion BuscarInmunizacion(string Inmunizacion)
        {
            Inmunizacion inmune = (from i in db.Inmunizacions where i.NombreInmunizacion.ToUpper().Trim() == Inmunizacion.ToUpper().Trim() select i).FirstOrDefault();
            return inmune;
        }
        #endregion
        #region ProfesionalDocenteGuia
        public ProfesionalDocenteGuia CrearProfesionalDocenteGuia(Persona person,ProfesionalDocenteGuia profesional, Inmunizacion inmunizacion, DocenciaHospitalaria docencia, int Estado)
        {
            ProfesionalDocenteGuia Docente = new ProfesionalDocenteGuia();
            Docente= BuscarProfesional(person,docencia,profesional);
            if (Docente != null && Estado == 1)
            {
                Docente.Profesion = Docente.Profesion.Replace(Docente.Profesion,profesional.Profesion);
                Docente.NumeroSuperintendencia = profesional.NumeroSuperintendencia;
                Docente.Telefono = profesional.Telefono;
                Docente.Correo = Docente.Correo.Replace(Docente.Correo, profesional.Correo);
                Docente.ValorDocente = profesional.ValorDocente;
                Docente.CumpleDatos = profesional.CumpleDatos;
                db.SaveChanges();
            }
                if (Docente == null && Estado == 1 || Docente == null && Estado == 0)
            {
               
                Docente = new ProfesionalDocenteGuia();
                Docente.PersonaPersonaId = person.PersonaId;
                Docente.InmunizacionInmunizacionId = inmunizacion.InmunizacionId;
                Docente.DocenciaHospitalariaDocenciaHospitalariaId = docencia.DocenciaHospitalariaId;
                Docente.Profesion = profesional.Profesion;
                Docente.NumeroSuperintendencia = profesional.NumeroSuperintendencia;
                Docente.Telefono = profesional.Telefono;
                Docente.Correo = profesional.Correo;
                Docente.ValorDocente = profesional.ValorDocente;
                Docente.CumpleDatos = profesional.CumpleDatos;
                db.ProfesionalDocenteGuias.Add(Docente);
                db.SaveChanges();
                
                //Volver a buscar persona para retornar 
                Docente = BuscarProfesional(person, docencia, profesional);
            }
            else
            {
                return Docente;
            }

            return Docente;
        }
        public ProfesionalDocenteGuia BuscarProfesional(Persona person, DocenciaHospitalaria docencia, ProfesionalDocenteGuia profesional)
        {
            ProfesionalDocenteGuia Docente = (from p in db.ProfesionalDocenteGuias where p.PersonaPersonaId == person.PersonaId &&
                                              p.DocenciaHospitalariaDocenciaHospitalariaId == docencia.DocenciaHospitalariaId &&
                                              p.Profesion.ToUpper().Trim()==profesional.Profesion.ToUpper().Trim() select p).FirstOrDefault();
            return Docente;
        }
        #endregion
        #region DocenciaHospitalaria
        public DocenciaHospitalaria CrearDocenciaHospitalaria(string NombreDocencia, int Estado)
        {
            DocenciaHospitalaria docencia = BuscarDocenciaHospitalaria(NombreDocencia);
            if (docencia!= null && Estado == 1)
            {
                docencia.NombreDocenciaHospitalaria =docencia.NombreDocenciaHospitalaria.Replace(docencia.NombreDocenciaHospitalaria,NombreDocencia);
                db.SaveChanges();

            }
                if (docencia == null && Estado == 1 ||docencia == null && Estado == 0)
            {
                docencia = new DocenciaHospitalaria();
                docencia.NombreDocenciaHospitalaria = NombreDocencia;
                db.DocenciaHospitalarias.Add(docencia);
                db.SaveChanges();
                // docencia =null;

            }
            else
            {
                return docencia;
            }

            return docencia;

        }
        public DocenciaHospitalaria BuscarDocenciaHospitalaria(string NombreDocencia)
        {
            DocenciaHospitalaria docencia = (from d in db.DocenciaHospitalarias where d.NombreDocenciaHospitalaria.ToUpper().Trim() == NombreDocencia.ToUpper().Trim() select d).FirstOrDefault();
            return docencia;
        }
        #endregion
        #region Institucion
        public Institucion CrearInstitucion(string NInstitucion,int Estado)
        {
            Institucion institucion = BuscarInstitucion(NInstitucion);
            if (institucion != null && Estado == 1)
            {
                institucion.NombreInstitucion = institucion.NombreInstitucion.Replace(institucion.NombreInstitucion,NInstitucion);
                db.SaveChanges();
            }
                if (institucion == null && Estado == 1 || institucion == null && Estado == 0)
            {
                institucion = new Institucion();
                institucion.NombreInstitucion = NInstitucion;
                db.Institucions.Add(institucion);
                db.SaveChanges();
                //institucion = null;
            }
            else
            {
                return institucion;
            }
            return institucion;
        }
        public Institucion BuscarInstitucion(string NInstitucion)
        {
            Institucion institucion = (from i in db.Institucions where i.NombreInstitucion == NInstitucion select i).FirstOrDefault();


            return institucion;
        }
        #endregion
        #region NombreUnidadDeServicio
        //public NombreUnidadDeServicio CrearNombreUnidadDeServicio(string nombreUnidadDeServicio)
        //{
        //    NombreUnidadDeServicio NUnidadDeServicio = BuscarNombreUnidadDeServicio(nombreUnidadDeServicio);
        //    if (NUnidadDeServicio == null)
        //    {
        //        NUnidadDeServicio = new NombreUnidadDeServicio();
        //        NUnidadDeServicio.NombreUnidadDeServicio1 = nombreUnidadDeServicio;
        //        db.NombreUnidadDeServicios.Add(NUnidadDeServicio);
        //        db.SaveChanges();
        //    }
        //    else
        //    {
        //        return NUnidadDeServicio;
        //    }
        //    return NUnidadDeServicio;
        //}
        //public NombreUnidadDeServicio BuscarNombreUnidadDeServicio(string NUnidadServicio)
        //{
        //    NombreUnidadDeServicio NUnidadDeServicio = (from n in db.NombreUnidadDeServicios where n.NombreUnidadDeServicio1 == NUnidadServicio select n).FirstOrDefault();
        //    return NUnidadDeServicio;
        //}
        //#endregion
        //#region UnidadDeServicio
        //public UnidadDeServicio CrearUnidadDeServicio(NombreUnidadDeServicio NombreUnidadServicio, CampoClinico campoClinico)
        //{
        //    UnidadDeServicio unidad = BuscarUnidadDeServicio(NombreUnidadServicio, campoClinico);
        //    if (unidad == null)
        //    {
        //        unidad = new UnidadDeServicio();
        //        unidad.NombreUnidadDeServicioId = NombreUnidadServicio.Id;
        //        unidad.CampoClinicoId = campoClinico.Id;
                
        //        db.UnidadDeServicios.Add(unidad);
        //        db.SaveChanges();
        //        // unidad = null;
        //    }
        //    else
        //    {
        //        return unidad;
        //    }
        //    return unidad;
        //}
        //public UnidadDeServicio BuscarUnidadDeServicio(NombreUnidadDeServicio NombreUnidadDeServicio, CampoClinico campoClinico)
        //{
        //    UnidadDeServicio unidad = (from u in db.UnidadDeServicios
        //                               where u.NombreUnidadDeServicio.Id == NombreUnidadDeServicio.Id &&
        //u.CampoClinicoId == campoClinico.Id
        //                               select u).FirstOrDefault();
        //    return unidad;
        //}
        #endregion
        #region nombreCampoClinico
        public NombreCampoClinico CrearNombreCampoClinico(string NcampoClinico, int Estado)
        {
            NombreCampoClinico NCampo = BuscarNombreCampoClinico(NcampoClinico);
            if (NCampo != null && Estado == 1)
            {
                NCampo.NombreCampo = NCampo.NombreCampo.Replace(NCampo.NombreCampo,NcampoClinico);
                db.SaveChanges();
            }
                if (NCampo == null && Estado == 1 || NCampo == null && Estado == 0)
            {
                NCampo = new NombreCampoClinico();
                NCampo.NombreCampo = NcampoClinico;
                db.NombreCampoClinicoSet.Add(NCampo);
                db.SaveChanges();
            }else
            {
                return NCampo;
            }
            return NCampo;
        }
        public NombreCampoClinico BuscarNombreCampoClinico(string NcampoClinico)
        {
            NombreCampoClinico NCampo = (from n in db.NombreCampoClinicoSet where n.NombreCampo.ToUpper().Trim() == NcampoClinico.ToUpper().Trim() select n).FirstOrDefault();
            return NCampo;
        }
        #endregion
        #region CampoClinico
        public CampoClinico CrearCampoClinico(NombreCampoClinico NCampoClinico, Institucion institucion,int Estado)
        {
            CampoClinico Campo = BuscarCampoClinico(NCampoClinico, institucion);
            if (Campo != null && Estado == 1)
            {
                Campo.NombreCampoClinicoId = NCampoClinico.Id;
                Campo.InstitucionId = institucion.Id;
                db.SaveChanges();
            }
                if (Campo == null && Estado == 1 || Campo == null && Estado == 0)
            {
                Campo = new CampoClinico();
                Campo.NombreCampoClinicoId = NCampoClinico.Id;
                Campo.InstitucionId = institucion.Id;
                db.CampoClinicos.Add(Campo);
                db.SaveChanges();
                // NombreCampo = null;
            }
            else
            {

                return Campo;


            }
            return Campo;

        }
        public CampoClinico BuscarCampoClinico(NombreCampoClinico NCampoClinico, Institucion institucion)
        {
            CampoClinico NombreCampo = (from c in db.CampoClinicos
                                        where c.NombreCampoClinicoId == NCampoClinico.Id && c.InstitucionId == institucion.Id
                                        select c).FirstOrDefault();
            return NombreCampo;
        }



        #endregion
        #region NombreCentroFormador
        public NombreCentroFormador CrearNombreCentroFormador(string NombreCentroFormador,int Estado)
        {
            NombreCentroFormador NombreCentro = BuscarNombreCentroFormador(NombreCentroFormador);
            if (NombreCentro != null && Estado == 1)
            {
                NombreCentro.NombreCentroFormador1 = NombreCentro.NombreCentroFormador1.Replace(NombreCentro.NombreCentroFormador1,NombreCentroFormador);
                db.SaveChanges();
            }
              else  if (NombreCentro == null && Estado == 1 || NombreCentro == null && Estado == 0)
            {
                NombreCentro = new NombreCentroFormador();
                NombreCentro.NombreCentroFormador1 = NombreCentroFormador;
                db.NombreCentroFormadors.Add(NombreCentro);
                db.SaveChanges();
                //  NombreCentro = null;
            }
           
            else
            {
                return NombreCentro;
            }
            return NombreCentro;
        }

        public NombreCentroFormador BuscarNombreCentroFormador(string NombreCentroFormador)
        {
                         NombreCentroFormador NombreCentro = (from n in db.NombreCentroFormadors
                                                 where n.NombreCentroFormador1.ToUpper().Trim() ==
                                                 NombreCentroFormador.ToUpper().Trim()
                                                 select n).FirstOrDefault();
            return NombreCentro;
        }
        #endregion
        #region Carrera
        public Carrera CrearCarrera(string NombreCarrera,int Estado)
        {
            Carrera carr = BuscarCarrera(NombreCarrera);
            if (carr != null && Estado == 1)
            {
                carr.NombreCarrera = carr.NombreCarrera.Replace(carr.NombreCarrera,NombreCarrera);
                db.SaveChanges();

            }
                if (carr == null && Estado == 1 || carr == null && Estado == 0)
            {
                carr = new Carrera();
                carr.NombreCarrera = NombreCarrera;
                db.Carreras.Add(carr);
                db.SaveChanges();
                //carr = null;
            }
            else
            {
                return carr;
            }
            return carr;
        }
        public Carrera BuscarCarrera(string NombreCarrera)
        {
            Carrera carr = (from c in db.Carreras where c.NombreCarrera.ToUpper().Trim() == NombreCarrera.ToUpper().Trim() select c).FirstOrDefault();
            return carr;
        }

        public Carrera CarreraFindById(int id)
        {
            Carrera carr = (from c in db.Carreras where c.CarreraId==id select c).FirstOrDefault();
            return carr;
        }
        #endregion
        #region Jornada
        /*   public Jornada CrearJornada(NombreJornada NomJornada, Periodo Periodos, Alumno Alumn)
           {
               Jornada jornada = BuscarJornada(NomJornada, Periodos, Alumn);
               if (jornada == null)
               {
                   jornada = new Jornada();
                   jornada.AlumnoPersonaId = Alumn.PersonaId;
                   jornada.NombreJornadaNombreJornadaId = NomJornada.NombreJornadaId;
                   //jornada.JornadaDias.JornadaDiasId = JornadaDia.JornadaDiasId;
                   jornada.PeriodoPeriodoId = Periodos.PeriodoId;
                   db.Jornadas.Add(jornada);
                   db.SaveChanges();
                   // jornada = null;
               } else
               {
                   return jornada;
               }
               return jornada;
           }
           public Jornada BuscarJornada(NombreJornada NomJornada, Periodo Periodos, Alumno Alumn)
           {
               Jornada jornada = (from j in db.Jornadas where j.NombreJornadaNombreJornadaId == NomJornada.NombreJornadaId &&
                                  j.PeriodoPeriodoId == Periodos.PeriodoId && j.AlumnoPersonaId
                                  == Alumn.PersonaId select j).FirstOrDefault();
               return jornada;
           }*/
        #endregion
        #region NombreJornada
        public NombreJornada crearNombreJornada(NombreJornada NombreJornada, int Estado)
        {
            NombreJornada NomJornada = BuscarNombreJornada(NombreJornada);
            if (NomJornada != null && Estado == 1)
            {
                NomJornada.Nombre = NomJornada.Nombre.Replace(NomJornada.Nombre,NombreJornada.Nombre);
                db.SaveChanges();

            }
                if (NomJornada == null && Estado == 1 || NomJornada == null && Estado == 0)
            {
                NomJornada = new NombreJornada();
                NomJornada.Nombre = NombreJornada.Nombre;
                db.NombreJornadas.Add(NomJornada);
                db.SaveChanges();
                // NomJornada = null;
            }
            else
            {
                return NomJornada;
            }
            return NomJornada;
        }
        public NombreJornada BuscarNombreJornada(NombreJornada NombreJornada)
        {
            NombreJornada NomJornada = (from j in db.NombreJornadas where j.Nombre.ToUpper().Trim() == NombreJornada.Nombre.ToUpper().Trim() select j).FirstOrDefault();
            return NomJornada;
        }
        #endregion
        #region DocenteAlumno
        /* public DocenteAlumno CrearDocenteAlumno(ProfesionalDocenteGuia profesional,Alumno Alumn)
         {
             DocenteAlumno DocenteAlumno=BuscarDocenteAlumno(profesional,Alumn);
             if (DocenteAlumno == null)
             {
                 DocenteAlumno.AlumnoId = Alumn.AlumnoId;
                 DocenteAlumno.ProfesionalDocenteGuiaId = profesional.ProfesionalDocenteGuiaId;
                 db.DocenteAlumno.Add(DocenteAlumno);
                 db.SaveChanges();
                 DocenteAlumno = null;
             }else
             {
                 return DocenteAlumno;
             }
             return DocenteAlumno;
         }
         public DocenteAlumno BuscarDocenteAlumno(ProfesionalDocenteGuia profesional, Alumno Alumn)
         {
             DocenteAlumno DocenteAlumno=(from d in db.DocenteAlumno where d.AlumnoId==Alumn.AlumnoId && 
                                          d.ProfesionalDocenteGuiaId==profesional.ProfesionalDocenteGuiaId select d).FirstOrDefault();
             return DocenteAlumno;
         }*/
        #endregion
        #region Dias
        public List<Dias> CrearDias()
        {
            string[] dia = new string[7];
            dia[0] = "lunes";
            dia[1] = "Martes";
            dia[2] = "Miercoles";
            dia[3] = "Jueves";
            dia[4] = "Viernes";
            dia[5] = "Sabado";
            dia[6] = "Domingo";
            List<Dias> dias = null;

            dias = BuscarDias();
            if (dias.Count == 0)
            {
                for (int i = 0; i < dia.Length; i++)
                {
                    Dias diasAd = new Dias();
                    diasAd.Dia = dia[i];
                    db.Dias.Add(diasAd);
                    db.SaveChanges();
                    // dias = null;
                }
            }
            else
            {
                dias = BuscarDias();
                return dias;
            }

            return dias;
        }
        public List<Dias> BuscarDias()
        {
            List<Dias> dias = (from d in db.Dias select d).ToList();
            return dias;
        }
        public Dias BuscarDia(string Dia)
        {
                         Dias dias = (from d in db.Dias where d.Dia.ToUpper().Trim()==Dia select d).FirstOrDefault();
                    return dias;
        }
        #endregion
        #region CampoClinicoAlumno
        public CampoClinicoAlumno CrearCampoClinicoAlumno(Alumno Alumn, ProfesionalDocenteGuia DocenteGuia, ProfesionalSupervisor Supervisor, Periodo Periodo,Asignatura Asignatura, Semestre Semestre,Anio ano,CampoClinico Campo)
        {
            CampoClinicoAlumno CampoAlumno = BuscarCampoClinicoAlumno(Alumn, DocenteGuia, Supervisor, Periodo,Asignatura, Semestre,ano,Campo);
            if (CampoAlumno == null)
            {
                CampoAlumno = new CampoClinicoAlumno();
                CampoAlumno.AlumnoAlumnoId = Alumn.AlumnoId;
                CampoAlumno.ProfesionalDocenteGuiaProfesionalDocenteGuiaId= DocenteGuia.ProfesionalDocenteGuiaId;
                CampoAlumno.ProfesionalSupervidorProfesionalSupervisorId = Supervisor.ProfesionalSupervisorId;
                CampoAlumno.PeriodoPeriodoId = Periodo.PeriodoId;
                CampoAlumno.CampoClinicoId = Campo.Id;
              //  CampoAlumno.UnidadDeServicioUnidadDeServicioId = UnidadServicio.UnidadDeServicioId;
                CampoAlumno.AsignaturaId = Asignatura.Id;
                CampoAlumno.SemestreId = Semestre.Id;
                CampoAlumno.AnioId = ano.Id;
                db.CampoClinicoAlumnos.Add(CampoAlumno);
                db.SaveChanges();

            }
            else
            {
                return CampoAlumno;
            }
            return CampoAlumno;
        }
        public CampoClinicoAlumno BuscarCampoClinicoAlumno(Alumno Alumn, ProfesionalDocenteGuia DocenteGuia, ProfesionalSupervisor Supervisor, Periodo Periodo,Asignatura Asignatura, Semestre Semestre, Anio ano, CampoClinico Campo)
        {
            //Puede arrojar error debido a que el profesional supervisor o docente guia pueden ser nulos
            CampoClinicoAlumno CampoAlumno = (from c in db.CampoClinicoAlumnos
                                              where c.AlumnoAlumnoId == Alumn.AlumnoId && c.ProfesionalDocenteGuiaProfesionalDocenteGuiaId == DocenteGuia.ProfesionalDocenteGuiaId &&
                                              c.ProfesionalSupervidorProfesionalSupervisorId == Supervisor.ProfesionalSupervisorId && c.PeriodoPeriodoId == Periodo.PeriodoId && 
                                              c.AsignaturaId==Asignatura.Id && c.SemestreId== Semestre.Id && c.AnioId==ano.Id&&c.CampoClinicoId==Campo.Id
                                              select c).FirstOrDefault();

            return CampoAlumno;
        }
        #endregion
        #region CampoClinicoAlumnosDias
        public CampoClinicoAlumnoDias CrearCampoClinicoAlumnosDias(CampoClinicoAlumno CampoAlumno, string Dia)
        {
            Dias Dias = BuscarDia(Dia.ToUpper().Trim());
            CampoClinicoAlumnoDias CampoAlumnoDias = BuscarCampoClinicoAlumnoDias(CampoAlumno, Dias);
            if (CampoAlumnoDias == null)
            {
                CampoAlumnoDias = new CampoClinicoAlumnoDias();
                CampoAlumnoDias.CampoClinicoAlumnoId = CampoAlumno.Id;
                CampoAlumnoDias.DiasDiasId = Dias.DiasId;
                db.CampoClinicoAlumnoDiasSet.Add(CampoAlumnoDias);
                db.SaveChanges();
            }
            else
            {
                return CampoAlumnoDias;
            }
            return CampoAlumnoDias;
        }
        public CampoClinicoAlumnoDias BuscarCampoClinicoAlumnoDias(CampoClinicoAlumno CampoAlumno, Dias Dias)
        {
            CampoClinicoAlumnoDias CampoAlumnoDias = (from cad in db.CampoClinicoAlumnoDiasSet
                                                      where cad.CampoClinicoAlumnoId == CampoAlumno.Id &&
                                                         cad.DiasDiasId == Dias.DiasId
                                                      select cad).FirstOrDefault();
            return CampoAlumnoDias;
        }
        #endregion 
        #region ProfesionalSupervisor
        public ProfesionalSupervisor crearProfesionalSupervisor(Persona person,ProfesionalSupervisor profSup,int Estado)
        {
            ProfesionalSupervisor Profesional = new ProfesionalSupervisor();
            Profesional = BuscarProfesionalSupervisor(person);
            if (Profesional != null && Estado == 1)
            {
             
                Profesional.ValorSupervisor = profSup.ValorSupervisor;
                Profesional.Observaciones =profSup.Observaciones;
                db.SaveChanges();
            }
                if (Profesional == null && Estado == 1 || Profesional == null && Estado == 0)
            {

                Profesional = new ProfesionalSupervisor();
                Profesional.PersonaPersonaId = person.PersonaId;
                Profesional.ValorSupervisor = profSup.ValorSupervisor;
                Profesional.Observaciones = profSup.Observaciones;
                db.ProfesionalSupervisorSet.Add(Profesional);
                db.SaveChanges();

                Profesional = BuscarProfesionalSupervisor(person);
            }
            else
            {
                return Profesional;
            }
            return Profesional;
        }
        public ProfesionalSupervisor BuscarProfesionalSupervisor(Persona person)
        {
            ProfesionalSupervisor Profesional = (from p in db.ProfesionalSupervisorSet where p.PersonaPersonaId == person.PersonaId select p).FirstOrDefault();
            return Profesional;
        }
        #endregion
        #region Asignatura 

        public Asignatura CrearAsignatura(Asignatura NombreAsignatura,int Estado)
        {
            Asignatura asignatura=BuscarAsignatura(NombreAsignatura);
            if (asignatura != null && Estado == 1)
            {
                asignatura.NombreAsignatura = asignatura.NombreAsignatura.Replace(asignatura.NombreAsignatura, NombreAsignatura.NombreAsignatura);
                if (asignatura.CodigoAsignatura == null || asignatura.CodigoAsignatura == "")
                {
                    asignatura.CodigoAsignatura = " ";

                }
                else
                {
                asignatura.CodigoAsignatura = asignatura.CodigoAsignatura.Replace(asignatura.CodigoAsignatura, NombreAsignatura.CodigoAsignatura);


                }
                db.SaveChanges();
            }
                if (asignatura == null && Estado == 1 || asignatura == null && Estado == 0)
            {
                asignatura = new Asignatura();
                asignatura.NombreAsignatura = NombreAsignatura.NombreAsignatura;
                if(asignatura.CodigoAsignatura==null)
                {
                    asignatura.CodigoAsignatura = "";

                }else
                {
                asignatura.CodigoAsignatura = NombreAsignatura.CodigoAsignatura;

                }
                db.Asignaturas.Add(asignatura);
                db.SaveChanges();
            }else
            {
                return asignatura;
            }
            return asignatura;

        }

        public Asignatura BuscarAsignatura(Asignatura nombreAsignatura)
        {
            Asignatura asignatura = db.Asignaturas.Where(a => a.NombreAsignatura.ToUpper().Equals(nombreAsignatura.NombreAsignatura.ToUpper() )).FirstOrDefault();
            return asignatura;
        }


        public Asignatura AsignaturaFindById(int id)
        {
            Asignatura asignatura = db.Asignaturas.Where(a => a.Id==id).FirstOrDefault();
            return asignatura;
        }
        #endregion

        #region Semestre

        public Semestre CrearSemestre(Semestre NombreSemestre)
        {
            Semestre Semestre = BuscarSemestre(NombreSemestre);
            if (Semestre == null)
            {
                Semestre = new Semestre();
                Semestre.NombreSemestre = NombreSemestre.NombreSemestre;
                db.Semestres.Add(Semestre);
                db.SaveChanges();
            }
            else
            {
                return Semestre;
            }
            return Semestre;

        }

        public Semestre BuscarSemestre(Semestre Semestre)
        {
            Semestre Semestres = db.Semestres.Where(a => a.NombreSemestre == Semestre.NombreSemestre).FirstOrDefault();
            return Semestres;
        }
        #endregion

        #region Usuario
        public Boolean CrearUsuario(Usuario usuario, Persona persona)
        {
            Usuario usuarios = BuscarUsuario(usuario);
            Estado estado = new Estado();
            if (usuarios == null)
            {
                usuarios = new Usuario();
                usuarios.Correo = usuario.Correo;
                usuarios.Cuenta = usuario.Cuenta;
                // usuarios.Estado = estado.Desactivar;
                //usuarios.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(usuario.Password,"MD5");
                usuarios.PersonaPersonaId = 1;
               // usuarios.PerfilUsuarioId = 1;
                db.Usuarios.Add(usuarios);
                db.SaveChanges();

            }else
            {
                return false;
            }
            return true;
        }
        public Usuario BuscarUsuario(Usuario usuario)
        {
            Usuario usuarios = db.Usuarios.Where(u => u.Cuenta == usuario.Cuenta && u.Correo == usuario.Correo).FirstOrDefault();
            return usuarios;
        }
        #endregion

        #region anio
        public Anio CrearAnio(Anio Ano)
        {
            Anio anio = BuscarAnio(Ano);
            if (anio==null)
            {
                anio = new Anio();
                anio.Ano = Ano.Ano;
                db.Anios.Add(anio);
                db.SaveChanges();
            }else
            {
                return anio;
            }
            return anio;
        }
        public Anio BuscarAnio(Anio Ano)
        {
            Anio anio = db.Anios.Where(a => a.Ano == Ano.Ano).FirstOrDefault();

            return anio;
        }
        #endregion

        #region AsignaturasAlumnos

        //public AsignaturaAlumno CrearAsignaturaAlumnos(AsignaturaAlumno AsAlumno, int Estado)
        //{
        //    AsignaturaAlumno asignaturaAlumno = BuscarAsignaturaAlumno(AsAlumno);
        //    if (asignaturaAlumno != null && Estado == 1)
        //    {
        //        asignaturaAlumno.AlumnoAlumnoId = AsAlumno.AlumnoAlumnoId;
        //        asignaturaAlumno.AsignaturaId = AsAlumno.AsignaturaId;
        //        asignaturaAlumno.CarreraCarreraId = AsAlumno.CarreraCarreraId;
        //        asignaturaAlumno.EstadoAsignatura = AsAlumno.EstadoAsignatura;
        //        asignaturaAlumno.SemestreId = AsAlumno.SemestreId;
        //        asignaturaAlumno.AnioId = AsAlumno.AnioId;
        //        asignaturaAlumno.PorcentajeDeExigenciaId = AsAlumno.PorcentajeDeExigenciaId;
        //        db.SaveChanges();
        //    }
        //    if (asignaturaAlumno == null && Estado == 1 || asignaturaAlumno == null && Estado == 0)
        //    {
        //        asignaturaAlumno = new AsignaturaAlumno();
        //       asignaturaAlumno.Alumno = AsAlumno.Alumno;
        //       asignaturaAlumno.Anio = AsAlumno.Anio;
        //       asignaturaAlumno.Semestre = AsAlumno.Semestre;
        //       asignaturaAlumno.Asignatura = AsAlumno.Asignatura;
        //       asignaturaAlumno.Carrera = AsAlumno.Carrera;
        //       asignaturaAlumno.PorcentajeDeExigencia = AsAlumno.PorcentajeDeExigencia;

        //        asignaturaAlumno.AlumnoAlumnoId = AsAlumno.AlumnoAlumnoId;
        //        asignaturaAlumno.AsignaturaId = AsAlumno.AsignaturaId;
        //        asignaturaAlumno.CarreraCarreraId = AsAlumno.CarreraCarreraId;
        //        asignaturaAlumno.EstadoAsignatura = AsAlumno.EstadoAsignatura;
        //        asignaturaAlumno.SemestreId = AsAlumno.SemestreId;
        //        asignaturaAlumno.AnioId = AsAlumno.AnioId;
        //        asignaturaAlumno.AsignaturaPreRequisito = "";
        //        asignaturaAlumno.PorcentajeDeExigenciaId = AsAlumno.PorcentajeDeExigenciaId;
        //        db.AsignaturasAlumnos.Add(asignaturaAlumno);
        //        db.SaveChanges();
        //    }
        //    else
        //    {
        //        return asignaturaAlumno;
        //    }
        //    return asignaturaAlumno;

        //}

        //public AsignaturaAlumno BuscarAsignaturaAlumno(AsignaturaAlumno AsAlumno)
        //{
        //    AsignaturaAlumno asignaturaAlumno = db.AsignaturasAlumnos.Where(a => a.AsignaturaId == AsAlumno.AsignaturaId&&a.AlumnoAlumnoId==AsAlumno.AlumnoAlumnoId
        //    ).FirstOrDefault();
        //    return asignaturaAlumno;
        //}

        #endregion

        #region porcentaje exigencia
        //public PorcentajeDeExigencia CrearPorcentajeDeExigencia(PorcentajeDeExigencia Porcentaje, int Estado)
        //{
        //    PorcentajeDeExigencia porcentaje = BuscarPorcentaje(Porcentaje);
        //    if (porcentaje != null && Estado == 1)
        //    {
        //        porcentaje.Porcentaje = Porcentaje.Porcentaje;
        //        db.SaveChanges();
        //    }
        //    if (porcentaje == null && Estado == 1 || porcentaje == null && Estado == 0)
        //    {
        //        porcentaje = new PorcentajeDeExigencia();
        //        porcentaje.Porcentaje = Porcentaje.Porcentaje;
        //        db.PorcentajesDeExigencias.Add(porcentaje);
        //        db.SaveChanges();
        //    }
        //    else
        //    {
        //        return porcentaje;
        //    }
        //    return porcentaje;

        //}

        //public PorcentajeDeExigencia BuscarPorcentaje(PorcentajeDeExigencia porcentaje)
        //{
        //    PorcentajeDeExigencia Porcentaje = db.PorcentajesDeExigencias.Where(a => a.Id == porcentaje.Id ).FirstOrDefault();
        //    return Porcentaje;
        //}
        #endregion


        #region Inmunizacion Alumno
        public InmunizacionAlumno CrearInmunizacionAlumno(Alumno alumno, Inmunizacion inmunizacion)
        {
            InmunizacionAlumno AlumnoInmune = BuscarInmunizacionAlumno(alumno,inmunizacion);
            if (AlumnoInmune == null)
            {
                AlumnoInmune = new InmunizacionAlumno();
                AlumnoInmune.InmunizacionInmunizacionId = inmunizacion.InmunizacionId;
                AlumnoInmune.AlumnoAlumnoId = alumno.AlumnoId;
                db.ImunizacionesAlumnos.Add(AlumnoInmune);
                db.SaveChanges();
                // inmune = null;
            }
            else
            {
                return AlumnoInmune;
            }

            return AlumnoInmune;
        }
        public InmunizacionAlumno BuscarInmunizacionAlumno(Alumno alumno, Inmunizacion inmunizacion)
        {
            InmunizacionAlumno inmune = (from i in db.ImunizacionesAlumnos where i.AlumnoAlumnoId == alumno.AlumnoId &&i.InmunizacionInmunizacionId== 
                                         inmunizacion.InmunizacionId select i).FirstOrDefault();
            return inmune;
        }


        #endregion

        #region CursoNivel
        public CursoNivel CrearCursoNivel(string Curso)
        {
            CursoNivel cursoNivel = BuscarCursoNivel(Curso);
            if (cursoNivel == null)
            {
                cursoNivel = new CursoNivel();
                cursoNivel.NombreCurso = Curso;
                db.CursosNiveles.Add(cursoNivel);
                db.SaveChanges();
                // inmune = null;
            }
            else
            {
                return cursoNivel;
            }

            return cursoNivel;
        }
        public CursoNivel BuscarCursoNivel(string Curso)
        {
            CursoNivel curso = (from i in db.CursosNiveles
                                         where i.NombreCurso.ToUpper() == Curso.ToUpper() select i).FirstOrDefault();
            return curso;
        }
        #endregion

        #region CursoAlumno
        public CursoAlumno CrearCursoAlumno(Alumno alumno, CursoNivel curso)
        {
            CursoAlumno cursoAlumno = BuscarCursoAlumno(alumno,curso);
            if (cursoAlumno == null)
            {
                cursoAlumno = new CursoAlumno();
                cursoAlumno.AlumnoAlumnoId = alumno.AlumnoId;
                cursoAlumno.CursoNivelId = curso.CursoNivelId;
                db.CursoAlumnos.Add(cursoAlumno);
                db.SaveChanges();
                // inmune = null;
            }
            else
            {
                return cursoAlumno;
            }

            return cursoAlumno;
        }
        public CursoAlumno BuscarCursoAlumno(Alumno alumno, CursoNivel curso)
        {
            CursoAlumno cursoAlumno = (from i in db.CursoAlumnos
                                where i.AlumnoAlumnoId == alumno.AlumnoId && i.CursoNivelId==curso.CursoNivelId
                                select i).FirstOrDefault();
            return cursoAlumno;
        }
        #endregion


        #region planEstiudios
        public PlanDeEstudio CrearPlanEstudio(PlanDeEstudio planEstudio)
        {
            PlanDeEstudio plan = BuscarPlanEstudio(planEstudio);
            if (plan == null)
            {
                plan = new PlanDeEstudio();
                plan.CarreraCarreraId = planEstudio.CarreraCarreraId;
                plan.AnioId = planEstudio.AnioId;
                plan.AsignaturaId = planEstudio.AsignaturaId;
                plan.PorcentajeReprobacion = planEstudio.PorcentajeReprobacion;
                plan.AsignaturaPreRequisito = planEstudio.AsignaturaPreRequisito;
                plan.SemestreId = planEstudio.SemestreId;
               // plan.RequisitosAsignaturaId = planEstudio.RequisitosAsignaturaId;
                plan.UD = planEstudio.UD;
                plan.Catedra = planEstudio.Catedra;
                plan.Taller = planEstudio.Taller;
                plan.LAB = planEstudio.LAB;
                plan.PC = planEstudio.PC;
                plan.SCT = planEstudio.SCT;
                plan.Materia = planEstudio.Materia;
                plan.Curso = planEstudio.Curso;

                db.PlanDeEstudios.Add(plan);
                db.SaveChanges();
                
            }
            else
            {
                return plan;
            }

            return plan;
        }
        public PlanDeEstudio BuscarPlanEstudio(PlanDeEstudio planEstudio)
        {
            PlanDeEstudio plan = (from i in db.PlanDeEstudios
                                where i.CarreraCarreraId ==planEstudio.CarreraCarreraId&&
                                i.AnioId==planEstudio.AnioId&&i.AsignaturaId==planEstudio.AsignaturaId
                                  select i).FirstOrDefault();
            return plan;
        }
        #endregion


        //#region Requisitos asignatura
        //public RequisitosAsignatura CrearReqAsignatura(RequisitosAsignatura requisitos)
        //{
        //    RequisitosAsignatura reqAsignatura = BuscarReqAsignatura(requisitos);
        //    if (reqAsignatura == null)
        //    {
        //        reqAsignatura = new RequisitosAsignatura();
        //        reqAsignatura.AsignaturaId = requisitos.AsignaturaId;
        //        reqAsignatura.PorcentajeReprobacion = requisitos.PorcentajeReprobacion;
        //        reqAsignatura.AsignaturaPreRequisito = requisitos.AsignaturaPreRequisito;
        //        reqAsignatura.SemestreId = requisitos.SemestreId;

        //        db.RequisitosAsignaturas.Add(reqAsignatura);
        //        db.SaveChanges();

        //    }
        //    else
        //    {
        //        return reqAsignatura;
        //    }

        //    return reqAsignatura;
        //}
        //public RequisitosAsignatura BuscarReqAsignatura(RequisitosAsignatura requisitos)
        //{
        //    RequisitosAsignatura req = (from i in db.RequisitosAsignaturas
        //                        where i.AsignaturaId==requisitos.AsignaturaId && i.SemestreId==requisitos.SemestreId
        //                                select i).FirstOrDefault();
        //    return req;
        //}
        //#endregion

          

#region PlanEstudioAlumno
public PlanEstudioAlumno CrearPlanEstudioAlumno(PlanEstudioAlumno planAlumno, int Estado)
        {
            PlanEstudioAlumno planAlumnos = BuscarPlanEstudioAlumno(planAlumno);
            
            if(planAlumnos!=null && Estado == 1)
            {
         
            planAlumnos.EstadoAsignatura = planAlumno.EstadoAsignatura;
           
            db.SaveChanges();
             }

            if (planAlumnos == null&&Estado==1 || planAlumnos==null&&Estado==0)
            {
                planAlumnos = new PlanEstudioAlumno();
                planAlumnos.PlanDeEstudioId = planAlumno.PlanDeEstudioId;
                planAlumnos.AlumnoAlumnoId = planAlumno.AlumnoAlumnoId;
                planAlumnos.EstadoAsignatura = planAlumno.EstadoAsignatura;
                db.PlanEstudioAlumnos.Add(planAlumnos);
                db.SaveChanges();
                // inmune = null;
            }
            else
            {
                return planAlumno;
            }

            return planAlumno;
        }
        public PlanEstudioAlumno BuscarPlanEstudioAlumno(PlanEstudioAlumno planAlumno)
        {
           PlanEstudioAlumno planAlumnos = (from i in db.PlanEstudioAlumnos
                                where i.PlanDeEstudioId== planAlumno.PlanDeEstudioId&&
                                i.AlumnoAlumnoId==planAlumno.AlumnoAlumnoId
                                select i).FirstOrDefault();
            return planAlumnos;
        }
        #endregion

    }
}
