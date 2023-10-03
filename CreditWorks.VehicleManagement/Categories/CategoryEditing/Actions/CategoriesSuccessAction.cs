using CreditWorks.VehicleManagement.Shared.Models;
using System.Collections.Immutable;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing.Actions
{
    public class CategoriesSuccessAction
    {
        public CategoriesSuccessAction(CategoriesList categories)
        {
            Categories = categories;
        }

        public CategoriesList Categories { get; }
    }
}
