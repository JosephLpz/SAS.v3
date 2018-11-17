namespace SAS.v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteDocenteAlumnoTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DocenteAlumno", new[] { "Alumno_PersonaId", "Alumno_AlumnoId" }, "dbo.Alumno");
            DropForeignKey("dbo.DocenteAlumno", new[] { "ProfesionalDocenteGuia_ProfesionalDocenteGuiaId", "ProfesionalDocenteGuia_PersonaId" }, "dbo.ProfesionalDocenteGuia");
            DropIndex("dbo.DocenteAlumno", new[] { "Alumno_PersonaId", "Alumno_AlumnoId" });
            DropIndex("dbo.DocenteAlumno", new[] { "ProfesionalDocenteGuia_ProfesionalDocenteGuiaId", "ProfesionalDocenteGuia_PersonaId" });
            DropTable("dbo.DocenteAlumno");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DocenteAlumno",
                c => new
                    {
                        DocenteAlumnoId = c.Int(nullable: false, identity: true),
                        AlumnoId = c.Int(nullable: false),
                        ProfesionalDocenteGuiaId = c.Int(nullable: false),
                        Alumno_PersonaId = c.Int(),
                        Alumno_AlumnoId = c.Int(),
                        ProfesionalDocenteGuia_ProfesionalDocenteGuiaId = c.Int(),
                        ProfesionalDocenteGuia_PersonaId = c.Int(),
                    })
                .PrimaryKey(t => t.DocenteAlumnoId);
            
            CreateIndex("dbo.DocenteAlumno", new[] { "ProfesionalDocenteGuia_ProfesionalDocenteGuiaId", "ProfesionalDocenteGuia_PersonaId" });
            CreateIndex("dbo.DocenteAlumno", new[] { "Alumno_PersonaId", "Alumno_AlumnoId" });
            AddForeignKey("dbo.DocenteAlumno", new[] { "ProfesionalDocenteGuia_ProfesionalDocenteGuiaId", "ProfesionalDocenteGuia_PersonaId" }, "dbo.ProfesionalDocenteGuia", new[] { "ProfesionalDocenteGuiaId", "PersonaId" });
            AddForeignKey("dbo.DocenteAlumno", new[] { "Alumno_PersonaId", "Alumno_AlumnoId" }, "dbo.Alumno", new[] { "AlumnoId", "PersonaId" });
        }
    }
}
