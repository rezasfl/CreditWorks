using CreditWorks.VehicleManagement.Vehicles.Models;
using Fluxor;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Actions.Create
{
    public class CreateEffect : Effect<CreateAction>
    {
        private readonly ILogger<CreateEffect> _logger;

        public CreateEffect(ILogger<CreateEffect> logger)
        {
            _logger = logger;
        }

        public override Task HandleAsync(CreateAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation($"Creating vehicle");
                dispatcher.Dispatch(new CreateSuccessAction(Vehicle.CreateNew()));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating vehicle, reason: {ex.Message}");
                dispatcher.Dispatch(new VehicleFailureAction());
            }

            return Task.CompletedTask;
        }
    }
}
