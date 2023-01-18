using EmployeeRegistratation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegistratation.Context.Persistence
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
    }
}