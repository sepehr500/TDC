namespace TDC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZipandOrgan1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Affil", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Affil");
        }
    }
}
