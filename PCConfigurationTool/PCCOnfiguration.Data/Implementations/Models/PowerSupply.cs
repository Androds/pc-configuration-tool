using PCConfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCConfiguration.Data.Models
{
    public class PowerSupply : IPowerSupply
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public sbyte Efficiency { get; set; }
        public short Wattage { get; set; }
        public bool Modular { get; set; }

        [NotMapped]
        public int Quantity { get; set; } = 1;

        public int FormFactorId { get; set; }
        public FormFactor FormFactor { get; set; }
    }
}
