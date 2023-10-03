using CreditWorks.VehicleManagement.Shared.Models;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing
{
    public class CategoriesState
    {
        public CategoriesState(bool isLoading, CategoriesList? original, CategoriesList? underEdit)
        {
            IsLoading = isLoading;
            Original = original;
            UnderEdit = underEdit;
        }

        public bool IsLoading { get; }
        public CategoriesList? Original { get; }
        public CategoriesList? UnderEdit { get; }
        public bool IsNew => Original == null;
        public bool HasEdits => Original != UnderEdit;
        public bool CanSave => HasEdits && (UnderEdit?.CanSave ?? false);
    }
}
