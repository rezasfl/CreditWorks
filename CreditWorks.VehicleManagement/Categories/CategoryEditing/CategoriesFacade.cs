using CreditWorks.VehicleManagement.Categories.CategoryEditing.Actions;
using CreditWorks.VehicleManagement.Categories.CategoryEditing.Actions.Delete;
using CreditWorks.VehicleManagement.Categories.CategoryEditing.Actions.List;
using CreditWorks.VehicleManagement.Categories.CategoryEditing.Actions.Update;
using CreditWorks.VehicleManagement.Categories.CategoryEditing.Models;
using Fluxor;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing
{
    public class CategoriesFacade
    {
        private readonly ILogger<CategoriesFacade> _logger;
        private readonly IDispatcher _dispatcher;
        private readonly IState<CategoriesState> _state;

        public CategoriesFacade(ILogger<CategoriesFacade> logger, IDispatcher dispatcher, IState<CategoriesState> state)
        {
            _logger = logger;
            _dispatcher = dispatcher;
            _state = state;
        }

        internal void List()
        {
            _logger.LogInformation($"Dispatching action to load categories list");
            _dispatcher.Dispatch(new ListAction());
        }

        internal void Save()
        {
            _logger.LogInformation($"Dispatching action to update category");
            _dispatcher.Dispatch(new UpdateAction());
        }

        internal void CancelChanges()
        {
            _logger.LogInformation($"Dispatching action to update category");
            _dispatcher.Dispatch(new CancelChangesAction());
        }

        internal void DeleteCategory(int id)
        {
            _logger.LogInformation($"Dispatching action to update category");
            _dispatcher.Dispatch(new DeleteAction(id));
        }

        internal void AddCategory()
        {
            if (_state.Value.UnderEdit != null)
            {
                _logger.LogInformation($"Adding a new category");

                var categories = _state.Value.UnderEdit.AddCategory();

                _dispatcher.Dispatch(new CategoriesSuccessAction(categories));
            }
            else
            {
                var errorMessage = $"Error adding cateogory, reason: No category under edit";
                _logger.LogError("{Message}", errorMessage);
                _dispatcher.Dispatch(new CategoriesFailureAction(errorMessage));
            }
        }

        internal void SetCategoryMaxWeight(Category category, float? maxWeight)
        {
            if (_state.Value.UnderEdit != null)
            {
                _logger.LogInformation($"Setting category max weight");

                var categories = _state.Value.UnderEdit.SetCategoryMaxWeight(category, maxWeight);

                _dispatcher.Dispatch(new CategoriesSuccessAction(categories));
            }
            else
            {
                var errorMessage = $"Error setting category max weight, reason: No category under edit";
                _logger.LogError("{Message}", errorMessage);
                _dispatcher.Dispatch(new CategoriesFailureAction(errorMessage));
            }
        }

        internal void SetCategoryMinWeight(Category category, float? minWeight)
        {
            if (_state.Value.UnderEdit != null)
            {
                _logger.LogInformation($"Setting category minimum weight");

                var categories = _state.Value.UnderEdit.SetCategoryMinWeight(category, minWeight);

                _dispatcher.Dispatch(new CategoriesSuccessAction(categories));
            }
            else
            {
                var errorMessage = $"Error setting category minimum weight, reason: No category under edit";
                _logger.LogError("{Message}", errorMessage);
                _dispatcher.Dispatch(new CategoriesFailureAction(errorMessage));
            }
        }

        internal void SetCategoryName(Category category, string? name)
        {
            if (_state.Value.UnderEdit != null)
            {
                _logger.LogInformation($"Setting category name");

                var categories = _state.Value.UnderEdit.SetCategoryName(category, name);

                _dispatcher.Dispatch(new CategoriesSuccessAction(categories));
            }
            else
            {
                var errorMessage = $"Error setting category name, reason: No category under edit";
                _logger.LogError("{Message}", errorMessage);
                _dispatcher.Dispatch(new CategoriesFailureAction(errorMessage));
            }
        }

        internal void SetCategoryIcon(Category category, string? icon)
        {
            if (_state.Value.UnderEdit != null)
            {
                _logger.LogInformation($"Setting category icon");

                var categories = _state.Value.UnderEdit.SetIcon(category, icon);

                _dispatcher.Dispatch(new CategoriesSuccessAction(categories));
            }
            else
            {
                var errorMessage = $"Error setting category icon, reason: No category under edit";
                _logger.LogError("{Message}", errorMessage);
                _dispatcher.Dispatch(new CategoriesFailureAction(errorMessage));
            }
        }
    }
}
