namespace CreditWorks.VehicleManagement.Vehicles.Models
{
    public class Category
    {
        public Category(int id, string name, float minWeight, float maxWeight, string icon)
        {
            Id = id;
            Name = name;
            MinWeight = minWeight;
            MaxWeight = maxWeight;
            Icon = icon;
        }

        public int Id { get; }
        public string Name { get; }
        public float MinWeight { get; }
        public float MaxWeight { get; }
        public string Icon { get; }
    }
}
