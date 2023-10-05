using CreditWorks.VehicleManagement.Vehicles.Models;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Actions.Create
{
    public class CreateSuccessAction
    {
        public CreateSuccessAction(Vehicle vehicle)
        {
            Vehicle = vehicle;
        }

        public Vehicle Vehicle { get; }
    }
}
