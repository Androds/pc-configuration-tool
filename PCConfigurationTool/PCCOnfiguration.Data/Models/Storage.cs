using PCCOnfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data.Models
{
    public class Storage : IStorage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Capacity { get; set; }
        public string Type { get; set; }
        public short Cache { get; set; }
        public double FormFactor { get; set; }
        public string Interface { get; set; }
    }
}
