using CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace CreditWorks.VehicleManagement.Vehicles.FluxEffects
{
    public class ClearStateEffect : Effect<ClearStateAction>
    {
        private readonly ILogger<ClearStateEffect> _logger;
        private readonly NavigationManager _navigationManager;

        public ClearStateEffect(ILogger<ClearStateEffect> logger, NavigationManager navigationManager)
        {
            _logger = logger;
            _navigationManager = navigationManager;
        }

        public override Task HandleAsync(ClearStateAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation($"Navigating to vehicle list");

            _navigationManager.NavigateTo("/vehicles");

            return Task.CompletedTask;
        }
    }
}
