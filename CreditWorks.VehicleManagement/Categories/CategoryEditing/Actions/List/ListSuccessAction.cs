using CreditWorks.VehicleManagement.Categories.CategoryEditing.Models;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing.Actions.List
{
    public class ListSuccessAction
    {
        public ListSuccessAction(CategoriesList categories)
        {
            Categories = categories;
        }

        public CategoriesList Categories { get; }
    }
}
