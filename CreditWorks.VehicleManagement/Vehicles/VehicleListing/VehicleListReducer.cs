using CreditWorks.VehicleManagement.Vehicles.VehicleListing.Actions;
using Fluxor;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing
{
    public static class VehicleListReducer
    {
        [ReducerMethod]
        public static VehicleListState ReduceSuccessAction(VehicleListState _, VehicleListSuccessAction action) =>
            new(false, null, action.Vehicles, action.Manufacturers, action.Categories);

        [ReducerMethod]
        public static VehicleListState ReduceFailureAction(VehicleListState state, VehicleListFailureAction action) =>
            new(false, action.ErrorMessage, state.Vehicles, state.Manufacturers, state.Categories);
    }
}
