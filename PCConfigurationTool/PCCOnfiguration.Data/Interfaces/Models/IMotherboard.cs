using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data.Interfaces.Models
{
    public interface IMotherboard : IPCItem
    {
        public string Socket { get; set; }
        public string FormFactor { get; set; }
        public short RamSlots { get; set; }
        public short MaxRam { get; set; }
    }
}
