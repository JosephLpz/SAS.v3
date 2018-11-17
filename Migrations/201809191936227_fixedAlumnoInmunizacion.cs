namespace SAS.v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedAlumnoInmunizacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inmunizacion",
                c => new
                    {
                        inmunizacionId = c.Int(nullable: false, identity: true),
                        inmunizacion = c.String(),
                    })
                .PrimaryKey(t => t.inmunizacionId);
            
            AddColumn("dbo.Alumno", "InmunizacionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Alumno", "InmunizacionId");
            AddForeignKey("dbo.Alumno", "InmunizacionId", "dbo.Inmunizacion", "inmunizacionId", cascadeDelete: true);
            DropColumn("dbo.Alumno", "InmunizaciónId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Alumno", "InmunizaciónId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Alumno", "InmunizacionId", "dbo.Inmunizacion");
            DropIndex("dbo.Alumno", new[] { "InmunizacionId" });
            DropColumn("dbo.Alumno", "InmunizacionId");
            DropTable("dbo.Inmunizacion");
        }
    }
}
