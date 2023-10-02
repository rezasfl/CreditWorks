using CreditWorks.VehicleManagement.Vehicles.Models;
using System.Collections.Immutable;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing
{
    public class VehicleListState
    {
        public VehicleListState(
            bool isLoading,
            string? errorMessage,
            IEnumerable<VehicleListItem>? vehicles,
            IEnumerable<Manufacturer>? manufacturers,
            IEnumerable<Category>? categories)
        {
            IsLoading = isLoading;
            ErrorMessage = errorMessage;
            Vehicles = vehicles?.ToImmutableList() ?? ImmutableList<VehicleListItem>.Empty;
            Manufacturers = manufacturers?.ToImmutableList() ?? ImmutableList<Manufacturer>.Empty;
            Categories = categories?.ToImmutableList() ?? ImmutableList<Category>.Empty;
        }

        public bool IsLoading { get; }
        public string? ErrorMessage { get; }
        public ImmutableList<VehicleListItem> Vehicles { get; }
        public ImmutableList<Manufacturer> Manufacturers { get; }
        public ImmutableList<Category> Categories { get; }
    }
}
