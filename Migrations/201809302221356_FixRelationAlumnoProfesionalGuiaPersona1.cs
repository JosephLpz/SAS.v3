namespace SAS.v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRelationAlumnoProfesionalGuiaPersona1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jornada", new[] { "Alumno_AlumnoId", "Alumno_PersonaId" }, "dbo.Alumno");
            DropIndex("dbo.Jornada", new[] { "Alumno_AlumnoId", "Alumno_PersonaId" });
            DropColumn("dbo.Jornada", "Alumno_PersonaId");
            RenameColumn(table: "dbo.Jornada", name: "Alumno_AlumnoId", newName: "Alumno_PersonaId");
            DropPrimaryKey("dbo.Alumno");
            DropPrimaryKey("dbo.ProfesionalDocenteGuia");
            DropPrimaryKey("dbo.ProfesionalSupervisor");
            AddPrimaryKey("dbo.Alumno", "PersonaId");
            AddPrimaryKey("dbo.ProfesionalDocenteGuia", "PersonaId");
            AddPrimaryKey("dbo.ProfesionalSupervisor", "PersonaId");
            CreateIndex("dbo.Jornada", "Alumno_PersonaId");
            AddForeignKey("dbo.Jornada", "Alumno_PersonaId", "dbo.Alumno", "PersonaId");
            DropColumn("dbo.Alumno", "AlumnoId");
            DropColumn("dbo.ProfesionalDocenteGuia", "ProfesionalDocenteGuiaId");
            DropColumn("dbo.ProfesionalSupervisor", "ProfesionalSupervisorId");
            DropColumn("dbo.Jornada", "AlumnoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jornada", "AlumnoId", c => c.Int(nullable: false));
            AddColumn("dbo.ProfesionalSupervisor", "ProfesionalSupervisorId", c => c.Int(nullable: false));
            AddColumn("dbo.ProfesionalDocenteGuia", "ProfesionalDocenteGuiaId", c => c.Int(nullable: false));
            AddColumn("dbo.Alumno", "AlumnoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Jornada", "Alumno_PersonaId", "dbo.Alumno");
            DropIndex("dbo.Jornada", new[] { "Alumno_PersonaId" });
            DropPrimaryKey("dbo.ProfesionalSupervisor");
            DropPrimaryKey("dbo.ProfesionalDocenteGuia");
            DropPrimaryKey("dbo.Alumno");
            AddPrimaryKey("dbo.ProfesionalSupervisor", new[] { "ProfesionalSupervisorId", "PersonaId" });
            AddPrimaryKey("dbo.ProfesionalDocenteGuia", new[] { "ProfesionalDocenteGuiaId", "PersonaId" });
            AddPrimaryKey("dbo.Alumno", new[] { "AlumnoId", "PersonaId" });
            RenameColumn(table: "dbo.Jornada", name: "Alumno_PersonaId", newName: "Alumno_AlumnoId");
            AddColumn("dbo.Jornada", "Alumno_PersonaId", c => c.Int());
            CreateIndex("dbo.Jornada", new[] { "Alumno_AlumnoId", "Alumno_PersonaId" });
            AddForeignKey("dbo.Jornada", new[] { "Alumno_AlumnoId", "Alumno_PersonaId" }, "dbo.Alumno", new[] { "AlumnoId", "PersonaId" });
        }
    }
}
