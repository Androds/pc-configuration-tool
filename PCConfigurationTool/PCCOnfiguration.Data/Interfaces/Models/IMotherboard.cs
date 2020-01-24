using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data.Interfaces.Models
{
    public interface IMotherboard : IPCItem
    {
        public short RamSlots { get; set; }
        public short MaxRam { get; set; }
    }
}
