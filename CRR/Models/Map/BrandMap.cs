using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using CRR.Models.Entidades;

namespace CRR.Models.Map
{
    public class BrandMap : EntityTypeConfiguration<Brand>
    {
        public BrandMap()
        {
            #region Properties
            ToTable("CRR_Brand");
            HasKey(c => c.CodeFA);
            Property(c => c.CodeFA).HasColumnName("CodeFA");
            Property(c => c.Description).HasColumnName("Description");
            Property(c => c.CigaretteCode).HasColumnName("CigaretteCode");
            Property(c => c.CigaretteWeight).HasColumnName("CigaretteWeight");
            Property(c => c.TobaccoWeight).HasColumnName("TobaccoWeight");
            Property(c => c.VeinCode).HasColumnName("VeinCode");
            Property(c => c.CigaretteCost).HasColumnName("CigaretteCost");
            Property(c => c.Active).HasColumnName("Active");
            #endregion

            #region HasRequired
            #endregion

            #region HasMany
            this.HasMany(x => x.FastShiftData).WithRequired(y => y.Brand).HasForeignKey(x => x.IdBrand);
            this.HasMany(x => x.WasteData).WithRequired(y => y.Brand).HasForeignKey(x => x.IdBrand);
            #endregion

            #region HasOptional
            #endregion
        }

    }
}