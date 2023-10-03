using CreditWorks.VehicleManagement.Categories.CategoryEditing.Actions.List;
using CreditWorks.VehicleManagement.Shared.Models;
using Fluxor;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing
{
    public class CategoriesFacade
    {
        private readonly ILogger<CategoriesFacade> _logger;
        private readonly IDispatcher _dispatcher;

        public CategoriesFacade(ILogger<CategoriesFacade> logger, IDispatcher dispatcher)
        {
            _logger = logger;
            _dispatcher = dispatcher;
        }

        internal void List()
        {
            _logger.LogInformation($"Dispatching action to load categories list");
            _dispatcher.Dispatch(new ListAction());
        }

        internal void Save()
        {

        }

        internal void CancelChanges()
        {

        }

        internal void SetCategoryIcon(Category? category, string? value)
        {
            throw new NotImplementedException();
        }

        internal void SetCategoryMaxWeight(Category? category, float value)
        {
            throw new NotImplementedException();
        }

        internal void SetCategoryMinWeight(Category? category, float value)
        {
            throw new NotImplementedException();
        }

        internal void SetCategoryName(Category? category, string? value)
        {
            throw new NotImplementedException();
        }
    }
}
