namespace CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Actions
{
    public class VehicleFailureAction
    {
        public VehicleFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }
}
