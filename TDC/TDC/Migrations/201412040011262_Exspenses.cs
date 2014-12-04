namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Exspenses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        product = c.String(),
                        cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApplicationUserID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Expenses", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Expenses");
        }
    }
}
