namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShockStuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        notification = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.GlobalDates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.ShockLUs", "ShockType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "UserId" });
            DropColumn("dbo.ShockLUs", "ShockType");
            DropTable("dbo.GlobalDates");
            DropTable("dbo.Messages");
        }
    }
}
