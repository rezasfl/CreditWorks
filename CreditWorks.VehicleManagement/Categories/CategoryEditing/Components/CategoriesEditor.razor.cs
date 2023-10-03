using CreditWorks.VehicleManagement.Shared.Models;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace CreditWorks.VehicleManagement.Categories.CategoryEditing.Components
{
    public partial class CategoriesEditor
    {
        [Inject] public IState<CategoriesState>? State { get; set; }

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