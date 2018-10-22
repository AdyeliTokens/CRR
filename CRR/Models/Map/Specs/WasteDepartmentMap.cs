using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using CRR.Models.Entidades.Specs;

namespace CRR.Models.Map
{
    public class WasteDepartmentMap : EntityTypeConfiguration<WasteDepartment>
    {
        public WasteDepartmentMap()
        {
            #region Properties
            ToTable("CRR_DepartmentWasteSpecs");
            HasKey(c => c.Id);
            Property(c => c.Id).HasColumnName("Id");
            Property(c => c.IdDepartment).HasColumnName("IdDepartment");
            Property(c => c.Value).HasColumnName("Value");
            Property(c => c.Active).HasColumnName("Active");
            #endregion

            #region HasRequired
            this.HasRequired(c => c.Department).WithMany(d => d.WasteDepartment).HasForeignKey(c => c.IdDepartment);
            #endregion

            #region HasMany
            #endregion

            #region HasOptional
            #endregion
        }

    }
}