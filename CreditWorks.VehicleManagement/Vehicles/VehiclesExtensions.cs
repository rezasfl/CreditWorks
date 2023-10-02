using CreditWorks.VehicleManagement.Vehicles.VehicleListing;

namespace CreditWorks.VehicleManagement.Vehicles
{
    public static class VehiclesExtensions
    {
        public static IServiceCollection AddVehicles(this IServiceCollection services)
        {
            //services.AddScoped<VehicleFacade>();
            services.AddScoped<VehicleListFacade>();

            return services;
        }
    }
}
