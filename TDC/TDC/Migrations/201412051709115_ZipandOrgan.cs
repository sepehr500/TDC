namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZipandOrgan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ParticipantOrOrgan", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Zip", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Zip");
            DropColumn("dbo.AspNetUsers", "ParticipantOrOrgan");
        }
    }
}
