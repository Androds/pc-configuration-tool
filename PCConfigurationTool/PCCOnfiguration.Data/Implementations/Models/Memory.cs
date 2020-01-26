using PCConfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCConfiguration.Data.Models
{
    public class Memory : IMemory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Speed { get; set; }
        public short Modules { get; set; }

        [NotMapped]
        public int Quantity { get; set; } = 1;


        public int TypeId { get; set; }
        public PCItemType Type { get; set; }
        public int CASLatencyId { get; set; }
        public MemoryLatency CASLatency { get; set; }
    }
}
