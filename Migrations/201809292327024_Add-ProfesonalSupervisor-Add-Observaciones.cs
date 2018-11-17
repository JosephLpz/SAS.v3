namespace SAS.v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfesonalSupervisorAddObservaciones : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfesionalSupervisor", "Observaciones", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfesionalSupervisor", "Observaciones");
        }
    }
}
