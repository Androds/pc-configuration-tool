using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data.Interfaces.Models
{
    public interface IVideocard : IPCItem
    {
        public string Chipset { get; set; }
        public int MemorySize { get; set; }
        public short CoreSpeed { get; set; }
        public short BoostSpeed { get; set; }
        public string Interface { get; set; }
    }
}
