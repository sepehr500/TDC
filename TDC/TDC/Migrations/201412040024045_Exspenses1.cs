namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Exspenses1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Expenses", "ApplicationUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expenses", "ApplicationUserID", c => c.Int(nullable: false));
        }
    }
}
