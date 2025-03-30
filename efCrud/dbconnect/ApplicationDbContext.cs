using efCrud.Entity;
using Microsoft.EntityFrameworkCore;

namespace efCrud.dbconnect
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
