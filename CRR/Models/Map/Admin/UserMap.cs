using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using CRR.Models.Entidades.Admin;

namespace CRR.Models.Map.Admin
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
           #region Properties
            ToTable("AspNetUsers");
            HasKey(c => c.Id);
            Property(c => c.Id).HasColumnName("Id");
            Property(c => c.Email).HasColumnName("Email");
            Property(c => c.PasswordHash).HasColumnName("PasswordHash");
            Property(c => c.SecurityStamp).HasColumnName("SecurityStamp");
            Property(c => c.UserName).HasColumnName("UserName");
            Property(c => c.PasswordHash).HasColumnName("PasswordHash");
            Property(c => c.SecurityStamp).HasColumnName("SecurityStamp");
            Property(c => c.PhoneNumber).HasColumnName("PhoneNumber");
            Property(c => c.TwoFactorEnabled).HasColumnName("TwoFactorEnabled");
            Property(c => c.LockOutEndDateUTC).HasColumnName("LockOutEndDateUTC");
            Property(c => c.AccessFailedCount).HasColumnName("AccessFailedCount");
            Property(c => c.TwoFactorEnabled).HasColumnName("TwoFactorEnabled");
            
            #endregion

            #region HasRequired
            #endregion

            #region HasMany
            //this.HasMany(x => x.WasteData).WithRequired(y => y.User);

            HasMany(c => c.Roles).WithMany(x => x.Users).Map(cs =>
            {
                cs.MapLeftKey("UserId");
                cs.MapRightKey("RoleId");
                cs.ToTable("AspNetUserRoles");
            });
            #endregion

            #region HasOptional
            #endregion
        }

    }
}