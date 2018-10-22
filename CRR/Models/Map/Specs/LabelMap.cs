using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using CRR.Models.Entidades.Specs;

namespace CRR.Models.Map.Specs
{
    public class LabelMap : EntityTypeConfiguration<Label>
    {
        public LabelMap()
        {
            #region Properties
            ToTable("CRR_Label");
            HasKey(c => c.Id);
            Property(c => c.Id).HasColumnName("Id");
            Property(c => c.IdWaste).HasColumnName("IdWaste");
            Property(c => c.Lot).HasColumnName("Lot");
            Property(c => c.Consecutive).HasColumnName("Consecutive");
            Property(c => c.ManufacturingCenter).HasColumnName("ManufacturingCenter");
            Property(c => c.ProductionDate).HasColumnName("ProductionDate");
            Property(c => c.ExpirationDate).HasColumnName("ExpirationDate");
            Property(c => c.BrandDescription).HasColumnName("BrandDescription");
            Property(c => c.ProductCode).HasColumnName("ProductCode");
            Property(c => c.ProductDescription).HasColumnName("ProductDescription");
            Property(c => c.LabelNumber).HasColumnName("LabelNumber");
            Property(c => c.FlashPoint).HasColumnName("FlashPoint");
            Property(c => c.Weight).HasColumnName("Weight");
            Property(c => c.Quantity).HasColumnName("Quantity");
            Property(c => c.ExtractionBank).HasColumnName("ExtractionBank");
            Property(c => c.ExtractionModule).HasColumnName("ExtractionModule");
            Property(c => c.Operator).HasColumnName("Operator");
            #endregion

            #region HasRequired
            this.HasRequired(r => r.Waste).WithMany(m => m.Labels).HasForeignKey(f=> f.IdWaste);
            #endregion

            #region HasMany
            #endregion

            #region HasOptional
            #endregion
        }
    }
}