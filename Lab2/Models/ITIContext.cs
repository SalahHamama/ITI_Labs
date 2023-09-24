using Microsoft.EntityFrameworkCore;

namespace Lab2.Models
{
    public class ITIContext : DbContext
    {
        public ITIContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HP;Database=ITI_Day2;Trusted_Connection=True;TrustServerCertificate=True");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Emp_Project> Emp_Projects { get; set; }
    }
}
