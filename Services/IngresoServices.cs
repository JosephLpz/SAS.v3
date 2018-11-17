using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using SAS.v1.Models;

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
        public Persona CrearPersona(Persona Datos)
        {
            Persona person = BuscarPersona(Datos);
            if (person == null)
            {
                person = new Persona();
                person.Rut = Datos.Rut;
                person.Dv = Datos.Dv;
                person.Nombre = Datos.Nombre;
                person.ApPaterno = Datos.ApPaterno;
                person.ApMaterno = Datos.ApMaterno;
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
            Persona person = (from p in db.Personas where p.Rut == Datos.Rut && p.Dv == Datos.Dv select p).FirstOrDefault();
            return person;
        }
        #endregion
        #region Alumno
        public Alumno CrearAlumno(Persona person,Alumno AlumnoDatos, Inmunizacion Inmunizacion, CentroFormador CentroFormador)
        {
            Alumno Alumn = null;
            Alumn = BuscarAlumno(person,CentroFormador);
            if (Alumn== null)
            {

                Alumn = new Alumno();
                //person = new Persona();
                //Alumn.Rut = AlumnoDatos.Rut;
                //Alumn.Dv = AlumnoDatos.Dv;
                //Alumn.Nombre = AlumnoDatos.Nombre;
                //Alumn.ApPaterno = AlumnoDatos.ApPaterno;
                //Alumn.ApMaterno = AlumnoDatos.ApMaterno;
                Alumn.PersonaPersonaId = person.PersonaId;
                Alumn.InmunizacionInmunizacionId = Inmunizacion.InmunizacionId;
                Alumn.CentroFormadorCentroFormadorId = CentroFormador.CentroFormadorId;
                Alumn.CursoNivel = AlumnoDatos.CursoNivel;
                Alumn.Observaciones = "";
                // Alumn.PeriodosId = Periodos.PeriodosId;
                db.Alumnos.Add(Alumn);
                db.SaveChanges();

                Alumn = BuscarAlumno(person, CentroFormador);
                // Alumn = null;
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
        public ProfesionalDocenteGuia CrearProfesionalDocenteGuia(Persona person,ProfesionalDocenteGuia profesional, Inmunizacion inmunizacion, DocenciaHospitalaria docencia)
        {
            ProfesionalDocenteGuia Docente = new ProfesionalDocenteGuia();
            Docente= BuscarProfesional(person,docencia,profesional);
            if (Docente == null)
            {
                // Docente.PersonaId = person.PersonaId;
                // Docente.ProfesionalDocenteGuiaId = profesional.PersonaId;
                //Docente.Rut = profesional.Rut;
                //Docente.Dv = profesional.Dv;
                //Docente.Nombre = profesional.Nombre;
                //Docente.ApPaterno = profesional.ApPaterno;
                //Docente.ApMaterno = profesional.ApMaterno;
                Docente = new ProfesionalDocenteGuia();
                Docente.PersonaPersonaId = person.PersonaId;
                Docente.InmunizacionInmunizacionId = inmunizacion.InmunizacionId;
                Docente.DocenciaHospitalariaDocenciaHospitalariaId = docencia.DocenciaHospitalariaId;
                Docente.Profesion = profesional.Profesion;
                Docente.NumeroSuperintendencia = profesional.NumeroSuperintendencia;
                Docente.Telefono = profesional.Telefono;
                Docente.Correo = profesional.Correo;
                Docente.ValorDocente = profesional.ValorDocente;
                //Docente.CumpliminetoRequisitos = profesional.CumpliminetoRequisitos;
                db.ProfesionalDocenteGuias.Add(Docente);
                db.SaveChanges();
                // Docente = null;
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
                                              p.Profesion.ToUpper().Trim()==profesional.Profesion.ToUpper().Trim()&&
                                              p.NumeroSuperintendencia==profesional.NumeroSuperintendencia select p).FirstOrDefault();
            return Docente;
        }
        #endregion
        #region DocenciaHospitalaria
        public DocenciaHospitalaria CrearDocenciaHospitalaria(string NombreDocencia)
        {
            DocenciaHospitalaria docencia = BuscarDocenciaHospitalaria(NombreDocencia);
            if (docencia == null)
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
        public Institucion CrearInstitucion(string NInstitucion)
        {
            Institucion institucion = BuscarInstitucion(NInstitucion);
            if (institucion == null)
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
        public NombreUnidadDeServicio CrearNombreUnidadDeServicio(string nombreUnidadDeServicio)
        {
            NombreUnidadDeServicio NUnidadDeServicio = BuscarNombreUnidadDeServicio(nombreUnidadDeServicio);
            if (NUnidadDeServicio == null)
            {
                NUnidadDeServicio = new NombreUnidadDeServicio();
                NUnidadDeServicio.NombreUnidadDeServicio1 = nombreUnidadDeServicio;
                db.NombreUnidadDeServicios.Add(NUnidadDeServicio);
                db.SaveChanges();
            }
            else
            {
                return NUnidadDeServicio;
            }
            return NUnidadDeServicio;
        }
        public NombreUnidadDeServicio BuscarNombreUnidadDeServicio(string NUnidadServicio)
        {
            NombreUnidadDeServicio NUnidadDeServicio = (from n in db.NombreUnidadDeServicios where n.NombreUnidadDeServicio1 == NUnidadServicio select n).FirstOrDefault();
            return NUnidadDeServicio;
        }
        #endregion
        #region UnidadDeServicio
        public UnidadDeServicio CrearUnidadDeServicio(NombreUnidadDeServicio NombreUnidadServicio, CampoClinico campoClinico)
        {
            UnidadDeServicio unidad = BuscarUnidadDeServicio(NombreUnidadServicio, campoClinico);
            if (unidad == null)
            {
                unidad = new UnidadDeServicio();
                unidad.NombreUnidadDeServicioId = NombreUnidadServicio.Id;
                unidad.CampoClinicoId = campoClinico.Id;
                
                db.UnidadDeServicios.Add(unidad);
                db.SaveChanges();
                // unidad = null;
            }
            else
            {
                return unidad;
            }
            return unidad;
        }
        public UnidadDeServicio BuscarUnidadDeServicio(NombreUnidadDeServicio NombreUnidadDeServicio, CampoClinico campoClinico)
        {
            UnidadDeServicio unidad = (from u in db.UnidadDeServicios
                                       where u.NombreUnidadDeServicio.Id == NombreUnidadDeServicio.Id &&
        u.CampoClinicoId == campoClinico.Id
                                       select u).FirstOrDefault();
            return unidad;
        }
        #endregion
        #region nombreCampoClinico
        public NombreCampoClinico CrearNombreCampoClinico(string NcampoClinico)
        {
            NombreCampoClinico NCampo = BuscarNombreCampoClinico(NcampoClinico);
            if (NCampo == null)
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
        public CampoClinico CrearCampoClinico(NombreCampoClinico NCampoClinico, Institucion institucion)
        {
            CampoClinico Campo = BuscarCampoClinico(NCampoClinico, institucion);
            if (Campo == null)
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
        public NombreCentroFormador CrearNombreCentroFormador(string NombreCentroFormador)
        {
            NombreCentroFormador NombreCentro = BuscarNombreCentroFormador(NombreCentroFormador);
            if (NombreCentro == null)
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
        public Carrera CrearCarrera(string NombreCarrera)
        {
            Carrera carr = BuscarCarrera(NombreCarrera);
            if (carr == null)
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
        public NombreJornada crearNombreJornada(NombreJornada NombreJornada)
        {
            NombreJornada NomJornada = BuscarNombreJornada(NombreJornada);
            if (NomJornada == null)
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
        public CampoClinicoAlumno CrearCampoClinicoAlumno(Alumno Alumn, ProfesionalDocenteGuia DocenteGuia, ProfesionalSupervisor Supervisor, Periodo Periodo, UnidadDeServicio UnidadServicio)
        {
            CampoClinicoAlumno CampoAlumno = BuscarCampoClinicoAlumno(Alumn, DocenteGuia, Supervisor, Periodo, UnidadServicio);
            if (CampoAlumno == null)
            {
                CampoAlumno = new CampoClinicoAlumno();
                CampoAlumno.AlumnoAlumnoId = Alumn.AlumnoId;
                CampoAlumno.ProfesionalDocenteGuiaProfesionalDocenteGuiaId= DocenteGuia.ProfesionalDocenteGuiaId;
                CampoAlumno.ProfesionalSupervidorProfesionalSupervisorId = Supervisor.ProfesionalSupervisorId;
                CampoAlumno.PeriodoPeriodoId = Periodo.PeriodoId;
                CampoAlumno.UnidadDeServicioUnidadDeServicioId = UnidadServicio.UnidadDeServicioId;
                db.CampoClinicoAlumnos.Add(CampoAlumno);
                db.SaveChanges();

            }
            else
            {
                return CampoAlumno;
            }
            return CampoAlumno;
        }
        public CampoClinicoAlumno BuscarCampoClinicoAlumno(Alumno Alumn, ProfesionalDocenteGuia DocenteGuia, ProfesionalSupervisor Supervisor, Periodo Periodo, UnidadDeServicio UnidadServicio)
        {
            //Puede arrojar error debido a que el profesional supervisor o docente guia pueden ser nulos
            CampoClinicoAlumno CampoAlumno = (from c in db.CampoClinicoAlumnos
                                              where c.AlumnoAlumnoId == Alumn.AlumnoId && c.ProfesionalDocenteGuiaProfesionalDocenteGuiaId == DocenteGuia.ProfesionalDocenteGuiaId &&
                                              c.ProfesionalSupervidorProfesionalSupervisorId == Supervisor.ProfesionalSupervisorId && c.PeriodoPeriodoId == Periodo.PeriodoId && 
                                              c.UnidadDeServicioUnidadDeServicioId == UnidadServicio.UnidadDeServicioId
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
        public ProfesionalSupervisor crearProfesionalSupervisor(Persona person,ProfesionalSupervisor profSup)
        {
            ProfesionalSupervisor Profesional = new ProfesionalSupervisor();
            Profesional = BuscarProfesionalSupervisor(person);
            if (Profesional == null)
            {

                //Profesional.Rut = profSup.Rut;
                //Profesional.Dv = profSup.Dv;
                //Profesional.Nombre = profSup.Nombre;
                //Profesional.ApPaterno = profSup.ApPaterno;
                //Profesional.ApMaterno = profSup.ApMaterno;
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


    }
}
