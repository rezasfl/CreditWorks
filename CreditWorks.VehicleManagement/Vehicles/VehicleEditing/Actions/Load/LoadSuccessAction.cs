using CreditWorks.VehicleManagement.Vehicles.Models;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Actions.Load
{
    public class LoadSuccessAction
    {
        public LoadSuccessAction(Vehicle vehicle)
        {
            Vehicle = vehicle;
        }

        public Vehicle Vehicle { get; set; }
    }
}
