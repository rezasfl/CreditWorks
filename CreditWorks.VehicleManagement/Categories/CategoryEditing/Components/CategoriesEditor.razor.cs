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

        }
    }
}