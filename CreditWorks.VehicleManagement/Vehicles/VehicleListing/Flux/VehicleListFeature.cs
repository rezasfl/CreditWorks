﻿using Fluxor;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing.Flux
{
    public class VehicleListFeature : Feature<VehicleListState>
    {
        public override string GetName() => nameof(VehicleListState);

        protected override VehicleListState GetInitialState()
        {
            return new(false, false, null, false, null, null, null, null);
        }
    }
}
