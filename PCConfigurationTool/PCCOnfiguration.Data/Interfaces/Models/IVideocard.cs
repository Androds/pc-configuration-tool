using System;
using System.Collections.Generic;
using System.Text;

namespace PCConfiguration.Data.Interfaces.Models
{
    public interface IVideoCard : IPCItem
    {
        public string Chipset { get; set; }
        public int MemorySize { get; set; }
        public short CoreSpeed { get; set; }
        public short BoostSpeed { get; set; }
    }
}
