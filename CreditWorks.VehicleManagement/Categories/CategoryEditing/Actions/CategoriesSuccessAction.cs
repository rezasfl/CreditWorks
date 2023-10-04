using CreditWorks.VehicleManagement.Categories.CategoryEditing.Models;

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
