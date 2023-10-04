using CreditWorks.VehicleManagement.Shared.Models;
using System.Collections.Immutable;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing
{
    public class CategoriesListValidation
    {
        public CategoriesListValidation(ImmutableList<(Category category, string error)> errors, ImmutableList<CategoryValidation> categoryValidations)
        {
            Errors = errors;
            CategoryValidations = categoryValidations;
        }

        public bool HasErros => Errors.Any() && CategoryValidations.Any(c => c.HasErrors);
        public ImmutableList<(Category category, string error)> Errors { get; }
        public ImmutableList<CategoryValidation> CategoryValidations { get; }

        public static CategoriesListValidation Validate(CategoriesList categories)
        {
            var errors = ValidateCategories(categories.Categories);

            return new CategoriesListValidation(
            errors.ToImmutableList(),
            categories.Categories.Select(CategoryValidation.Validate).ToImmutableList());
        }

        private static IEnumerable<(Category category, string error)> ValidateCategories(ImmutableList<Category> categories)
        {
            var exceptions = new List<(Category, string)>();

            foreach (var category in categories)
            {
                foreach (var overlap in categories.Where(otherCategory => category != otherCategory && category.MinWeight < otherCategory.MaxWeight && category.MaxWeight > otherCategory.MinWeight))
                    exceptions.Add((category, $"This category overlaps with another category {overlap.Name}"));
            }
            return exceptions;
        }

        public static CategoriesListValidation Empty()
        {
            return new CategoriesListValidation(ImmutableList<(Category category, string error)>.Empty, ImmutableList<CategoryValidation>.Empty);
        }
    }
}
