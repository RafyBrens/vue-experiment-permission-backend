using Microsoft.EntityFrameworkCore;
using RequestPermission.Business.Entities.Identity;
using RequestPermission.Database.EntityConfigurations;


namespace RequestPermission.Database
{
    public class RequestPermissionContext: DbContext
    {
        public RequestPermissionContext(DbContextOptions<RequestPermissionContext> options):base(options) { }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermissionTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionEntityConfiguration());
        }

        #region Tables

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }

        #endregion

    }
}
