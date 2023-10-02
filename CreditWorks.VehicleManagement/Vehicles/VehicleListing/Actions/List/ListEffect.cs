using CreditWorks.VehicleManagement.Data;
using CreditWorks.VehicleManagement.Data.Models;
using Fluxor;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing.Actions.List
{
    public class ListEffect : Effect<ListAction>
    {
        private readonly IDbContextFactory<VehiclesDbContext> _dbContextFactory;

        public ListEffect(IDbContextFactory<VehiclesDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public override async Task HandleAsync(ListAction action, IDispatcher dispatcher)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            //used to see if we can connect to the DB
            //var canConnect = context.Database.CanConnect();

            var manufacturers = GenerateManufacturers(await context.Manufacturers.ToListAsync());
            var categories = GenerateCategories(await context.Categories.ToListAsync());
            var vehicles = GenerateVehicles(await context.Vehicles.ToListAsync());

            dispatcher.Dispatch(new VehicleListSuccessAction(vehicles, manufacturers, categories));
        }

        private static ImmutableList<Models.Category> GenerateCategories(IEnumerable<Category> categories)
        {
            return categories
                .Select(c => new Models.Category(c.Id, c.Name, c.MinWeight, c.MaxWeight, c.IconUrl))
                .ToImmutableList();
        }

        private static ImmutableList<Models.Manufacturer> GenerateManufacturers(IEnumerable<Manufacturer> manufacturers)
        {
            return manufacturers
                .Select(c => new Models.Manufacturer(c.Id, c.Name))
                .ToImmutableList();
        }

        private static ImmutableList<Models.VehicleListItem> GenerateVehicles(IEnumerable<Vehicle> vehicles)
        {
            return vehicles
                .Select(c => new Models.VehicleListItem(c.Id, c.Manufacturer.Id, c.Category.Id, c.Owner, c.Year))
                .ToImmutableList();
        }
    }
}
