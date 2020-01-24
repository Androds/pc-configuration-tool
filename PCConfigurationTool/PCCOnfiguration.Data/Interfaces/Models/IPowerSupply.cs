using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data.Interfaces.Models
{
    public interface IPowerSupply : IPCItem
    {
        public string FormFactor { get; set; }
        public sbyte Efficiency { get; set; }
        public short Wattage { get; set; }
        public bool Modular { get; set; }
    }
}
