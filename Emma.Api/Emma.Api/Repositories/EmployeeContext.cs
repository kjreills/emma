using Microsoft.EntityFrameworkCore;

namespace Emma.Api.Repositories
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);

            modelBuilder.Entity<Employee>().HasOne(e => e.Department).WithMany();
            modelBuilder.Entity<Employee>().HasOne(e => e.Designation).WithMany();

            modelBuilder.Entity<Department>().HasKey(e => e.Id);
            modelBuilder.Entity<Designation>().HasKey(e => e.Id);
        }

        public DbSet<Employee>? Employee { get; set; }
        public DbSet<Department>? Department { get; set; }
        public DbSet<Designation>? Designation { get; set; }
    }
}
