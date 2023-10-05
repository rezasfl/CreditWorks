using CreditWorks.VehicleManagement.Vehicles.Models;
using System.Collections.Immutable;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing
{
    public class VehicleListState
    {
        public VehicleListState(
            bool isLoading,
            bool sortedByOwner,
            int? manufacturer,
            bool sortedByYear,
            int? category,
            IEnumerable<VehicleListItem>? vehicles,
            IEnumerable<Manufacturer>? manufacturers,
            IEnumerable<Category>? categories)
        {
            IsLoading = isLoading;
            SortedByOwner = sortedByOwner;
            Manufacturer = manufacturer;
            SortedByYear = sortedByYear;
            Category = category;

            Vehicles = vehicles?.ToImmutableList() ?? ImmutableList<VehicleListItem>.Empty;
            Manufacturers = manufacturers?.ToImmutableList() ?? ImmutableList<Manufacturer>.Empty;
            Categories = categories?.ToImmutableList() ?? ImmutableList<Category>.Empty;
        }

        public bool IsLoading { get; }

        //Listing filters
        public bool HasFilters => Manufacturer.HasValue || SortedByYear || Category.HasValue;
        public bool SortedByOwner { get; }
        public int? Manufacturer { get; }
        public bool SortedByYear { get; }
        public int? Category { get; }

        public ImmutableList<VehicleListItem> Vehicles { get; }
        public ImmutableList<Manufacturer> Manufacturers { get; }
        public ImmutableList<Category> Categories { get; }
    }
}
