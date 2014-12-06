namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShockUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShockUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        ShockLU_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.ShockLUs", t => t.ShockLU_ID)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ShockLU_ID);
            
            CreateTable(
                "dbo.ShockLUs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.AspNetUsers", "Money");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Money", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.ShockUsers", "ShockLU_ID", "dbo.ShockLUs");
            DropForeignKey("dbo.ShockUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ShockUsers", new[] { "ShockLU_ID" });
            DropIndex("dbo.ShockUsers", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ShockLUs");
            DropTable("dbo.ShockUsers");
        }
    }
}
