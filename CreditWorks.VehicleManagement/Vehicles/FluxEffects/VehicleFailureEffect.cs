using Blazored.Toast.Services;
using CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Actions;
using Fluxor;

namespace CreditWorks.VehicleManagement.Vehicles.FluxEffects
{
    public class VehicleFailureEffect : Effect<VehicleFailureAction>
    {
        private readonly IToastService _toastService;
        private readonly ILogger<VehicleFailureEffect> _logger;

        public VehicleFailureEffect(ILogger<VehicleFailureEffect> logger, IToastService toastService)
        {
            _logger = logger;
            _toastService = toastService;
        }

        public override Task HandleAsync(VehicleFailureAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation(action.ErrorMessage);
            _toastService.ShowError(action.ErrorMessage);

            return Task.CompletedTask;
        }
    }
}
