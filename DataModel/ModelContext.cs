using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataModel
{
    public class mFrameworkDbContext : DbContext
    {
        public mFrameworkDbContext()
            : base("mFrameworkDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<AccessControlList> accesscontrollist { get; set; }
        public DbSet<RoleUserDetail> roleuserdtl { get; set; }
        public DbSet<RoleMaster> rolemaster { get; set; }
        public DbSet<UserMaster> usermaster { get; set; }
        public DbSet<ScreenMaster> screenmaster { get; set; }
        public DbSet<MenuMaster> menumaster { get; set; }
        public DbSet<DepartmentMaster> departmentmaster { get; set; }
    }
    public class mFrameworkInitializer : CreateDatabaseIfNotExists<mFrameworkDbContext>
    {
        public mFrameworkInitializer()
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<mFrameworkDbContext, DataModel.Migrations.Configuration>());

        }

    }
}