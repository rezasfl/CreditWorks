using Fluxor;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing.Actions.List
{
    public static class ListReducer
    {
        [ReducerMethod]
        public static VehicleListState ReduceAction(VehicleListState state, ListAction _) =>
            new(true, null, state.Vehicles, state.Manufacturers, state.Categories);
    }
}
