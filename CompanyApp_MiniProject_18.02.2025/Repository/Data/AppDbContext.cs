using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Repository.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-M839BQT\\SQLEXPRESS;Database=CompanyAppDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
