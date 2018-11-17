
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/10/2018 17:13:58
-- Generated from EDMX file: D:\ProyectoAreaSalud.v4\SAS.v3\SAS.v3\Models\Modelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BD_SAS.v6];
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
IF OBJECT_ID(N'[dbo].[FK_UnidadDeServicioNombreUnidadDeServicio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UnidadDeServicios] DROP CONSTRAINT [FK_UnidadDeServicioNombreUnidadDeServicio];
GO
IF OBJECT_ID(N'[dbo].[FK_CampoClinicoNombreCampoClinico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampoClinicos] DROP CONSTRAINT [FK_CampoClinicoNombreCampoClinico];
GO
IF OBJECT_ID(N'[dbo].[FK_UnidadDeServicioCampoClinico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UnidadDeServicios] DROP CONSTRAINT [FK_UnidadDeServicioCampoClinico];
GO
IF OBJECT_ID(N'[dbo].[FK_InstitucionCampoClinico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampoClinicos] DROP CONSTRAINT [FK_InstitucionCampoClinico];
GO
IF OBJECT_ID(N'[dbo].[FK_AlumnoPersona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Alumnos] DROP CONSTRAINT [FK_AlumnoPersona];
GO
IF OBJECT_ID(N'[dbo].[FK_AlumnoInmunizacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Alumnos] DROP CONSTRAINT [FK_AlumnoInmunizacion];
GO
IF OBJECT_ID(N'[dbo].[FK_AlumnoCentroFormador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Alumnos] DROP CONSTRAINT [FK_AlumnoCentroFormador];
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
IF OBJECT_ID(N'[dbo].[FK_ProfesionalSupervidorPersona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfesionalSupervisorSet] DROP CONSTRAINT [FK_ProfesionalSupervidorPersona];
GO
IF OBJECT_ID(N'[dbo].[FK_CampoClinicoAlumnoAlumno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampoClinicoAlumnos] DROP CONSTRAINT [FK_CampoClinicoAlumnoAlumno];
GO
IF OBJECT_ID(N'[dbo].[FK_CampoClinicoAlumnoProfesionalDocenteGuia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampoClinicoAlumnos] DROP CONSTRAINT [FK_CampoClinicoAlumnoProfesionalDocenteGuia];
GO
IF OBJECT_ID(N'[dbo].[FK_CampoClinicoAlumnoProfesionalSupervidor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampoClinicoAlumnos] DROP CONSTRAINT [FK_CampoClinicoAlumnoProfesionalSupervidor];
GO
IF OBJECT_ID(N'[dbo].[FK_CampoClinicoAlumnoUnidadDeServicio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampoClinicoAlumnos] DROP CONSTRAINT [FK_CampoClinicoAlumnoUnidadDeServicio];
GO
IF OBJECT_ID(N'[dbo].[FK_CampoClinicoAlumnoPeriodo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampoClinicoAlumnos] DROP CONSTRAINT [FK_CampoClinicoAlumnoPeriodo];
GO
IF OBJECT_ID(N'[dbo].[FK_CampoClinicoAlumnoDiasCampoClinicoAlumno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampoClinicoAlumnoDiasSet] DROP CONSTRAINT [FK_CampoClinicoAlumnoDiasCampoClinicoAlumno];
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
IF OBJECT_ID(N'[dbo].[UnidadDeServicios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UnidadDeServicios];
GO
IF OBJECT_ID(N'[dbo].[CampoClinicoAlumnoDiasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CampoClinicoAlumnoDiasSet];
GO
IF OBJECT_ID(N'[dbo].[NombreUnidadDeServicios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NombreUnidadDeServicios];
GO
IF OBJECT_ID(N'[dbo].[NombreCampoClinicoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NombreCampoClinicoSet];
GO
IF OBJECT_ID(N'[dbo].[CampoClinicos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CampoClinicos];
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
IF OBJECT_ID(N'[dbo].[ProfesionalDocenteGuias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfesionalDocenteGuias];
GO
IF OBJECT_ID(N'[dbo].[ProfesionalSupervisorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfesionalSupervisorSet];
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
    [ApMaterno] nvarchar(max)  NOT NULL
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
    [NombreCentroFormadorNombreCentroFormadorId] int  NOT NULL
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

-- Creating table 'UnidadDeServicios'
CREATE TABLE [dbo].[UnidadDeServicios] (
    [UnidadDeServicioId] int IDENTITY(1,1) NOT NULL,
    [NombreUnidadDeServicioId] int  NOT NULL,
    [CampoClinicoId] int  NOT NULL
);
GO

-- Creating table 'CampoClinicoAlumnoDiasSet'
CREATE TABLE [dbo].[CampoClinicoAlumnoDiasSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DiasDiasId] int  NOT NULL,
    [CampoClinicoAlumnoId] int  NOT NULL
);
GO

-- Creating table 'NombreUnidadDeServicios'
CREATE TABLE [dbo].[NombreUnidadDeServicios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreUnidadDeServicio1] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NombreCampoClinicoSet'
CREATE TABLE [dbo].[NombreCampoClinicoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreCampo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CampoClinicos'
CREATE TABLE [dbo].[CampoClinicos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreCampoClinicoId] int  NOT NULL,
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
    [ProfesionalDocenteGuiaProfesionalDocenteGuiaId] int  NOT NULL,
    [ProfesionalSupervidorProfesionalSupervisorId] int  NOT NULL,
    [UnidadDeServicioUnidadDeServicioId] int  NOT NULL,
    [PeriodoPeriodoId] int  NOT NULL
);
GO

-- Creating table 'Alumnos'
CREATE TABLE [dbo].[Alumnos] (
    [AlumnoId] int IDENTITY(1,1) NOT NULL,
    [CursoNivel] nvarchar(max)  NOT NULL,
    [Observaciones] nvarchar(max)  NOT NULL,
    [PersonaPersonaId] int  NOT NULL,
    [InmunizacionInmunizacionId] int  NOT NULL,
    [CentroFormadorCentroFormadorId] int  NOT NULL
);
GO

-- Creating table 'ProfesionalDocenteGuias'
CREATE TABLE [dbo].[ProfesionalDocenteGuias] (
    [ProfesionalDocenteGuiaId] int IDENTITY(1,1) NOT NULL,
    [Profesion] nvarchar(max)  NOT NULL,
    [NumeroSuperintendencia] int  NOT NULL,
    [Telefono] bigint  NOT NULL,
    [Correo] nvarchar(max)  NOT NULL,
    [ValorDocente] int  NOT NULL,
    [PersonaPersonaId] int  NOT NULL,
    [DocenciaHospitalariaDocenciaHospitalariaId] int  NOT NULL,
    [InmunizacionInmunizacionId] int  NOT NULL
);
GO

-- Creating table 'ProfesionalSupervisorSet'
CREATE TABLE [dbo].[ProfesionalSupervisorSet] (
    [ProfesionalSupervisorId] int IDENTITY(1,1) NOT NULL,
    [ValorSupervisor] int  NOT NULL,
    [Observaciones] nvarchar(max)  NOT NULL,
    [PersonaPersonaId] int  NOT NULL
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

-- Creating primary key on [UnidadDeServicioId] in table 'UnidadDeServicios'
ALTER TABLE [dbo].[UnidadDeServicios]
ADD CONSTRAINT [PK_UnidadDeServicios]
    PRIMARY KEY CLUSTERED ([UnidadDeServicioId] ASC);
GO

-- Creating primary key on [Id] in table 'CampoClinicoAlumnoDiasSet'
ALTER TABLE [dbo].[CampoClinicoAlumnoDiasSet]
ADD CONSTRAINT [PK_CampoClinicoAlumnoDiasSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NombreUnidadDeServicios'
ALTER TABLE [dbo].[NombreUnidadDeServicios]
ADD CONSTRAINT [PK_NombreUnidadDeServicios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NombreCampoClinicoSet'
ALTER TABLE [dbo].[NombreCampoClinicoSet]
ADD CONSTRAINT [PK_NombreCampoClinicoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CampoClinicos'
ALTER TABLE [dbo].[CampoClinicos]
ADD CONSTRAINT [PK_CampoClinicos]
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

-- Creating primary key on [ProfesionalDocenteGuiaId] in table 'ProfesionalDocenteGuias'
ALTER TABLE [dbo].[ProfesionalDocenteGuias]
ADD CONSTRAINT [PK_ProfesionalDocenteGuias]
    PRIMARY KEY CLUSTERED ([ProfesionalDocenteGuiaId] ASC);
GO

-- Creating primary key on [ProfesionalSupervisorId] in table 'ProfesionalSupervisorSet'
ALTER TABLE [dbo].[ProfesionalSupervisorSet]
ADD CONSTRAINT [PK_ProfesionalSupervisorSet]
    PRIMARY KEY CLUSTERED ([ProfesionalSupervisorId] ASC);
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

-- Creating foreign key on [NombreUnidadDeServicioId] in table 'UnidadDeServicios'
ALTER TABLE [dbo].[UnidadDeServicios]
ADD CONSTRAINT [FK_UnidadDeServicioNombreUnidadDeServicio]
    FOREIGN KEY ([NombreUnidadDeServicioId])
    REFERENCES [dbo].[NombreUnidadDeServicios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UnidadDeServicioNombreUnidadDeServicio'
CREATE INDEX [IX_FK_UnidadDeServicioNombreUnidadDeServicio]
ON [dbo].[UnidadDeServicios]
    ([NombreUnidadDeServicioId]);
GO

-- Creating foreign key on [NombreCampoClinicoId] in table 'CampoClinicos'
ALTER TABLE [dbo].[CampoClinicos]
ADD CONSTRAINT [FK_CampoClinicoNombreCampoClinico]
    FOREIGN KEY ([NombreCampoClinicoId])
    REFERENCES [dbo].[NombreCampoClinicoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CampoClinicoNombreCampoClinico'
CREATE INDEX [IX_FK_CampoClinicoNombreCampoClinico]
ON [dbo].[CampoClinicos]
    ([NombreCampoClinicoId]);
GO

-- Creating foreign key on [CampoClinicoId] in table 'UnidadDeServicios'
ALTER TABLE [dbo].[UnidadDeServicios]
ADD CONSTRAINT [FK_UnidadDeServicioCampoClinico]
    FOREIGN KEY ([CampoClinicoId])
    REFERENCES [dbo].[CampoClinicos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UnidadDeServicioCampoClinico'
CREATE INDEX [IX_FK_UnidadDeServicioCampoClinico]
ON [dbo].[UnidadDeServicios]
    ([CampoClinicoId]);
GO

-- Creating foreign key on [InstitucionId] in table 'CampoClinicos'
ALTER TABLE [dbo].[CampoClinicos]
ADD CONSTRAINT [FK_InstitucionCampoClinico]
    FOREIGN KEY ([InstitucionId])
    REFERENCES [dbo].[Institucions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InstitucionCampoClinico'
CREATE INDEX [IX_FK_InstitucionCampoClinico]
ON [dbo].[CampoClinicos]
    ([InstitucionId]);
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

-- Creating foreign key on [InmunizacionInmunizacionId] in table 'Alumnos'
ALTER TABLE [dbo].[Alumnos]
ADD CONSTRAINT [FK_AlumnoInmunizacion]
    FOREIGN KEY ([InmunizacionInmunizacionId])
    REFERENCES [dbo].[Inmunizacions]
        ([InmunizacionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlumnoInmunizacion'
CREATE INDEX [IX_FK_AlumnoInmunizacion]
ON [dbo].[Alumnos]
    ([InmunizacionInmunizacionId]);
GO

-- Creating foreign key on [CentroFormadorCentroFormadorId] in table 'Alumnos'
ALTER TABLE [dbo].[Alumnos]
ADD CONSTRAINT [FK_AlumnoCentroFormador]
    FOREIGN KEY ([CentroFormadorCentroFormadorId])
    REFERENCES [dbo].[CentroFormadors]
        ([CentroFormadorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlumnoCentroFormador'
CREATE INDEX [IX_FK_AlumnoCentroFormador]
ON [dbo].[Alumnos]
    ([CentroFormadorCentroFormadorId]);
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

-- Creating foreign key on [PersonaPersonaId] in table 'ProfesionalSupervisorSet'
ALTER TABLE [dbo].[ProfesionalSupervisorSet]
ADD CONSTRAINT [FK_ProfesionalSupervidorPersona]
    FOREIGN KEY ([PersonaPersonaId])
    REFERENCES [dbo].[Personas]
        ([PersonaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfesionalSupervidorPersona'
CREATE INDEX [IX_FK_ProfesionalSupervidorPersona]
ON [dbo].[ProfesionalSupervisorSet]
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

-- Creating foreign key on [ProfesionalDocenteGuiaProfesionalDocenteGuiaId] in table 'CampoClinicoAlumnos'
ALTER TABLE [dbo].[CampoClinicoAlumnos]
ADD CONSTRAINT [FK_CampoClinicoAlumnoProfesionalDocenteGuia]
    FOREIGN KEY ([ProfesionalDocenteGuiaProfesionalDocenteGuiaId])
    REFERENCES [dbo].[ProfesionalDocenteGuias]
        ([ProfesionalDocenteGuiaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CampoClinicoAlumnoProfesionalDocenteGuia'
CREATE INDEX [IX_FK_CampoClinicoAlumnoProfesionalDocenteGuia]
ON [dbo].[CampoClinicoAlumnos]
    ([ProfesionalDocenteGuiaProfesionalDocenteGuiaId]);
GO

-- Creating foreign key on [ProfesionalSupervidorProfesionalSupervisorId] in table 'CampoClinicoAlumnos'
ALTER TABLE [dbo].[CampoClinicoAlumnos]
ADD CONSTRAINT [FK_CampoClinicoAlumnoProfesionalSupervidor]
    FOREIGN KEY ([ProfesionalSupervidorProfesionalSupervisorId])
    REFERENCES [dbo].[ProfesionalSupervisorSet]
        ([ProfesionalSupervisorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CampoClinicoAlumnoProfesionalSupervidor'
CREATE INDEX [IX_FK_CampoClinicoAlumnoProfesionalSupervidor]
ON [dbo].[CampoClinicoAlumnos]
    ([ProfesionalSupervidorProfesionalSupervisorId]);
GO

-- Creating foreign key on [UnidadDeServicioUnidadDeServicioId] in table 'CampoClinicoAlumnos'
ALTER TABLE [dbo].[CampoClinicoAlumnos]
ADD CONSTRAINT [FK_CampoClinicoAlumnoUnidadDeServicio]
    FOREIGN KEY ([UnidadDeServicioUnidadDeServicioId])
    REFERENCES [dbo].[UnidadDeServicios]
        ([UnidadDeServicioId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CampoClinicoAlumnoUnidadDeServicio'
CREATE INDEX [IX_FK_CampoClinicoAlumnoUnidadDeServicio]
ON [dbo].[CampoClinicoAlumnos]
    ([UnidadDeServicioUnidadDeServicioId]);
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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------