namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Retry2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Expenses", name: "ApplicationUser_Id", newName: "User_Id");
            RenameColumn(table: "dbo.Incomes", name: "ApplicationUserId", newName: "UserId");
            RenameColumn(table: "dbo.Reflections", name: "ApplicationUserId", newName: "UserId");
            RenameColumn(table: "dbo.ShockUsers", name: "ApplicationUser_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Reflections", name: "IX_ApplicationUserId", newName: "IX_UserId");
            RenameIndex(table: "dbo.Expenses", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Incomes", name: "IX_ApplicationUserId", newName: "IX_UserId");
            RenameIndex(table: "dbo.ShockUsers", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ShockUsers", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.Incomes", name: "IX_UserId", newName: "IX_ApplicationUserId");
            RenameIndex(table: "dbo.Expenses", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.Reflections", name: "IX_UserId", newName: "IX_ApplicationUserId");
            RenameColumn(table: "dbo.ShockUsers", name: "User_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Reflections", name: "UserId", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.Incomes", name: "UserId", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.Expenses", name: "User_Id", newName: "ApplicationUser_Id");
        }
    }
}
