namespace CreditWorks.VehicleManagement.Vehicles.Models
{
    public class Category
    {
        public Category(int id, string name, string icon)
        {
            Id = id;
            Name = name;
            Icon = icon;
        }

        public int Id { get; }
        public string Name { get; }
        public string Icon { get; }
    }
}
