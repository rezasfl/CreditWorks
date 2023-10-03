using System.Collections.Immutable;

namespace CreditWorks.VehicleManagement.Shared.Models
{
    public class CategoriesList
    {
        public CategoriesList(ImmutableList<Category> categories, bool canSave)
        {
            Categories = categories;
            CanSave = canSave;
        }

        public ImmutableList<Category> Categories { get; }
        public bool CanSave { get; }
    }
}
