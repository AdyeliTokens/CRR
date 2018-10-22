using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using CRR.Models.Entidades.Admin;

namespace CRR.Models.Map.Admin
{
    public class RolMap : EntityTypeConfiguration<Rol>
    {
        public RolMap()
        {
            #region Properties
            ToTable("AspNetRoles");
            HasKey(c => c.Id);
            Property(c => c.Id).HasColumnName("Id");
            Property(c => c.Name).HasColumnName("Name");
           
            #endregion

            #region HasRequired
            #endregion

            #region HasMany
            HasMany(c => c.Users).WithMany(x => x.Roles).Map(cs =>
            {
                cs.MapLeftKey("RoleId");
                cs.MapRightKey("UserId");
                cs.ToTable("AspNetUserRoles");
            });
            #endregion

            #region HasOptional
            #endregion
        }

    }
}