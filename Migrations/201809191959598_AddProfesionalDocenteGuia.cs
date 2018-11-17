namespace SAS.v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfesionalDocenteGuia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfesionalDocenteGuia",
                c => new
                    {
                        ProfesionalDocenteGuiaId = c.Int(nullable: false),
                        PersonaId = c.Int(nullable: false),
                        Profesion = c.String(),
                        NumeroSuperintendencia = c.Int(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Correo = c.String(),
                        CumplimientoRequisitos = c.Boolean(nullable: false),
                        InmunizacionId = c.Int(nullable: false),
                        DocenciaHospitalariaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProfesionalDocenteGuiaId, t.PersonaId })
                .ForeignKey("dbo.DocenciaHospitalaria", t => t.DocenciaHospitalariaId, cascadeDelete: true)
                .ForeignKey("dbo.Inmunizacion", t => t.InmunizacionId, cascadeDelete: true)
                .ForeignKey("dbo.Persona", t => t.PersonaId, cascadeDelete: true)
                .Index(t => t.PersonaId)
                .Index(t => t.InmunizacionId)
                .Index(t => t.DocenciaHospitalariaId);
            
            CreateTable(
                "dbo.DocenciaHospitalaria",
                c => new
                    {
                        DocenciaHospitalariaId = c.Int(nullable: false, identity: true),
                        NombreDocenciaHospitalaria = c.String(),
                    })
                .PrimaryKey(t => t.DocenciaHospitalariaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfesionalDocenteGuia", "PersonaId", "dbo.Persona");
            DropForeignKey("dbo.ProfesionalDocenteGuia", "InmunizacionId", "dbo.Inmunizacion");
            DropForeignKey("dbo.ProfesionalDocenteGuia", "DocenciaHospitalariaId", "dbo.DocenciaHospitalaria");
            DropIndex("dbo.ProfesionalDocenteGuia", new[] { "DocenciaHospitalariaId" });
            DropIndex("dbo.ProfesionalDocenteGuia", new[] { "InmunizacionId" });
            DropIndex("dbo.ProfesionalDocenteGuia", new[] { "PersonaId" });
            DropTable("dbo.DocenciaHospitalaria");
            DropTable("dbo.ProfesionalDocenteGuia");
        }
    }
}
