namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "level", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "type", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "sex", c => c.Int());
            AddColumn("dbo.AspNetUsers", "again", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "again");
            DropColumn("dbo.AspNetUsers", "sex");
            DropColumn("dbo.AspNetUsers", "type");
            DropColumn("dbo.AspNetUsers", "level");
        }
    }
}
