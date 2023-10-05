using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditWorks.VehicleManagement.Data.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public Manufacturer Manufacturer { get; set; }
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string Owner { get; set; }
        public int Year { get; set; }
        public float Weight { get; set; }
    }
}
