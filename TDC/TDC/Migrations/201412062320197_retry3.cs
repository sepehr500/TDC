namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retry3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Expenses", "UserID");
        }
    }
}
