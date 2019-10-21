using TestTask.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TestTask.DAL
{
    public class BankContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Office> Offices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Organization>()
                .HasMany(c => c.Workers).WithMany(i => i.Organizations)
                .Map(t => t.MapLeftKey("OrganizationID")
                    .MapRightKey("WorkerID")
                    .ToTable("OrganizationWorker"));
        }
    }
}