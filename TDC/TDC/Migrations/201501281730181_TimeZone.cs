namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeZone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "TimeZoneOffset", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "TimeZoneOffset");
        }
    }
}
