using Fluxor;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleEditing
{
    public class VehicleFeature : Feature<VehicleState>
    {
        public override string GetName() => nameof(VehicleState);

        protected override VehicleState GetInitialState()
        {
            return new(false, null, null);
        }
    }
}
