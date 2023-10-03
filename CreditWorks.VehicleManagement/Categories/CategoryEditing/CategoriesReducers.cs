using CreditWorks.VehicleManagement.Categories.CategoryEditing.Actions;
using Fluxor;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing
{
    public static class CategoriesReducers
    {
        [ReducerMethod]
        public static CategoriesState Reduce(CategoriesState state, CategoriesSuccessAction action) =>
            new(false, state.Original, action.Categories);

        [ReducerMethod]
        public static CategoriesState Reduce(CategoriesState state, CategoriesFailureAction _) =>
            new(false, state.Original, state.UnderEdit);

        [ReducerMethod]
        public static CategoriesState Reduce(CategoriesState _, ClearStateAction __)
        {
            return new(false, null, null);
        }

        [ReducerMethod]
        public static CategoriesState Reduce(CategoriesState state, CancelChangesAction _) =>
            new(false, state.Original, state.Original);
    }
}
