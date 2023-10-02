using CreditWorks.VehicleManagement.Core.Data.Models;
using CreditWorks.VehicleManagement.Data;
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

            var vehicles = GenerateVehicles(context.Vehicles.Select(v => v));
            var manufacturers = GenerateManufacturers(context.Manufacturers.Select(m => m));
            var categories = GenerateCategories(context.Categories.Select(c => c));

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
