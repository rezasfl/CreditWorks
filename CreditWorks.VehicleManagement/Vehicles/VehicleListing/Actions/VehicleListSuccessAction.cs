using CreditWorks.VehicleManagement.Vehicles.Models;
using System.Collections.Immutable;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing.Actions
{
    public class VehicleListSuccessAction
    {
        public VehicleListSuccessAction(
            ImmutableList<Category> categories,
            ImmutableList<Manufacturer> manufacturers,
            ImmutableList<VehicleListItem> vehicles
            )
        {
            Vehicles = vehicles;
            Manufacturers = manufacturers;
            Categories = categories;
        }

        public ImmutableList<Category> Categories { get; }
        public ImmutableList<Manufacturer> Manufacturers { get; }
        public ImmutableList<VehicleListItem> Vehicles { get; }
    }
}
