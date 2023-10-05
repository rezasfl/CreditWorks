using CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Actions;
using CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Actions.Delete;
using CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Actions.Load;
using CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Actions.Update;
using Fluxor;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleEditing
{
    public static class VehicleReducers
    {
        [ReducerMethod]
        public static VehicleState Reduce(VehicleState _, LoadAction action) =>
            new(true, null, null);
        [ReducerMethod]
        public static VehicleState Reduce(VehicleState _, LoadSuccessAction action) =>
            new(false, action.Vehicle, action.Vehicle);

        [ReducerMethod]
        public static VehicleState Reduce(VehicleState state, VehicleSuccessAction action) =>
            new(false, state.Original, action.Vehicle);

        [ReducerMethod]
        public static VehicleState Reduce(VehicleState state, VehicleFailureAction _) =>
            new(false, state.Original, state.UnderEdit);

        [ReducerMethod]
        public static VehicleState Reduce(VehicleState state, UpdateAction __) =>
            new(true, state.Original, state.UnderEdit);

        [ReducerMethod]
        public static VehicleState Reduce(VehicleState state, DeleteAction __) =>
            new(true, state.Original, state.UnderEdit);

        [ReducerMethod]
        public static VehicleState Reduce(VehicleState _, ClearStateAction __) =>
            new(false, null, null);

        [ReducerMethod]
        public static VehicleState Reduce(VehicleState state, CancelChangesAction _) =>
            new(false, state.Original, state.Original);
    }
}
