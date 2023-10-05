using Fluxor;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing.Flux
{
    public class CategoriesFeature : Feature<CategoriesState>
    {
        public override string GetName() => nameof(CategoriesState);

        protected override CategoriesState GetInitialState()
        {
            return new(false, null, null);
        }
    }
}
