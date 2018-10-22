namespace CRR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CRR_Brand",
                c => new
                    {
                        CodeFA = c.String(nullable: false, maxLength: 11),
                        Description = c.String(),
                        CigaretteCode = c.String(),
                        CigaretteWeight = c.Double(nullable: false),
                        TobaccoWeight = c.Double(nullable: false),
                        VeinCode = c.String(),
                        CigaretteCost = c.Double(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CodeFA);
            
            CreateTable(
                "dbo.CRR_FastShiftData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdWorkCenter = c.String(nullable: false, maxLength: 11),
                        IdDepartment = c.String(nullable: false, maxLength: 11),
                        IdBrand = c.String(nullable: false, maxLength: 11),
                        CodeFAName = c.String(),
                        ProdVol = c.Double(nullable: false),
                        TargetQty = c.Double(nullable: false),
                        CurrentTargetQty = c.Double(nullable: false),
                        OrderNo = c.Int(nullable: false),
                        OrderStatus = c.Short(),
                        CigaretteCode = c.String(),
                        CigaretteName = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CRR_Department", t => t.IdDepartment)
                .ForeignKey("dbo.CRR_WorkCenter", t => t.IdWorkCenter)
                .ForeignKey("dbo.CRR_Brand", t => t.IdBrand)
                .Index(t => t.IdWorkCenter)
                .Index(t => t.IdDepartment)
                .Index(t => t.IdBrand);
            
            CreateTable(
                "dbo.CRR_Department",
                c => new
                    {
                        Department = c.String(nullable: false, maxLength: 11),
                        IdLESMES = c.Int(nullable: false),
                        Facility = c.String(),
                        Company = c.String(),
                        CalendarID = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Department);
            
            CreateTable(
                "dbo.CRR_DepartmentWasteSpecs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdDepartment = c.String(nullable: false, maxLength: 11),
                        Value = c.Double(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CRR_Department", t => t.IdDepartment)
                .Index(t => t.IdDepartment);
            
            CreateTable(
                "dbo.CRR_WorkCenter",
                c => new
                    {
                        WorkCenter = c.String(nullable: false, maxLength: 11),
                        IdLESMES = c.Int(nullable: false),
                        Facility = c.String(),
                        Company = c.String(),
                        Department = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.WorkCenter);
            
            CreateTable(
                "dbo.CRR_WasteData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkCenter = c.String(nullable: false, maxLength: 11),
                        Shift = c.Int(nullable: false),
                        CodeFA = c.String(nullable: false, maxLength: 11),
                        BankExtraction = c.Int(nullable: false),
                        VolumeWaste = c.Double(nullable: false),
                        CigaretteWeight = c.Double(nullable: false),
                        CigaretteWaste = c.Double(nullable: false),
                        IdUser = c.String(nullable: false, maxLength: 128),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdUser)
                .ForeignKey("dbo.CRR_WorkCenter", t => t.WorkCenter)
                .ForeignKey("dbo.CRR_Brand", t => t.CodeFA)
                .Index(t => t.WorkCenter)
                .Index(t => t.CodeFA)
                .Index(t => t.IdUser);
            
            //CreateTable(
            //    "dbo.AspNetUsers",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Email = c.String(maxLength: 250),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(maxLength: 250),
            //            SecurityStamp = c.String(maxLength: 250),
            //            PhoneNumber = c.String(maxLength: 250),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockOutEndDateUTC = c.Boolean(),
            //            LockOutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(maxLength: 250),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AspNetRoles",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Create = c.Boolean(nullable: false),
            //            Read = c.Boolean(nullable: false),
            //            Update = c.Boolean(nullable: false),
            //            Delete = c.Boolean(nullable: false),
            //            Active = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CRR_WorkCenterWasteSpecs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdWorkCenter = c.String(nullable: false, maxLength: 11),
                        Value = c.Double(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CRR_WorkCenter", t => t.IdWorkCenter)
                .Index(t => t.IdWorkCenter);
            
            //CreateTable(
            //    "dbo.AspNetUserRoles",
            //    c => new
            //        {
            //            RoleId = c.Int(nullable: false),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.RoleId, t.UserId })
            //    .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId)
            //    .Index(t => t.RoleId)
            //    .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CRR_WasteData", "CodeFA", "dbo.CRR_Brand");
            DropForeignKey("dbo.CRR_FastShiftData", "IdBrand", "dbo.CRR_Brand");
            DropForeignKey("dbo.CRR_FastShiftData", "IdWorkCenter", "dbo.CRR_WorkCenter");
            DropForeignKey("dbo.CRR_WorkCenterWasteSpecs", "IdWorkCenter", "dbo.CRR_WorkCenter");
            DropForeignKey("dbo.CRR_WasteData", "WorkCenter", "dbo.CRR_WorkCenter");
            DropForeignKey("dbo.CRR_WasteData", "IdUser", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CRR_DepartmentWasteSpecs", "IdDepartment", "dbo.CRR_Department");
            DropForeignKey("dbo.CRR_FastShiftData", "IdDepartment", "dbo.CRR_Department");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.CRR_WorkCenterWasteSpecs", new[] { "IdWorkCenter" });
            DropIndex("dbo.CRR_WasteData", new[] { "IdUser" });
            DropIndex("dbo.CRR_WasteData", new[] { "CodeFA" });
            DropIndex("dbo.CRR_WasteData", new[] { "WorkCenter" });
            DropIndex("dbo.CRR_DepartmentWasteSpecs", new[] { "IdDepartment" });
            DropIndex("dbo.CRR_FastShiftData", new[] { "IdBrand" });
            DropIndex("dbo.CRR_FastShiftData", new[] { "IdDepartment" });
            DropIndex("dbo.CRR_FastShiftData", new[] { "IdWorkCenter" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.CRR_WorkCenterWasteSpecs");
            //DropTable("dbo.AspNetRoles");
            //DropTable("dbo.AspNetUsers");
            DropTable("dbo.CRR_WasteData");
            DropTable("dbo.CRR_WorkCenter");
            DropTable("dbo.CRR_DepartmentWasteSpecs");
            DropTable("dbo.CRR_Department");
            DropTable("dbo.CRR_FastShiftData");
            DropTable("dbo.CRR_Brand");
        }
    }
}
