namespace CreditWorks.VehicleManagement.Shared.Models
{
    public class Category
    {
        public Category(int id, string name, float minWeight, float maxWeight, string iconUrl)
        {
            Id = id;
            Name = name;
            MinWeight = minWeight;
            MaxWeight = maxWeight;
            IconUrl = iconUrl;
        }

        public int Id { get; }
        public string Name { get; }
        public float MinWeight { get; }
        public float MaxWeight { get; }
        public string IconUrl { get; }

        public bool CanSave => ModelIsValid();

        private bool ModelIsValid()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return false;
            if (MinWeight > MaxWeight)
                return false;
            if (string.IsNullOrWhiteSpace(IconUrl))
                return false;

            return true;
        }
    }
}
