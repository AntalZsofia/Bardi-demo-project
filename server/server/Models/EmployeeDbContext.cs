using Bardi_demo_project.Services;
using Microsoft.EntityFrameworkCore;

namespace Bardi_demo_project.Models;

public class EmployeeDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                IdentificationNumber = 1001,
                Name = "John",
                VectorOfImage = new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }
            }
        );
    }
}
    
    
