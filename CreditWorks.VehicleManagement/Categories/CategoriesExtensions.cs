using CreditWorks.VehicleManagement.Categories.CategoryEditing;

namespace CreditWorks.VehicleManagement.Categories
{
    public static class CategoriesExtensions
    {
        public static IServiceCollection AddCategories(this IServiceCollection services)
        {
            services.AddScoped<CategoriesFacade>();

            return services;
        }
    }
}
