using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditWorks.VehicleManagement.Data.Models
{
    public class Vehicle
    {
        //The key ise used to identify Id as the primary key for Vehicle table when creating it using entity framework
        [Key, Required]
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        [Required, ForeignKey("ManufacturerId")]
        public Manufacturer Manufacturer { get; set; }
        [Required]
        public string Owner { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public decimal Weight { get; set; }
    }
}
