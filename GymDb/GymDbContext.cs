using GymApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GymDb
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        // add-migration InitialMigration
    }
}
