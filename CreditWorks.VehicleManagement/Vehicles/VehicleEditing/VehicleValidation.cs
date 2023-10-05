using CreditWorks.VehicleManagement.Vehicles.Models;

namespace CreditWorks.VehicleManagement.Vehicles.VehicleEditing
{
    public class VehicleValidation
    {
        public VehicleValidation(bool nameIsValid, bool manifacturerIsValid, bool yearIsValid, bool weightIsValid)
        {
            OwnerIsValid = nameIsValid;
            ManufacturerIsValid = manifacturerIsValid;
            YearIsValid = yearIsValid;
            WeightIsValid = weightIsValid;
        }

        public bool HasErrors => !OwnerIsValid || !ManufacturerIsValid || !YearIsValid || !WeightIsValid;
        public bool OwnerIsValid { get; }
        public bool ManufacturerIsValid { get; }
        public bool YearIsValid { get; }
        public bool WeightIsValid { get; }

        public static VehicleValidation Validate(Vehicle? underEdit)
        {
            if (underEdit != null)
                return new(
                    !string.IsNullOrWhiteSpace(underEdit.Owner),
                    underEdit.Manufacturer.HasValue,
                    underEdit.Year.HasValue,
                    underEdit.Weight.HasValue && underEdit.Weight > 0);

            return new(false, false, false, false);
        }
    }
}
