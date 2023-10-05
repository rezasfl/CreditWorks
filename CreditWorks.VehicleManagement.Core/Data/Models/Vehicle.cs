using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditWorks.VehicleManagement.Data.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public Manufacturer Manufacturer { get; set; } = default!;
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public Category Category { get; set; } = default!;
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string Owner { get; set; } = string.Empty;
        public int Year { get; set; }
        public float Weight { get; set; }
    }
}
