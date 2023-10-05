using CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Actions.Save;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace CreditWorks.VehicleManagement.Vehicles.FluxEffects
{
    public class VehicleSaveSuccessEffect : Effect<SaveSuccessAction>
    {
        private readonly ILogger<VehicleSaveSuccessEffect> _logger;
        private readonly NavigationManager _navigationManager;

        public VehicleSaveSuccessEffect(ILogger<VehicleSaveSuccessEffect> logger, NavigationManager navigationManager)
        {
            _logger = logger;
            _navigationManager = navigationManager;
        }

        public override Task HandleAsync(SaveSuccessAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation($"Navigating to vehicle list");

            _navigationManager.NavigateTo("/vehicles");

            return Task.CompletedTask;
        }
    }
}
