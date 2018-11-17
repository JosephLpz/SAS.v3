namespace SAS.v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPeriodos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Periodos",
                c => new
                    {
                        PeriodosId = c.Int(nullable: false, identity: true),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaTermino = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PeriodosId);
            
            AddColumn("dbo.Alumno", "PeriodosId", c => c.Int(nullable: false));
            CreateIndex("dbo.Alumno", "PeriodosId");
            AddForeignKey("dbo.Alumno", "PeriodosId", "dbo.Periodos", "PeriodosId");
            DropColumn("dbo.Alumno", "PeriodoId");
            DropColumn("dbo.Alumno", "Periodos_PeriodoId");
            DropColumn("dbo.Alumno", "Periodos_FechaInicio");
            DropColumn("dbo.Alumno", "Periodos_FechaTermino");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Alumno", "Periodos_FechaTermino", c => c.DateTime(nullable: false));
            AddColumn("dbo.Alumno", "Periodos_FechaInicio", c => c.DateTime(nullable: false));
            AddColumn("dbo.Alumno", "Periodos_PeriodoId", c => c.Int(nullable: false));
            AddColumn("dbo.Alumno", "PeriodoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Alumno", "PeriodosId", "dbo.Periodos");
            DropIndex("dbo.Alumno", new[] { "PeriodosId" });
            DropColumn("dbo.Alumno", "PeriodosId");
            DropTable("dbo.Periodos");
        }
    }
}
