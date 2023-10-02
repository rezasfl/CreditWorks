using CreditWorks.VehicleManagement.Shared.Models;

namespace CreditWorks.VehicleManagement.Vehicles.Models
{
    public class Vehicle
    {
        public Vehicle(int id, int manufacturer, Category category, string owner, int year, float weight)
        {
            Id = id;
            Manufacturer = manufacturer;
            Category = category;
            Owner = owner;
            Year = year;
            Weight = weight;
        }

        public int Id { get; }
        public int Manufacturer { get; }
        public Category Category { get; }
        public string Owner { get; }
        public int Year { get; }
        public float Weight { get; }
    }
}
