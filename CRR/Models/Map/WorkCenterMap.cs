using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using CRR.Models.Entidades;

namespace CRR.Models.Map
{
    public class WorkCenterMap : EntityTypeConfiguration<WorkCenter>
    {
        public WorkCenterMap()
        {
            #region Properties
            ToTable("CRR_WorkCenter");
            HasKey(c => c.Name);
            Property(c => c.Name).HasColumnName("WorkCenter");
            Property(c => c.TextID).HasColumnName("IdLESMES");
            Property(c => c.Facility).HasColumnName("Facility");
            Property(c => c.Company).HasColumnName("Company");
            Property(c => c.DepartmentName).HasColumnName("Department");
            Property(c => c.Active).HasColumnName("Active");
            #endregion

            #region HasRequired
            #endregion

            #region HasMany
            this.HasMany(x => x.FastShiftData).WithRequired(y => y.WorkCenter).HasForeignKey(x => x.IdWorkcenter);
            this.HasMany(x => x.WasteData).WithRequired(y => y.WorkCenter).HasForeignKey(x => x.IdWorkCenter);
            this.HasMany(x => x.WasteWorkCenter).WithRequired(y => y.WorkCenter).HasForeignKey(x => x.IdWorkCenter);
            this.HasMany(x => x.QTMsData).WithRequired(y => y.WorkCenter).HasForeignKey(x => x.IdWorkCenter);
            this.HasMany(x => x.VisualData).WithRequired(y => y.WorkCenter).HasForeignKey(x => x.IdWorkCenter);
            this.HasMany(x => x.RunningTimeData).WithRequired(y => y.WorkCenter).HasForeignKey(x => x.IdWorkCenter);
            #endregion

            #region HasOptional
            #endregion
        }
    }
}