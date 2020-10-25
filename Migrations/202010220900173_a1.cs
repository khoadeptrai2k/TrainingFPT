namespace TrainingFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "WorkingPlace");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "WorkingPlace", c => c.String());
        }
    }
}
