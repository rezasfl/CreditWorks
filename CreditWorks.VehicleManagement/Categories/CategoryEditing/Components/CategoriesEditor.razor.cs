using CreditWorks.VehicleManagement.Shared.Models;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing.Components
{
    public partial class CategoriesEditor : FluxorComponent
    {
        [Inject] public IState<CategoriesState>? State { get; set; }
        [Inject] public CategoriesFacade? Facade { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (State != null)
                State.StateChanged += StateChanged;

            Facade?.List();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && State != null)
                State.StateChanged -= StateChanged;

            base.Dispose(disposing);
        }

        private void StateChanged(object? sender, EventArgs e)
        {
            if (State != null)
            {
                if (!State.Value.UnderEdit?.Categories.Any(c => c.Id == _selectedCategoryId) ?? true)
                    _selectedCategoryId = null;
                if (!_selectedCategoryId.HasValue)
                    _selectedCategoryId = 
                        State.Value.UnderEdit?.Categories.FirstOrDefault(c => c.Id == 0)?.Id ??
                        State.Value.UnderEdit?.Categories.FirstOrDefault()?.Id;
                _selectedCategory = State.Value.UnderEdit?.Categories.FirstOrDefault(c => c.Id == _selectedCategoryId);
            }

            StateHasChanged();
        }



        private Category? _selectedCategory;
        private int? _selectedCategoryId;
        public int? SelectedCategoryId
        {
            get => _selectedCategory?.Id;
            set
            {
                if (_selectedCategory?.Id != value)
                {
                    _selectedCategoryId = value;
                    _selectedCategory = State?.Value.UnderEdit?.Categories.SingleOrDefault(c => c.Id == value);
                }
            }
        }

        private void AddCategory()
        {
            Facade?.AddCategory();
        }

        private void SaveCategories()
        {
            Facade?.Save();
        }
    }
}