using CreditWorks.VehicleManagement.Vehicles.Models;
using System.Collections.Immutable;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing.Actions
{
    public class VehicleListSuccessAction
    {
        public VehicleListSuccessAction(
            bool sortedByOwner,
            int? manufacturerId,
            bool sortedByYear,
            int? category,
            ImmutableList<Category> categories,
            ImmutableList<Manufacturer> manufacturers,
            ImmutableList<VehicleListItem> vehicles
            )
        {
            ManufacturerId = manufacturerId;
            SortedByYear = sortedByYear;
            Category = category;
            Categories = categories;

            Vehicles = vehicles;
            Manufacturers = manufacturers;
            SortedByOwner = sortedByOwner;
        }

        public bool SortedByOwner { get; }
        public int? ManufacturerId { get; }
        public bool SortedByYear { get; }
        public int? Category { get; }

        public ImmutableList<Category> Categories { get; }
        public ImmutableList<Manufacturer> Manufacturers { get; }
        public ImmutableList<VehicleListItem> Vehicles { get; }
    }
}
