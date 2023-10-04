using Blazored.Modal.Services;
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

        [CascadingParameter] public IModalService? Modal { get; set; }

        protected override void OnParametersSet()
        {
            if (State?.Value.UnderEdit != null && Category != null)
            {
                _name = Category.Name;
                _minWeight = Category.MinWeight;
                _maxWeight = Category.MaxWeight;
                _icon = Category.Icon;

                //getting heavier and lighter categories
                var lighterCategory = State.Value.UnderEdit.Categories.FirstOrDefault(c => c.MaxWeight > Category.MinWeight);
                var heavierCategory = State.Value.UnderEdit.Categories.FirstOrDefault(c => c.MinWeight > Category.MaxWeight);

                //setting _minWeightMax to the maximum weight of the lighter category + 1
                if (lighterCategory != null)
                {
                    _minWeightMax = Math.Max(lighterCategory!.MaxWeight!.Value, (_minWeight.HasValue ? _minWeight.Value : 0) + 1);
                }

                //setting _maxWeightMax to the minimum weight of the heavier category - 1
                if (heavierCategory != null)
                {
                    if (lighterCategory != null)
                        _maxWeightMax = Math.Max(lighterCategory!.MinWeight!.Value, _maxWeight.HasValue ? _maxWeight.Value : 0);

                    if (_maxWeightMax > 0)
                        _maxWeightMax--;
                }
            }

            base.OnParametersSet();
        }

        private float? _maxWeightMax;
        private float? _minWeightMax;

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