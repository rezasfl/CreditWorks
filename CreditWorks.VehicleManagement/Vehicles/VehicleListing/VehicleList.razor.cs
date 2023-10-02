using CreditWorks.VehicleManagement.Vehicles.Models;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing
{
    public partial class VehicleList : FluxorComponent
    {
        [Inject] public IState<VehicleListState>? State { get; set; }
        [Inject] public VehicleListFacade? Facade { get; set; }
        [Inject] public NavigationManager? NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            Facade?.List();
        }

        private void OnVehicleRowClicked(VehicleListItem vehicle)
        {
            NavigationManager?.NavigateTo($"/vehicles/{vehicle.Id}");
        }
    }
}