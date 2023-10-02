using Fluxor;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing.Actions.List
{
    public static class ListReducer
    {
        [ReducerMethod]
        public static VehicleListState ReduceAction(VehicleListState state, ListAction action) =>
            new(
                true,
                null,
                action.SortedByOwner,
                action.ManufacturerId,
                action.SortedByYear,
                action.Category,
                state.Vehicles,
                state.Manufacturers,
                state.Categories);
    }
}
