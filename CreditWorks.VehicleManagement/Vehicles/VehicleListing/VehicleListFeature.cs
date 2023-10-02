using Fluxor;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing
{
    public class VehicleListFeature : Feature<VehicleListState>
    {
        public override string GetName() => nameof(VehicleListState);

        protected override VehicleListState GetInitialState()
        {
            return new(false, null, null, null, null);
        }
    }
}
