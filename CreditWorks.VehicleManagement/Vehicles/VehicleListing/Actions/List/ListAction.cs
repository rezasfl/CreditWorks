namespace CreditWorks.VehicleManagement.Vehicles.VehicleListing.Actions.List
{
    public class ListAction
    {
        public ListAction(bool sortedByOwner, int? manufacturerId, bool sortedByYear, int? category)
        {
            SortedByOwner = sortedByOwner;
            ManufacturerId = manufacturerId;
            SortedByYear = sortedByYear;
            Category = category;
        }

        public bool SortedByOwner { get; }
        public int? ManufacturerId { get; }
        public bool SortedByYear { get; }
        public int? Category { get; }
    }
}
