using CreditWorks.VehicleManagement.Data;
using CreditWorks.VehicleManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditWorks.VehicleManagement.Core.Managers
{
    public class VehicleManager
    {
        private IDbContextFactory<VehiclesDbContext> _dbContextFactory;

        public VehicleManager(IDbContextFactory<VehiclesDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task AddVehicle(Vehicle vehicle)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            //add validation

            await context.Vehicles.AddAsync(vehicle);
        }

        public async Task<Tuple<IEnumerable<Category>, IEnumerable<Manufacturer>, IEnumerable<Vehicle>>> GetInitialData()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            //used to see if we can connect to the DB
            //var canConnect = context.Database.CanConnect();

            var categories = await context.Categories.ToListAsync();
            var manufacturers = await context.Manufacturers.ToListAsync();
            var vehicles = await context.Vehicles.ToListAsync();

            return new Tuple<IEnumerable<Category>, IEnumerable<Manufacturer>, IEnumerable<Vehicle>>(categories, manufacturers, vehicles);
        }
    }
}
