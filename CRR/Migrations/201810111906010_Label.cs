namespace CRR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Label : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CRR_Label",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdWaste = c.Int(nullable: false),
                        Lot = c.String(),
                        Consecutive = c.String(),
                        ManufacturingCenter = c.String(),
                        ProductionDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        BrandDescription = c.String(),
                        ProductCode = c.String(),
                        ProductDescription = c.String(),
                        LabelNumber = c.String(),
                        FlashPoint = c.String(),
                        Weight = c.Double(nullable: false),
                        Quantity = c.Double(nullable: false),
                        ExtractionBank = c.String(),
                        ExtractionModule = c.String(),
                        Operator = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CRR_WasteData", t => t.IdWaste)
                .Index(t => t.IdWaste);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CRR_Label", "IdWaste", "dbo.CRR_WasteData");
            DropIndex("dbo.CRR_Label", new[] { "IdWaste" });
            DropTable("dbo.CRR_Label");
        }
    }
}
