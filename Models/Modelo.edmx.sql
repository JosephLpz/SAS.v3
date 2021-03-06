
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/21/2019 23:39:12
-- Generated from EDMX file: D:\Proyecto_escuela_de_la_salud\SES v.2.0\SES\SAS.v3\SAS.v3\Models\Modelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BD_SES.v10];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CentroFormadorCarrera]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CentroFormadors] DROP CONSTRAINT [FK_CentroFormadorCarrera];
GO
IF OBJECT_ID(N'[dbo].[FK_CentroFormadorNombreCentroFormador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CentroFormadors] DROP CONSTRAINT [FK_CentroFormadorNombreCentroFormador];
GO
IF OBJECT_ID(N'[dbo].[FK_PeriodoNombreJornada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Periodos] DROP CONSTRAINT [FK_PeriodoNombreJornada];
GO
IF OBJECT_ID(N'[dbo].[FK_CampoClinicoAlumnoDiasDias]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampoClinicoAlumnoDiasSet] DROP CONSTRAINT [FK_CampoClinicoAlumnoDiasDias];
GO
IF OBJECT_ID(N'[dbo].[FK_AlumnoPersona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Alumnos] DROP CONSTRAINT [FK_AlumnoPersona];
GO
IF OBJECT_ID(N'[dbo].[FK_CampoClinicoAlumnoAlumno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampoClinicoAlumnos] DROP CONSTRAINT [FK_CampoClinicoAlumnoAlumno];
GO
IF OBJECT_ID(N'[dbo].[FK_CampoClinicoAlumnoPeriodo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampoClinicoAlumnos] DROP CONSTRAINT [FK_CampoClinicoAlumnoPeriodo];
GO
IF OBJECT_ID(N'[dbo].[FK_CampoClinicoAlumnoDiasCampoClinicoAlumno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampoClinicoAlumnoDiasSet] DROP CONSTRAINT [FK_CampoClinicoAlumnoDiasCampoClinicoAlumno];
GO
IF OBJECT_ID(N'[dbo].[FK_CampoClinicoAlumnoAsignatura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampoClinicoAlumnos] DROP CONSTRAINT [FK_CampoClinicoAlumnoAsignatura];
GO
IF OBJECT_ID(N'[dbo].[FK_CampoClinicoAlumnoSemestre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampoClinicoAlumnos] DROP CONSTRAINT [FK_CampoClinicoAlumnoSemestre];
GO
IF OBJECT_ID(N'[dbo].[FK_CampoClinicoAlumnoAnio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampoClinicoAlumnos] DROP CONSTRAINT [FK_CampoClinicoAlumnoAnio];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesionalDocenteGuiaPersona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfesionalDocenteGuias] DROP CONSTRAINT [FK_ProfesionalDocenteGuiaPersona];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesionalDocenteGuiaDocenciaHospitalaria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfesionalDocenteGuias] DROP CONSTRAINT [FK_ProfesionalDocenteGuiaDocenciaHospitalaria];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesionalDocenteGuiaInmunizacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfesionalDocenteGuias] DROP CONSTRAINT [FK_ProfesionalDocenteGuiaInmunizacion];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfesionalDocenteGuiaCampoClinicoAlumno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampoClinicoAlumnos] DROP CONSTRAINT [FK_ProfesionalDocenteGuiaCampoClinicoAlumno];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioPersona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_UsuarioPersona];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilUsuarioUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerfilUsuarios] DROP CONSTRAINT [FK_PerfilUsuarioUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_ImunizacionAlumnoAlumno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImunizacionesAlumnos] DROP CONSTRAINT [FK_ImunizacionAlumnoAlumno];
GO
IF OBJECT_ID(N'[dbo].[FK_ImunizacionAlumnoInmunizacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImunizacionesAlumnos] DROP CONSTRAINT [FK_ImunizacionAlumnoInmunizacion];
GO
IF OBJECT_ID(N'[dbo].[FK_CursoAlumnoAlumno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CursoAlumnos] DROP CONSTRAINT [FK_CursoAlumnoAlumno];
GO
IF OBJECT_ID(N'[dbo].[FK_CursoAlumnoCursoNivel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CursoAlumnos] DROP CONSTRAINT [FK_CursoAlumnoCursoNivel];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanDeEstudioCarrera]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanDeEstudios] DROP CONSTRAINT [FK_PlanDeEstudioCarrera];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanDeEstudioAnio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanDeEstudios] DROP CONSTRAINT [FK_PlanDeEstudioAnio];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanEstudioAlumnoPlanDeEstudio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanEstudioAlumnos] DROP CONSTRAINT [FK_PlanEstudioAlumnoPlanDeEstudio];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanEstudioAlumnoAlumno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanEstudioAlumnos] DROP CONSTRAINT [FK_PlanEstudioAlumnoAlumno];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanDeEstudioAsignatura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanDeEstudios] DROP CONSTRAINT [FK_PlanDeEstudioAsignatura];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanDeEstudioSemestre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanDeEstudios] DROP CONSTRAINT [FK_PlanDeEstudioSemestre];
GO
IF OBJECT_ID(N'[dbo].[FK_SolicitudDeCupoCarrera]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SolicitudDeCupos] DROP CONSTRAINT [FK_SolicitudDeCupoCarrera];
GO
IF OBJECT_ID(N'[dbo].[FK_SolicitudDeCupoServicio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SolicitudDeCupos] DROP CONSTRAINT [FK_SolicitudDeCupoServicio];
GO
IF OBJECT_ID(N'[dbo].[FK_SolicitudDeCupoPeriodo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SolicitudDeCupos] DROP CONSTRAINT [FK_SolicitudDeCupoPeriodo];
GO
IF OBJECT_ID(N'[dbo].[FK_SolicitudDeCupoSupervision]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SolicitudDeCupos] DROP CONSTRAINT [FK_SolicitudDeCupoSupervision];
GO
IF OBJECT_ID(N'[dbo].[FK_SolicitudDeCupoAsignatura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SolicitudDeCupos] DROP CONSTRAINT [FK_SolicitudDeCupoAsignatura];
GO
IF OBJECT_ID(N'[dbo].[FK_ProyeccionDeCupoAsignatura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProyeccionDeCupos] DROP CONSTRAINT [FK_ProyeccionDeCupoAsignatura];
GO
IF OBJECT_ID(N'[dbo].[FK_ProyeccionDeCupoCarrera]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProyeccionDeCupos] DROP CONSTRAINT [FK_ProyeccionDeCupoCarrera];
GO
IF OBJECT_ID(N'[dbo].[FK_ProyeccionDeCupoAnio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProyeccionDeCupos] DROP CONSTRAINT [FK_ProyeccionDeCupoAnio];
GO
IF OBJECT_ID(N'[dbo].[FK_ProyeccionAlumnoProyeccionDeCupo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProyeccionAlumnos] DROP CONSTRAINT [FK_ProyeccionAlumnoProyeccionDeCupo];
GO
IF OBJECT_ID(N'[dbo].[FK_ProyeccionAlumnoAlumno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProyeccionAlumnos] DROP CONSTRAINT [FK_ProyeccionAlumnoAlumno];
GO
IF OBJECT_ID(N'[dbo].[FK_ProyeccionDeCupoSolicitudDeCupo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SolicitudDeCupos] DROP CONSTRAINT [FK_ProyeccionDeCupoSolicitudDeCupo];
GO
IF OBJECT_ID(N'[dbo].[FK_InstitucionNombreCampoClinico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NombreCampoClinicoSet] DROP CONSTRAINT [FK_InstitucionNombreCampoClinico];
GO
IF OBJECT_ID(N'[dbo].[FK_CentroFormadorAnio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CentroFormadors] DROP CONSTRAINT [FK_CentroFormadorAnio];
GO
IF OBJECT_ID(N'[dbo].[FK_ContadorSituacionAnio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContadorSituacions] DROP CONSTRAINT [FK_ContadorSituacionAnio];
GO
IF OBJECT_ID(N'[dbo].[FK_NombreCampoClinicoCampoClinicoAlumno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampoClinicoAlumnos] DROP CONSTRAINT [FK_NombreCampoClinicoCampoClinicoAlumno];
GO
IF OBJECT_ID(N'[dbo].[FK_NombreCampoClinicoSolicitudDeCupo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SolicitudDeCupos] DROP CONSTRAINT [FK_NombreCampoClinicoSolicitudDeCupo];
GO
IF OBJECT_ID(N'[dbo].[FK_AlumnoCentroFormador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Alumnos] DROP CONSTRAINT [FK_AlumnoCentroFormador];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Personas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personas];
GO
IF OBJECT_ID(N'[dbo].[DocenciaHospitalarias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocenciaHospitalarias];
GO
IF OBJECT_ID(N'[dbo].[Inmunizacions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Inmunizacions];
GO
IF OBJECT_ID(N'[dbo].[CentroFormadors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CentroFormadors];
GO
IF OBJECT_ID(N'[dbo].[NombreCentroFormadors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NombreCentroFormadors];
GO
IF OBJECT_ID(N'[dbo].[Carreras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Carreras];
GO
IF OBJECT_ID(N'[dbo].[NombreJornadas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NombreJornadas];
GO
IF OBJECT_ID(N'[dbo].[Dias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dias];
GO
IF OBJECT_ID(N'[dbo].[Periodos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Periodos];
GO
IF OBJECT_ID(N'[dbo].[CampoClinicoAlumnoDiasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CampoClinicoAlumnoDiasSet];
GO
IF OBJECT_ID(N'[dbo].[NombreCampoClinicoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NombreCampoClinicoSet];
GO
IF OBJECT_ID(N'[dbo].[Institucions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Institucions];
GO
IF OBJECT_ID(N'[dbo].[CampoClinicoAlumnos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CampoClinicoAlumnos];
GO
IF OBJECT_ID(N'[dbo].[Alumnos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Alumnos];
GO
IF OBJECT_ID(N'[dbo].[Asignaturas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Asignaturas];
GO
IF OBJECT_ID(N'[dbo].[Semestres]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Semestres];
GO
IF OBJECT_ID(N'[dbo].[Anios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Anios];
GO
IF OBJECT_ID(N'[dbo].[ProfesionalDocenteGuias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfesionalDocenteGuias];
GO
IF OBJECT_ID(N'[dbo].[PerfilUsuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PerfilUsuarios];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO
IF OBJECT_ID(N'[dbo].[ImunizacionesAlumnos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImunizacionesAlumnos];
GO
IF OBJECT_ID(N'[dbo].[CursosNiveles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CursosNiveles];
GO
IF OBJECT_ID(N'[dbo].[CursoAlumnos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CursoAlumnos];
GO
IF OBJECT_ID(N'[dbo].[PlanDeEstudios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanDeEstudios];
GO
IF OBJECT_ID(N'[dbo].[PlanEstudioAlumnos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanEstudioAlumnos];
GO
IF OBJECT_ID(N'[dbo].[SolicitudDeCupos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SolicitudDeCupos];
GO
IF OBJECT_ID(N'[dbo].[Servicios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Servicios];
GO
IF OBJECT_ID(N'[dbo].[Supervicions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Supervicions];
GO
IF OBJECT_ID(N'[dbo].[ProyeccionDeCupos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProyeccionDeCupos];
GO
IF OBJECT_ID(N'[dbo].[ProyeccionAlumnos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProyeccionAlumnos];
GO
IF OBJECT_ID(N'[dbo].[ContadorSituacions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContadorSituacions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Personas'
CREATE TABLE [dbo].[Personas] (
    [PersonaId] int IDENTITY(1,1) NOT NULL,
    [Rut] nvarchar(max)  NOT NULL,
    [Dv] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [ApPaterno] nvarchar(max)  NOT NULL,
    [ApMaterno] nvarchar(max)  NOT NULL,
    [Estado] tinyint  NOT NULL
);
GO

-- Creating table 'DocenciaHospitalarias'
CREATE TABLE [dbo].[DocenciaHospitalarias] (
    [DocenciaHospitalariaId] int IDENTITY(1,1) NOT NULL,
    [NombreDocenciaHospitalaria] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Inmunizacions'
CREATE TABLE [dbo].[Inmunizacions] (
    [InmunizacionId] int IDENTITY(1,1) NOT NULL,
    [NombreInmunizacion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CentroFormadors'
CREATE TABLE [dbo].[CentroFormadors] (
    [CentroFormadorId] int IDENTITY(1,1) NOT NULL,
    [CarreraCarreraId] int  NOT NULL,
    [NombreCentroFormadorNombreCentroFormadorId] int  NOT NULL,
    [AnioId] int  NOT NULL
);
GO

-- Creating table 'NombreCentroFormadors'
CREATE TABLE [dbo].[NombreCentroFormadors] (
    [NombreCentroFormadorId] int IDENTITY(1,1) NOT NULL,
    [NombreCentroFormador1] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Carreras'
CREATE TABLE [dbo].[Carreras] (
    [CarreraId] int IDENTITY(1,1) NOT NULL,
    [NombreCarrera] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NombreJornadas'
CREATE TABLE [dbo].[NombreJornadas] (
    [NombreJornadaId] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Dias'
CREATE TABLE [dbo].[Dias] (
    [DiasId] int IDENTITY(1,1) NOT NULL,
    [Dia] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Periodos'
CREATE TABLE [dbo].[Periodos] (
    [PeriodoId] int IDENTITY(1,1) NOT NULL,
    [FechaInicio] datetime  NOT NULL,
    [FechaTermino] datetime  NOT NULL,
    [NombreJornadaNombreJornadaId] int  NOT NULL
);
GO

-- Creating table 'CampoClinicoAlumnoDiasSet'
CREATE TABLE [dbo].[CampoClinicoAlumnoDiasSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DiasDiasId] int  NOT NULL,
    [CampoClinicoAlumnoId] int  NOT NULL
);
GO

-- Creating table 'NombreCampoClinicoSet'
CREATE TABLE [dbo].[NombreCampoClinicoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreCampo] nvarchar(max)  NOT NULL,
    [InstitucionId] int  NOT NULL
);
GO

-- Creating table 'Institucions'
CREATE TABLE [dbo].[Institucions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreInstitucion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CampoClinicoAlumnos'
CREATE TABLE [dbo].[CampoClinicoAlumnos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AlumnoAlumnoId] int  NOT NULL,
    [UnidadDeServicioUnidadDeServicioId] int  NOT NULL,
    [PeriodoPeriodoId] int  NOT NULL,
    [AsignaturaId] int  NOT NULL,
    [SemestreId] int  NOT NULL,
    [AnioId] int  NOT NULL,
    [ProfesionalDocenteGuiaProfesionalDocenteGuiaId] int  NOT NULL,
    [InstitucionId] int  NOT NULL,
    [NombreCampoClinicoId] int  NOT NULL
);
GO

-- Creating table 'Alumnos'
CREATE TABLE [dbo].[Alumnos] (
    [AlumnoId] int IDENTITY(1,1) NOT NULL,
    [Observaciones] nvarchar(max)  NOT NULL,
    [PersonaPersonaId] int  NOT NULL,
    [CentroFormadorId] int  NOT NULL,
    [SituacionAlumno] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Asignaturas'
CREATE TABLE [dbo].[Asignaturas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreAsignatura] nvarchar(max)  NOT NULL,
    [CodigoAsignatura] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Semestres'
CREATE TABLE [dbo].[Semestres] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreSemestre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Anios'
CREATE TABLE [dbo].[Anios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ano] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProfesionalDocenteGuias'
CREATE TABLE [dbo].[ProfesionalDocenteGuias] (
    [ProfesionalDocenteGuiaId] int IDENTITY(1,1) NOT NULL,
    [Profesion] nvarchar(max)  NOT NULL,
    [NumeroSuperintendencia] bigint  NOT NULL,
    [Telefono] bigint  NOT NULL,
    [Correo] nvarchar(max)  NOT NULL,
    [CumpleDatos] nvarchar(max)  NOT NULL,
    [ValorDocente] bigint  NOT NULL,
    [PersonaPersonaId] int  NOT NULL,
    [DocenciaHospitalariaDocenciaHospitalariaId] int  NOT NULL,
    [InmunizacionInmunizacionId] int  NOT NULL,
    [TipoDocente] int  NOT NULL
);
GO

-- Creating table 'PerfilUsuarios'
CREATE TABLE [dbo].[PerfilUsuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Perfil] int  NOT NULL,
    [Estado] tinyint  NOT NULL,
    [UsuarioId] int  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cuenta] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Correo] nvarchar(max)  NOT NULL,
    [Estado] tinyint  NOT NULL,
    [PersonaPersonaId] int  NOT NULL
);
GO

-- Creating table 'ImunizacionesAlumnos'
CREATE TABLE [dbo].[ImunizacionesAlumnos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AlumnoAlumnoId] int  NOT NULL,
    [InmunizacionInmunizacionId] int  NOT NULL
);
GO

-- Creating table 'CursosNiveles'
CREATE TABLE [dbo].[CursosNiveles] (
    [CursoNivelId] int IDENTITY(1,1) NOT NULL,
    [NombreCurso] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CursoAlumnos'
CREATE TABLE [dbo].[CursoAlumnos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AlumnoAlumnoId] int  NOT NULL,
    [CursoNivelId] int  NOT NULL
);
GO

-- Creating table 'PlanDeEstudios'
CREATE TABLE [dbo].[PlanDeEstudios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CarreraCarreraId] int  NOT NULL,
    [AnioId] int  NOT NULL,
    [UD] nvarchar(max)  NOT NULL,
    [Catedra] nvarchar(max)  NOT NULL,
    [Taller] nvarchar(max)  NOT NULL,
    [LAB] nvarchar(max)  NOT NULL,
    [PC] nvarchar(max)  NOT NULL,
    [SCT] nvarchar(max)  NOT NULL,
    [Materia] nvarchar(max)  NOT NULL,
    [Curso] nvarchar(max)  NOT NULL,
    [AsignaturaId] int  NOT NULL,
    [SemestreId] int  NOT NULL,
    [PorcentajeReprobacion] nvarchar(max)  NOT NULL,
    [AsignaturaPreRequisito] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PlanEstudioAlumnos'
CREATE TABLE [dbo].[PlanEstudioAlumnos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PlanDeEstudioId] int  NOT NULL,
    [AlumnoAlumnoId] int  NOT NULL,
    [EstadoAsignatura] int  NOT NULL
);
GO

-- Creating table 'SolicitudDeCupos'
CREATE TABLE [dbo].[SolicitudDeCupos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CarreraCarreraId] int  NOT NULL,
    [ServicioId] int  NOT NULL,
    [CuposAlumnos] int  NOT NULL,
    [TotalSemanaPorGrupo] int  NOT NULL,
    [PeriodoPeriodoId] int  NOT NULL,
    [SupervisionId] int  NOT NULL,
    [AsignaturaId] int  NOT NULL,
    [Observacion] nvarchar(max)  NOT NULL,
    [ProyeccionDeCupoId] int  NOT NULL,
    [InstitucionId] int  NOT NULL,
    [NombreCampoClinicoId] int  NOT NULL
);
GO

-- Creating table 'Servicios'
CREATE TABLE [dbo].[Servicios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreServicio] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Supervicions'
CREATE TABLE [dbo].[Supervicions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreSupervision] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProyeccionDeCupos'
CREATE TABLE [dbo].[ProyeccionDeCupos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AsignaturaId] int  NOT NULL,
    [CarreraCarreraId] int  NOT NULL,
    [AnioId] int  NOT NULL,
    [CuposProyectados] nvarchar(max)  NOT NULL,
    [CuposRestantes] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProyeccionAlumnos'
CREATE TABLE [dbo].[ProyeccionAlumnos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProyeccionDeCupoId] int  NOT NULL,
    [AlumnoAlumnoId] int  NOT NULL
);
GO

-- Creating table 'ContadorSituacions'
CREATE TABLE [dbo].[ContadorSituacions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Vigente] nvarchar(max)  NOT NULL,
    [RetiroTemporal] nvarchar(max)  NOT NULL,
    [RetiroDefinitivo] nvarchar(max)  NOT NULL,
    [EliminadoAcademica] nvarchar(max)  NOT NULL,
    [RetractoMatricula] nvarchar(max)  NOT NULL,
    [EiminadoNoMatricula] nvarchar(max)  NOT NULL,
    [Abandono] nvarchar(max)  NOT NULL,
    [AnioId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PersonaId] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [PK_Personas]
    PRIMARY KEY CLUSTERED ([PersonaId] ASC);
GO

-- Creating primary key on [DocenciaHospitalariaId] in table 'DocenciaHospitalarias'
ALTER TABLE [dbo].[DocenciaHospitalarias]
ADD CONSTRAINT [PK_DocenciaHospitalarias]
    PRIMARY KEY CLUSTERED ([DocenciaHospitalariaId] ASC);
GO

-- Creating primary key on [InmunizacionId] in table 'Inmunizacions'
ALTER TABLE [dbo].[Inmunizacions]
ADD CONSTRAINT [PK_Inmunizacions]
    PRIMARY KEY CLUSTERED ([InmunizacionId] ASC);
GO

-- Creating primary key on [CentroFormadorId] in table 'CentroFormadors'
ALTER TABLE [dbo].[CentroFormadors]
ADD CONSTRAINT [PK_CentroFormadors]
    PRIMARY KEY CLUSTERED ([CentroFormadorId] ASC);
GO

-- Creating primary key on [NombreCentroFormadorId] in table 'NombreCentroFormadors'
ALTER TABLE [dbo].[NombreCentroFormadors]
ADD CONSTRAINT [PK_NombreCentroFormadors]
    PRIMARY KEY CLUSTERED ([NombreCentroFormadorId] ASC);
GO

-- Creating primary key on [CarreraId] in table 'Carreras'
ALTER TABLE [dbo].[Carreras]
ADD CONSTRAINT [PK_Carreras]
    PRIMARY KEY CLUSTERED ([CarreraId] ASC);
GO

-- Creating primary key on [NombreJornadaId] in table 'NombreJornadas'
ALTER TABLE [dbo].[NombreJornadas]
ADD CONSTRAINT [PK_NombreJornadas]
    PRIMARY KEY CLUSTERED ([NombreJornadaId] ASC);
GO

-- Creating primary key on [DiasId] in table 'Dias'
ALTER TABLE [dbo].[Dias]
ADD CONSTRAINT [PK_Dias]
    PRIMARY KEY CLUSTERED ([DiasId] ASC);
GO

-- Creating primary key on [PeriodoId] in table 'Periodos'
ALTER TABLE [dbo].[Periodos]
ADD CONSTRAINT [PK_Periodos]
    PRIMARY KEY CLUSTERED ([PeriodoId] ASC);
GO

-- Creating primary key on [Id] in table 'CampoClinicoAlumnoDiasSet'
ALTER TABLE [dbo].[CampoClinicoAlumnoDiasSet]
ADD CONSTRAINT [PK_CampoClinicoAlumnoDiasSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NombreCampoClinicoSet'
ALTER TABLE [dbo].[NombreCampoClinicoSet]
ADD CONSTRAINT [PK_NombreCampoClinicoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Institucions'
ALTER TABLE [dbo].[Institucions]
ADD CONSTRAINT [PK_Institucions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CampoClinicoAlumnos'
ALTER TABLE [dbo].[CampoClinicoAlumnos]
ADD CONSTRAINT [PK_CampoClinicoAlumnos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AlumnoId] in table 'Alumnos'
ALTER TABLE [dbo].[Alumnos]
ADD CONSTRAINT [PK_Alumnos]
    PRIMARY KEY CLUSTERED ([AlumnoId] ASC);
GO

-- Creating primary key on [Id] in table 'Asignaturas'
ALTER TABLE [dbo].[Asignaturas]
ADD CONSTRAINT [PK_Asignaturas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Semestres'
ALTER TABLE [dbo].[Semestres]
ADD CONSTRAINT [PK_Semestres]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Anios'
ALTER TABLE [dbo].[Anios]
ADD CONSTRAINT [PK_Anios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ProfesionalDocenteGuiaId] in table 'ProfesionalDocenteGuias'
ALTER TABLE [dbo].[ProfesionalDocenteGuias]
ADD CONSTRAINT [PK_ProfesionalDocenteGuias]
    PRIMARY KEY CLUSTERED ([ProfesionalDocenteGuiaId] ASC);
GO

-- Creating primary key on [Id] in table 'PerfilUsuarios'
ALTER TABLE [dbo].[PerfilUsuarios]
ADD CONSTRAINT [PK_PerfilUsuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ImunizacionesAlumnos'
ALTER TABLE [dbo].[ImunizacionesAlumnos]
ADD CONSTRAINT [PK_ImunizacionesAlumnos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CursoNivelId] in table 'CursosNiveles'
ALTER TABLE [dbo].[CursosNiveles]
ADD CONSTRAINT [PK_CursosNiveles]
    PRIMARY KEY CLUSTERED ([CursoNivelId] ASC);
GO

-- Creating primary key on [Id] in table 'CursoAlumnos'
ALTER TABLE [dbo].[CursoAlumnos]
ADD CONSTRAINT [PK_CursoAlumnos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlanDeEstudios'
ALTER TABLE [dbo].[PlanDeEstudios]
ADD CONSTRAINT [PK_PlanDeEstudios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlanEstudioAlumnos'
ALTER TABLE [dbo].[PlanEstudioAlumnos]
ADD CONSTRAINT [PK_PlanEstudioAlumnos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SolicitudDeCupos'
ALTER TABLE [dbo].[SolicitudDeCupos]
ADD CONSTRAINT [PK_SolicitudDeCupos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Servicios'
ALTER TABLE [dbo].[Servicios]
ADD CONSTRAINT [PK_Servicios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Supervicions'
ALTER TABLE [dbo].[Supervicions]
ADD CONSTRAINT [PK_Supervicions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProyeccionDeCupos'
ALTER TABLE [dbo].[ProyeccionDeCupos]
ADD CONSTRAINT [PK_ProyeccionDeCupos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProyeccionAlumnos'
ALTER TABLE [dbo].[ProyeccionAlumnos]
ADD CONSTRAINT [PK_ProyeccionAlumnos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContadorSituacions'
ALTER TABLE [dbo].[ContadorSituacions]
ADD CONSTRAINT [PK_ContadorSituacions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CarreraCarreraId] in table 'CentroFormadors'
ALTER TABLE [dbo].[CentroFormadors]
ADD CONSTRAINT [FK_CentroFormadorCarrera]
    FOREIGN KEY ([CarreraCarreraId])
    REFERENCES [dbo].[Carreras]
        ([CarreraId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CentroFormadorCarrera'
CREATE INDEX [IX_FK_CentroFormadorCarrera]
ON [dbo].[CentroFormadors]
    ([CarreraCarreraId]);
GO

-- Creating foreign key on [NombreCentroFormadorNombreCentroFormadorId] in table 'CentroFormadors'
ALTER TABLE [dbo].[CentroFormadors]
ADD CONSTRAINT [FK_CentroFormadorNombreCentroFormador]
    FOREIGN KEY ([NombreCentroFormadorNombreCentroFormadorId])
    REFERENCES [dbo].[NombreCentroFormadors]
        ([NombreCentroFormadorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CentroFormadorNombreCentroFormador'
CREATE INDEX [IX_FK_CentroFormadorNombreCentroFormador]
ON [dbo].[CentroFormadors]
    ([NombreCentroFormadorNombreCentroFormadorId]);
GO

-- Creating foreign key on [NombreJornadaNombreJornadaId] in table 'Periodos'
ALTER TABLE [dbo].[Periodos]
ADD CONSTRAINT [FK_PeriodoNombreJornada]
    FOREIGN KEY ([NombreJornadaNombreJornadaId])
    REFERENCES [dbo].[NombreJornadas]
        ([NombreJornadaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PeriodoNombreJornada'
CREATE INDEX [IX_FK_PeriodoNombreJornada]
ON [dbo].[Periodos]
    ([NombreJornadaNombreJornadaId]);
GO

-- Creating foreign key on [DiasDiasId] in table 'CampoClinicoAlumnoDiasSet'
ALTER TABLE [dbo].[CampoClinicoAlumnoDiasSet]
ADD CONSTRAINT [FK_CampoClinicoAlumnoDiasDias]
    FOREIGN KEY ([DiasDiasId])
    REFERENCES [dbo].[Dias]
        ([DiasId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CampoClinicoAlumnoDiasDias'
CREATE INDEX [IX_FK_CampoClinicoAlumnoDiasDias]
ON [dbo].[CampoClinicoAlumnoDiasSet]
    ([DiasDiasId]);
GO

-- Creating foreign key on [PersonaPersonaId] in table 'Alumnos'
ALTER TABLE [dbo].[Alumnos]
ADD CONSTRAINT [FK_AlumnoPersona]
    FOREIGN KEY ([PersonaPersonaId])
    REFERENCES [dbo].[Personas]
        ([PersonaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlumnoPersona'
CREATE INDEX [IX_FK_AlumnoPersona]
ON [dbo].[Alumnos]
    ([PersonaPersonaId]);
GO

-- Creating foreign key on [AlumnoAlumnoId] in table 'CampoClinicoAlumnos'
ALTER TABLE [dbo].[CampoClinicoAlumnos]
ADD CONSTRAINT [FK_CampoClinicoAlumnoAlumno]
    FOREIGN KEY ([AlumnoAlumnoId])
    REFERENCES [dbo].[Alumnos]
        ([AlumnoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CampoClinicoAlumnoAlumno'
CREATE INDEX [IX_FK_CampoClinicoAlumnoAlumno]
ON [dbo].[CampoClinicoAlumnos]
    ([AlumnoAlumnoId]);
GO

-- Creating foreign key on [PeriodoPeriodoId] in table 'CampoClinicoAlumnos'
ALTER TABLE [dbo].[CampoClinicoAlumnos]
ADD CONSTRAINT [FK_CampoClinicoAlumnoPeriodo]
    FOREIGN KEY ([PeriodoPeriodoId])
    REFERENCES [dbo].[Periodos]
        ([PeriodoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CampoClinicoAlumnoPeriodo'
CREATE INDEX [IX_FK_CampoClinicoAlumnoPeriodo]
ON [dbo].[CampoClinicoAlumnos]
    ([PeriodoPeriodoId]);
GO

-- Creating foreign key on [CampoClinicoAlumnoId] in table 'CampoClinicoAlumnoDiasSet'
ALTER TABLE [dbo].[CampoClinicoAlumnoDiasSet]
ADD CONSTRAINT [FK_CampoClinicoAlumnoDiasCampoClinicoAlumno]
    FOREIGN KEY ([CampoClinicoAlumnoId])
    REFERENCES [dbo].[CampoClinicoAlumnos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CampoClinicoAlumnoDiasCampoClinicoAlumno'
CREATE INDEX [IX_FK_CampoClinicoAlumnoDiasCampoClinicoAlumno]
ON [dbo].[CampoClinicoAlumnoDiasSet]
    ([CampoClinicoAlumnoId]);
GO

-- Creating foreign key on [AsignaturaId] in table 'CampoClinicoAlumnos'
ALTER TABLE [dbo].[CampoClinicoAlumnos]
ADD CONSTRAINT [FK_CampoClinicoAlumnoAsignatura]
    FOREIGN KEY ([AsignaturaId])
    REFERENCES [dbo].[Asignaturas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CampoClinicoAlumnoAsignatura'
CREATE INDEX [IX_FK_CampoClinicoAlumnoAsignatura]
ON [dbo].[CampoClinicoAlumnos]
    ([AsignaturaId]);
GO

-- Creating foreign key on [SemestreId] in table 'CampoClinicoAlumnos'
ALTER TABLE [dbo].[CampoClinicoAlumnos]
ADD CONSTRAINT [FK_CampoClinicoAlumnoSemestre]
    FOREIGN KEY ([SemestreId])
    REFERENCES [dbo].[Semestres]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CampoClinicoAlumnoSemestre'
CREATE INDEX [IX_FK_CampoClinicoAlumnoSemestre]
ON [dbo].[CampoClinicoAlumnos]
    ([SemestreId]);
GO

-- Creating foreign key on [AnioId] in table 'CampoClinicoAlumnos'
ALTER TABLE [dbo].[CampoClinicoAlumnos]
ADD CONSTRAINT [FK_CampoClinicoAlumnoAnio]
    FOREIGN KEY ([AnioId])
    REFERENCES [dbo].[Anios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CampoClinicoAlumnoAnio'
CREATE INDEX [IX_FK_CampoClinicoAlumnoAnio]
ON [dbo].[CampoClinicoAlumnos]
    ([AnioId]);
GO

-- Creating foreign key on [PersonaPersonaId] in table 'ProfesionalDocenteGuias'
ALTER TABLE [dbo].[ProfesionalDocenteGuias]
ADD CONSTRAINT [FK_ProfesionalDocenteGuiaPersona]
    FOREIGN KEY ([PersonaPersonaId])
    REFERENCES [dbo].[Personas]
        ([PersonaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesionalDocenteGuiaPersona'
CREATE INDEX [IX_FK_ProfesionalDocenteGuiaPersona]
ON [dbo].[ProfesionalDocenteGuias]
    ([PersonaPersonaId]);
GO

-- Creating foreign key on [DocenciaHospitalariaDocenciaHospitalariaId] in table 'ProfesionalDocenteGuias'
ALTER TABLE [dbo].[ProfesionalDocenteGuias]
ADD CONSTRAINT [FK_ProfesionalDocenteGuiaDocenciaHospitalaria]
    FOREIGN KEY ([DocenciaHospitalariaDocenciaHospitalariaId])
    REFERENCES [dbo].[DocenciaHospitalarias]
        ([DocenciaHospitalariaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesionalDocenteGuiaDocenciaHospitalaria'
CREATE INDEX [IX_FK_ProfesionalDocenteGuiaDocenciaHospitalaria]
ON [dbo].[ProfesionalDocenteGuias]
    ([DocenciaHospitalariaDocenciaHospitalariaId]);
GO

-- Creating foreign key on [InmunizacionInmunizacionId] in table 'ProfesionalDocenteGuias'
ALTER TABLE [dbo].[ProfesionalDocenteGuias]
ADD CONSTRAINT [FK_ProfesionalDocenteGuiaInmunizacion]
    FOREIGN KEY ([InmunizacionInmunizacionId])
    REFERENCES [dbo].[Inmunizacions]
        ([InmunizacionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesionalDocenteGuiaInmunizacion'
CREATE INDEX [IX_FK_ProfesionalDocenteGuiaInmunizacion]
ON [dbo].[ProfesionalDocenteGuias]
    ([InmunizacionInmunizacionId]);
GO

-- Creating foreign key on [ProfesionalDocenteGuiaProfesionalDocenteGuiaId] in table 'CampoClinicoAlumnos'
ALTER TABLE [dbo].[CampoClinicoAlumnos]
ADD CONSTRAINT [FK_ProfesionalDocenteGuiaCampoClinicoAlumno]
    FOREIGN KEY ([ProfesionalDocenteGuiaProfesionalDocenteGuiaId])
    REFERENCES [dbo].[ProfesionalDocenteGuias]
        ([ProfesionalDocenteGuiaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesionalDocenteGuiaCampoClinicoAlumno'
CREATE INDEX [IX_FK_ProfesionalDocenteGuiaCampoClinicoAlumno]
ON [dbo].[CampoClinicoAlumnos]
    ([ProfesionalDocenteGuiaProfesionalDocenteGuiaId]);
GO

-- Creating foreign key on [PersonaPersonaId] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_UsuarioPersona]
    FOREIGN KEY ([PersonaPersonaId])
    REFERENCES [dbo].[Personas]
        ([PersonaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioPersona'
CREATE INDEX [IX_FK_UsuarioPersona]
ON [dbo].[Usuarios]
    ([PersonaPersonaId]);
GO

-- Creating foreign key on [UsuarioId] in table 'PerfilUsuarios'
ALTER TABLE [dbo].[PerfilUsuarios]
ADD CONSTRAINT [FK_PerfilUsuarioUsuario]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerfilUsuarioUsuario'
CREATE INDEX [IX_FK_PerfilUsuarioUsuario]
ON [dbo].[PerfilUsuarios]
    ([UsuarioId]);
GO

-- Creating foreign key on [AlumnoAlumnoId] in table 'ImunizacionesAlumnos'
ALTER TABLE [dbo].[ImunizacionesAlumnos]
ADD CONSTRAINT [FK_ImunizacionAlumnoAlumno]
    FOREIGN KEY ([AlumnoAlumnoId])
    REFERENCES [dbo].[Alumnos]
        ([AlumnoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImunizacionAlumnoAlumno'
CREATE INDEX [IX_FK_ImunizacionAlumnoAlumno]
ON [dbo].[ImunizacionesAlumnos]
    ([AlumnoAlumnoId]);
GO

-- Creating foreign key on [InmunizacionInmunizacionId] in table 'ImunizacionesAlumnos'
ALTER TABLE [dbo].[ImunizacionesAlumnos]
ADD CONSTRAINT [FK_ImunizacionAlumnoInmunizacion]
    FOREIGN KEY ([InmunizacionInmunizacionId])
    REFERENCES [dbo].[Inmunizacions]
        ([InmunizacionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImunizacionAlumnoInmunizacion'
CREATE INDEX [IX_FK_ImunizacionAlumnoInmunizacion]
ON [dbo].[ImunizacionesAlumnos]
    ([InmunizacionInmunizacionId]);
GO

-- Creating foreign key on [AlumnoAlumnoId] in table 'CursoAlumnos'
ALTER TABLE [dbo].[CursoAlumnos]
ADD CONSTRAINT [FK_CursoAlumnoAlumno]
    FOREIGN KEY ([AlumnoAlumnoId])
    REFERENCES [dbo].[Alumnos]
        ([AlumnoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CursoAlumnoAlumno'
CREATE INDEX [IX_FK_CursoAlumnoAlumno]
ON [dbo].[CursoAlumnos]
    ([AlumnoAlumnoId]);
GO

-- Creating foreign key on [CursoNivelId] in table 'CursoAlumnos'
ALTER TABLE [dbo].[CursoAlumnos]
ADD CONSTRAINT [FK_CursoAlumnoCursoNivel]
    FOREIGN KEY ([CursoNivelId])
    REFERENCES [dbo].[CursosNiveles]
        ([CursoNivelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CursoAlumnoCursoNivel'
CREATE INDEX [IX_FK_CursoAlumnoCursoNivel]
ON [dbo].[CursoAlumnos]
    ([CursoNivelId]);
GO

-- Creating foreign key on [CarreraCarreraId] in table 'PlanDeEstudios'
ALTER TABLE [dbo].[PlanDeEstudios]
ADD CONSTRAINT [FK_PlanDeEstudioCarrera]
    FOREIGN KEY ([CarreraCarreraId])
    REFERENCES [dbo].[Carreras]
        ([CarreraId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanDeEstudioCarrera'
CREATE INDEX [IX_FK_PlanDeEstudioCarrera]
ON [dbo].[PlanDeEstudios]
    ([CarreraCarreraId]);
GO

-- Creating foreign key on [AnioId] in table 'PlanDeEstudios'
ALTER TABLE [dbo].[PlanDeEstudios]
ADD CONSTRAINT [FK_PlanDeEstudioAnio]
    FOREIGN KEY ([AnioId])
    REFERENCES [dbo].[Anios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanDeEstudioAnio'
CREATE INDEX [IX_FK_PlanDeEstudioAnio]
ON [dbo].[PlanDeEstudios]
    ([AnioId]);
GO

-- Creating foreign key on [PlanDeEstudioId] in table 'PlanEstudioAlumnos'
ALTER TABLE [dbo].[PlanEstudioAlumnos]
ADD CONSTRAINT [FK_PlanEstudioAlumnoPlanDeEstudio]
    FOREIGN KEY ([PlanDeEstudioId])
    REFERENCES [dbo].[PlanDeEstudios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanEstudioAlumnoPlanDeEstudio'
CREATE INDEX [IX_FK_PlanEstudioAlumnoPlanDeEstudio]
ON [dbo].[PlanEstudioAlumnos]
    ([PlanDeEstudioId]);
GO

-- Creating foreign key on [AlumnoAlumnoId] in table 'PlanEstudioAlumnos'
ALTER TABLE [dbo].[PlanEstudioAlumnos]
ADD CONSTRAINT [FK_PlanEstudioAlumnoAlumno]
    FOREIGN KEY ([AlumnoAlumnoId])
    REFERENCES [dbo].[Alumnos]
        ([AlumnoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanEstudioAlumnoAlumno'
CREATE INDEX [IX_FK_PlanEstudioAlumnoAlumno]
ON [dbo].[PlanEstudioAlumnos]
    ([AlumnoAlumnoId]);
GO

-- Creating foreign key on [AsignaturaId] in table 'PlanDeEstudios'
ALTER TABLE [dbo].[PlanDeEstudios]
ADD CONSTRAINT [FK_PlanDeEstudioAsignatura]
    FOREIGN KEY ([AsignaturaId])
    REFERENCES [dbo].[Asignaturas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanDeEstudioAsignatura'
CREATE INDEX [IX_FK_PlanDeEstudioAsignatura]
ON [dbo].[PlanDeEstudios]
    ([AsignaturaId]);
GO

-- Creating foreign key on [SemestreId] in table 'PlanDeEstudios'
ALTER TABLE [dbo].[PlanDeEstudios]
ADD CONSTRAINT [FK_PlanDeEstudioSemestre]
    FOREIGN KEY ([SemestreId])
    REFERENCES [dbo].[Semestres]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanDeEstudioSemestre'
CREATE INDEX [IX_FK_PlanDeEstudioSemestre]
ON [dbo].[PlanDeEstudios]
    ([SemestreId]);
GO

-- Creating foreign key on [CarreraCarreraId] in table 'SolicitudDeCupos'
ALTER TABLE [dbo].[SolicitudDeCupos]
ADD CONSTRAINT [FK_SolicitudDeCupoCarrera]
    FOREIGN KEY ([CarreraCarreraId])
    REFERENCES [dbo].[Carreras]
        ([CarreraId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SolicitudDeCupoCarrera'
CREATE INDEX [IX_FK_SolicitudDeCupoCarrera]
ON [dbo].[SolicitudDeCupos]
    ([CarreraCarreraId]);
GO

-- Creating foreign key on [ServicioId] in table 'SolicitudDeCupos'
ALTER TABLE [dbo].[SolicitudDeCupos]
ADD CONSTRAINT [FK_SolicitudDeCupoServicio]
    FOREIGN KEY ([ServicioId])
    REFERENCES [dbo].[Servicios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SolicitudDeCupoServicio'
CREATE INDEX [IX_FK_SolicitudDeCupoServicio]
ON [dbo].[SolicitudDeCupos]
    ([ServicioId]);
GO

-- Creating foreign key on [PeriodoPeriodoId] in table 'SolicitudDeCupos'
ALTER TABLE [dbo].[SolicitudDeCupos]
ADD CONSTRAINT [FK_SolicitudDeCupoPeriodo]
    FOREIGN KEY ([PeriodoPeriodoId])
    REFERENCES [dbo].[Periodos]
        ([PeriodoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SolicitudDeCupoPeriodo'
CREATE INDEX [IX_FK_SolicitudDeCupoPeriodo]
ON [dbo].[SolicitudDeCupos]
    ([PeriodoPeriodoId]);
GO

-- Creating foreign key on [SupervisionId] in table 'SolicitudDeCupos'
ALTER TABLE [dbo].[SolicitudDeCupos]
ADD CONSTRAINT [FK_SolicitudDeCupoSupervision]
    FOREIGN KEY ([SupervisionId])
    REFERENCES [dbo].[Supervicions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SolicitudDeCupoSupervision'
CREATE INDEX [IX_FK_SolicitudDeCupoSupervision]
ON [dbo].[SolicitudDeCupos]
    ([SupervisionId]);
GO

-- Creating foreign key on [AsignaturaId] in table 'SolicitudDeCupos'
ALTER TABLE [dbo].[SolicitudDeCupos]
ADD CONSTRAINT [FK_SolicitudDeCupoAsignatura]
    FOREIGN KEY ([AsignaturaId])
    REFERENCES [dbo].[Asignaturas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SolicitudDeCupoAsignatura'
CREATE INDEX [IX_FK_SolicitudDeCupoAsignatura]
ON [dbo].[SolicitudDeCupos]
    ([AsignaturaId]);
GO

-- Creating foreign key on [AsignaturaId] in table 'ProyeccionDeCupos'
ALTER TABLE [dbo].[ProyeccionDeCupos]
ADD CONSTRAINT [FK_ProyeccionDeCupoAsignatura]
    FOREIGN KEY ([AsignaturaId])
    REFERENCES [dbo].[Asignaturas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProyeccionDeCupoAsignatura'
CREATE INDEX [IX_FK_ProyeccionDeCupoAsignatura]
ON [dbo].[ProyeccionDeCupos]
    ([AsignaturaId]);
GO

-- Creating foreign key on [CarreraCarreraId] in table 'ProyeccionDeCupos'
ALTER TABLE [dbo].[ProyeccionDeCupos]
ADD CONSTRAINT [FK_ProyeccionDeCupoCarrera]
    FOREIGN KEY ([CarreraCarreraId])
    REFERENCES [dbo].[Carreras]
        ([CarreraId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProyeccionDeCupoCarrera'
CREATE INDEX [IX_FK_ProyeccionDeCupoCarrera]
ON [dbo].[ProyeccionDeCupos]
    ([CarreraCarreraId]);
GO

-- Creating foreign key on [AnioId] in table 'ProyeccionDeCupos'
ALTER TABLE [dbo].[ProyeccionDeCupos]
ADD CONSTRAINT [FK_ProyeccionDeCupoAnio]
    FOREIGN KEY ([AnioId])
    REFERENCES [dbo].[Anios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProyeccionDeCupoAnio'
CREATE INDEX [IX_FK_ProyeccionDeCupoAnio]
ON [dbo].[ProyeccionDeCupos]
    ([AnioId]);
GO

-- Creating foreign key on [ProyeccionDeCupoId] in table 'ProyeccionAlumnos'
ALTER TABLE [dbo].[ProyeccionAlumnos]
ADD CONSTRAINT [FK_ProyeccionAlumnoProyeccionDeCupo]
    FOREIGN KEY ([ProyeccionDeCupoId])
    REFERENCES [dbo].[ProyeccionDeCupos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProyeccionAlumnoProyeccionDeCupo'
CREATE INDEX [IX_FK_ProyeccionAlumnoProyeccionDeCupo]
ON [dbo].[ProyeccionAlumnos]
    ([ProyeccionDeCupoId]);
GO

-- Creating foreign key on [AlumnoAlumnoId] in table 'ProyeccionAlumnos'
ALTER TABLE [dbo].[ProyeccionAlumnos]
ADD CONSTRAINT [FK_ProyeccionAlumnoAlumno]
    FOREIGN KEY ([AlumnoAlumnoId])
    REFERENCES [dbo].[Alumnos]
        ([AlumnoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProyeccionAlumnoAlumno'
CREATE INDEX [IX_FK_ProyeccionAlumnoAlumno]
ON [dbo].[ProyeccionAlumnos]
    ([AlumnoAlumnoId]);
GO

-- Creating foreign key on [ProyeccionDeCupoId] in table 'SolicitudDeCupos'
ALTER TABLE [dbo].[SolicitudDeCupos]
ADD CONSTRAINT [FK_ProyeccionDeCupoSolicitudDeCupo]
    FOREIGN KEY ([ProyeccionDeCupoId])
    REFERENCES [dbo].[ProyeccionDeCupos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProyeccionDeCupoSolicitudDeCupo'
CREATE INDEX [IX_FK_ProyeccionDeCupoSolicitudDeCupo]
ON [dbo].[SolicitudDeCupos]
    ([ProyeccionDeCupoId]);
GO

-- Creating foreign key on [InstitucionId] in table 'NombreCampoClinicoSet'
ALTER TABLE [dbo].[NombreCampoClinicoSet]
ADD CONSTRAINT [FK_InstitucionNombreCampoClinico]
    FOREIGN KEY ([InstitucionId])
    REFERENCES [dbo].[Institucions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InstitucionNombreCampoClinico'
CREATE INDEX [IX_FK_InstitucionNombreCampoClinico]
ON [dbo].[NombreCampoClinicoSet]
    ([InstitucionId]);
GO

-- Creating foreign key on [AnioId] in table 'CentroFormadors'
ALTER TABLE [dbo].[CentroFormadors]
ADD CONSTRAINT [FK_CentroFormadorAnio]
    FOREIGN KEY ([AnioId])
    REFERENCES [dbo].[Anios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CentroFormadorAnio'
CREATE INDEX [IX_FK_CentroFormadorAnio]
ON [dbo].[CentroFormadors]
    ([AnioId]);
GO

-- Creating foreign key on [AnioId] in table 'ContadorSituacions'
ALTER TABLE [dbo].[ContadorSituacions]
ADD CONSTRAINT [FK_ContadorSituacionAnio]
    FOREIGN KEY ([AnioId])
    REFERENCES [dbo].[Anios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContadorSituacionAnio'
CREATE INDEX [IX_FK_ContadorSituacionAnio]
ON [dbo].[ContadorSituacions]
    ([AnioId]);
GO

-- Creating foreign key on [NombreCampoClinicoId] in table 'CampoClinicoAlumnos'
ALTER TABLE [dbo].[CampoClinicoAlumnos]
ADD CONSTRAINT [FK_NombreCampoClinicoCampoClinicoAlumno]
    FOREIGN KEY ([NombreCampoClinicoId])
    REFERENCES [dbo].[NombreCampoClinicoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NombreCampoClinicoCampoClinicoAlumno'
CREATE INDEX [IX_FK_NombreCampoClinicoCampoClinicoAlumno]
ON [dbo].[CampoClinicoAlumnos]
    ([NombreCampoClinicoId]);
GO

-- Creating foreign key on [NombreCampoClinicoId] in table 'SolicitudDeCupos'
ALTER TABLE [dbo].[SolicitudDeCupos]
ADD CONSTRAINT [FK_NombreCampoClinicoSolicitudDeCupo]
    FOREIGN KEY ([NombreCampoClinicoId])
    REFERENCES [dbo].[NombreCampoClinicoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NombreCampoClinicoSolicitudDeCupo'
CREATE INDEX [IX_FK_NombreCampoClinicoSolicitudDeCupo]
ON [dbo].[SolicitudDeCupos]
    ([NombreCampoClinicoId]);
GO

-- Creating foreign key on [CentroFormadorId] in table 'Alumnos'
ALTER TABLE [dbo].[Alumnos]
ADD CONSTRAINT [FK_AlumnoCentroFormador]
    FOREIGN KEY ([CentroFormadorId])
    REFERENCES [dbo].[CentroFormadors]
        ([CentroFormadorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlumnoCentroFormador'
CREATE INDEX [IX_FK_AlumnoCentroFormador]
ON [dbo].[Alumnos]
    ([CentroFormadorId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------