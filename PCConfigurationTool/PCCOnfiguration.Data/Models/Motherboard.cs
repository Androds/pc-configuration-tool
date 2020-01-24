using PCCOnfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data.Models
{
    public class Motherboard : IMotherboard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Socket { get; set; }
        public string FormFactor { get; set; }
        public short RamSlots { get; set; }
        public short MaxRam { get; set; }
    }
}
