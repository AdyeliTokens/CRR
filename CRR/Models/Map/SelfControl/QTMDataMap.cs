using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using CRR.Models.Entidades;
using CRR.Models.Entidades.SelfControl;

namespace CRR.Models.Map
{
    public class QTMDataMap : EntityTypeConfiguration<QTMData>
    {
        public QTMDataMap()
        {
            #region Properties
            ToTable("CRR_QTMData");
            HasKey(c => c.Id);
            Property(c => c.Id).HasColumnName("Id");
            Property(c => c.IdWorkCenter).HasColumnName("IdWorkCenter");
            Property(c => c.Value).HasColumnName("Value");
            Property(c => c.WeekNo).HasColumnName("WeekNo");
            Property(c => c.DateBegin).HasColumnName("DateBegin");
            Property(c => c.DateEnd).HasColumnName("DateEnd");
            Property(c => c.Shift).HasColumnName("Shift");
            #endregion

            #region HasRequired
            this.HasRequired(x => x.WorkCenter).WithMany(y => y.QTMsData).HasForeignKey(x=> x.IdWorkCenter);
            #endregion

            #region HasMany
            #endregion

            #region HasOptional
            #endregion
        }

    }
}