namespace SAS.v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCentroFormador : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CentroFormador",
                c => new
                    {
                        CentroFormadorId = c.Int(nullable: false, identity: true),
                        NombreCentroFormadorId = c.Int(nullable: false),
                        CarrerId = c.Int(nullable: false),
                        Carrera_CarreraId = c.Int(),
                    })
                .PrimaryKey(t => t.CentroFormadorId)
                .ForeignKey("dbo.Carrera", t => t.Carrera_CarreraId)
                .ForeignKey("dbo.NombreCentroFormador", t => t.NombreCentroFormadorId, cascadeDelete: true)
                .Index(t => t.NombreCentroFormadorId)
                .Index(t => t.Carrera_CarreraId);
            
            CreateTable(
                "dbo.Carrera",
                c => new
                    {
                        CarreraId = c.Int(nullable: false, identity: true),
                        NombreCarrera = c.String(),
                    })
                .PrimaryKey(t => t.CarreraId);
            
            CreateTable(
                "dbo.NombreCentroFormador",
                c => new
                    {
                        NombreCentroFormadorId = c.Int(nullable: false, identity: true),
                        NombreCentro = c.String(),
                    })
                .PrimaryKey(t => t.NombreCentroFormadorId);
            
            CreateIndex("dbo.Alumno", "CentroFormadorId");
            AddForeignKey("dbo.Alumno", "CentroFormadorId", "dbo.CentroFormador", "CentroFormadorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CentroFormador", "NombreCentroFormadorId", "dbo.NombreCentroFormador");
            DropForeignKey("dbo.CentroFormador", "Carrera_CarreraId", "dbo.Carrera");
            DropForeignKey("dbo.Alumno", "CentroFormadorId", "dbo.CentroFormador");
            DropIndex("dbo.CentroFormador", new[] { "Carrera_CarreraId" });
            DropIndex("dbo.CentroFormador", new[] { "NombreCentroFormadorId" });
            DropIndex("dbo.Alumno", new[] { "CentroFormadorId" });
            DropTable("dbo.NombreCentroFormador");
            DropTable("dbo.Carrera");
            DropTable("dbo.CentroFormador");
        }
    }
}
