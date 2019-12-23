﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAS.v1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModeloContainer : DbContext
    {
        public ModeloContainer()
            : base("name=ModeloContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<DocenciaHospitalaria> DocenciaHospitalarias { get; set; }
        public virtual DbSet<Inmunizacion> Inmunizacions { get; set; }
        public virtual DbSet<CentroFormador> CentroFormadors { get; set; }
        public virtual DbSet<NombreCentroFormador> NombreCentroFormadors { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<NombreJornada> NombreJornadas { get; set; }
        public virtual DbSet<Dias> Dias { get; set; }
        public virtual DbSet<Periodo> Periodos { get; set; }
        public virtual DbSet<CampoClinicoAlumnoDias> CampoClinicoAlumnoDiasSet { get; set; }
        public virtual DbSet<NombreCampoClinico> NombreCampoClinicoSet { get; set; }
        public virtual DbSet<Institucion> Institucions { get; set; }
        public virtual DbSet<CampoClinicoAlumno> CampoClinicoAlumnos { get; set; }
        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Asignatura> Asignaturas { get; set; }
        public virtual DbSet<Semestre> Semestres { get; set; }
        public virtual DbSet<Anio> Anios { get; set; }
        public virtual DbSet<ProfesionalDocenteGuia> ProfesionalDocenteGuias { get; set; }
        public virtual DbSet<PerfilUsuario> PerfilUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<InmunizacionAlumno> ImunizacionesAlumnos { get; set; }
        public virtual DbSet<CursoNivel> CursosNiveles { get; set; }
        public virtual DbSet<CursoAlumno> CursoAlumnos { get; set; }
        public virtual DbSet<PlanDeEstudio> PlanDeEstudios { get; set; }
        public virtual DbSet<PlanEstudioAlumno> PlanEstudioAlumnos { get; set; }
        public virtual DbSet<SolicitudDeCupo> SolicitudDeCupos { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<Supervision> Supervicions { get; set; }
        public virtual DbSet<ProyeccionDeCupo> ProyeccionDeCupos { get; set; }
        public virtual DbSet<ProyeccionAlumno> ProyeccionAlumnos { get; set; }
        public virtual DbSet<ContadorSituacion> ContadorSituacions { get; set; }
    }
}
