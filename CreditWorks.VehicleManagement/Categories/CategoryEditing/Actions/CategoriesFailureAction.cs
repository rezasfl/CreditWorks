namespace CreditWorks.VehicleManagement.Categories.CategoryEditing.Actions
{
    public class CategoriesFailureAction
    {
        public CategoriesFailureAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }
}
