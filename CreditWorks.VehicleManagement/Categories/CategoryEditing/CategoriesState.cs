using CreditWorks.VehicleManagement.Categories.CategoryEditing.Models;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing
{
    public class CategoriesState
    {
        public CategoriesState(bool isLoading, CategoriesList? original, CategoriesList? underEdit)
        {
            IsLoading = isLoading;
            Original = original;
            UnderEdit = underEdit;

            if (underEdit != null)
                CategoriesListValidation = CategoriesListValidation.Validate(underEdit);
            else
                CategoriesListValidation = CategoriesListValidation.Empty();
        }

        public bool IsLoading { get; }
        public bool IsNew => Original == null;
        public bool HasEdits => Original != UnderEdit;

        public CategoriesList? Original { get; }
        public CategoriesList? UnderEdit { get; }
        public CategoriesListValidation CategoriesListValidation { get; }
        public bool CanSave => HasEdits && (UnderEdit?.CanSave ?? false);
    }
}
