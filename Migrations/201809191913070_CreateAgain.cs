namespace SAS.v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        PersonaId = c.Int(nullable: false, identity: true),
                        Rut = c.String(nullable: false),
                        dv = c.String(nullable: false, maxLength: 1),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        ApPaterno = c.String(nullable: false, maxLength: 50),
                        ApMaterno = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PersonaId);
            
            CreateTable(
                "dbo.Alumno",
                c => new
                    {
                        AlumnoId = c.Int(nullable: false),
                        PersonaId = c.Int(nullable: false),
                        InmunizaciónId = c.Int(nullable: false),
                        CursoNivel = c.String(),
                        Observaciones = c.String(),
                        CampoClinicoId = c.Int(nullable: false),
                        CentroFormadorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AlumnoId, t.PersonaId })
                .ForeignKey("dbo.CampoClinico", t => t.CampoClinicoId, cascadeDelete: true)
                .ForeignKey("dbo.Persona", t => t.PersonaId, cascadeDelete: true)
                .Index(t => t.PersonaId)
                .Index(t => t.CampoClinicoId);
            
            CreateTable(
                "dbo.CampoClinico",
                c => new
                    {
                        CampoClinicoId = c.Int(nullable: false, identity: true),
                        InstitucionId = c.Int(nullable: false),
                        UnidadDeServicioId = c.Int(nullable: false),
                        NombreCampoClinicoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CampoClinicoId)
                .ForeignKey("dbo.Institucion", t => t.InstitucionId, cascadeDelete: true)
                .ForeignKey("dbo.NombreCampoClinico", t => t.NombreCampoClinicoId, cascadeDelete: true)
                .ForeignKey("dbo.UnidadDeServicio", t => t.UnidadDeServicioId, cascadeDelete: true)
                .Index(t => t.InstitucionId)
                .Index(t => t.UnidadDeServicioId)
                .Index(t => t.NombreCampoClinicoId);
            
            CreateTable(
                "dbo.Institucion",
                c => new
                    {
                        InstitucionId = c.Int(nullable: false, identity: true),
                        NombreInstitucion = c.String(),
                    })
                .PrimaryKey(t => t.InstitucionId);
            
            CreateTable(
                "dbo.NombreCampoClinico",
                c => new
                    {
                        NombreCampoClinicoId = c.Int(nullable: false, identity: true),
                        NombreCampo = c.String(),
                    })
                .PrimaryKey(t => t.NombreCampoClinicoId);
            
            CreateTable(
                "dbo.UnidadDeServicio",
                c => new
                    {
                        UnidadDeServicioId = c.Int(nullable: false, identity: true),
                        NombreUnidadDeServicio = c.String(),
                    })
                .PrimaryKey(t => t.UnidadDeServicioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alumno", "PersonaId", "dbo.Persona");
            DropForeignKey("dbo.CampoClinico", "UnidadDeServicioId", "dbo.UnidadDeServicio");
            DropForeignKey("dbo.CampoClinico", "NombreCampoClinicoId", "dbo.NombreCampoClinico");
            DropForeignKey("dbo.CampoClinico", "InstitucionId", "dbo.Institucion");
            DropForeignKey("dbo.Alumno", "CampoClinicoId", "dbo.CampoClinico");
            DropIndex("dbo.CampoClinico", new[] { "NombreCampoClinicoId" });
            DropIndex("dbo.CampoClinico", new[] { "UnidadDeServicioId" });
            DropIndex("dbo.CampoClinico", new[] { "InstitucionId" });
            DropIndex("dbo.Alumno", new[] { "CampoClinicoId" });
            DropIndex("dbo.Alumno", new[] { "PersonaId" });
            DropTable("dbo.UnidadDeServicio");
            DropTable("dbo.NombreCampoClinico");
            DropTable("dbo.Institucion");
            DropTable("dbo.CampoClinico");
            DropTable("dbo.Alumno");
            DropTable("dbo.Persona");
        }
    }
}
