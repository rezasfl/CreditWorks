using CreditWorks.VehicleManagement.Data.Models;

namespace CreditWorks.VehicleManagement.Vehicles.Models
{
    public class Vehicle
    {
        public Vehicle(string id, int? manufacturer, int? category, string? owner, int? year, float? weight)
        {
            Id = id;
            Manufacturer = manufacturer;
            Category = category;
            Owner = owner;
            Year = year;
            Weight = weight;
        }

        public string Id { get; }
        public int? Manufacturer { get; }
        public int? Category { get; }
        public string? Owner { get; }
        public int? Year { get; }
        public float? Weight { get; }

        public bool CanSave => ModelIsValid();

        internal static Vehicle Create()
        {
            return new("NEW", null, null, null, null, null);
        }

        internal Vehicle SetManufacturer(int? manufacturer)
        {
            if (Manufacturer == manufacturer)
                return this;

            return new Vehicle(Id, manufacturer, Category, Owner, Year, Weight);
        }

        internal Vehicle SetCategory(int category)
        {
            if (Category == category)
                return this;

            return new Vehicle(Id, Manufacturer, category, Owner, Year, Weight);
        }

        internal Vehicle SetOwner(string? owner)
        {
            if (Owner == owner)
                return this;

            return new Vehicle(Id, Manufacturer, Category, owner, Year, Weight);
        }

        internal Vehicle SetYear(int? year)
        {
            if (Year == year)
                return this;

            return new Vehicle(Id, Manufacturer, Category, Owner, year, Weight);
        }

        internal Vehicle SetWeight(float? weight)
        {
            if (Weight == weight)
                return this;

            return new Vehicle(Id, Manufacturer, Category, Owner, Year, weight);
        }

        private bool ModelIsValid()
        {
            if (!Manufacturer.HasValue)
                return false;
            if (!Category.HasValue)
                return false;
            if (string.IsNullOrWhiteSpace(Owner))
                return false;
            if (!Year.HasValue)
                return false;
            if (!Weight.HasValue)
                return false;

            return true;
        }
    }
}
