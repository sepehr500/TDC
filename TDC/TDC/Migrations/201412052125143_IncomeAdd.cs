namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncomeAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incomes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Incomes", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Incomes");
        }
    }
}
