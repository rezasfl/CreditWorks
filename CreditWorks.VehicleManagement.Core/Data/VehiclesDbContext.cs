using CreditWorks.VehicleManagement.Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditWorks.VehicleManagement.Data
{
    public class VehiclesDbContext : DbContext
    {
        public VehiclesDbContext(DbContextOptions<VehiclesDbContext> options) : base(options)
        {

        }

        public DbSet<Manufacturer> Manufacturers { get; }
        public DbSet<Category> Categories { get; }
        public DbSet<Vehicle> Vehicles { get; }
    }
}
