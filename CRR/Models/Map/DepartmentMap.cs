using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using CRR.Models.Entidades;

namespace CRR.Models.Map
{
    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            #region Properties
            ToTable("CRR_Department");
            HasKey(c => c.Name);
            Property(c => c.IdLESMES).HasColumnName("IdLESMES");
            Property(c => c.Name).HasColumnName("Department");
            Property(c => c.Facility).HasColumnName("Facility");
            Property(c => c.Company).HasColumnName("Company");
            Property(c => c.CalendarID).HasColumnName("CalendarID");
            Property(c => c.Active).HasColumnName("Active");
            #endregion

            #region HasRequired
            #endregion

            #region HasMany
            this.HasMany(x => x.WasteDepartment).WithRequired(y => y.Department).HasForeignKey(x=> x.IdDepartment);
            this.HasMany(x => x.FastShiftData).WithRequired(y => y.Department).HasForeignKey(x => x.IdDepartment);
            #endregion

            #region HasOptional
            #endregion
        }
    }
}