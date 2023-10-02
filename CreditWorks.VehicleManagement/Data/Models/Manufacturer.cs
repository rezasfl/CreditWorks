using System.ComponentModel.DataAnnotations;

namespace CreditWorks.VehicleManagement.Data.Models
{
    public class Manufacturer
    {
        //The key ise used to identify Id as the primary key for Manufacturer table when creating it using entity framework
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
