namespace CreditWorks.VehicleManagement.Categories.CategoryEditing.Models
{
    public class CategoryValidation
    {
        public CategoryValidation(Category category, bool nameIsValid, bool iconIsValid, bool minWeightIsValid, bool maxWeightIsValid)
        {
            Category = category;
            NameIsValid = nameIsValid;
            IconIsValid = iconIsValid;
            MinWeightIsValid = minWeightIsValid;
            MaxWeightIsValid = maxWeightIsValid;
        }

        public Category Category { get; }
        public bool HasErrors => !NameIsValid || !IconIsValid || !MinWeightIsValid || MaxWeightIsValid;
        public bool NameIsValid { get; }
        public bool IconIsValid { get; }
        public bool MinWeightIsValid { get; }
        public bool MaxWeightIsValid { get; }

        public static CategoryValidation Validate(Category category)
        {
            return new CategoryValidation(
                category,
                !string.IsNullOrWhiteSpace(category.Name),
                !string.IsNullOrWhiteSpace(category.Icon),
                category.MinWeight.HasValue && category.MinWeight < category.MaxWeight,
                category.MaxWeight.HasValue && category.MaxWeight > category.MinWeight);
        }
    }
}
