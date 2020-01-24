using PCCOnfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data.Models
{
    public class Memory : IMemory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Speed { get; set; }
        public short Modules { get; set; }
        public MemoryType Type { get; set; }

        public MemoryLatency CASLatency { get; set; }
    }
}
