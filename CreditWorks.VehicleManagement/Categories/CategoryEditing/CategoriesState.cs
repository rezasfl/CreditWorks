using CreditWorks.VehicleManagement.Shared.Models;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing
{
    public class CategoriesState
    {
        public CategoriesState(CategoriesList? original, CategoriesList? underEdit)
        {
            Original = original;
            UnderEdit = underEdit;
        }

        public CategoriesList? Original { get; }
        public CategoriesList? UnderEdit { get; }
        public bool IsNew => Original == null;
        public bool HasEdits => Original != UnderEdit;
        public bool CanSave => HasEdits && (UnderEdit?.CanSave ?? false);
    }
}
