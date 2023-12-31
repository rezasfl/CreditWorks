﻿using CreditWorks.VehicleManagement.Categories.CategoryEditing.Actions;
using CreditWorks.VehicleManagement.Categories.CategoryEditing.Actions.Delete;
using CreditWorks.VehicleManagement.Categories.CategoryEditing.Actions.List;
using CreditWorks.VehicleManagement.Categories.CategoryEditing.Actions.Update;
using Fluxor;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing.Flux
{
    public static class CategoriesReducers
    {
        [ReducerMethod]
        public static CategoriesState Reduce(CategoriesState _, ListAction __) =>
            new(true, null, null);

        [ReducerMethod]
        public static CategoriesState Reduce(CategoriesState _, ListSuccessAction action) =>
            new(false, action.Categories, action.Categories);

        [ReducerMethod]
        public static CategoriesState Reduce(CategoriesState state, CategoriesSuccessAction action) =>
            new(false, state.Original, action.Categories);

        [ReducerMethod]
        public static CategoriesState Reduce(CategoriesState state, CategoriesFailureAction _) =>
            new(false, state.Original, state.UnderEdit);

        [ReducerMethod]
        public static CategoriesState Reduce(CategoriesState state, UpdateAction __) =>
            new(true, state.Original, state.UnderEdit);

        [ReducerMethod]
        public static CategoriesState Reduce(CategoriesState state, DeleteAction __) =>
            new(true, state.Original, state.UnderEdit);

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
