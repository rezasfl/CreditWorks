using CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Flux;
using CreditWorks.VehicleManagement.Vehicles.VehicleListing.Flux;

namespace CreditWorks.VehicleManagement.Vehicles
{
    public static class VehiclesExtensions
    {
        public static IServiceCollection AddVehicles(this IServiceCollection services)
        {
            services.AddScoped<VehicleFacade>();
            services.AddScoped<VehicleListFacade>();

            return services;
        }
    }
}
