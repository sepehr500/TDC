namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reflection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reflections",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Memo = c.String(maxLength: 140),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reflections", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reflections", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Reflections");
        }
    }
}
