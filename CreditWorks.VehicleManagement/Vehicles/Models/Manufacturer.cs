﻿namespace CreditWorks.VehicleManagement.Vehicles.Models
{
    public class Manufacturer
    {
        public Manufacturer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}
