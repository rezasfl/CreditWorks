using CreditWorks.VehicleManagement.Vehicles.Models;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleEditing.Flux
{
    public class VehicleState
    {
        public VehicleState(bool isLoading, Vehicle? original, Vehicle? underEdit)
        {
            IsLoading = isLoading;
            Original = original;
            UnderEdit = underEdit;
            VehicleValidation = VehicleValidation.Validate(underEdit);
        }

        public bool IsLoading { get; }
        public bool IsNew => Original == null;
        public bool HasEdits => Original != UnderEdit;

        public Vehicle? Original { get; }
        public Vehicle? UnderEdit { get; }
        public VehicleValidation VehicleValidation { get; }
        public bool CanSave => HasEdits && (UnderEdit?.CanSave ?? false);
    }
}
