using PCCOnfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data.Models
{
    public class PowerSupply : IPowerSupply
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string FormFactor { get; set; }
        public sbyte Efficiency { get; set; }
        public short Wattage { get; set; }
        public bool Modular { get; set; }
    }
}
