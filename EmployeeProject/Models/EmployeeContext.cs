using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options) { }
        DbSet<EmployeeClass> Employees { get; set; }

        
    }
}
