using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using CreditWorks.VehicleManagement;
using CreditWorks.VehicleManagement.Shared;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Fluxor;
using CreditWorks.VehicleManagement.Vehicles.Models;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing
{
    public partial class VehicleList : FluxorComponent
    {
        [Inject] public IState<VehicleListState> State { get; set; }
        [Inject] public VehicleListFacade Facade { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            Facade.List();
        }

        private void OnVehicleRowClicked(VehicleListItem vehicle)
        {
            NavigationManager?.NavigateTo($"/vehicles/{vehicle.Id}");
        }
    }
}