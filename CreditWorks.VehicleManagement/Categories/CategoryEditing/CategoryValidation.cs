using CreditWorks.VehicleManagement.Shared.Models;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing
{
    public class CategoryValidation
    {
        public CategoryValidation(Category category, bool nameIsValid, bool iconIsValid, bool weightIsValid)
        {
            Category = category;
            NameIsValid = nameIsValid;
            IconIsValid = iconIsValid;
            WeightIsValid = weightIsValid;
        }

        public Category Category { get; }
        public bool HasErrors => !NameIsValid || !IconIsValid || !WeightIsValid;
        public bool NameIsValid { get; }
        public bool IconIsValid { get; }
        public bool WeightIsValid { get; }

        public static CategoryValidation Validate(Category category)
        {
            return new CategoryValidation(
                category,
                !string.IsNullOrWhiteSpace(category.Name),
                !string.IsNullOrWhiteSpace(category.Icon),
                category.MinWeight.HasValue && category.MaxWeight.HasValue && category.MinWeight < category.MaxWeight);
        }
    }
}
