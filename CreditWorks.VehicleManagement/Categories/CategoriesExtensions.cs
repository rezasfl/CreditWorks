using CreditWorks.VehicleManagement.Categories.CategoryEditing.Flux;

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
