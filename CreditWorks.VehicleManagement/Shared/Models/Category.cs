namespace CreditWorks.VehicleManagement.Shared.Models
{
    public class Category
    {
        public Category(int id, string? name, float? minWeight, float? maxWeight, string? icon)
        {
            Id = id;
            Name = name;
            MinWeight = minWeight;
            MaxWeight = maxWeight;
            Icon = icon;
        }

        public int Id { get; }
        public string? Name { get; }
        public float? MinWeight { get; }
        public float? MaxWeight { get; }
        public string? Icon { get; }

        public bool CanSave => ModelIsValid();

        internal static Category Create(int id, float? nextMinWeight, float? nextMaxWeight)
        {
            return new(id, "NEW", nextMinWeight, nextMaxWeight, null);
        }

        internal Category SetIcon(string? icon)
        {
            if (Icon == icon)
                return this;

            return new Category(Id, Name, MinWeight, MaxWeight, icon);
        }

        internal Category SetMaxWeight(float? maxWeight)
        {
            return new(Id, Name, MinWeight, maxWeight, Icon);
        }

        internal Category SetMinWeight(float? minWeight)
        {
            return new(Id, Name, minWeight, MaxWeight, Icon);
        }

        internal Category SetName(string? name)
        {
            return new(Id, name, MinWeight, MaxWeight, Icon);
        }

        private bool ModelIsValid()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return false;
            if (MinWeight > MaxWeight)
                return false;
            if (string.IsNullOrWhiteSpace(Icon))
                return false;

            return true;
        }
    }
}
