namespace SAS.v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJornadas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jornada",
                c => new
                    {
                        JornadaId = c.Int(nullable: false, identity: true),
                        AlumnoId = c.Int(nullable: false),
                        NombreJornadaId = c.Int(nullable: false),
                        Alumno_PersonaId = c.Int(),
                        Alumno_AlumnoId = c.Int(),
                    })
                .PrimaryKey(t => t.JornadaId)
                .ForeignKey("dbo.Alumno", t => new { t.Alumno_PersonaId, t.Alumno_AlumnoId })
                .ForeignKey("dbo.NombreJornada", t => t.NombreJornadaId)
                .Index(t => t.NombreJornadaId)
                .Index(t => new { t.Alumno_PersonaId, t.Alumno_AlumnoId });
            
            CreateTable(
                "dbo.JornadaDias",
                c => new
                    {
                        JornadaDiasId = c.Int(nullable: false, identity: true),
                        JornadaId = c.Int(nullable: false),
                        DiasId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JornadaDiasId)
                .ForeignKey("dbo.Dias", t => t.DiasId)
                .ForeignKey("dbo.Jornada", t => t.JornadaId)
                .Index(t => t.JornadaId)
                .Index(t => t.DiasId);
            
            CreateTable(
                "dbo.Dias",
                c => new
                    {
                        DiasId = c.Int(nullable: false, identity: true),
                        Dia = c.String(),
                    })
                .PrimaryKey(t => t.DiasId);
            
            CreateTable(
                "dbo.NombreJornada",
                c => new
                    {
                        NombreJornadaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.NombreJornadaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jornada", "NombreJornadaId", "dbo.NombreJornada");
            DropForeignKey("dbo.JornadaDias", "JornadaId", "dbo.Jornada");
            DropForeignKey("dbo.JornadaDias", "DiasId", "dbo.Dias");
            DropForeignKey("dbo.Jornada", new[] { "Alumno_PersonaId", "Alumno_AlumnoId" }, "dbo.Alumno");
            DropIndex("dbo.JornadaDias", new[] { "DiasId" });
            DropIndex("dbo.JornadaDias", new[] { "JornadaId" });
            DropIndex("dbo.Jornada", new[] { "Alumno_PersonaId", "Alumno_AlumnoId" });
            DropIndex("dbo.Jornada", new[] { "NombreJornadaId" });
            DropTable("dbo.NombreJornada");
            DropTable("dbo.Dias");
            DropTable("dbo.JornadaDias");
            DropTable("dbo.Jornada");
        }
    }
}
