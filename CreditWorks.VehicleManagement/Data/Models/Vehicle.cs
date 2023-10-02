using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditWorks.VehicleManagement.Data.Models
{
    public class Vehicle
    {
        //The key ise used to identify Id as the primary key for Vehicle table when creating it using entity framework
        [Key]
        public int Id { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Owner { get; set; }
        public int Year { get; set; }
        public decimal Weight { get; set; }
    }
}
