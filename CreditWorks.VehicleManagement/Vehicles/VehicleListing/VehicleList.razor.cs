using Blazored.Modal;
using Blazored.Modal.Services;
using CreditWorks.VehicleManagement.SharedComponents;
using CreditWorks.VehicleManagement.Vehicles.Models;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing
{
    public partial class VehicleList : FluxorComponent
    {
        [Inject] public IState<VehicleListState>? State { get; set; }
        [Inject] public NavigationManager? NavigationManager { get; set; }
        [Inject] public VehicleListFacade? Facade { get; set; }

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
            }

            StateHasChanged();
        }

        private void OnCreateClicked()
        {
            NavigationManager?.NavigateTo($"/vehicles/NEW");
        }

        private void OnVehicleRowClicked(VehicleListItem vehicle)
        {
            NavigationManager?.NavigateTo($"/vehicles/{vehicle.Id}");
        }
    }
}