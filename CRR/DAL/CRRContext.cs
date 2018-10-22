using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CRR.Models.Entidades;
using CRR.Models.Entidades.Admin;
using CRR.Models.Entidades.SelfControl;
using CRR.Models.Entidades.Specs;
using CRR.Models.Map;
using CRR.Models.Map.Admin;
using CRR.Models.Map.Specs;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CRR.DAL
{
    public class CRRContext : DbContext
    {

        public  CRRContext() : base("CRRContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            this.Database.CommandTimeout = 60;
            Database.Log = s => System.Diagnostics.Trace.WriteLine(s);
        }

        public static CRRContext Create()
        {
            return new CRRContext();
        }

        #region Administrator
        public DbSet<User> User { get; set; }
        public DbSet<Rol> Rol { get; set; }
        #endregion

        #region Specs
        public DbSet<WasteDepartment> WasteDepartments { get; set; }
        public DbSet<WasteWorkCenter> WasteWorkCenters { get; set; }
        public DbSet<SelfControlSpecs> SelfControlSpecs { get; set; }
        public DbSet<Label> Label { get; set; }
        #endregion

        #region Secondary
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<FastShiftData> FastShiftData { get; set; }
        public DbSet<WasteData> WasteData { get; set; }       
        public DbSet<WorkCenter> WorkCenters { get; set; }
        #endregion

        #region SelfControl
        public DbSet<QTMData> QTMData { get; set; }
        public DbSet<VisualData> VisualData { get; set; }
        public DbSet<RunningTimeData> RunningTimeData { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Administrator
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RolMap());
            // Configure Asp Net Identity Tables
            modelBuilder.Entity<User>().ToTable("AspNetUsers");
            #endregion

            #region Specs
            modelBuilder.Configurations.Add(new WasteDepartmentMap());
            modelBuilder.Configurations.Add(new WasteWorkCenterMap());
            modelBuilder.Configurations.Add(new SelfControlSpecsMap ());
            modelBuilder.Configurations.Add(new LabelMap());
            #endregion

            #region Secondary
            modelBuilder.Configurations.Add (new BrandMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new FastShiftDataMap());
            modelBuilder.Configurations.Add(new WasteDataMap());
            modelBuilder.Configurations.Add(new WorkCenterMap());
            #endregion

            #region SelfControl
            modelBuilder.Configurations.Add(new QTMDataMap());
            modelBuilder.Configurations.Add(new VisualDataMap());
            modelBuilder.Configurations.Add(new RunningTimeDataMap());
            #endregion


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            Database.SetInitializer<CRRContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}