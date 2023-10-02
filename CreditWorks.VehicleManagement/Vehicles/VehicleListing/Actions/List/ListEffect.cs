using CreditWorks.VehicleManagement.Core.Managers;
using CreditWorks.VehicleManagement.Data.Models;
using Fluxor;
using System.Collections.Immutable;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing.Actions.List
{
    public class ListEffect : Effect<ListAction>
    {
        private readonly VehicleManager _manager;

        public ListEffect(VehicleManager manager)
        {
            _manager = manager;
        }

        public override async Task HandleAsync(ListAction action, IDispatcher dispatcher)
        {
            var data = await _manager.GetInitialData();

            dispatcher.Dispatch(
                new VehicleListSuccessAction(
                    GenerateCategories(data.Item1),
                    GenerateManufacturers(data.Item2),
                    GenerateVehicles(data.Item3)));
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
