using Blazored.Modal;
using Blazored.Modal.Services;
using CreditWorks.VehicleManagement.Categories.CategoryEditing.Models;
using CreditWorks.VehicleManagement.SharedComponents;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing.Components
{
    public partial class CategoriesEditor : FluxorComponent
    {
        [Inject] public IState<CategoriesState>? State { get; set; }
        [Inject] public CategoriesFacade? Facade { get; set; }

        [CascadingParameter] IModalService Modal { get; set; } = default!;
        private IModalReference? _spinnerModal = null;

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
                if (State.Value.IsLoading && _spinnerModal == null)
                    _spinnerModal = Modal.Show<Spinner>(string.Empty, new ModalOptions() { Class = "text-center" });

                if (!State.Value.IsLoading && _spinnerModal != null)
                {
                    _spinnerModal?.Close();
                    _spinnerModal = null;
                }

                StateHasChanged();

                _validation = State.Value.CategoriesListValidation;

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

        private CategoriesListValidation? _validation;

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

        private string GenerateName(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                return "NOT SET";

            return category.Name;
        }

        private string GenerateBgColor(string? error)
        {
            if (!string.IsNullOrWhiteSpace(error))
                return "bg-danger-25";

            return "";
        }

        private void AddCategory()
        {
            Facade?.AddCategory();
        }

        private void SaveCategories()
        {
            if (Facade != null && Modal != null)
            {
                var spinnerModal = Modal.Show<Spinner>(string.Empty, new ModalOptions() { Class = "text-center" });

                Facade.Save();

                spinnerModal.Close();
            }
        }
    }
}