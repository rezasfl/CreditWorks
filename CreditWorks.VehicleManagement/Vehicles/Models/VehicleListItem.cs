namespace CreditWorks.VehicleManagement.Vehicles.Models
{
    public class VehicleListItem
    {
        public VehicleListItem(int id, int manifacturer, int category, string owner, int year)
        {
            Id = id;
            Manifacturer = manifacturer;
            Category = category;
            Owner = owner;
            Year = year;
        }

        public int Id { get; }
        public int Manifacturer { get; }
        public int Category { get; }
        public string Owner { get; }
        public int Year { get; }
    }
}
