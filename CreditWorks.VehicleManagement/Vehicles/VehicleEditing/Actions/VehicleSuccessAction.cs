using CreditWorks.VehicleManagement.Vehicles.Models;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Actions
{
    public class VehicleSuccessAction
    {
        public VehicleSuccessAction(Vehicle vehicle)
        {
            Vehicle = vehicle;
        }

        public Vehicle Vehicle { get; }
    }
}
