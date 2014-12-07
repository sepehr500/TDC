namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestAppId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Incomes", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.Incomes", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Incomes", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Incomes", name: "ApplicationUserId", newName: "ApplicationUser_Id");
        }
    }
}
