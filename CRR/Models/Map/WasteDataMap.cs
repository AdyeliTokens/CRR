using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using CRR.Models.Entidades;

namespace CRR.Models.Map
{
    public class WasteDataMap : EntityTypeConfiguration<WasteData>
    {
        public WasteDataMap()
        {
            #region Properties
            ToTable("CRR_WasteData");
            HasKey(c => c.Id);
            Property(c => c.Id).HasColumnName("Id");
            Property(c => c.IdWorkCenter).HasColumnName("WorkCenter");
            Property(c => c.Shift).HasColumnName("Shift");
            Property(c => c.IdBrand).HasColumnName("CodeFA");
            Property(c => c.BankExtraction).HasColumnName("BankExtraction");
            Property(c => c.VolumeWaste).HasColumnName("VolumeWaste");
            Property(c => c.CigaretteWeight).HasColumnName("CigaretteWeight");
            Property(c => c.CigaretteWaste).HasColumnName("CigaretteWaste");
            Property(c => c.IdUser).HasColumnName("IdUser");
            Property(c => c.RegistrationDate).HasColumnName("RegistrationDate");
            #endregion

            #region HasRequired
            this.HasRequired(c => c.WorkCenter).WithMany(p => p.WasteData).HasForeignKey(c => c.IdWorkCenter);
            this.HasRequired(c => c.Brand).WithMany(p => p.WasteData).HasForeignKey(c => c.IdBrand);
            //this.HasRequired(c => c.User).WithMany(p => p.WasteData).HasForeignKey(c => c.IdUser);
            #endregion

            #region HasMany
            this.HasMany(m => m.Labels).WithRequired(r => r.Waste);
            #endregion

            #region HasOptional
            #endregion
        }
    }
}