namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShockUsers", "ShockLU_ID", "dbo.ShockLUs");
            DropIndex("dbo.ShockUsers", new[] { "ShockLU_ID" });
            DropColumn("dbo.ShockUsers", "ShockLUId");
            RenameColumn(table: "dbo.ShockUsers", name: "ShockLU_ID", newName: "ShockLUId");
            AlterColumn("dbo.ShockUsers", "ShockLUId", c => c.Int(nullable: false));
            AlterColumn("dbo.ShockUsers", "ShockLUId", c => c.Int(nullable: false));
            CreateIndex("dbo.ShockUsers", "ShockLUId");
            AddForeignKey("dbo.ShockUsers", "ShockLUId", "dbo.ShockLUs", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShockUsers", "ShockLUId", "dbo.ShockLUs");
            DropIndex("dbo.ShockUsers", new[] { "ShockLUId" });
            AlterColumn("dbo.ShockUsers", "ShockLUId", c => c.Int());
            AlterColumn("dbo.ShockUsers", "ShockLUId", c => c.String());
            RenameColumn(table: "dbo.ShockUsers", name: "ShockLUId", newName: "ShockLU_ID");
            AddColumn("dbo.ShockUsers", "ShockLUId", c => c.String());
            CreateIndex("dbo.ShockUsers", "ShockLU_ID");
            AddForeignKey("dbo.ShockUsers", "ShockLU_ID", "dbo.ShockLUs", "ID");
        }
    }
}
