namespace SAS.v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRelationAlumnoProfesionalGuiaPersona : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Alumno", new[] { "PersonaId", "ProfesionalSupervisorId" }, "dbo.ProfesionalSupervisor");
            DropForeignKey("dbo.ProfesionalDocenteGuia", new[] { "Alumno_PersonaId", "Alumno_AlumnoId" }, "dbo.Alumno");
            DropIndex("dbo.Alumno", new[] { "PersonaId", "ProfesionalSupervisorId" });
            DropIndex("dbo.ProfesionalDocenteGuia", new[] { "Alumno_PersonaId", "Alumno_AlumnoId" });
            RenameColumn(table: "dbo.Jornada", name: "Alumno_PersonaId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Jornada", name: "Alumno_AlumnoId", newName: "Alumno_PersonaId");
            RenameColumn(table: "dbo.Jornada", name: "__mig_tmp__0", newName: "Alumno_AlumnoId");
            RenameIndex(table: "dbo.Jornada", name: "IX_Alumno_PersonaId_Alumno_AlumnoId", newName: "IX_Alumno_AlumnoId_Alumno_PersonaId");
            DropColumn("dbo.Alumno", "ProfesionalSupervisorId");
            DropColumn("dbo.ProfesionalDocenteGuia", "Alumno_PersonaId");
            DropColumn("dbo.ProfesionalDocenteGuia", "Alumno_AlumnoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProfesionalDocenteGuia", "Alumno_AlumnoId", c => c.Int());
            AddColumn("dbo.ProfesionalDocenteGuia", "Alumno_PersonaId", c => c.Int());
            AddColumn("dbo.Alumno", "ProfesionalSupervisorId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Jornada", name: "IX_Alumno_AlumnoId_Alumno_PersonaId", newName: "IX_Alumno_PersonaId_Alumno_AlumnoId");
            RenameColumn(table: "dbo.Jornada", name: "Alumno_AlumnoId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Jornada", name: "Alumno_PersonaId", newName: "Alumno_AlumnoId");
            RenameColumn(table: "dbo.Jornada", name: "__mig_tmp__0", newName: "Alumno_PersonaId");
            CreateIndex("dbo.ProfesionalDocenteGuia", new[] { "Alumno_PersonaId", "Alumno_AlumnoId" });
            CreateIndex("dbo.Alumno", new[] { "PersonaId", "ProfesionalSupervisorId" });
            AddForeignKey("dbo.ProfesionalDocenteGuia", new[] { "Alumno_PersonaId", "Alumno_AlumnoId" }, "dbo.Alumno", new[] { "AlumnoId", "PersonaId" });
            AddForeignKey("dbo.Alumno", new[] { "PersonaId", "ProfesionalSupervisorId" }, "dbo.ProfesionalSupervisor", new[] { "ProfesionalSupervisorId", "PersonaId" });
        }
    }
}
