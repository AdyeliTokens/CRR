namespace CRR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Autocontrol : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CRR_QTMData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdWorkCenter = c.String(nullable: false, maxLength: 11),
                        Value = c.Int(nullable: false),
                        WeekNo = c.Int(nullable: false),
                        DateBegin = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CRR_WorkCenter", t => t.IdWorkCenter)
                .Index(t => t.IdWorkCenter);
            
            CreateTable(
                "dbo.CRR_RunningTimeData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdWorkCenter = c.String(nullable: false, maxLength: 11),
                        Type = c.String(),
                        RunningTime = c.Int(nullable: false),
                        Shift = c.Int(nullable: false),
                        ShiftName = c.String(),
                        WeekNo = c.Int(nullable: false),
                        BeginTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CRR_WorkCenter", t => t.IdWorkCenter)
                .Index(t => t.IdWorkCenter);
            
            CreateTable(
                "dbo.CRR_VisualData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdWorkCenter = c.String(nullable: false, maxLength: 11),
                        Value = c.Int(nullable: false),
                        WeekNo = c.Int(nullable: false),
                        DateBegin = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CRR_WorkCenter", t => t.IdWorkCenter)
                .Index(t => t.IdWorkCenter);
            
            CreateTable(
                "dbo.CRR_SelfControlSpecs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Value = c.Double(nullable: false),
                        UM = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            //DropColumn("dbo.AspNetRoles", "Create");
            //DropColumn("dbo.AspNetRoles", "Read");
            //DropColumn("dbo.AspNetRoles", "Update");
            //DropColumn("dbo.AspNetRoles", "Delete");
            //DropColumn("dbo.AspNetRoles", "Active");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.AspNetRoles", "Active", c => c.Boolean(nullable: false));
            //AddColumn("dbo.AspNetRoles", "Delete", c => c.Boolean(nullable: false));
            //AddColumn("dbo.AspNetRoles", "Update", c => c.Boolean(nullable: false));
            //AddColumn("dbo.AspNetRoles", "Read", c => c.Boolean(nullable: false));
            //AddColumn("dbo.AspNetRoles", "Create", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.CRR_VisualData", "IdWorkCenter", "dbo.CRR_WorkCenter");
            DropForeignKey("dbo.CRR_RunningTimeData", "IdWorkCenter", "dbo.CRR_WorkCenter");
            DropForeignKey("dbo.CRR_QTMData", "IdWorkCenter", "dbo.CRR_WorkCenter");
            DropIndex("dbo.CRR_VisualData", new[] { "IdWorkCenter" });
            DropIndex("dbo.CRR_RunningTimeData", new[] { "IdWorkCenter" });
            DropIndex("dbo.CRR_QTMData", new[] { "IdWorkCenter" });
            DropTable("dbo.CRR_SelfControlSpecs");
            DropTable("dbo.CRR_VisualData");
            DropTable("dbo.CRR_RunningTimeData");
            DropTable("dbo.CRR_QTMData");
        }
    }
}
