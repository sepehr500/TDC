namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayDays2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "PlayDays", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "PlayDays", c => c.Int(nullable: false));
        }
    }
}
