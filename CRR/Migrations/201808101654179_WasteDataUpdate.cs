namespace CRR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WasteDataUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CRR_WasteData", "IdUser", "dbo.AspNetUsers");
            DropIndex("dbo.CRR_WasteData", new[] { "IdUser" });
            AlterColumn("dbo.CRR_WasteData", "IdUser", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CRR_WasteData", "IdUser", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.CRR_WasteData", "IdUser");
            AddForeignKey("dbo.CRR_WasteData", "IdUser", "dbo.AspNetUsers", "Id");
        }
    }
}
