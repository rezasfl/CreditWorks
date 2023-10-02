using CreditWorks.VehicleManagement.Core.Data.Models;
using CreditWorks.VehicleManagement.Data;
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
    }
}
