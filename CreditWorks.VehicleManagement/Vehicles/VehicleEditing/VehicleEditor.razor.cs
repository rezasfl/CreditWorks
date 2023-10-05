using CreditWorks.VehicleManagement.Vehicles.VehicleListing;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleEditing
{
    public partial class VehicleEditor : FluxorComponent
    {
        [Inject] public IState<VehicleListState>? VehicleListState { get; set; }
        [Inject] public IState<VehicleState>? State { get; set; }
        [Inject] public VehicleFacade? Facade { get; set; }
        [Inject] public NavigationManager? NavigationManager { get; set; }

        [Parameter] public string? Id { get; set; }

        protected override void OnParametersSet()
        {
            if (State?.Value != null && Facade != null && !string.IsNullOrWhiteSpace(Id) && State.Value.UnderEdit?.Id != Id)
                if (Id.Equals("NEW", StringComparison.OrdinalIgnoreCase))
                    Facade.Create();
                else
                    Facade.Load(Id);

            base.OnParametersSet();
        }

        protected override void OnInitialized()
        {
            if (State != null)
                State.StateChanged += StateChanged;

            base.OnInitialized();
        }

        private void StateChanged(object? sender, EventArgs eventArgs)
        {
            if (State != null && State.Value.UnderEdit != null)
            {
                _owner = State.Value.UnderEdit.Owner;
                _manufacturer = State.Value.UnderEdit.Manufacturer;
                _year = State.Value.UnderEdit.Year;
                _weight = State.Value.UnderEdit.Weight;
            }
        }

        private string? _owner;
        public string? Owner
        {
            get => _owner;
            set
            {
                if (_owner != value)
                    Facade?.SetOwner(value);
            }
        }

        private int? _manufacturer;
        public int? Manufacturer
        {
            get => _manufacturer;
            set
            {
                if (_manufacturer != value)
                    Facade?.SetManufacturer(value);
            }
        }

        private int? _year;
        public int? Year
        {
            get => _year;
            set
            {
                if (value < 1800 || value > DateTime.Now.Year)
                    return;

                if (_year != value)
                    Facade?.SetYear(value);
            }
        }

        private float? _weight;
        public float? Weight
        {
            get => _weight;
            set
            {
                if (value < 0)
                    return;

                if (_weight != value)
                    Facade?.SetWeight(value);
            }
        }

        private string GenerateCurrentBreadcrumbTitle()
        {
            var result = $"Vehicle: {Id}";

            if (!string.IsNullOrEmpty(Owner))
                result += $" ({Owner})";

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                var parts = NavigationManager?.Uri.Split("/vehicles", StringSplitOptions.RemoveEmptyEntries);

                if (parts != null && parts.Length < 2)
                    Facade?.ClearState();
            }

            if (State != null && disposing)
                State.StateChanged -= StateChanged;

            base.Dispose(disposing);
        }
    }
}
