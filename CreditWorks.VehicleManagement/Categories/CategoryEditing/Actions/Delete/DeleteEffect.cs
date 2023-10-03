using CreditWorks.VehicleManagement.Core.Managers;
using CreditWorks.VehicleManagement.Shared.Models;
using Fluxor;
using System.Collections.Immutable;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing.Actions.Delete
{
    public class DeleteEffect : Effect<DeleteAction>
    {
        private readonly VehicleManager _manager;
        private readonly ILogger<DeleteEffect> _logger;
        private readonly IState<CategoriesState> _state;

        public DeleteEffect(VehicleManager manager, ILogger<DeleteEffect> logger, IState<CategoriesState> state)
        {
            _manager = manager;
            _logger = logger;
            _state = state;
        }

        public override async Task HandleAsync(DeleteAction action, IDispatcher dispatcher)
        {
            try
            {
                if (_state.Value.UnderEdit != null)
                {
                    var result = await _manager.DeleteCategory(action.Id);

                    dispatcher.Dispatch(new CategoriesSuccessAction(GenerateCategoryList(result)));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting category, reason: {ex.Message}");
                dispatcher.Dispatch(new CategoriesFailureAction(ex.Message));
            }
        }

        private static CategoriesList GenerateCategoryList(IEnumerable<Data.Models.Category> categories)
        {
            var convertedCategories = categories
                .Select(c => new Category(c.Id, c.Name, c.MinWeight, c.MaxWeight, c.IconUrl))
                .ToImmutableList();

            return new CategoriesList(convertedCategories);
        }
    }
}
