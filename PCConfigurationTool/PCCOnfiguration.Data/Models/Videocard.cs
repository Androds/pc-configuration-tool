using PCCOnfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data.Models
{
    public class Videocard : IVideocard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Chipset { get; set; }
        public int MemorySize { get; set; }
        public short CoreSpeed { get; set; }
        public short BoostSpeed { get; set; }
        public string Interface { get; set; }
    }
}
