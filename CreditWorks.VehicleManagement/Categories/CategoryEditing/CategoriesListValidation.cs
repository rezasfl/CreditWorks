using CreditWorks.VehicleManagement.Categories.CategoryEditing.Models;
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

        public bool HasErros => Errors.Any() || CategoryValidations.Any(c => c.HasErrors);
        public ImmutableList<(Category category, string error)> Errors { get; }
        public ImmutableList<CategoryValidation> CategoryValidations { get; }

        public static CategoriesListValidation Validate(CategoriesList categories)
        {
            var categoryValidations = categories.Categories.Select(CategoryValidation.Validate).ToImmutableList();
            var errors = ValidateCategories(categories.Categories, categoryValidations).ToImmutableList();

            return new CategoriesListValidation(errors, categoryValidations);
        }

        private static IEnumerable<(Category category, string error)> ValidateCategories(ImmutableList<Category> categories, ImmutableList<CategoryValidation> categoryValidations)
        {
            var exceptions = new List<(Category, string)>();

            foreach (var category in categories)
            {
                foreach (var overlap in categories.Where(otherCategory => category != otherCategory && category.MinWeight < otherCategory.MaxWeight && category.MaxWeight > otherCategory.MinWeight))
                    exceptions.Add((category, $"This category's weight overlaps with {overlap.Name} category"));

                var categoryValidation = categoryValidations.Single(v => v.Category == category);

                if (!categoryValidation.NameIsValid)
                    exceptions.Add((category, $"Please set this category's name"));

                if (!categoryValidation.IconIsValid)
                    exceptions.Add((category, $"Please set this category's icon"));

                if (!categoryValidation.WeightIsValid)
                    exceptions.Add((category, $"Please set a valid weight range for this category"));
            }
            return exceptions;
        }

        public static CategoriesListValidation Empty()
        {
            return new CategoriesListValidation(ImmutableList<(Category category, string error)>.Empty, ImmutableList<CategoryValidation>.Empty);
        }
    }
}
