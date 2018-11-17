namespace SAS.v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDocenteAlumno : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Alumno", "PersonaId", "dbo.Persona");
            DropForeignKey("dbo.ProfesionalDocenteGuia", "PersonaId", "dbo.Persona");
            DropForeignKey("dbo.Alumno", "CampoClinicoId", "dbo.CampoClinico");
            DropForeignKey("dbo.Alumno", "CentroFormadorId", "dbo.CentroFormador");
            DropForeignKey("dbo.Alumno", "InmunizacionId", "dbo.Inmunizacion");
            DropForeignKey("dbo.CampoClinico", "InstitucionId", "dbo.Institucion");
            DropForeignKey("dbo.CampoClinico", "NombreCampoClinicoId", "dbo.NombreCampoClinico");
            DropForeignKey("dbo.CampoClinico", "UnidadDeServicioId", "dbo.UnidadDeServicio");
            DropForeignKey("dbo.CentroFormador", "NombreCentroFormadorId", "dbo.NombreCentroFormador");
            DropForeignKey("dbo.ProfesionalDocenteGuia", "InmunizacionId", "dbo.Inmunizacion");
            DropForeignKey("dbo.ProfesionalDocenteGuia", "DocenciaHospitalariaId", "dbo.DocenciaHospitalaria");
            CreateTable(
                "dbo.DocenteAlumno",
                c => new
                    {
                        DocenteAlumnoID = c.Int(nullable: false, identity: true),
                        AlumnoId = c.Int(nullable: false),
                        ProfesionalDocenteGuiaId = c.Int(nullable: false),
                        Alumno_PersonaId = c.Int(),
                        Alumno_AlumnoId = c.Int(),
                        ProfesionalDocenteGuia_ProfesionalDocenteGuiaId = c.Int(),
                        ProfesionalDocenteGuia_PersonaId = c.Int(),
                    })
                .PrimaryKey(t => t.DocenteAlumnoID)
                .ForeignKey("dbo.Alumno", t => new { t.Alumno_PersonaId, t.Alumno_AlumnoId })
                .ForeignKey("dbo.ProfesionalDocenteGuia", t => new { t.ProfesionalDocenteGuia_ProfesionalDocenteGuiaId, t.ProfesionalDocenteGuia_PersonaId })
                .Index(t => new { t.Alumno_PersonaId, t.Alumno_AlumnoId })
                .Index(t => new { t.ProfesionalDocenteGuia_ProfesionalDocenteGuiaId, t.ProfesionalDocenteGuia_PersonaId });
            
            AddColumn("dbo.ProfesionalDocenteGuia", "Alumno_PersonaId", c => c.Int());
            AddColumn("dbo.ProfesionalDocenteGuia", "Alumno_AlumnoId", c => c.Int());
            CreateIndex("dbo.ProfesionalDocenteGuia", new[] { "Alumno_PersonaId", "Alumno_AlumnoId" });
            AddForeignKey("dbo.ProfesionalDocenteGuia", new[] { "Alumno_PersonaId", "Alumno_AlumnoId" }, "dbo.Alumno", new[] { "AlumnoId", "PersonaId" });
            AddForeignKey("dbo.Alumno", "PersonaId", "dbo.Persona", "PersonaId");
            AddForeignKey("dbo.ProfesionalDocenteGuia", "PersonaId", "dbo.Persona", "PersonaId");
            AddForeignKey("dbo.Alumno", "CampoClinicoId", "dbo.CampoClinico", "CampoClinicoId");
            AddForeignKey("dbo.Alumno", "CentroFormadorId", "dbo.CentroFormador", "CentroFormadorId");
            AddForeignKey("dbo.Alumno", "InmunizacionId", "dbo.Inmunizacion", "InmunizacionId");
            AddForeignKey("dbo.CampoClinico", "InstitucionId", "dbo.Institucion", "InstitucionId");
            AddForeignKey("dbo.CampoClinico", "NombreCampoClinicoId", "dbo.NombreCampoClinico", "NombreCampoClinicoId");
            AddForeignKey("dbo.CampoClinico", "UnidadDeServicioId", "dbo.UnidadDeServicio", "UnidadDeServicioId");
            AddForeignKey("dbo.CentroFormador", "NombreCentroFormadorId", "dbo.NombreCentroFormador", "NombreCentroFormadorId");
            AddForeignKey("dbo.ProfesionalDocenteGuia", "InmunizacionId", "dbo.Inmunizacion", "InmunizacionId");
            AddForeignKey("dbo.ProfesionalDocenteGuia", "DocenciaHospitalariaId", "dbo.DocenciaHospitalaria", "DocenciaHospitalariaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfesionalDocenteGuia", "DocenciaHospitalariaId", "dbo.DocenciaHospitalaria");
            DropForeignKey("dbo.ProfesionalDocenteGuia", "InmunizacionId", "dbo.Inmunizacion");
            DropForeignKey("dbo.CentroFormador", "NombreCentroFormadorId", "dbo.NombreCentroFormador");
            DropForeignKey("dbo.CampoClinico", "UnidadDeServicioId", "dbo.UnidadDeServicio");
            DropForeignKey("dbo.CampoClinico", "NombreCampoClinicoId", "dbo.NombreCampoClinico");
            DropForeignKey("dbo.CampoClinico", "InstitucionId", "dbo.Institucion");
            DropForeignKey("dbo.Alumno", "InmunizacionId", "dbo.Inmunizacion");
            DropForeignKey("dbo.Alumno", "CentroFormadorId", "dbo.CentroFormador");
            DropForeignKey("dbo.Alumno", "CampoClinicoId", "dbo.CampoClinico");
            DropForeignKey("dbo.ProfesionalDocenteGuia", "PersonaId", "dbo.Persona");
            DropForeignKey("dbo.Alumno", "PersonaId", "dbo.Persona");
            DropForeignKey("dbo.ProfesionalDocenteGuia", new[] { "Alumno_PersonaId", "Alumno_AlumnoId" }, "dbo.Alumno");
            DropForeignKey("dbo.DocenteAlumno", new[] { "ProfesionalDocenteGuia_ProfesionalDocenteGuiaId", "ProfesionalDocenteGuia_PersonaId" }, "dbo.ProfesionalDocenteGuia");
            DropForeignKey("dbo.DocenteAlumno", new[] { "Alumno_PersonaId", "Alumno_AlumnoId" }, "dbo.Alumno");
            DropIndex("dbo.ProfesionalDocenteGuia", new[] { "Alumno_PersonaId", "Alumno_AlumnoId" });
            DropIndex("dbo.DocenteAlumno", new[] { "ProfesionalDocenteGuia_ProfesionalDocenteGuiaId", "ProfesionalDocenteGuia_PersonaId" });
            DropIndex("dbo.DocenteAlumno", new[] { "Alumno_PersonaId", "Alumno_AlumnoId" });
            DropColumn("dbo.ProfesionalDocenteGuia", "Alumno_AlumnoId");
            DropColumn("dbo.ProfesionalDocenteGuia", "Alumno_PersonaId");
            DropTable("dbo.DocenteAlumno");
            AddForeignKey("dbo.ProfesionalDocenteGuia", "DocenciaHospitalariaId", "dbo.DocenciaHospitalaria", "DocenciaHospitalariaId", cascadeDelete: true);
            AddForeignKey("dbo.ProfesionalDocenteGuia", "InmunizacionId", "dbo.Inmunizacion", "InmunizacionId", cascadeDelete: true);
            AddForeignKey("dbo.CentroFormador", "NombreCentroFormadorId", "dbo.NombreCentroFormador", "NombreCentroFormadorId", cascadeDelete: true);
            AddForeignKey("dbo.CampoClinico", "UnidadDeServicioId", "dbo.UnidadDeServicio", "UnidadDeServicioId", cascadeDelete: true);
            AddForeignKey("dbo.CampoClinico", "NombreCampoClinicoId", "dbo.NombreCampoClinico", "NombreCampoClinicoId", cascadeDelete: true);
            AddForeignKey("dbo.CampoClinico", "InstitucionId", "dbo.Institucion", "InstitucionId", cascadeDelete: true);
            AddForeignKey("dbo.Alumno", "InmunizacionId", "dbo.Inmunizacion", "InmunizacionId", cascadeDelete: true);
            AddForeignKey("dbo.Alumno", "CentroFormadorId", "dbo.CentroFormador", "CentroFormadorId", cascadeDelete: true);
            AddForeignKey("dbo.Alumno", "CampoClinicoId", "dbo.CampoClinico", "CampoClinicoId", cascadeDelete: true);
            AddForeignKey("dbo.ProfesionalDocenteGuia", "PersonaId", "dbo.Persona", "PersonaId", cascadeDelete: true);
            AddForeignKey("dbo.Alumno", "PersonaId", "dbo.Persona", "PersonaId", cascadeDelete: true);
        }
    }
}
