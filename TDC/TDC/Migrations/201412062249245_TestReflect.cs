namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestReflect : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Reflections", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.Reflections", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Reflections", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Reflections", name: "ApplicationUserId", newName: "ApplicationUser_Id");
        }
    }
}
