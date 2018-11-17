namespace SAS.v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfesonalSupervisor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfesionalSupervisor",
                c => new
                    {
                        ProfesionalSupervisorId = c.Int(nullable: false),
                        PersonaId = c.Int(nullable: false),
                        ValorSupervisor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProfesionalSupervisorId, t.PersonaId })
                .ForeignKey("dbo.Persona", t => t.PersonaId)
                .Index(t => t.PersonaId);
            
            AddColumn("dbo.Alumno", "ProfesionalSupervisorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Alumno", new[] { "PersonaId", "ProfesionalSupervisorId" });
            AddForeignKey("dbo.Alumno", new[] { "PersonaId", "ProfesionalSupervisorId" }, "dbo.ProfesionalSupervisor", new[] { "ProfesionalSupervisorId", "PersonaId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfesionalSupervisor", "PersonaId", "dbo.Persona");
            DropForeignKey("dbo.Alumno", new[] { "PersonaId", "ProfesionalSupervisorId" }, "dbo.ProfesionalSupervisor");
            DropIndex("dbo.ProfesionalSupervisor", new[] { "PersonaId" });
            DropIndex("dbo.Alumno", new[] { "PersonaId", "ProfesionalSupervisorId" });
            DropColumn("dbo.Alumno", "ProfesionalSupervisorId");
            DropTable("dbo.ProfesionalSupervisor");
        }
    }
}
