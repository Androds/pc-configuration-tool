using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data.Interfaces.Models
{
    public interface IStorage : IPCItem
    {
        public string Capacity { get; set; }
        public string Type { get; set; }
        public short Cache { get; set; }
        public double FormFactor { get; set; }
        public string Interface { get; set; }
    }
}
