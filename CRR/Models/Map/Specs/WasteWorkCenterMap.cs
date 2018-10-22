using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using CRR.Models.Entidades.Specs;

namespace CRR.Models.Map
{
    public class WasteWorkCenterMap : EntityTypeConfiguration<WasteWorkCenter>
    {
        public WasteWorkCenterMap()
        {
            #region Properties
            ToTable("CRR_WorkCenterWasteSpecs");
            HasKey(c => c.Id);
            Property(c => c.Id).HasColumnName("Id");
            Property(c => c.IdWorkCenter).HasColumnName("IdWorkCenter");
            Property(c => c.Value).HasColumnName("Value");
            Property(c => c.Active).HasColumnName("Active");
            #endregion

            #region HasRequired
            this.HasRequired(c => c.WorkCenter).WithMany(d => d.WasteWorkCenter).HasForeignKey(c => c.IdWorkCenter);
            #endregion

            #region HasMany
            #endregion

            #region HasOptional
            #endregion
        }

    }
}