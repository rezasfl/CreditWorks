using CreditWorks.VehicleManagement.Core.Managers;
using CreditWorks.VehicleManagement.Data.Models;
using Fluxor;
using System.Collections.Immutable;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing.Actions.List
{
    public class ListEffect : Effect<ListAction>
    {
        private readonly VehicleManager _manager;
        private readonly ILogger<ListEffect> _logger;

        public ListEffect(VehicleManager manager, ILogger<ListEffect> logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public override async Task HandleAsync(ListAction action, IDispatcher dispatcher)
        {
            try
            {
                var data = await _manager.GetInitialData(action.SortedByOwner, action.ManufacturerId, action.SortedByYear, action.Category);

                dispatcher.Dispatch(
                    new VehicleListSuccessAction(
                        action.SortedByOwner,
                        action.ManufacturerId,
                        action.SortedByYear,
                        action.Category,
                        GenerateCategories(data.Item1),
                        GenerateManufacturers(data.Item2),
                        GenerateVehicles(data.Item3)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading vehicle list, reason: {ex.Message}");
                dispatcher.Dispatch(new VehicleListFailureAction(ex.Message));
            }
        }

        private static ImmutableList<Shared.Models.Category> GenerateCategories(IEnumerable<Category> categories)
        {
            return categories
                .Select(c => new Shared.Models.Category(c.Id, c.Name, c.MinWeight, c.MaxWeight, c.IconUrl))
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
