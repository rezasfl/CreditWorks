using CreditWorks.VehicleManagement.Data.Models;
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

            float? nextMinWeight = 0;
            float? nextMaxWeight = 1;

            var orderedCategories = Categories.OrderBy(c => c.MinWeight).ToList();

            //Iterate over the ordered categories
            for (int i = 0; i < orderedCategories.Count; i++)
            {
                var currentCategory = orderedCategories[i];
                var nextCategory = (orderedCategories.Count - 1) > i ? orderedCategories[i + 1] : null;

                //Set nextMinWeight to the MaxWeight of the category that its MinWeight is less than the current minWeight.
                if (currentCategory.MaxWeight > nextMinWeight)
                {
                    nextMinWeight = currentCategory.MaxWeight + 0.01f;

                    //if this category is the last category
                    if (nextMaxWeight != null)
                        nextMaxWeight = currentCategory.MaxWeight + 0.02f;
                }

                //Set nextMaxWeight to the MinWeight of the next category that its MinWeight is bigger than the current maxWeight.
                if (nextCategory != null && nextCategory.MinWeight > nextMaxWeight)
                    nextMaxWeight = nextCategory.MinWeight + 0.01f;
            }

            var newContact = Category.Create(newId, nextMinWeight, nextMaxWeight);

            return new(Categories.Add(newContact));
        }

        internal CategoriesList SetCategoryMaxWeight(Category oldCategory, float? maxWeight)
        {
            if (!Categories.Contains(oldCategory))
                return this;

            //if (Categories.Any(c => c.MaxWeight >= maxWeight))
            //    return this;

            var newCategory = oldCategory.SetMaxWeight(maxWeight);

            return ReplaceCategory(oldCategory, newCategory);
        }

        internal CategoriesList SetCategoryMinWeight(Category oldCategory, float? minWeight)
        {
            if (!Categories.Contains(oldCategory))
                return this;

            //if (Categories.Any(c => c.MinWeight <= minWeight))
            //    return this;

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
