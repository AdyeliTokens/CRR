namespace CRR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes_SelfControl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CRR_QTMData", "Shift", c => c.Int(nullable: false));
            AddColumn("dbo.CRR_VisualData", "Shift", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CRR_VisualData", "Shift");
            DropColumn("dbo.CRR_QTMData", "Shift");
        }
    }
}
