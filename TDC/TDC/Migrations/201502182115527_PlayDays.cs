namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayDays : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PlayDays", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PlayDays");
        }
    }
}
