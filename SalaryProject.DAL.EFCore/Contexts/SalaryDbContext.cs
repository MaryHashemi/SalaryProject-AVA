using Microsoft.EntityFrameworkCore;
using SalaryProject.DAL.EFCore.Mapping;
using SalaryProject.Domain.Models;

namespace SalaryProject.DAL.EFCore.Contexts
{
    public class SalaryDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public SalaryDbContext(DbContextOptions<SalaryDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeMapping());
        }
    }
}
