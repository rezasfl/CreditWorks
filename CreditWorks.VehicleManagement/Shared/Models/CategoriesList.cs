using System.Collections.Immutable;

namespace CreditWorks.VehicleManagement.Shared.Models
{
    public class CategoriesList
    {
        public CategoriesList(ImmutableList<Category> categories)
        {
            Categories = categories;
        }

        public ImmutableList<Category> Categories { get; }
        public bool CanSave => Categories.All(c => c.CanSave);

        internal CategoriesList AddCategory()
        {
            var previousId = Categories.Any() ? Math.Min(Categories.Min(c => c.Id), 0) : 0;
            var newId = previousId - 1;

            var newContact = Category.Create(newId);

            return new(Categories.Add(newContact));
        }

        internal CategoriesList SetCategoryMaxWeight(Category oldCategory, float? maxWeight)
        {
            if (!Categories.Contains(oldCategory))
                return this;

            var newCategory = oldCategory.SetMaxWeight(maxWeight);

            return ReplaceCategory(oldCategory, newCategory);
        }

        internal CategoriesList SetCategoryMinWeight(Category oldCategory, float? minWeight)
        {
            if (!Categories.Contains(oldCategory))
                return this;

            var newCategory = oldCategory.SetMinWeight(minWeight);

            return ReplaceCategory(oldCategory, newCategory);
        }

        internal CategoriesList SetCategoryName(Category oldCategory, string? name)
        {
            if (!Categories.Contains(oldCategory))
                return this;

            var newCategory = oldCategory.SetName(name);

            return ReplaceCategory(oldCategory, newCategory);
        }

        internal CategoriesList SetIcon(Category oldCategory, string? icon)
        {
            if (!Categories.Contains(oldCategory))
                return this;

            var newCategory = oldCategory.SetIcon(icon);

            return ReplaceCategory(oldCategory, newCategory);
        }

        private CategoriesList ReplaceCategory(Category oldCategory, Category newCategory)
        {
            if (oldCategory == newCategory)
                return this;
            var categories = Categories.Replace(oldCategory, newCategory);

            return new CategoriesList(categories);
        }
    }
}
