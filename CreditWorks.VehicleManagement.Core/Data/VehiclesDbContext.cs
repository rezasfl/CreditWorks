using CreditWorks.VehicleManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditWorks.VehicleManagement.Data
{
    public class VehiclesDbContext : DbContext
    {
        public VehiclesDbContext(DbContextOptions<VehiclesDbContext> options) : base(options)
        {

        }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
