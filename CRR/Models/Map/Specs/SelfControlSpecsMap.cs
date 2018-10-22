using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using CRR.Models.Entidades.Specs;

namespace CRR.Models.Map.Specs
{
    public class SelfControlSpecsMap : EntityTypeConfiguration<SelfControlSpecs>
    {
        public SelfControlSpecsMap()
        {
            #region Properties
            ToTable("CRR_SelfControlSpecs");
            HasKey(c => c.Id);
            Property(c => c.Id).HasColumnName("Id");
            Property(c => c.Descripcion).HasColumnName("Descripcion");
            Property(c => c.Value).HasColumnName("Value");
            Property(c => c.UM).HasColumnName("UM");
            Property(c => c.Active).HasColumnName("Active");
            #endregion

            #region HasRequired
            #endregion

            #region HasMany
            #endregion

            #region HasOptional
            #endregion
        }
    }
}