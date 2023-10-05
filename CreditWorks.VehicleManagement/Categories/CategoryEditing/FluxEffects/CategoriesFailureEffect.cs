using Blazored.Toast.Services;
using CreditWorks.VehicleManagement.Categories.CategoryEditing.Actions;
using Fluxor;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing.FluxEffects
{
    public class CategoriesFailureEffect : Effect<CategoriesFailureAction>
    {
        private readonly IToastService _toastService;
        private readonly ILogger<CategoriesFailureEffect> _logger;

        public CategoriesFailureEffect(ILogger<CategoriesFailureEffect> logger, IToastService toastService)
        {
            _logger = logger;
            _toastService = toastService;
        }

        public override Task HandleAsync(CategoriesFailureAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation(action.ErrorMessage);
            _toastService.ShowError(action.ErrorMessage);

            return Task.CompletedTask;
        }
    }
}
