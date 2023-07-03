using GymApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GymDb
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {
            
        }

        DbSet<Customer> Customers { get; set; }
        DbSet<Employee> Employees { get; set; }

        // add-migration InitialMigration
    }
}
