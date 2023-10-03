using CreditWorks.VehicleManagement.Shared.Models;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing.Components
{
    public partial class CategoryEditor : FluxorComponent
    {
        [Parameter] public Category? Category { get; set; }

        [Inject] public IState<CategoriesState>? State { get; set; }
        [Inject] public CategoriesFacade? Facade { get; set; }

        protected override void OnParametersSet()
        {
            if (Category != null)
            {
                _name = Category.Name;
                _minWeight = Category.MinWeight;
                _maxWeight = Category.MaxWeight;
                _icon = Category.Icon;
            }

            base.OnParametersSet();
        }

        private string? _name;
        public string? Name
        {
            get => _name;
            set
            {
                if (_name != value)
                    Facade?.SetCategoryName(Category, value);
            }
        }

        private float? _minWeight;
        public float? MinWeight
        {
            get => _minWeight;
            set
            {
                if (_minWeight != value)
                    Facade?.SetCategoryMinWeight(Category, value);
            }
        }

        private float? _maxWeight;
        public float? MaxWeight
        {
            get => _maxWeight;
            set
            {
                if (_maxWeight != value)
                    Facade?.SetCategoryMaxWeight(Category, value);
            }
        }

        private string? _icon;
        public string? Icon
        {
            get => _icon;
            set
            {
                if (_icon != value)
                    Facade?.SetCategoryIcon(Category!, value);
            }
        }

        private void ResetIcon()
        {
            Facade?.SetCategoryIcon(Category!, null);
        }

        private void DeleteCategory()
        {
            Facade?.DeleteCategory(Category!.Id);
        }
    }
}