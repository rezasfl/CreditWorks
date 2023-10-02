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

        public async Task<Tuple<IEnumerable<Category>, IEnumerable<Manufacturer>, IEnumerable<Vehicle>>> GetInitialData(
            bool sortedByOwner,
            int? manufacturerId,
            bool sortedByYear,
            int? category)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            //used to see if we can connect to the DB
            //var canConnect = context.Database.CanConnect();

            var categories = await context.Categories.ToListAsync();
            var manufacturers = await context.Manufacturers.ToListAsync();
            var vehicles = await context.Vehicles.ToListAsync();

            //If we want to sort by both owner AND year, we can use OrderBy().ThenBy()
            //but for now, we sort either by owner or year
            if (sortedByOwner)
                vehicles = vehicles.OrderBy(x => x.Owner).ToList();
            else if (sortedByYear)
                vehicles = vehicles.OrderBy(x => x.Year).ToList();

            if (manufacturerId.HasValue)
                vehicles = vehicles.Where(x => x.Manufacturer.Id == manufacturerId).ToList();

            if (category.HasValue)
                vehicles = vehicles.Where(x => x.Category.Id == category).ToList();

            return new Tuple<IEnumerable<Category>, IEnumerable<Manufacturer>, IEnumerable<Vehicle>>(categories, manufacturers, vehicles);
        }
    }
}
