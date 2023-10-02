﻿using System.ComponentModel.DataAnnotations;

namespace CreditWorks.VehicleManagement.Data.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
