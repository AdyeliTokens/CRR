using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using CRR.Models.Entidades;

namespace CRR.Models.Map
{
    public class FastShiftDataMap : EntityTypeConfiguration<FastShiftData>
    {
        public FastShiftDataMap()
        {
            #region Properties
            ToTable("CRR_FastShiftData");
            HasKey(c => c.Id);
            Property(c => c.Id).HasColumnName("Id");
            Property(c => c.IdWorkcenter).HasColumnName("IdWorkCenter");
            Property(c => c.IdDepartment).HasColumnName("IdDepartment");
            Property(c => c.IdBrand).HasColumnName("IdBrand");
            Property(c => c.FAName).HasColumnName("CodeFAName");
            Property(c => c.ProdVol).HasColumnName("ProdVol");
            Property(c => c.TargetQty).HasColumnName("TargetQty");
            Property(c => c.CurrentTargetQty).HasColumnName("CurrentTargetQty");
            Property(c => c.OrderNo).HasColumnName("OrderNo");
            Property(c => c.OrderStatus).HasColumnName("OrderStatus");
            Property(c => c.CigaretteCode).HasColumnName("CigaretteCode");
            Property(c => c.CigaretteName).HasColumnName("CigaretteName");
            Property(c => c.RegistrationDate).HasColumnName("RegistrationDate");
            #endregion

            #region HasRequired
            this.HasRequired(c => c.WorkCenter).WithMany(e => e.FastShiftData).HasForeignKey(c => c.IdWorkcenter);
            this.HasRequired(c => c.Department).WithMany(e => e.FastShiftData).HasForeignKey(c => c.IdDepartment);
            this.HasRequired(c => c.Brand).WithMany(e => e.FastShiftData).HasForeignKey(c => c.IdBrand);
            #endregion

            #region HasMany
            #endregion

            #region HasOptional
            #endregion
        }

    }
}