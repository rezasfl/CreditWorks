namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing.Actions
{
    public class VehicleListFailureAction
    {
        public VehicleListFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }
}
