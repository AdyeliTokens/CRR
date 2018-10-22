using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using CRR.Models.Entidades;
using CRR.Models.Entidades.SelfControl;

namespace CRR.Models.Map
{
    public class RunningTimeDataMap : EntityTypeConfiguration<RunningTimeData>
    {
        public RunningTimeDataMap()
        {
            #region Properties
            ToTable("CRR_RunningTimeData");
            HasKey(c => c.Id);
            Property(c => c.Id).HasColumnName("Id");
            Property(c => c.IdWorkCenter).HasColumnName("IdWorkCenter");
            Property(c => c.Type).HasColumnName("Type");
            Property(c => c.Shift).HasColumnName("Shift");
            Property(c => c.ShiftName).HasColumnName("ShiftName");
            Property(c => c.WeekNo).HasColumnName("WeekNo");
            Property(c => c.BeginTime).HasColumnName("BeginTime");
            Property(c => c.EndTime).HasColumnName("EndTime");
            #endregion

            #region HasRequired
            this.HasRequired(x => x.WorkCenter).WithMany(y => y.RunningTimeData);
            #endregion

            #region HasMany
            #endregion

            #region HasOptional
            #endregion
        }

    }
}