namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlertTF : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Alert", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Alert");
        }
    }
}
