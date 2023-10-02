using System.ComponentModel.DataAnnotations;

namespace CreditWorks.VehicleManagement.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //using float for min/max weight because precision is not very important here (2 decimal points is sufficient)
        public float MinWeight { get; set; }
        public float MaxWeight { get; set; }
        public string IconUrl { get; set; }
    }
}
