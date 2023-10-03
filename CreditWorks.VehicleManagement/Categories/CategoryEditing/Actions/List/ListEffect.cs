using CreditWorks.VehicleManagement.Categories.CategoryEditing.Actions;
using CreditWorks.VehicleManagement.Categories.CategoryEditing.Actions.List;
using CreditWorks.VehicleManagement.Core.Managers;
using CreditWorks.VehicleManagement.Shared.Models;
using Fluxor;
using System.Collections.Immutable;

namespace CreditWorks.Categories.CategoryEditing.VehicleListing.Actions.List
{
    public class ListEffect : Effect<ListAction>
    {
        private readonly VehicleManager _manager;
        private readonly ILogger<ListEffect> _logger;

        public ListEffect(VehicleManager manager, ILogger<ListEffect> logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public override async Task HandleAsync(ListAction action, IDispatcher dispatcher)
        {
            try
            {
                var categories = await _manager.GetCategories();

                dispatcher.Dispatch(new CategoriesSuccessAction(GenerateCategories(categories)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading vehicle list, reason: {ex.Message}");
                dispatcher.Dispatch(new CategoriesFailureAction(ex.Message));

                //TODO: UI flux effect for showing error in UI
            }
        }

        private static CategoriesList GenerateCategories(IEnumerable<VehicleManagement.Data.Models.Category> categories)
        {
            var convertedCategories = categories
                .Select(c => new Category(c.Id, c.Name, c.MinWeight, c.MaxWeight, c.IconUrl))
                .ToImmutableList();

            return new CategoriesList(convertedCategories, false);
        }
    }
}
