using Fluxor;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Flux
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
