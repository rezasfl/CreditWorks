using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing
{
    public partial class VehicleListTableHeader : FluxorComponent
    {
        [Inject] public IState<VehicleListState>? State { get; set; }
        [Inject] public VehicleListFacade? Facade { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (State != null)
                State.StateChanged += StateChanged;
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
                _sortedByOwner = State.Value.SortedByOwner;
                _selectedManufacturer = State.Value.Manufacturer;
                _sortedByYear = State.Value.SortedByYear;
                _category = State.Value.Category;
            }

            StateHasChanged();
        }

        private bool _sortedByOwner;
        public bool SortedByOwner
        {
            get => _sortedByOwner;
            set
            {
                if (_sortedByOwner == value)
                    return;

                Facade?.List(value, SelectedManufacturer, !value, Category);
            }
        }

        private int? _selectedManufacturer;
        public int? SelectedManufacturer
        {
            get => _selectedManufacturer;
            set
            {
                if (_selectedManufacturer == value)
                    return;

                value = value.HasValue && value.Value > 0 ? value : null;

                Facade?.List(SortedByOwner, value, Year, Category);
            }
        }

        private bool _sortedByYear;
        public bool Year
        {
            get => _sortedByYear;
            set
            {
                if (_sortedByYear == value)
                    return;

                Facade?.List(!value, SelectedManufacturer, value, Category);
            }
        }

        private int? _category;
        public int? Category
        {
            get => _category;
            set
            {
                if (_category == value)
                    return;

                value = value.HasValue && value.Value > 0 ? value : null;

                Facade?.List(SortedByOwner, SelectedManufacturer, Year, value);
            }
        }

        private void ClearFilters()
        {
            Facade?.List();
        }
    }
}