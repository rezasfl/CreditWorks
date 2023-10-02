using System.ComponentModel.DataAnnotations;

namespace CreditWorks.VehicleManagement.Core.Data.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Category Category { get; set; }
        public string Owner { get; set; }
        public int Year { get; set; }
        public float Weight { get; set; }
    }
}
