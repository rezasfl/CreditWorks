using CreditWorks.VehicleManagement.Vehicles.Models;
using System.Collections.Immutable;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing.Actions
{
    public class VehicleListSuccessAction
    {
        public VehicleListSuccessAction(
            ImmutableList<VehicleListItem> vehicles,
            ImmutableList<Manufacturer> manufacturers,
            ImmutableList<Category> categories)
        {
            Vehicles = vehicles;
            Manufacturers = manufacturers;
            Categories = categories;
        }

        public ImmutableList<VehicleListItem> Vehicles { get; }
        public ImmutableList<Manufacturer> Manufacturers { get; }
        public ImmutableList<Category> Categories { get; }
    }
}
