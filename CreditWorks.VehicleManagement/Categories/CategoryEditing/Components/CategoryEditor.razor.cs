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
            //name
            //min weight
            //maxweight
            //icon

            base.OnParametersSet();
        }
    }
}