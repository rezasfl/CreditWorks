using CreditWorks.VehicleManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditWorks.VehicleManagement.Data
{
    public class VehiclesDbContext : DbContext
    {
        public VehiclesDbContext(DbContextOptions<VehiclesDbContext> options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicles { get; }
        public DbSet<Manufacturer> Manufacturers { get; }
    }
}
